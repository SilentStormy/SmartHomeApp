using Core_Domain.Entities;
using Core_Domain.Interface;
using Core_Domain.Result;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Service
{
    public class UserService : IUserAuthService
    {
        private readonly string _connectionstring;
        private readonly IUserRepository _userRepository;
        private readonly IRegistrationConfirmation _registrationConfirmation;

        public UserService(IUserRepository userRepository, IRegistrationConfirmation registrationConfirmation)
        {

            _userRepository = userRepository;
            _registrationConfirmation = registrationConfirmation;
        }

        public AuthResult Register(User user)
        {
            if (_userRepository.EmailExists(user.Email))
            {
                return AuthResult.FailedResult(false, "Dit email adres bestaat er al!");
            }

            _userRepository.Register(
                 user.Firstname,
                 user.Lastname,
                 user.DateOfBirth,
                 user.Email,
                 user.Password,
                 user.Role);

            _registrationConfirmation.Send(user);
            return AuthResult.SuccessResult(true, "Jij bent succevol geregistreerd!");


        }

        public AuthResult Login(User user)
        {
            var loggedinuser = _userRepository.Login(user.Email, user.Password);

            if (loggedinuser == null)
            {
                return AuthResult.FailedResult(false, "Emailadress of wachtwoord is onjuist!");
            }
            return AuthResult.SuccessResult(true, "Jij bent succesvol ingelogd!");

        }

        public bool EmailExists(User user)
        {
            return _userRepository.EmailExists(user.Email);


        }

        //public RevokeStatus RevokeStatus(User user)
        //{
        //    _userRepository.RevokeAccess(guest.)
        //}
    }

    public interface IUserAuthentication
    {
    }
}
