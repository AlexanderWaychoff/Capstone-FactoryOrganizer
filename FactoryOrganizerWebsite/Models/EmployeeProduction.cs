using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class EmployeeProduction
    {
        public int EmployeeProductionID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime DayOfProduction { get; set; }
        public int ProductCompletedAmount { get; set; }
        public string JobNumber { get; set; }
        public int? Operation { get; set; }
    }
}