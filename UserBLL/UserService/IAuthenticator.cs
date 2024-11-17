using JeugdLinkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.UserService
{
    public interface IAuthenticator
    {
        UserDTO Login(string email, string password);
    }
}
