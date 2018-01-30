using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class FilePath
    {
        public string WholeFilePath { get; set; }
        public string CustomerName { get; set; }
        public bool IsAssignedToCell { get; set; }
        public string CellNumber { get; set; }
        public string ItemNumber { get; set; }
    }
}