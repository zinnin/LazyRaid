namespace LazyRaid.Models
{
    public enum MechanicCounterRequirmentType
    {
        Player,
        Ability,
    }
    
    public class CounterRequirements : BindableReferenceBase
    {
        public MechanicCounterRequirmentType MechanicCounterType { get; set; }
        public Reference<SpellEffect> RequiredEffect { get; set; } 
        public int NumberNeeded { get; set; }
    }
}
