namespace DBWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBillingHistories",
                c => new
                    {
                        BillPaymentId = c.Int(nullable: false, identity: true),
                        BillPaidDate = c.DateTime(nullable: false),
                        CustomerMobileNumber = c.Int(nullable: false),
                        BillPaymentMode = c.Int(nullable: false),
                        BillAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BillPaymentId)
                .ForeignKey("dbo.Customers", t => t.CustomerMobileNumber, cascadeDelete: true)
                .Index(t => t.CustomerMobileNumber);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        MobileNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        CustomersEmployeeId = c.Int(nullable: false),
                        CustomersIdentity = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MobileNumber)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        TShirtSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBillingHistories", "CustomerMobileNumber", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Customers", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CustomerBillingHistories", new[] { "CustomerMobileNumber" });
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerBillingHistories");
        }
    }
}
