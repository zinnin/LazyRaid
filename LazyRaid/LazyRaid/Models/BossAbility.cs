using System.Collections.Generic;

namespace LazyRaid.Models
{
    public class BossAbility : BindableReferenceBase
    {
        public string Name { get; set; }
        public OC<CounterRequirements> CounterRequirements { get; set; } = new OC<CounterRequirements>();
        public OCReference<Player> PlayerBlacklist { get; set; } = new OCReference<Player>();
        public OCReference<PlayerAbility> PlayerAbilityBlacklist { get; set; } = new OCReference<PlayerAbility>();
        public OCReference<PlayerAbilityPlayerBlacklistCombo> PlayerAbilityPlayerComboBlackList = new OCReference<PlayerAbilityPlayerBlacklistCombo>();
        public Dictionary<BossAbility, OC<CounterAbilityUserPriority>> CustomAbilityPriorities { get; set; } = new Dictionary<BossAbility, OC<CounterAbilityUserPriority>>();
    }
}
