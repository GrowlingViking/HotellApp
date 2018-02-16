using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelCore.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private ServiceFactory factory;

        [TestInitialize]
        public void Init()
        {
            factory = new ServiceFactory();
        }

        [TestMethod]
        public void MakeReservation()
        {
            var repo = factory.GetCustomerService();
            var roomService = factory.GetRoomService();
            var roomType = roomService.GetRoomType(RoomTypes.Family);
            Assert.IsNotNull(roomType);

            var reservation = repo.MakeReservation("Erik", roomType, DateTime.Now, DateTime.Now);
            Assert.IsTrue(reservation.Id > 0);
        }
    }
}
