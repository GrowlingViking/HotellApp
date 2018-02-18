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
        public void GettingTasksAndNotesDoesNotCrash()
        {
            var repo = factory.GetStaffService();
            var tasks = repo.GetTasks("Cleaning");
            Assert.IsNotNull(tasks);
            var notes = repo.GetNotes(2);
            Assert.IsNotNull(notes);
        }
    }
}
