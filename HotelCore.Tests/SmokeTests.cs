using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelCore.Tests
{
    [TestClass]
    public class SmokeTests
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
            var repo = factory.GetCustomerService();
            var reservations = repo.GetReservations("Erik");
        }
    }
}
