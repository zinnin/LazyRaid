using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRaid.Models
{
    public class UserSelections
    {
        [SerializeAsGUID]
        public Instance SelectedInstance { get; set; }
        [SerializeAsGUID]
        public Boss SelectedBoss { get; set; }
        [SerializeAsGUID]
        public BossEvent SelectedEvent { get; set; }
        [SerializeAsGUID]
        public Group SelectedGroup { get; set; }
    }
}
