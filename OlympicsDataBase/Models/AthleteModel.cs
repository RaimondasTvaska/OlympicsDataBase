using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class AthleteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Country_Id { get; set; }
        public string CountryName { get; set; }
        List<SportModel> Sports { get; set; }
    }
}
