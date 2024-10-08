﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListUniversity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        private string login { get; set; }
        private string password { get; set; }


        public static void AddNewUser(string fullname, string login, string password, string email) 
        {
            string query = "INSERT INTO Users (fullname, login, password, email) VALUES (@fullname, @login, @password, @email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(Server.Server.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand sqlCommand = new SqlCommand(query, conn);

                        sqlCommand.Parameters.AddWithValue("@fullname", fullname);
                        sqlCommand.Parameters.AddWithValue("@login", login);
                        sqlCommand.Parameters.AddWithValue("@password", password);
                        sqlCommand.Parameters.AddWithValue("@email", email);

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

        public static bool CheckUsers(string login, string password) 
        {
            string query = "SELECT 1 FROM Users WHERE login = @login AND password = @password";

            try
            {
                using (SqlConnection conn = new SqlConnection(Server.Server.ConnectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@login", login);
                    sqlCommand.Parameters.AddWithValue("@password", password);

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

        public User GetUser(string login) 
        {
            string query = "SELECT fullname, login, password, email FROM Users WHERE login = @login";

            try
            {
                using (SqlConnection conn = new SqlConnection(Server.Server.ConnectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, conn);

                    sqlCommand.Parameters.AddWithValue("@login", login);

                    SqlDataReader reader = sqlCommand.ExecuteReader();

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
