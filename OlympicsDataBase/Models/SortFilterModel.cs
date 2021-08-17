using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class SortFilterModel
    {
        public string FilterCountry { get; set; }
        public string FilterSport { get; set; }
        public string FilterActivity { get; set; }
        public string Sort { get; set; }
    }
}
