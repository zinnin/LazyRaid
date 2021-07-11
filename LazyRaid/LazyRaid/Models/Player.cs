namespace LazyRaid.Models
{
    public class Player : BindableReferenceBase
    {
        public string Name { get; set; }
        public Reference<Specialization> CurrentSpecialization { get; set; }
        public OCReference<Specialization> AvailableSpecializations { get; set; } = new OCReference<Specialization>();
    }
}
