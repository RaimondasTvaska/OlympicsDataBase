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
            using var command = new SqlCommand(@"select athletes.Name, athletes.Surname, countries.CountryName, STRING_AGG (sports.sportName, ',  ') AS 'sports'
                from athletes 
                join AthletesSports
                on athletes.Id = AthletesSports.AthleteId
                join countries
                on athletes.country_id = countries.Id
                join sports 
                on AthletesSports.SportId = Sports.Id
                group by Name, Surname, CountryName; ", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athletes.Add(new AthleteModel()
                {
                    //Id = reader.GetInt32(0),
                    Name = reader.GetString(0),
                    Surname = reader.GetString(1),
                    CountryName = reader.GetString(2),
                    SportName = reader.GetString(3),
                });
            }
            _connection.Close();

            return athletes;
        }
        public int AddNewAthlete(ParticipantsModel participants)
        {
            int athleteId = 0;
            _connection.Open();

            string insertText = $"insert into dbo.Athletes (Name, Surname, Country_Id) " +
                $"values('{participants.AthleteCreateInformation.Name}'," +
                $" '{participants.AthleteCreateInformation.Surname}', " +
                $"'{participants.AthleteCreateInformation.Country_Id}') SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(insertText, _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athleteId = Convert.ToInt32(reader.GetDecimal(0));
            }
            reader.Close();
            //1. Isgauti naujai sukurto Atleto id
            /**
             select id from dbo.Atletes where Name = @name and Surname = @surname
             */

            //2. Ideti Atleto id ir Sporto id i [dbo].[AthletesSports]
            foreach (var sportId in participants.SportInformation)
            {
            command = new($"insert into dbo.AthletesSports (AthleteId, SportId) " +
                $"values('{athleteId}'," +
                $" '{sportId}') ;", _connection);
            command.ExecuteNonQuery();

            }

            _connection.Close();
            return athleteId;
            
        }

    }
}
