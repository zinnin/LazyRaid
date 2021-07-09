using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Specialization
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<PlayerAbility> Abilities { get; set; }
    }
}
