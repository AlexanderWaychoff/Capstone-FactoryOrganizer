using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryOrganizerWebsite.Models
{
    public class FilePathToProgram
    {
        public int FilePathToProgramID { get; set; }
        public string ProgramType { get; set; }
        public string FilePath { get; set; }
    }
}
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-FactoryOrganizerWebsite-20180119012225;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False