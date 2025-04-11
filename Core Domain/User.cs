using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private DateTime dateofbirth;
        private string email;
        private string password;

        
       public string Firstname
        {
            get { return firstname; }

            set {
                if (!string.IsNullOrEmpty(value))

                    firstname = value;
                else throw new ArgumentException("Firstname cannot be empty");

                 }
        } 
        public string Lastname
        {
            get { return lastname; }

            set { 
                if(!string.IsNullOrEmpty(value)) 
                    
                        lastname = value;
                else throw new ArgumentException("Lastname cannot be empty");
            }
        }
        public DateTime DateOfBirth
        {
            get { return dateofbirth; }

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("Date of birth cannot be in the future");
                dateofbirth = value;

            }
        }


        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty");
                email = value;
            }
        }

        //[Required(ErrorMessage = "Wachtwoord is verplicht")]
        //[MinLength(6, ErrorMessage = "Wachtwoord moet minstens 6 tekens bevatten")]
        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Wachtwoord is verplicht");
                password = value;
            }
        }

        public User (string email, string password)
        {
            Email=email;
            Password=password;
        } 
        
        
    }
}
