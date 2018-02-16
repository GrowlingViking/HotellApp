using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelCore.Tests
{
    [TestClass]
    public class StaffServiceTests
    {
        private ServiceFactory factory;

        [TestInitialize]
        public void Init()
        {
            factory = new ServiceFactory();
        }

        [TestMethod]
        public void NothingCrashes()
        {
            var repo = factory.GetStaffService();
            var tasks = repo.GetTasks("Cleaning");
            var notes = repo.GetNotes(2);
        }
    }
}
