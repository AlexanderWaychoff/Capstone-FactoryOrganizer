using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class EmployeeScrap
    {
        public int EmployeeId { get; set; }
        public DateTime DayOfProduction { get; set; }
        public int TotalScrap { get; set; }
        //public int ScrapFromEXTRA { get; set; }
        public int TotalPieces { get; set; }
        public float AverageCycleTime { get; set; }
    }
}