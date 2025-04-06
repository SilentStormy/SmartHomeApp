using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain
{
    public class UserService
    {
        private readonly string _connectionstring;

        public UserService(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public bool Register(User user)
        {
            UserRepository userRepository = new(_connectionstring);
            userRepository.Register(
                user.Firstname,
                user.Lastname,
                user.DateOfBirth,
                user.Email,
                user.Password);
            return true;
                


        }
    }
}
