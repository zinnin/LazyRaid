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
        private Boss _boss;
        public Boss Boss
        {
            get => _boss;
            set => SetProperty(ref _boss, value);
        }
        public Raid Raid { get; set; }
    }
}
