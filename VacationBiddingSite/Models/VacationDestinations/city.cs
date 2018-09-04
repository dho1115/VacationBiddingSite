using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationBiddingSite.Models.VacationDestinations
{
    public class city
    {
        public int id { get; set; }
        public string name { get; set; }
        public country GetCountry { get; set; }
    }
}
