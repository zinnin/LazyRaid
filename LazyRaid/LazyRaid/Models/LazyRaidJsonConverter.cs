using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace LazyRaid.Models
{

    class LazyRaidJsonConverter : JsonConverter
    {
        private UserData userData;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((BindableReferenceBase)value).ID.ToString());
        }

        public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            foreach (PropertyInfo property in userData.GetType().GetProperties())
            {
                var obj = property.GetValue(userData);
                if (obj is OCLibrary<BindableReferenceBase>)
                {
                    OCLibrary<BindableReferenceBase> lookupDictionary = (OCLibrary<BindableReferenceBase>)obj;
                    if (lookupDictionary.ObjectTypeName == type.Name)
                    {
                        Guid lookupID = new Guid(reader.Value.ToString());
                        if (lookupDictionary.ContainsKey(lookupID))
                        {
                            return lookupDictionary.GetValue(lookupID);
                        }
                    }
                }
            }

            return FormatterServices.GetUninitializedObject(type);
        }

        public override bool CanConvert(Type type)
        {
            var attribute = type.GetCustomAttribute<SerializeAsGUIDAttribute>();
            bool canSerialzeAsGuid = attribute != null && type.IsAssignableFrom(typeof(BindableReferenceBase));
            return canSerialzeAsGuid;
        }

        public LazyRaidJsonConverter(UserData Data)
        {
            userData = Data;
        }
    }
}
