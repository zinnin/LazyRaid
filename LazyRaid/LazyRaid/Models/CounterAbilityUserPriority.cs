namespace LazyRaid.Models
{
    public class CounterAbilityUserPriority
    {
        public int Index { get; set; }
        public Reference<Player> Player { get; set; }
        public Reference<PlayerAbility> Ability { get; set; }
    }
}
