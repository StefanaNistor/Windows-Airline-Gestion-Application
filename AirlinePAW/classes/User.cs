using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinePAW.classes
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }

        public User() { }

        public User(string username, string password, bool role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
