using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain
{
    public class User
    {
        private int userId;
        private string firstname;
        private string lastname;
        private DateOnly dateofbirth;
        private string email;
        private string password;

       public string Firstname
        {
            get { return firstname; }

            set { firstname = value; }
        } 
        public string Lastname
        {
            get { return lastname; }

            set { lastname = value; }
        }
        public DateOnly DateOfBirth
        {
            get { return dateofbirth; }

            set { dateofbirth = value; }
        } 
        public string Email
        {
            get { return email; }

            set { email = value; }
        } 
        public string Password
        {
            get { return password; }

            set { password = value; }
        }


    }
}
