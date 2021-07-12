namespace LazyRaid.Models
{
    class UserDataDefaults
    {
        private OCLibrary<SpellEffect> _spellEffects;
        private OCLibrary<PlayerAbility> _playerAbilities;
        private OCLibrary<Specialization> _specializations;

        public UserDataDefaults()
        {
            DefineDefaults();
        }

        private void DefineDefaults()
        {
            SpellEffect physDebufImmunity = new SpellEffect("Physical Debuff Immunity");
            SpellEffect magicDebuffImmunity = new SpellEffect("Magical Debuff Immunity");
            SpellEffect physDamageImmunity = new SpellEffect("Physical Damage Immunity");
            SpellEffect magicDamageImmunity = new SpellEffect("Magical Damage Immunity");
            SpellEffect stunImmunity = new SpellEffect("Stun Immunity");
            SpellEffect physicalDamageReduction = new SpellEffect("PhysicalDamageReduction");
            SpellEffect magicalDamageReduction = new SpellEffect("MagicalDamageReduction");
            SpellEffect healthEqualizer = new SpellEffect("HealthEqualizer");
            SpellEffect movementSpeedIncrease = new SpellEffect("MovementSpeedIncrease");

            _spellEffects = new OCLibrary<SpellEffect>
            {
               physDebufImmunity,
                magicDebuffImmunity,
                physicalDamageReduction,
                magicalDamageReduction,
                healthEqualizer,
                movementSpeedIncrease,
            };

            PlayerAbility divineShield = new PlayerAbility("Divine Shield", 300, EffectTargetingType.Personal, new SpellEffect[] { physDebufImmunity, magicDebuffImmunity, physDamageImmunity, magicDamageImmunity, stunImmunity });
            PlayerAbility iceBlock = new PlayerAbility("Ice Block Shield", 300, EffectTargetingType.Personal, new SpellEffect[] { physDebufImmunity, magicDebuffImmunity, physDamageImmunity, magicDamageImmunity, stunImmunity });

            _playerAbilities = new OCLibrary<PlayerAbility>
            {
                divineShield,
                iceBlock,
            };

            Specialization holyPaladin = new Specialization("Holy Paladin", divineShield);
            Specialization frostMage = new Specialization("Frost Mage", iceBlock);

            _specializations = new OCLibrary<Specialization>
            {
                holyPaladin,
                frostMage,
            };

            BossAbility bossAbility = new BossAbility("Sinseeker", BossAbilityTargetingType.Soak, 3, new CounterRequirements(MechanicCounterRequirmentType.Ability, 1, physDebufImmunity));


        }

        public object GetDefaultData(object defaultData)
        {
            if (defaultData is OCLibrary<SpellEffect>)
            {
                return _spellEffects;
            }
            else if (defaultData is OCLibrary<PlayerAbility>)
            {
                return _playerAbilities;
            }
            else if (defaultData is OCLibrary<Specialization>)
            {
                return _specializations;
            }

            return null;
        }
    }
}
