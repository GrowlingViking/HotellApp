using System;
using System.Text;
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
            var res = rs.GetReservations(false);
            Assert.IsNotNull(res);
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
