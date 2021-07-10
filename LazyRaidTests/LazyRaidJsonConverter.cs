using Microsoft.VisualStudio.TestTools.UnitTesting;
using LazyRaid.Models;

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


        }
    }
}
