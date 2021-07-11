namespace LazyRaid.Models
{
    public class Specialization : BindableReferenceBase
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public OCReference<PlayerAbility> Abilities { get; set; } = new OCReference<PlayerAbility>();
    }
}
