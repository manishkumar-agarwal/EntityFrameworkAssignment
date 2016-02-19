namespace DBWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingCustomers : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.Customers", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            DropColumn("dbo.Customers", "CustomersEmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomersEmployeeId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Customers", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameColumn(table: "dbo.Customers", name: "EmployeeId", newName: "Employee_EmployeeId");
        }
    }
}
