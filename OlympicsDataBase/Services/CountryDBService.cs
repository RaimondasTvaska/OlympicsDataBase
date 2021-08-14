using Olympics.Models;
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
            List<CountryModel> countries = new List<CountryModel>();
            _connection.Open();
            using var command = new SqlCommand("SELECT * FROM dbo.Countries where;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryModel()
                {
                    Id = reader.GetInt32(0),
                    CountryName = reader.GetString(1),
                    ISO3 = reader.GetString(2)

                });
            }
            _connection.Close();

            return countries[0];

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
                    CountryName = reader.GetString(1),
                    ISO3 = reader.GetString(2)
                    
                });
            }
            _connection.Close();

            return countries;
        }
        public void AddCountry(CountryModel country)
        {
            _connection.Open();

            string insertText = $"insert into dbo.Countries (CountryName, ISO3) " +
                $"values('{country.CountryName}', '{country.ISO3}') ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();


        }
    }
}
