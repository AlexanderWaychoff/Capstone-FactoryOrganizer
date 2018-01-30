using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class ProductAwaitingConfirmation
    {
        public int ProductAwaitingConfirmationID { get; set; }
        public string CustomerName { get; set; }
        public string ItemNumber { get; set; }
        public int TotalOrder { get; set; }
        public string CellNumber { get; set; }
    }
}