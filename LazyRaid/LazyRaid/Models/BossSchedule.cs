using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class BossSchedule
    {
        public ObservableCollection<BossEvent> Events { get; set; }
    }
}
