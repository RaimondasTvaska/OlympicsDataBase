using Olympics.Models;
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
        public ParticipantsModel AllParticipants()
        {

            ParticipantsModel participants = new ParticipantsModel()

            {
                Athletes = _athleteDB.AllAthletes(),
                Countries = _countryDB.AllCountries(),
                Sports = _sportDB.AllSports()
            };

            return participants;
        }
        public ParticipantsModel NewAthlete()
        {
            List<AthleteModel> athletesList = new();
            athletesList.Add(new AthleteModel ());

            ParticipantsModel participants = new ParticipantsModel()

            {
                Athletes = athletesList,
                Countries = _countryDB.AllCountries(),
                Sports = _sportDB.AllSports()

            };

            return participants;
        }
    }
}
