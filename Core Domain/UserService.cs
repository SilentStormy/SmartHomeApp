using Core_Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain
{
    public class UserService:IUserservice
    {
        private readonly string _connectionstring;
        private readonly IUserRepository _userRepository; 

        public UserService(IUserRepository userRepository)
        {
            
            _userRepository = userRepository;
        }

        public bool Register(User user)
        {
           
           _userRepository.Register(
                user.Firstname,
                user.Lastname,
                user.DateOfBirth,
                user.Email,
                user.Password);
            return true;
                

        }

        public bool Login(User user)
        { 
           var loggedinuser=_userRepository.Login(user.Email, user.Password);

            if (loggedinuser == null)
            {
                throw new Exception("E-mailadres of wachtwoord is onjuist.");
            }
            return true;
             
        }
    }
}
