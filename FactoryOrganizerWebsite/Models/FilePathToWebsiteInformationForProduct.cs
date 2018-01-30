using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class FilePathToWebsiteInformationForProduct
    {
        //allFolderNames.CustomersFolder customerList.Text allFolderNames.CellsFolder  everyCustomerCell.Text customerProducts.Text
        public int FilePathToWebsiteInformationForProductID { get; set; }
        public string CustomerName { get; set; }
        public string ItemNumber { get; set; }
        public bool IsAssignedToCell { get; set; }
        public string CellNumber { get; set; }
        public string WholeFilePath { get; set; }
    }
}