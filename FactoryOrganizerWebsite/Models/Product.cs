using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ItemNumber { get; set; }
        public string Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
        public string WholeFilePath { get; set; }
        public string CellNumber { get; set; }
    }
}