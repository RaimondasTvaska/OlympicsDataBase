using Olympics.Models;
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
                    Country_Id = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                    CountryName = reader.GetString(4)
                });
            }
            _connection.Close();

            return athletes;
        }
        public void AddNewAthlete(ParticipantsModel participants)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Athletes (Name, Surname, Country_Id) " +
                $"values('{participants.AthleteCreateInformation.Name}'," +
                $" '{participants.AthleteCreateInformation.Surname}', " +
                $"'{participants.AthleteCreateInformation.Country_Id}') ";

            //1. Isgauti naujai sukurto Atleto id
            /**
             select id from dbo.Atletes where Name = @name and Surname = @surname
             */
            using var command1 = new SqlCommand("SELECT Id FROM dbo.Athletes WHERE Name = _name, Surname = _surname;", _connection);

            //2. Ideti Atleto id ir Sporto id i [dbo].[AthletesSports]
            string insertText1 = $"insert into dbo.AthletesSports (AthleteId, SportId) " +
                $"values('{participants.AthleteCreateInformation.Id}'," +
                $" '{participants.SportInformation.Id}') ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

            
        }

    }
}
