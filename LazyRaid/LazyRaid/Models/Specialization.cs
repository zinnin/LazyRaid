using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LazyRaid.Models
{
    public class Specialization
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ImageSource Icon { get; set; }
        public ObservableCollection<PlayerAbility> Abilities { get; set; }
    }
}
