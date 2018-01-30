using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class CustomerInformation
    {
        public int CustomerInformationID { get; set; }
        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}