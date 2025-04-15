using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        void Register(string firstname, string lastname, DateTime dateofbirth, string email, string password,string role);
        UserDTO Login(string email, string password);
        bool EmailExists(string email);

        void RevokeAccess(int guestid);
    }
}
