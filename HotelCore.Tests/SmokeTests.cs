using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelCore.Tests
{
    [TestClass]
    public class SmokeTests
    {
        [TestMethod]
        public void NothingCrashes()
        {
            var repo = new CustomerService();
            var reservations = repo.GetReservations("Erik");
        }
    }
}
