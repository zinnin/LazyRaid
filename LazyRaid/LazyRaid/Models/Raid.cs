using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    class Raid
    {
        public string Name { get; set; }
        public ObservableCollection<Specialization> Specialization { get; set; }
    }
}
