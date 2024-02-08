using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinePAW.classes
{
    public class Booking
    {
        public int BookingId { get; set; }
        public User User { get; set; }
        public Route Route { get; set; }
        public int NoPeople { get; set; }

        public Booking() 
        {
            Route= new Route();
            User = new User();
        }

        public Booking(User user, Route route, int noPeople):this()
        {
            User = user;
            Route = route;
            NoPeople = noPeople;
        }
    }
}
