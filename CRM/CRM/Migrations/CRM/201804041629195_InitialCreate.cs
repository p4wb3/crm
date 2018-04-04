namespace CRM.Migrations.CRM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Adress = c.String(),
                        SectionName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Sections", t => t.SectionName)
                .Index(t => t.SectionName);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionName = c.String(nullable: false, maxLength: 128),
                        Job = c.String(),
                    })
                .PrimaryKey(t => t.SectionName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SectionName", "dbo.Sections");
            DropIndex("dbo.Employees", new[] { "SectionName" });
            DropTable("dbo.Sections");
            DropTable("dbo.Employees");
        }
    }
}
