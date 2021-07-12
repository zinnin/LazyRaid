namespace LazyRaid.Models
{
    public class BossTime
    {
        public int Minutes { get; set; } = 0;
        public int Seconds { get; set; } = 0;

        public BossTime(int minutes = 0)
        {
            AddTime(minutes);
        }

        public BossTime(int minutes, int seconds)
        {
            AddTime(minutes, seconds);
        }

        public void AddSeconds(int seconds)
        {
            AddTime(0, seconds);
        }

        public void AddMinutes(int minutes)
        {
            AddTime(minutes);
        }

        public void AddTime(int minutes, int seconds = 0)
        {
            Minutes += minutes + (seconds / 60);
            Seconds += seconds % 60;
        }

        public new string ToString => $"{Minutes}:{Seconds}";
        public int ToInt => (Minutes * 60) + Seconds;

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
