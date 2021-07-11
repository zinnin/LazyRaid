namespace LazyRaid.Models
{
    public class Boss : BindableReferenceBase
    {
        public string Name { get; set; }
        public OCReference<BossAbility> Abilities { get; set; } = new OCReference<BossAbility>();
        public OCReference<BossEvent> Events { get; set; } = new OCReference<BossEvent>();
    }
}
