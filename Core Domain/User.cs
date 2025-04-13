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
       
        private string firstname;
        private string lastname;
        private DateTime dateofbirth;
        private string email;
        private string password;

        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Firstname
        {
            get { return firstname; }

            set {  firstname = value;}
        }

        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Lastname
        {
            get { return lastname; }

            set {lastname = value;}
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

        [Required(ErrorMessage = "Email is verplicht")]
        public string Email
        {
            get { return email; }
            set { email = value;}
        }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minstens 6 tekens bevatten")]
        public string Password
        {
            get => password;
            set
            {
               password = value;
            }
        }
        public User() { }
        public User (string email, string password)
        {
            Email=email;
            Password=password;
        } 
        public User(string firstname, string lastname, DateTime dateofbirth, string email, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateofbirth;
            Email = email;
            Password = password;
        }

        public string GetName(string name)

        { 
            return firstname;
        }
    }
}
