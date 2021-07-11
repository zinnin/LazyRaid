using System.Collections.Generic;

namespace LazyRaid.Models
{
    public class PlayerAbility : BindableReferenceBase
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }

        public OCReference<Counter> Counters { get; set; } = new OCReference<Counter>();

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
