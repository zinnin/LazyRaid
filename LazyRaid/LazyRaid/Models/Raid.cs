using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Raid
    {
        public string Name { get; set; }
        public ObservableCollection<Player> Players { get; set; }
    }
}
