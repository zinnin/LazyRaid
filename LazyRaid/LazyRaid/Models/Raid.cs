using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Raid
    {
        public string Name { get; set; }
        public OC<Player> Players { get; set; }
    }
}
