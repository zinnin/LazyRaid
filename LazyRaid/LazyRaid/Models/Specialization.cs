namespace LazyRaid.Models
{
    public class Specialization : BindableReferenceBase
    {
        public string Name { get; set; } = "New Specialization";
        public OCReference<PlayerAbility> Abilities { get; set; } = new OCReference<PlayerAbility>();

        public Specialization()
        {

        }

        public Specialization(string name, PlayerAbility playerAbilities)
        {
            Name = name;
            Abilities.Add(playerAbilities);
        }

        public Specialization(string name, PlayerAbility[] playerAbilities)
        {
            Name = name;
            if (playerAbilities != null)
            {
                foreach(PlayerAbility ability in playerAbilities)
                {
                    Abilities.Add(ability);
                }
            }
        }
    }
}
