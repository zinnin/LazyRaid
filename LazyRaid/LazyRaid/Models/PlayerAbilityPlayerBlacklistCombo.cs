namespace LazyRaid.Models
{
    public class PlayerAbilityPlayerBlacklistCombo : BindableReferenceBase
    {
        Reference<Player> Player { get; set; }
        Reference<PlayerAbility> PlayerAbility { get; set; }

        public PlayerAbilityPlayerBlacklistCombo(Player playerToBlacklist, PlayerAbility abilityToBlacklist)
        {
            Player = new Reference<Player>(playerToBlacklist);
            PlayerAbility = new Reference<PlayerAbility>(abilityToBlacklist);
        }
    }
}
