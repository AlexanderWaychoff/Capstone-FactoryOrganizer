using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class JobsForProduction
    {
        public int JobsForProductionID { get; set; }
        public string JobNumber { get; set; }
        public string ItemNumber { get; set; }
        public int EmployeeNumber { get; set; }
        public int ProductID { get; set; }
        public int TotalPieces { get; set; }
        public int? Operation { get; set; }

    }
}