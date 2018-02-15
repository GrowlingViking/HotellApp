using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelApiContracts;

namespace HotelApiBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/reservations")]
    public class UserReservationsController : Controller
    {
        [Route("availability")]
        [HttpPost]
        public void CheckAvailability([FromBody] RoomBookingParams bookingParams)
        {
            Ok();
        }
    }
}