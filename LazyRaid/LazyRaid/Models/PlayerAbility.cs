using System.Collections.Generic;

namespace LazyRaid.Models
{
    public class PlayerAbility : BindableReferenceBase
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }

        public OC<Counter> Counters { get; set; }

        public bool IsCounter(BossAbility bossAbility)
        {
            return true;
        }

        public bool IsCounter(BossEvent bossEvent)
        {
            return true;
        }
    }
}
