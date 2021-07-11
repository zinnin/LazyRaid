using Microsoft.VisualStudio.TestTools.UnitTesting;
using LazyRaid;
using LazyRaid.Models;
using System.Threading.Tasks;
using System;

namespace LazyRaidTests
{
    [TestClass]
    public class LazyRaidJsonConverter
    {
        [TestMethod]
        public void TestSerialization()
        {
            UserData testUserData = new UserData();
            testUserData.LoadUserData("FileNameWillNeverExist");
            
            SpellEffect newCounter = new SpellEffect
            {
                Name = "CounterName",
            };
            testUserData.UserSelections.SelectedCounter.SetSelection(newCounter);

            SpellEffect newCounter2 = new SpellEffect
            {
                Name = "CounterName",
            };

            testUserData.Counters.Add(newCounter);
            testUserData.Counters.Add(newCounter2);

            PlayerAbility newPlayerAbility = new PlayerAbility
            {
                Name = "PlayerAbility",
                Counters = new OCReference<SpellEffect>
                {
                    newCounter,
                    newCounter2,
                },
            };

            testUserData.PlayerAbilities.Add(newPlayerAbility);

            Task saveTask = Task.Run(() => testUserData.SaveUserDataAsync("TestUserData.LRD"));
            Task.WaitAll(saveTask);

            UserData loadUserDataTest = new UserData();
            loadUserDataTest.LoadUserData("TestUserData.LRD");

            foreach (PlayerAbility ability in loadUserDataTest.PlayerAbilities)
            {
                foreach (SpellEffect counter in ability.Counters)
                {
                    counter.Name = "Renamed";
                }
            }

            foreach (PlayerAbility ability in loadUserDataTest.PlayerAbilities)
            {
                foreach (SpellEffect counter in ability.Counters)
                {
                    foreach(SpellEffect originalCounter in loadUserDataTest.Counters)
                    {
                        Assert.AreEqual(originalCounter.Name, counter.Name);
                    }
                }
            }

            Assert.IsTrue(loadUserDataTest.UserSelections.SelectedCounter.GetSelection() != null);

            Console.Write("Serialization Tests Complete!");
        }
    }
}
