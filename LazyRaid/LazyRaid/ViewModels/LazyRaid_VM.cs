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
        private UserData _userData;
        public UserData UserData
        {
            get => _userData;
            set => SetProperty(ref _userData, value);
        }

        public DelegateCommand RunAutoSchedularCmd { get; private set; }

        public LazyRaid_VM()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            //Implemented Functionality

            //Un-Implemented Functionality
            RunAutoSchedularCmd = new DelegateCommand(async () => await RunAutoScheduler());

            //ToDo Functionality

            
            //// Raid Editor
            ////// Player Editor
            //////// Spec Editor
                    // Spec Exporter
                      // Multi-Select?
                    // Spec Importer
            ///////// Player Ability Editor
            

            //// Instance Editor
                // Instance Export 
                // Instance Import
                // Instance Selection
                // Instance Create
                // Instance Delete
            ///// Boss Editor
                  // Boss Export?
                  // Boss Import?

            ////// Boss Ability Editor

            //// Counter Requirements Editor
            

            


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
            UserData.UserSelections.SelectedBoss.Events.Sort((a, b) => { return a.Timestamp.CompareTo(b.Timestamp); });
            foreach (BossEvent bossEvent in UserData.UserSelections.SelectedBoss.Events)
            {

            }
        }

        public void Load(Boss boss)
        {
            UserData.UserSelections.SelectedBoss = boss;

        }

        public void NewAbility(string abilityName)
        {
            if (BossLoaded())
            {
                BossAbility bossAbility = new BossAbility
                {
                    Name = abilityName,
                };

                UserData.UserSelections.SelectedBoss.Abilities.Add(bossAbility);
                UserData.UserSelections.SelectedBoss.AbilityPriorities.Add(bossAbility, new OC<CounterAbilityUserPriority>());
            }
        }

        public void RemoveAbility(BossAbility ability)
        {
            if (BossLoaded() && UserData.UserSelections.SelectedBoss.Abilities.Contains(ability))
            {
                UserData.UserSelections.SelectedBoss.Abilities.Remove(ability);
                UserData.UserSelections.SelectedBoss.AbilityPriorities.Remove(ability);
            }
        }

        private void EnforceAbilityPriorityDefinitons()
        {
            if (BossLoaded())
            {
                foreach (KeyValuePair<BossAbility, OC<CounterAbilityUserPriority>> abilityPriorityDefinition in UserData.UserSelections.SelectedBoss.AbilityPriorities)
                {

                }
            }
        }

        private OC<PlayerAbility> GetAvailableCounterList(BossAbility bossAbility)
        {
            OC<PlayerAbility> abilityCounters = new OC<PlayerAbility>();

            foreach (Player player in UserData.UserSelections.SelectedGroup.Players)
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
            return (UserData.UserSelections.SelectedBoss != null);
        }
    }
}
