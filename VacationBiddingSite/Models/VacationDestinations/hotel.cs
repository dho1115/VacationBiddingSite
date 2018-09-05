using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationBiddingSite.Models.VacationDestinations
{
    public class hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double AverageRoomRate { get; set; }
        public bool Restaurant24Hour { get; set; }
        public bool buffet { get; set; }        
    }
}
