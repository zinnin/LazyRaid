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
            
            Counter newCounter = new Counter
            {
                Name = "CounterName",
            };
            testUserData.UserSelections.SelectedCounter.SetSelection(newCounter);

            Counter newCounter2 = new Counter
            {
                Name = "CounterName",
            };

            testUserData.Counters.Add(newCounter);
            testUserData.Counters.Add(newCounter2);

            PlayerAbility newPlayerAbility = new PlayerAbility
            {
                Name = "PlayerAbility",
                Counters = new OCReference<Counter>
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
                foreach (Counter counter in ability.Counters)
                {
                    counter.Name = "Renamed";
                }
            }

            foreach (PlayerAbility ability in loadUserDataTest.PlayerAbilities)
            {
                foreach (Counter counter in ability.Counters)
                {
                    foreach(Counter originalCounter in loadUserDataTest.Counters)
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
