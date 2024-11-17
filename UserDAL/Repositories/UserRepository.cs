using JeugdLinkDAL.Entities;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connstring;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(string connstring, ILogger<UserRepository> logger)
        {
            _connstring = connstring;
            _logger = logger;
        }
        public bool IsCreated(string email)
        {
            bool isregistered = false;
            try
            {
                using (var connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string CheckEmail = @"SELECT COUNT(*) FROM users WHERE Email=@Email"; 
                    using (MySqlCommand checkuser = new MySqlCommand(CheckEmail, connection))
                    {
                        checkuser.Parameters.AddWithValue("@Email", email);
                        int result = Convert.ToInt32(checkuser.ExecuteScalar()); 

                        if (result > 0)
                        {
                            isregistered = true;
                            _logger.LogError($"This email {email} already exists in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking the registration of the user.");
            }
            return isregistered;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            try
            {
                using (var connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string insertdata = @"INSERT INTO users (Firstname, Lastname,Email,Password,DateOfBirth) VALUES(@Firstname, @Lastname,@Email,@Password,@DateOfBirth)";


                    using (var cmd = new MySqlCommand(insertdata, connection))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", user.firstname);
                        cmd.Parameters.AddWithValue("@lastname", user.lastname);
                        cmd.Parameters.AddWithValue("@Email", user.email);
                        cmd.Parameters.AddWithValue("@Password", user.password);
                        cmd.Parameters.AddWithValue("@DateOfBirth", user.dateofbirth);
                        cmd.ExecuteNonQuery();


                    }
                }

            }


            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during the registration of the user");
            }
            return user;
        }

        public UserDTO ReadUser(string email)
        {
            UserDTO user = null;
            try
            {
                using (var connection = new MySqlConnection(_connstring))
                {
                    connection.Open();
                    string retrieve = @"SELECT * FROM users WHERE Email = @Email";
                    using (var cmd = new MySqlCommand(retrieve, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserDTO
                                {
                                    id = reader.GetInt32("ID"),
                                    firstname = reader.GetString("Firstname"),
                                    lastname = reader.GetString("Lastname"),
                                    email = reader.GetString("Email"),
                                    password = reader.GetString("Password"),
                                    dateofbirth = reader.GetDateTime("DateOfBirth")
                                };



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the user for login.");
            }
            return user;
        }

      
        

    }
}
