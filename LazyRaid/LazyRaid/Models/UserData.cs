using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace LazyRaid.Models
{
    public class UserData : BindableBase
    {
        private OCLibrary<Counter> _counters;
        public OCLibrary<Counter> Counters { get=> _counters; set => SetProperty(ref _counters, value); }

        private OCLibrary<PlayerAbility> _playerAbilities;
        public OCLibrary<PlayerAbility> PlayerAbilities { get => _playerAbilities; set => SetProperty(ref _playerAbilities, value); }

        private OCLibrary<Specialization> _specializations;
        public OCLibrary<Specialization> Specializations { get => _specializations; set => SetProperty(ref _specializations, value); }

        private OCLibrary<Player> _players;
        public OCLibrary<Player> Players { get => _players; set => SetProperty(ref _players, value); }

        private OCLibrary<Group> _groups;
        public OCLibrary<Group> Groups { get => _groups; set => SetProperty(ref _groups, value); }

        private OCLibrary<BossAbility> _bossAbilities;
        public OCLibrary<BossAbility> BossAbilities { get => _bossAbilities; set => SetProperty(ref _bossAbilities, value); }

        private OCLibrary<Boss> _bosses;
        public OCLibrary<Boss> Bosses { get => _bosses; set => SetProperty(ref _bosses, value); }

        private OCLibrary<Instance> _instances;
        public OCLibrary<Instance> Instances { get => _instances; set => SetProperty(ref _instances, value); }

        private UserSelections _userSelections;
        public UserSelections UserSelections { get => _userSelections; set => SetProperty(ref _userSelections, value); }

        private Task SaveDataTask { get; set; }
        private bool pendingSave = false;
        private Dictionary<string, string> saveDictionary = new Dictionary<string, string>();

        private void SaveUserData(string fileName)
        {
            // This is done like this because we need to control the load order of objects in order to preserve object references at runtime
            saveDictionary = new Dictionary<string, string>();
            SaveField(Counters);
            SaveField(PlayerAbilities);
            SaveField(Specializations);
            SaveField(Players);
            SaveField(Groups);
            SaveField(Bosses);
            SaveField(Instances);
            SaveField(UserSelections);

            File.WriteAllText(fileName, JsonConvert.SerializeObject(saveDictionary));
            if (pendingSave)
            {
                pendingSave = false;
                SaveUserData(fileName);
            }
        }

        public async Task SaveUserDataAsync(string fileName = "UserData.LRD")
        {
            if (SaveDataTask == null || SaveDataTask.IsCompleted)
            {
                SaveDataTask = Task.Run(() => SaveUserData(fileName));
                await SaveDataTask;
            }
            else
            {
                pendingSave = true;
            }
        }

        public void LoadUserData(string fileName = "UserData.LRD")
        {
            if (File.Exists(fileName))
            {
                saveDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(fileName));
                
            }

            // Load Order Matters, objects that Ref need to have those Refs loaded first
            LoadField(Counters, new OCLibrary<Counter>());
            LoadField(PlayerAbilities, new OCLibrary<PlayerAbility>());
            LoadField(Specializations, new OCLibrary<Specialization>());
            LoadField(Players, new OCLibrary<Player>());
            LoadField(Groups, new OCLibrary<Group>());
            LoadField(Bosses, new OCLibrary<Boss>());
            LoadField(Instances, new OCLibrary<Instance>());
            LoadField(UserSelections, new UserSelections());
        }

        private void SaveField(object field)
        {
            saveDictionary.Add(LazyRaidExtensions.GetMemberName(() => field), JsonConvert.SerializeObject(field));
        }

        private void LoadField<T>(T field, T loadFailureFallback)
        {
            string fieldName = LazyRaidExtensions.GetMemberName(() => field);
            if (saveDictionary.ContainsKey(fieldName))
            {
                field = JsonConvert.DeserializeObject<T>(saveDictionary[fieldName], new LazyRaidJsonConverter(this));
            }
            else
            {
                field = loadFailureFallback;
            }
        }
    }
}
