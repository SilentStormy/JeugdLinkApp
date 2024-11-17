using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeugdLinkDAL.Entities;

namespace JeugdLinkDAL.Repositories
{
    public interface IUserRepository
    {
        bool IsCreated(string email);
        UserDTO CreateUser(UserDTO user);
        UserDTO ReadUser(string email);
       
    }
}
