using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Customer { get; set; }
        public decimal Price { get; set; }
    }
}