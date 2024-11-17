using JeugdLinkBLL.Security;
using JeugdLinkDAL.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.UserService
{
    public class Registration : IRegistration
    {



        private readonly IUserRepository _userRepository;

        public Registration(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsRegistered(string email)
        {
            return _userRepository.IsCreated(email);
        }

        public bool Register(UserDTO user)
        {

            if (_userRepository.IsCreated(user.email))
            {
                return false;
            }
            else
            {
                PasswordHash passwordHash = new PasswordHash();
                passwordHash.HashPassord(user.password);

                _userRepository.CreateUser(user);
            }
            
            return true;
        }


    }
}
