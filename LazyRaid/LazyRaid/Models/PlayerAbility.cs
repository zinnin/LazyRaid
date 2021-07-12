namespace LazyRaid.Models
{
    public enum EffectTargetingType
    {
        Personal,
        External,
        RaidWide,
        RaidWideStacked,
        TargetCapped,
    }

    public class PlayerAbility : BindableReferenceBase
    {
        public string Name { get; set; } = "New Player Ability";
        public int Cooldown { get; set; } = 0;
        public EffectTargetingType TargetingType { get; set; } = EffectTargetingType.Personal;

        public bool IsExclusive { get; set; } = false;
        public int ExclusiveCooldown { get; set; } = 0;

        public OCReference<SpellEffect> SpellEffects { get; set; } = new OCReference<SpellEffect>();

        public PlayerAbility()
        {

        }

        public PlayerAbility(string name, int cooldown, EffectTargetingType targetType, bool isExlusive, int exclusiveCooldown, SpellEffect spellEffects)
        {
            Name = name;
            Cooldown = cooldown;
            TargetingType = targetType;
            IsExclusive = isExlusive;
            ExclusiveCooldown = exclusiveCooldown;
            SpellEffects.Add(spellEffects);

        }

        public PlayerAbility(string name, int cooldown, EffectTargetingType targetType, bool isExlusive, int exclusiveCooldown, SpellEffect[] spellEffects)
        {
            Name = name;
            Cooldown = cooldown;
            TargetingType = targetType;
            IsExclusive = isExlusive;
            ExclusiveCooldown = exclusiveCooldown;
            if (spellEffects != null)
            {
                foreach (SpellEffect effect in spellEffects)
                {
                    SpellEffects.Add(effect);
                }
            }
        }

        public PlayerAbility(string name, int cooldown, EffectTargetingType targetType, SpellEffect spellEffects)
        {
            Name = name;
            Cooldown = cooldown;
            TargetingType = targetType;
            SpellEffects.Add(spellEffects);
        }

        public PlayerAbility(string name, int cooldown, EffectTargetingType targetType, SpellEffect[] spellEffects)
        {
            Name = name;
            Cooldown = cooldown;
            TargetingType = targetType;
            if (spellEffects != null)
            {
                foreach (SpellEffect effect in spellEffects)
                {
                    SpellEffects.Add(effect);
                }
            }
        }
    }
}
