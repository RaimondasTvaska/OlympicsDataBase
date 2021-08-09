using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class AthleteDBService
    {
        private SqlConnection _connection;


        public AthleteDBService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<AthleteModel> AllAthletes()
        {
            List<AthleteModel> athletes = new();

            _connection.Open();
            using var command = new SqlCommand("SELECT * FROM dbo.AthletesWithCountries;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athletes.Add(new AthleteModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Country_Id = reader.GetInt32(3),
                    CountryName = reader.GetString(4)
                });
            }
            _connection.Close();

            return athletes;
        }
        public void AddNewAthlete (AthleteModel athlete)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Athletes (Name, Surname, Country) " +
                $"values('{athlete.Name}', '{athlete.Surname}', '{athlete.Country}') ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

            
        }

    }
}
