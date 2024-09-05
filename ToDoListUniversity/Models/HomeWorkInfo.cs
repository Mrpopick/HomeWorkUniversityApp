using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using ToDoListUniversity.Services;

namespace ToDoListUniversity.Models
{
    public class HomeWorkInfo
    {
        public HomeWorkInfo()
        {
            this.guid = ViewService.CreateNewGuid();
        }
        private string guid { get; set; }
        public string subject { get; set; }
        public string difficulty { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string fullname { get; set; }



        public static void AddNewHomeWork(HomeWorkInfo hmInfo)
        {
            string query = "INSERT INTO HomeworkTask (subject, difficulty, description, start, last, fullname, guid) VALUES (@subject, @difficulty, @description, @start, @last, @fullname, @guid)";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Server.Server.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@subject", hmInfo.subject);
                    sqlCommand.Parameters.AddWithValue("@difficulty", hmInfo.difficulty);
                    sqlCommand.Parameters.AddWithValue("@description", hmInfo.description);
                    sqlCommand.Parameters.AddWithValue("@start", hmInfo.start);
                    sqlCommand.Parameters.AddWithValue("@last", hmInfo.end);
                    sqlCommand.Parameters.AddWithValue("@fullname", hmInfo.fullname);
                    sqlCommand.Parameters.AddWithValue("@guid", hmInfo.guid);

                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static List<HomeWorkInfo> GetAllHomewWork()
        {
            List<HomeWorkInfo> homeworkList = new List<HomeWorkInfo>();

            string query = "SELECT subject, difficulty, description, start, last, fullname, guid FROM HomeworkTask";

            using (MySqlConnection connection = new MySqlConnection(Server.Server.ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    HomeWorkInfo homeWorkInfo = new HomeWorkInfo();
                    homeWorkInfo.subject = reader.GetString(0);
                    homeWorkInfo.difficulty = reader.GetString(1);
                    homeWorkInfo.description = reader.GetString(2);
                    homeWorkInfo.start = reader.GetDateTime(3);
                    homeWorkInfo.end = reader.GetDateTime(4);
                    homeWorkInfo.fullname = reader.GetString(5);
                    homeWorkInfo.guid = reader.GetString(6);

                    homeworkList.Add(homeWorkInfo);
                }

                reader.Close();
                connection.Close();
            }

            return homeworkList;
        }

        public static void UpdateHomeWork(HomeWorkInfo hm)
        {

            string query = $"UPDATE HomeworkTask SET subject = @subject, difficulty = @difficulty, description = @description, start = @start, last = @last, fullname = @fullname WHERE guid = @guid";

            using (MySqlConnection connection = new MySqlConnection(Server.Server.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@subject", hm.subject);
                command.Parameters.AddWithValue("@difficulty", hm.difficulty);
                command.Parameters.AddWithValue("@description", hm.description);
                command.Parameters.AddWithValue("@start", hm.start);
                command.Parameters.AddWithValue("@last", hm.end);
                command.Parameters.AddWithValue("@fullname", hm.fullname);
                command.Parameters.AddWithValue("@guid", hm.guid);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DeleteHomeWork(HomeWorkInfo hm)
        {
            string query = "DELETE FROM HomeworkTask WHERE guid = @guid";

            using (MySqlConnection connection = new MySqlConnection(Server.Server.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@guid", hm.guid);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
