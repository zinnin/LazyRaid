namespace LazyRaid.Models
{
    public interface IAbilityCounter
    {
        bool CountersMechanic(BossAbility bossAbility);
    }

    public class Counter : BindableReferenceBase
    {
        public string Name { get; set; }
    }


    public class TestData
    {
        public void Test()
        {
            PlayerAbility newAbility = new PlayerAbility
            {
                Name = "DivineShield",
                Counters = new OCReference<Counter>
                {
                    new Counter
                    {
                        Name = "PhysicalDebuffImmunity",
                    },
                },
            };
        }
    }
}