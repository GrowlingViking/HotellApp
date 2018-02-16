using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore
{
    public class ServiceFactory
    {
        private dat154_18_1Entities ctx;

        public ServiceFactory()
        {
            this.ctx = new dat154_18_1Entities();
        }

        public CustomerService GetCustomerService()
        {
            return new CustomerService(ctx);
        }

        public RoomService GetRoomService()
        {
            return new RoomService(ctx);
        }

        public ReceptionService GetReceptionService()
        {
            return new ReceptionService(ctx);
        }

        public StaffService GetStaffService()
        {
            return new StaffService(ctx);
        }
    }
}
