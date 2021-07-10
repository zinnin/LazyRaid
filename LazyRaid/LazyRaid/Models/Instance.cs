using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRaid.Models
{
    public class Instance : BindableReferenceBase
    {
        OC<Boss> Bosses { get; set; } = new OC<Boss>();
    }
}
