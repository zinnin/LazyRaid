using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Group : BindableReferenceBase
    {
        public string Name { get; set; }
        public OCReference<Player> Players { get; set; } = new OCReference<Player>();
    }
}
