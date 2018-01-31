using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class ReportForProduct
    {
        public int ReportForProductID { get; set; }
        public string CustomerName { get; set; }
        public string ItemNumber { get; set; }
        public string ReportNumber { get; set; }
        public string CellNumber { get; set; }
        public string RequiredOperations { get; set; }
        public string PartsLeftOnCurrentOperation { get; set; }
        public string CurrentOperation { get; set; }
        public int TotalOrder { get; set; }
    }
}