namespace DBWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertedBackMobileNumberSetup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBillingHistories", "CustomerMobileNumber", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "MobileNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "MobileNumber");
            AddForeignKey("dbo.CustomerBillingHistories", "CustomerMobileNumber", "dbo.Customers", "MobileNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBillingHistories", "CustomerMobileNumber", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "MobileNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "MobileNumber");
            AddForeignKey("dbo.CustomerBillingHistories", "CustomerMobileNumber", "dbo.Customers", "MobileNumber", cascadeDelete: true);
        }
    }
}
