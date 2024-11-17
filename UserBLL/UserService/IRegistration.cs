using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeugdLinkDAL;
using JeugdLinkDAL.Entities;

namespace JeugdLinkBLL.UserService
{
    public interface IRegistration
    {
        bool IsRegistered(string email);
        bool Register(UserDTO user);
    }
}
