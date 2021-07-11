namespace LazyRaid.Models
{
    public class Instance : BindableReferenceBase
    {
        OCReference<Boss> Bosses { get; set; } = new OCReference<Boss>();
    }
}
