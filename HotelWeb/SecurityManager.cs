using HotelCore;
using HotelCore.Entities;
using HotelCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWeb
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(Exception cause = null)
        {

        }
    }

    public class SecurityManager
    {
        private UserService userService;

        public SecurityManager(ServiceFactory serviceFactory)
        {
            userService = serviceFactory.GetUserService();
        }

        public User VerifyUserLogin(string username, string password)
        {
            try
            {
                User user = userService.FindUserByName(username);
                if (user.Password == password) // TODO: password hashing
                {
                    return user;
                }
                else
                {
                    throw new AuthorizationException();
                }
            }
            catch (Exception e)
            {
                throw new AuthorizationException(e);
            }
        }

        public bool Register(string username, string password)
        {
            if (!userService.UserExists(username))
            {
                userService.CreateNewUser(username, password);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}