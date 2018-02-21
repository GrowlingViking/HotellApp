using HotelCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Services
{
    public class UserService
    {
        private HotelModelCf ctx;

        public UserService(HotelModelCf ctx)
        {
            this.ctx = ctx;
        }

        public void CreateNewUser(string username, string password)
        {
            User user = new User
            {
                UserName = username,
                Password = password
            };
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        public User FindUserByName(string username)
        {
            return ctx.Users.Where(u => u.UserName == username).First();
        }

        public bool UserExists(string username)
        {
            return ctx.Users.Where(u => u.UserName == username).Count() > 0;
        }
    }
}
