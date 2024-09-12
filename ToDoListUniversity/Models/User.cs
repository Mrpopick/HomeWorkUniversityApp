using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ToDoListUniversity.Models
{
    public class User
    {
        public string fullname { get; set; }
        public string email { get; set; }
        private string login { get; set; }
        private string password { get; set; }

        public User(string login, string password) 
        {
            this.login = login;
            this.password = password;
        }

        public User() {  }

        public User(string fullname, string email, string login, string password) : this(fullname, email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.login = login;
        }

        public  void AddNewUser(User user)
        {
            string query = "INSERT INTO Users (fullname, login, password, email) VALUES (@fullname, @login, @password, @email)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Server.Server.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand sqlCommand = new MySqlCommand(query, conn);

                        sqlCommand.Parameters.AddWithValue("@fullname", user.fullname);
                        sqlCommand.Parameters.AddWithValue("@login", user.login);
                        sqlCommand.Parameters.AddWithValue("@password", user.password);
                        sqlCommand.Parameters.AddWithValue("@email", user.email);

                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public  bool CheckUsers(User user)
        {
            string query = "SELECT 1 FROM Users WHERE login = @login AND password = @password";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Server.Server.ConnectionString))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@login", user.login);
                    sqlCommand.Parameters.AddWithValue("@password", user.password);

                    object result = sqlCommand.ExecuteScalar();
                    return result != null;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log the error or throw a custom exception
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public User GetUser(User us)
        {
            string query = "SELECT fullname, login, password, email FROM Users WHERE login = @login";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Server.Server.ConnectionString))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@login", us.login);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        User user = new User
                        {
                            /*Id = reader.GetInt32(0)*/
                            fullname = reader.GetString(0),
                            password = reader.GetString(1),
                            login = reader.GetString(2),
                            email = reader.GetString(3)
                        };

                        return user;
                    }
                    else
                    {
                        return null; // User not found
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }

}
