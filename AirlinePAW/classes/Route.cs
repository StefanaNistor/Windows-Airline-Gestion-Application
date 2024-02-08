using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinePAW.classes
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public Company Company { get; set; }

        public Route() {
        
            Company=new Company();
        }

        public Route(string origin, string destination, double distance, Company company):this()
        {
            Origin = origin;
            Destination = destination;
            Distance = distance;
            Company = company;
        }
       

    }
}
