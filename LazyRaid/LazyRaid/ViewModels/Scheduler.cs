using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyRaid.Models
{
    public class Scheduler
    {
        public Boss Boss { get; set; }
        public Raid Raid { get; set; }

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
            Boss.Events.Sort((a, b) => { return a.Timestamp.CompareTo(b.Timestamp); });
            foreach (BossEvent bossEvent in Boss.Events)
            {

            }
        }

        public void Load(Boss boss)
        {
            Boss = boss;

        }

        public void NewAbility(string abilityName)
        {
            if (BossLoaded())
            {
                BossAbility bossAbility = new BossAbility
                {
                    Name = abilityName,
                };

                Boss.Abilities.Add(bossAbility);
                Boss.AbilityPriorities.Add(bossAbility, new OC<CounterAbilityUserPriority>());
            }
        }

        public void RemoveAbility(BossAbility ability)
        {
            if (BossLoaded() && Boss.Abilities.Contains(ability))
            {
                Boss.Abilities.Remove(ability);
                Boss.AbilityPriorities.Remove(ability);
            }
        }

        private void EnforceAbilityPriorityDefinitons()
        {
            if (BossLoaded())
            {
                foreach (KeyValuePair<BossAbility, OC<CounterAbilityUserPriority>> abilityPriorityDefinition in Boss.AbilityPriorities)
                {

                }
            }
        }

        private OC<PlayerAbility> GetAvailableCounterList(BossAbility bossAbility)
        {
            OC<PlayerAbility> abilityCounters = new OC<PlayerAbility>();

            foreach (Player player in Raid.Players)
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
            return (Boss != null);
        }
    }
}
