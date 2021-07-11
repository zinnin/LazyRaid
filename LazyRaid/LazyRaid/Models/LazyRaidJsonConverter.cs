using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LazyRaid.Models
{
    class LazyRaidJsonConverter : JsonConverter
    {
        private UserData userData;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType().GetCustomAttribute<SerializeAsGuidListAttribute>() != null)
            {
                List<Guid> guides = new List<Guid>();

                foreach (var valueObj in (IEnumerable<BindableReferenceBase>)value)
                {
                    guides.Add(valueObj.ID);
                }

                writer.WriteValue(JsonConvert.SerializeObject(guides));
            }
            else if (value.GetType().GetCustomAttribute<SerializeAsGuidAttribute>() != null)
            {
                writer.WriteValue(value.ToString());
            }
        }

        // For ever case of using OCReference<T> or Reference<T> in code, that needs to be added below in the same pattern.
        public override object ReadJson(JsonReader reader, Type type, object existingRefObj, JsonSerializer serializer)
        {
            if (existingRefObj == null)
            {
                throw new Exception("Existing OCReference must be initialized before Deserialization");
            }
            
            if (existingRefObj is OCReference<Counter> CountersRef)
            {
                List<Guid> guides = JsonConvert.DeserializeObject<List<Guid>>(reader.Value.ToString());
                foreach (Guid ID in guides)
                {
                    CountersRef.Add(userData.Counters.GetValue(ID));
                }
            }
            else if (existingRefObj is Reference<Counter> CounterRef)
            {
                Guid guid = new Guid(reader.Value.ToString());
                CounterRef.SetSelection(userData.Counters.GetValue(guid));
            }
            else if (existingRefObj is OCReference<PlayerAbility> PlayerAbilitysRef)
            {
                List<Guid> guides = JsonConvert.DeserializeObject<List<Guid>>(reader.Value.ToString());
                foreach (Guid ID in guides)
                {
                    PlayerAbilitysRef.Add(userData.PlayerAbilities.GetValue(ID));
                }
            }
            else if (existingRefObj is OCReference<Specialization> SpecializationsRef)
            {
                List<Guid> guides = JsonConvert.DeserializeObject<List<Guid>>(reader.Value.ToString());
                foreach (Guid ID in guides)
                {
                    SpecializationsRef.Add(userData.Specializations.GetValue(ID));
                }
            }
            else if (existingRefObj is Reference<Specialization> SpecializationRef)
            {
                Guid guid = new Guid(reader.Value.ToString());
                SpecializationRef.SetSelection(userData.Specializations.GetValue(guid));
            }
            else
            {
                throw new Exception($"{type} not implemented in LazyRaidJsonConverter");
            }

            return existingRefObj;
        }

        public override bool CanConvert(Type type)
        {
            var listAttribute = type.GetCustomAttribute<SerializeAsGuidListAttribute>();
            var singleAttribute = type.GetCustomAttribute<SerializeAsGuidAttribute>();
            bool canSerialzeAsGuid = listAttribute != null || singleAttribute != null;
            return canSerialzeAsGuid;
        }

        public LazyRaidJsonConverter(UserData Data)
        {
            userData = Data;
        }
    }
}
