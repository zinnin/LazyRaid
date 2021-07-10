using System.Collections.Generic;

namespace LazyRaid.Models
{
    public class Boss : BindableReferenceBase
    {
        public string Name { get; set; }
        public OC<BossAbility> Abilities { get; set; } = new OC<BossAbility>();
        public Dictionary<BossAbility, OC<CounterAbilityUserPriority>> AbilityPriorities { get; set; } = new Dictionary<BossAbility, OC<CounterAbilityUserPriority>>();
        public OC<BossEvent> Events { get; set; } = new OC<BossEvent>();

        
    }
}
