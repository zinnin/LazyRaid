namespace LazyRaid.Models
{
    public class BossEvent : BindableReferenceBase
    {
        public BossTime Timestamp { get; set; }
        public Reference<BossAbility> Ability { get; set; }
        public OCReference<PlayerAbility> ScheduledCooldowns { get; set; } = new OCReference<PlayerAbility>();
        public OCReference<CounterRequirements> EventCounterRequirements { get; set; } = new OCReference<CounterRequirements>();
        public OCReference<PlayerAbilityPlayerBlacklistCombo> PlayerAbilityPlayerComboBlackList { get; set; } = new OCReference<PlayerAbilityPlayerBlacklistCombo>();
        public OCReference<Player> PlayerBlacklist { get; set; } = new OCReference<Player>();
        public string Note { get; set; }
    }
}
