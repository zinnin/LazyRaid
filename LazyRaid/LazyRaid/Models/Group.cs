using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Group : BindableReferenceBase
    {
        public string Name { get; set; }
        public OC<Player> Players { get; set; }
    }
}
