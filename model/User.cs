using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathApp.model
{
    class User : IComparable<User>
    {
        private string username;
        public string Username { get => this.username; set => this.username = value; }
        private string password;
        public string Password { get => this.password; set => this.password = value; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return username + "|" + password;
        }
        public int CompareTo(User other)
        {
            return 1;
        }
    }
}
