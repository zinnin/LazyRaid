using System.Collections.ObjectModel;

namespace LazyRaid.Models
{
    public class BossEvent
    {
        public BossTime Timestamp { get; set; }
        public BossAbility Ability { get; set; }
        public ObservableCollection<PlayerAbility> Cooldowns { get; set; }
        public string Note { get; set; }
    }
}
