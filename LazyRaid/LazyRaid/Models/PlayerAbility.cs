using System.Collections.Generic;

namespace LazyRaid.Models
{
    public class PlayerAbility : BindableReferenceBase
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public bool IsExclusive { get; set; }
        public int ExclusiveCooldown { get; set; }

        public OCReference<SpellEffect> Counters { get; set; } = new OCReference<SpellEffect>();

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
