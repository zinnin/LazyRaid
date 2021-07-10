using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyRaid.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace LazyRaid
{
    class LazyRaid_VM : BindableBase
    {
        private UserData _userData = new UserData();
        public UserData UserData
        {
            get => _userData;
            set => SetProperty(ref _userData, value);
        }

        private Boss _selectedBoss;
        public Boss SelectedBoss
        {
            get => _selectedBoss;
            set => SetProperty(ref _selectedBoss, value);
        }

        private OC<BossAbility> _bossAbilityTemp = new OC<BossAbility>();
        public OC<BossAbility> BossAbilityTemp
        {
            get => _bossAbilityTemp;
            set => SetProperty(ref _bossAbilityTemp, value);
        }

        public DelegateCommand RunAutoSchedularCmd { get; private set; }

        public LazyRaid_VM()
        {
            CreateCommands();
            TestTemplates();
        }

        private void CreateCommands()
        {
            RunAutoSchedularCmd = new DelegateCommand(async () => await RunAutoScheduler());
        }

        private void TestTemplates()
        {
            UserData.Bosses = new OC<Boss>();
            UserData.Bosses.Add(new Boss { Name = "Kel'Thuzad" });
            UserData.Bosses.Add(new Boss { Name = "Sylvanas" });
            UserData.Bosses.Add(new Boss { Name = "Painthruster LongNameGuy" });

            BossAbilityTemp.Add(new BossAbility { Name = "Big AoE" });
            BossAbilityTemp.Add(new BossAbility { Name = "FUck the raid" });
            BossAbilityTemp.Add(new BossAbility { Name = "Smacks the tank" });
        }

        private Task AutoSchedulerTask { get; set; }
        public BossTime FirstPassScheduleTimeStamp { get; set; } = new BossTime();
        public bool ReverseAutoSchedulers { get; set; }
        public BossSchedulerSettings Settings { get; set; }

        public async Task RunAutoScheduler()
        {
            if (AutoSchedulerTask == null || AutoSchedulerTask.IsCompleted)
            {
                AutoSchedulerTask = Task.Run(AutoSchedule);
                await AutoSchedulerTask;     
            }
        }

        private void AutoSchedule()
        {
            UserData.Boss.Events.Sort((a, b) => { return a.Timestamp.CompareTo(b.Timestamp); });
            foreach (BossEvent bossEvent in UserData.Boss.Events)
            {

            }
        }

        public void Load(Boss boss)
        {
            UserData.Boss = boss;
        }

        public void NewAbility(string abilityName)
        {
            if (BossLoaded())
            {
                BossAbility bossAbility = new BossAbility
                {
                    Name = abilityName,
                };

                UserData.Boss.Abilities.Add(bossAbility);
                UserData.Boss.AbilityPriorities.Add(bossAbility, new OC<CounterAbilityUserPriority>());
            }
        }

        public void RemoveAbility(BossAbility ability)
        {
            if (BossLoaded() && UserData.Boss.Abilities.Contains(ability))
            {
                UserData.Boss.Abilities.Remove(ability);
                UserData.Boss.AbilityPriorities.Remove(ability);
            }
        }

        private void EnforceAbilityPriorityDefinitons()
        {
            if (BossLoaded())
            {
                foreach (KeyValuePair<BossAbility, OC<CounterAbilityUserPriority>> abilityPriorityDefinition in UserData.Boss.AbilityPriorities)
                {

                }
            }
        }

        private OC<PlayerAbility> GetAvailableCounterList(BossAbility bossAbility)
        {
            OC<PlayerAbility> abilityCounters = new OC<PlayerAbility>();

            foreach (Player player in UserData.Raid.Players)
            {
                if (player.CurrentSpecialization != null)
                {
                    foreach (PlayerAbility playerAbility in player.CurrentSpecialization.Abilities)
                    {
                        if (playerAbility.IsCounter(bossAbility))
                        {
                            abilityCounters.Add(playerAbility);
                        }
                    }
                }
            }

            return abilityCounters;
        }

        private bool BossLoaded()
        {
            return (UserData.Boss != null);
        }
    }
}
