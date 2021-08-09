using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class CountryDBService
    {
        private SqlConnection _connection;


        public CountryDBService(SqlConnection connection)
        {
            _connection = connection;
        }
        public CountryModel GetCountryById()
        {
            _connection.Open();
            using var command = new SqlCommand("SELECT * FROM dbo.Countries where;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ISO3 = reader.GetString(2)

                });
            }
            _connection.Close();

            return countries;

        }

        public List<CountryModel> AllCountries()
        {
            List<CountryModel> countries = new();

            _connection.Open();
            using var command = new SqlCommand("SELECT * FROM dbo.Countries;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ISO3 = reader.GetString(2)
                    
                });
            }
            _connection.Close();

            return countries;
        }
        public void AddCountry(CountryModel country)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Countries (Name, ISO3) " +
                $"values('{country.Name}', '{country.ISO3}') ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();


        }
    }
}
