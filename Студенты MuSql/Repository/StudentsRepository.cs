using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Студенты_MuSql.Models;

namespace Студенты_MuSql.Repository
{
    internal class StudentsRepository : IStudentsRepository
    {
        private string connString { get; set; }
        public StudentsRepository(string host, string db, string user, string password)
        {
            connString = $"server = {host};uid = {user};pwd = {password};database = {db}";
        }
        public List<Students> GetAll()
        {
            List<Students> allstudents = new List<Students>();
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand querryCommand = conn.CreateCommand();
            querryCommand.CommandText = "SELECT * FROM University.Students";
            try
            {
                conn.OpenAsync();
                MySqlDataReader reader;
                reader = querryCommand.ExecuteReader();

                while (reader.Read())
                {
                    allstudents.Add(new Students { Stu_id = reader.GetInt32(0), Stu_Name = reader.GetString(1), Stu_SurName = reader.GetString(2), Stu_Age = reader.GetInt32(3), Stu_AvgScore = reader.GetInt32(4) });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка {e.Message}");
                throw e;
            }
            conn.Close();
            return allstudents;
        }

        public int Insert(Students value)
        {
            int rows = 0;

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand querryCommand = conn.CreateCommand();
            querryCommand.CommandText = $"INSERT INTO University.Students(Stu_Name, Stu_SurName, Stu_Age, Stu_AvgScore) VALUES('{value.Stu_Name}', '{value.Stu_SurName}', {value.Stu_Age}, {value.Stu_AvgScore});";
            try
            {
                conn.OpenAsync();
                rows = querryCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
                throw ex;
            }
            conn.Close();
            return rows;
        }

        public int Update(int id, Students value)
        {
            int rows = 0;

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand querryCommand = conn.CreateCommand();
            querryCommand.CommandText = $"UPDATE University.Students SET Stu_Name = '{value.Stu_Name}', Stu_SurName = '{value.Stu_SurName}', Stu_Age = {value.Stu_Age}, Stu_AvgScore = {value.Stu_AvgScore} WHERE Stu_id = {id}";
            try
            {
                conn.OpenAsync();
                rows = querryCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
                throw ex;
            }
            conn.Close();
            return rows;
        }
    }
}
