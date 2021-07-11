using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class BossEvent : BindableReferenceBase
    {
        public BossTime Timestamp { get; set; }
        public BossAbility Ability { get; set; }
        public OC<PlayerAbility> ScheduledCooldowns { get; set; } = new OC<PlayerAbility>();
        public OC<CounterRequirements> EventCounterRequirements { get; set; } = new OC<CounterRequirements>();
        public string Note { get; set; }
    }
}
