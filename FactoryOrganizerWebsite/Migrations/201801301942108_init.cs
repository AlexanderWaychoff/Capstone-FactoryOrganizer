namespace FactoryOrganizerWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInformations",
                c => new
                    {
                        CustomerInformationID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        AccountNumber = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerInformationID);
            
            CreateTable(
                "dbo.EmployeeProductions",
                c => new
                    {
                        EmployeeProductionID = c.Int(nullable: false, identity: true),
                        EmployeeNumber = c.Int(nullable: false),
                        DayOfProduction = c.DateTime(nullable: false),
                        ProductCompletedAmount = c.Int(nullable: false),
                        JobNumber = c.String(),
                        Operation = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeProductionID);
            
            CreateTable(
                "dbo.EmployeeScraps",
                c => new
                    {
                        EmployeeScrapID = c.Int(nullable: false, identity: true),
                        EmployeeNumber = c.Int(nullable: false),
                        DayOfProduction = c.DateTime(nullable: false),
                        Scrap = c.Int(nullable: false),
                        ScrapReason = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeScrapID);
            
            CreateTable(
                "dbo.FilePathToPrograms",
                c => new
                    {
                        FilePathToProgramID = c.Int(nullable: false, identity: true),
                        ProgramType = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.FilePathToProgramID);
            
            CreateTable(
                "dbo.FilePathToWebsiteInformationForProducts",
                c => new
                    {
                        FilePathToWebsiteInformationForProductID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        ItemNumber = c.String(),
                        IsAssignedToCell = c.Boolean(nullable: false),
                        CellNumber = c.String(),
                    })
                .PrimaryKey(t => t.FilePathToWebsiteInformationForProductID);
            
            CreateTable(
                "dbo.JobsForProductions",
                c => new
                    {
                        JobsForProductionID = c.Int(nullable: false, identity: true),
                        JobNumber = c.String(),
                        ItemNumber = c.String(),
                        EmployeeNumber = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        TotalPieces = c.Int(nullable: false),
                        Operation = c.Int(),
                    })
                .PrimaryKey(t => t.JobsForProductionID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ItemNumber = c.String(),
                        Customer = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholeFilePath = c.String(),
                        CellNumber = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductAwaitingConfirmations",
                c => new
                    {
                        ProductAwaitingConfirmationID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        ItemNumber = c.String(),
                        TotalOrder = c.Int(nullable: false),
                        CellNumber = c.String(),
                    })
                .PrimaryKey(t => t.ProductAwaitingConfirmationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductAwaitingConfirmations");
            DropTable("dbo.Products");
            DropTable("dbo.JobsForProductions");
            DropTable("dbo.FilePathToWebsiteInformationForProducts");
            DropTable("dbo.FilePathToPrograms");
            DropTable("dbo.EmployeeScraps");
            DropTable("dbo.EmployeeProductions");
            DropTable("dbo.CustomerInformations");
        }
    }
}
