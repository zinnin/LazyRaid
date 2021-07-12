using System.Collections.Generic;

namespace LazyRaid.Models
{
    public enum BossAbilityTargetingType
    {
        RandomTargets,          // Schedule this based on Lucky Charm Markers, assign markers to the tool, people's abilities get assigned to them
        Soak,                   // Schedule based on finding individuals that match the requirements, will be able to define per event if desired
        AoE,                    // Schedule based on finding individuals with abilities that match the requirements for AoE, Event will dictate can / cannot be stacked
        DefineTargetsPerEvent,  // The event will just have a collection of players that are targeted that event, to enable for some manual control over some things
    }
    
    public class BossAbility : BindableReferenceBase
    {
        public string Name { get; set; } = "New Boss Ability";
        public BossAbilityTargetingType TargetingType { get; set; } = BossAbilityTargetingType.AoE;
        public int NumberOfTargets { get; set; } = 1;
        public OCReference<CounterRequirements> CounterRequirements { get; set; } = new OCReference<CounterRequirements>();
        public OCReference<Player> PlayerBlacklist { get; set; } = new OCReference<Player>();
        public OCReference<PlayerAbility> PlayerAbilityBlacklist { get; set; } = new OCReference<PlayerAbility>();
        public OCReference<PlayerAbilityPlayerBlacklistCombo> PlayerAbilityPlayerComboBlackList = new OCReference<PlayerAbilityPlayerBlacklistCombo>();
        public Dictionary<BossAbility, OC<CounterAbilityUserPriority>> CustomAbilityPriorities { get; set; } = new Dictionary<BossAbility, OC<CounterAbilityUserPriority>>();
        public BossAbility()
        {

        }

        public BossAbility(string name, BossAbilityTargetingType targetType, CounterRequirements[] counterRequirements)
        {

        }

        public BossAbility(string name, BossAbilityTargetingType targetType, CounterRequirements counterRequirements)
        {

        }

        public BossAbility(string name, BossAbilityTargetingType targetType, int targetCount, CounterRequirements[] counterRequirements)
        {

        }

        public BossAbility(string name, BossAbilityTargetingType targetType, int targetCount, CounterRequirements counterRequirements)
        {

        }
    }
}
