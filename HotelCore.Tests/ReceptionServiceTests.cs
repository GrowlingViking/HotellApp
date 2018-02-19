using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelCore.Tests
{

    [TestClass]
    public class ReceptionServiceTests
    {
        private ServiceFactory factory;

        [TestInitialize]
        public void Init()
        {
            factory = new ServiceFactory();
        }

        [TestMethod]
        public void GetReservationsTest()
        {
            var rs = factory.GetReceptionService();
            List<Entities.Reservation> res = rs.GetReservations(false);
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.First().Type);
        }

        [TestMethod]
        public void GetRoomsTest()
        {
            var rs = factory.GetReceptionService();
            List<Entities.Room> res = rs.GetRooms();
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.First().Type);
        }

        [TestMethod]
        public void GetReadyRoomsTest()
        {
            var rs = factory.GetReceptionService();
            var rooms = rs.GetReadyRooms(RoomTypes.Family);
            Assert.IsNotNull(rooms);
        }
    }
}
