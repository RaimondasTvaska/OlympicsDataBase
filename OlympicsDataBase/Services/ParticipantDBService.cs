using Olympics.Models;
using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class ParticipantDBService
    {
        private AthleteDBService _athleteDB;
        private CountryDBService _countryDB;
        private SportDBService _sportDB;


        public ParticipantDBService(AthleteDBService athleteDB, CountryDBService countryDB, SportDBService sportDB)
        {
            _athleteDB = athleteDB;
            _countryDB = countryDB;
            _sportDB = sportDB;
        }
        public ParticipantModel All()
        {
            
            ParticipantModel participants = new ParticipantModel()

            {
                athletes = _athleteDB.AllAthletes(),
                countries = _countryDB.AllCountries(),
                sports = _sportDB.AllSports()
            };

            return participants;
        }
        public ParticipantModel NewAthlete()
        {
            List<AthleteModel> athletesList = new();
            athletesList.Add(new AthleteModel ());

            ParticipantModel participants = new ParticipantModel()

            {
                athletes = athletesList,
                countries = _countryDB.AllCountries(),
                sports = _sportDB.AllSports()
            };

            return participants;
        }
    }
}
