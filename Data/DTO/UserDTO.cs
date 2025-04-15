using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role {  get; set; }   
    }
}
