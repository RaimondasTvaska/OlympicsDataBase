using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class SportDBService
    {
        private SqlConnection _connection;


        public SportDBService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<SportModel> AllSports()
        {
            List<SportModel> sports = new();

            _connection.Open();
            using var command = new SqlCommand("SELECT * FROM dbo.Sports;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                sports.Add(new SportModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    TeamActivity = reader.GetBoolean(2)

                });
            }
            _connection.Close();

            return sports;
        }
        public void AddSport(SportModel sport)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Sports (Name, TeamActivity) " +
                $"values('{sport.Name}', '{sport.TeamActivity}') ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();


        }
    }
}
