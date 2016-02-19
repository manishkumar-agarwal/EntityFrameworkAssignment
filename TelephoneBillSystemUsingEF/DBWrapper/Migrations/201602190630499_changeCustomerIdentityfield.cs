namespace DBWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCustomerIdentityfield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomersIdentity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomersIdentity", c => c.Int(nullable: false));
        }
    }
}
