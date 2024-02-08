using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinePAW.classes
{
    public class Company
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
        
        public Company() { }
        
        public Company(int company_id, string company_name)
        {
            this.company_id = company_id;
            this.company_name = company_name;
        }
    }
}
