using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class ParticipantsModel
    {
        public List<AthleteModel> Athletes { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<SportModel> Sports { get; set; }
        public AthleteModel AthleteCreateInformation { get; set; }
        public CountryModel CountryInformation { get; set; }
        public SportModel SportInformation { get; set; }
    }
}
