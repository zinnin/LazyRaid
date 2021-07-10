using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class BossAbility : BindableReferenceBase
    {
        public string Name { get; set; }
        public OC<CounterRequirements> CounterRequirements { get; set; } = new OC<CounterRequirements>();

    }
}
