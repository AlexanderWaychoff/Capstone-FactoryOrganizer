namespace FactoryOrganizerWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportForProducts", "PartsLeftOnCurrentOperation", c => c.String());
            DropColumn("dbo.ReportForProducts", "PartsLeffOnCurrentOperation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportForProducts", "PartsLeffOnCurrentOperation", c => c.String());
            DropColumn("dbo.ReportForProducts", "PartsLeftOnCurrentOperation");
        }
    }
}
