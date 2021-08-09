using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class ParticipantModel
    {
        public List<AthleteModel> athletes { get; set; }
        public List<CountryModel> countries { get; set; }
        public List<SportModel> sports { get; set; }
        public AthleteModel AthleteCreateInformation { get; set; }
    }
}
