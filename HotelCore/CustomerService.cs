﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore
{
    public class CustomerService
    {
        private dat154_18_1Entities dx;

        public CustomerService()
        {
            dx = new dat154_18_1Entities();
        }

        public List<Reservation> getReseptions(String User)
        {
            return dx.Reservations.Where(x => x.User.UserName == User).ToList();
        }
    }
}
