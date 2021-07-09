using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyRaid.LazyRaid.Models
{
    class BossTime
    {
        public int Minute { get; set; }
        public int Seconds { get; set; }

        public void AddSeconds(int seconds)
        {

        }

        public void AddMinutes(int minute)
        {

        }

        public void AddTime(int minute, int seconds = 0)
        {

        }

        public new string ToString => $"{Minute}:{Seconds}";
    }
}
