namespace LazyRaid.Models
{
    public class SpellEffect : BindableReferenceBase
    {
        public string Name { get; set; }
        public SpellEffect(string name)
        {
            Name = name;
        }

        public SpellEffect()
        {

        }
    }
}