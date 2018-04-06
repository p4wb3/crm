namespace CRM.Migrations.CRM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Section_Id", newName: "SectionId");
            RenameIndex(table: "dbo.Employees", name: "IX_Section_Id", newName: "IX_SectionId");
            DropColumn("dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Employees", name: "IX_SectionId", newName: "IX_Section_Id");
            RenameColumn(table: "dbo.Employees", name: "SectionId", newName: "Section_Id");
        }
    }
}
