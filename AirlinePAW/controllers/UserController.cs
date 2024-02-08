using AirlinePAW.classes;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace AirlinePAW.controllers
{

    public class UserController
       
    {
        private string ConnectionString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public UserController() { }

        //authenticate a user
        public bool AuthenticateUser(string username, string password, bool role)
        {
            var query = "SELECT * FROM User WHERE Username = @username AND Password = @password AND Role = @role";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", role);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //register a user
        public bool RegisterUser(string username, string password, int role)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var query = "INSERT INTO User (Username, Password, Role) VALUES (@username, @password, @role)";

                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                    
                int rowsAffected = command.ExecuteNonQuery();

               // Check if any rows were affected
               if (rowsAffected > 0)
                {
                 return true;
                }

            }
            return false;
        }

        //get nonstaff users
        public List<User> GetUsersNotStaff() 
        {
            List<User> users = new List<User>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var query = "SELECT user_id, username, role FROM User WHERE role = 0";
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        user.Username = reader["username"].ToString();
                        int temprole = Convert.ToInt32(reader["role"]);
                        if(temprole == 0)
                        {
                            user.Role = false;
                        }
                        else
                        {
                            user.Role = true;
                        }
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        //get a user based on params
        public User GetUser(string username, string password, bool role)
        {
            User user = new User();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM User WHERE username = @username AND password = @password AND role = @role";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        user.Username = reader["username"].ToString();
                        user.Password = reader["password"].ToString();
                        int temprole = Convert.ToInt32(reader["role"]);
                        if (temprole == 0)
                        {
                            user.Role = false;
                        }
                        else
                        {
                            user.Role = true;
                        }
                    }
                }
            }
            return user;
        }

        //delete users
        public bool DeleteUser(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var query = "DELETE FROM User WHERE user_id = @id";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }

        //get all users
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM User";
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(reader["user_id"]);
                        user.Username = reader["username"].ToString();
                        user.Password = reader["password"].ToString();
                        int temprole = Convert.ToInt32(reader["role"]);
                        if (temprole == 0)
                        {
                            user.Role = false;
                        }
                        else
                        {
                            user.Role = true;
                        }
                        users.Add(user);
                    }
                }
            }
            return users;
        }


    }

}
