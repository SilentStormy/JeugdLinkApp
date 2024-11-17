using JeugdLinkDAL.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.UserService
{
    public class Authentication : IAuthenticator
    {
        private readonly IUserRepository _userRepository;

        public Authentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Login(string email, string password)
        {
            var user = _userRepository.ReadUser(email);
            if (user != null && user.password == password)
            {
                return user;
            }

            return null;
        }

    }
}
