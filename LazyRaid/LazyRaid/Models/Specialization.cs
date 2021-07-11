using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LazyRaid.Models
{
    public class Specialization : BindableReferenceBase
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ImageSource Icon { get; set; }
        public OC<PlayerAbility> Abilities { get; set; } = new OC<PlayerAbility>();
    }
}
