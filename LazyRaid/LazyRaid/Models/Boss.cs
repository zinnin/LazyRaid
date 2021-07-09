using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class Boss
    {
        public string Name { get; set; }
        public ObservableCollection<BossAbility> Abilities { get; set; } 
        public BossSchedule Schedule { get; set; }
    }
}
