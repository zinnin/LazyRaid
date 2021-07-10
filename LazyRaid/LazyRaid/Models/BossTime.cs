namespace LazyRaid.Models
{
    public class BossTime
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public BossTime()
        {
            Minutes = 0;
            Seconds = 0;
        }

        public BossTime(int minutes)
        {
            Minutes = minutes;
            Seconds = 0;
        }

        public BossTime(int minutes, int seconds)
        {
            Minutes = minutes + (seconds / 60);
            Seconds = seconds % 60;
        }

        public void AddSeconds(int seconds)
        {
            Minutes += seconds / 60;
            Seconds += seconds % 60;
        }

        public void AddMinutes(int minute)
        {
            Minutes += minute;
        }

        public void AddTime(int minutes, int seconds = 0)
        {
            Minutes += minutes + (seconds / 60);
            Seconds += seconds % 60;
        }

        public new string ToString => $"{Minutes}:{Seconds}";

        public bool Equals(BossTime bossTime)
        {
            return (bossTime.Minutes == Minutes && bossTime.Seconds == Seconds);
        }

        public int CompareTo(BossTime otherTime)
        {
            return (Equals(otherTime) ? 0 : (otherTime.Minutes > Minutes || (otherTime.Minutes == Minutes && otherTime.Seconds > Seconds)) ? 1 : -1);
        }
    }
}
