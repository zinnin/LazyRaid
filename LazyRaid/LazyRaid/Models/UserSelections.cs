using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRaid.Models
{
    public class UserSelections
    {
        //public Reference<Instance> SelectedInstance { get; set; } = new Reference<Instance>();
        //public Reference<Boss> SelectedBoss { get; set; } = new Reference<Boss>();
        //public Reference<BossEvent> SelectedEvent { get; set; } = new Reference<BossEvent>();
        //public Reference<Group> SelectedGroup { get; set; } = new Reference<Group>();
        public Reference<Counter> SelectedCounter { get; set; } = new Reference<Counter>();
    }
}
