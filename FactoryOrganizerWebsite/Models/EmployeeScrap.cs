﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class EmployeeScrap
    {
        public int EmployeeScrapID { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime DayOfProduction { get; set; }
        public int Scrap { get; set; }
        //public int ScrapFromEXTRA { get; set; }
        public int ScrapReason { get; set; }
    }
}