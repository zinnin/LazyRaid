using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace LazyRaid.Models
{
    public class UserData : BindableBase
    {
        public Boss Boss;

        private OC<Boss> _bosses;
        public OC<Boss> Bosses
        {
            get => _bosses;
            set => SetProperty(ref _bosses, value);
        }
        public Raid Raid { get; set; }
    }
}
