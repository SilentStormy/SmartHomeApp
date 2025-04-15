using Core_Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Interface
{
    public interface IUserserivce
    {
        AuthResult Register(User user);
        AuthResult Login(User user);
        bool EmailExists(User user);

        //RevokeStatus RevokeStatus(Guest guest);
        
    }

}
