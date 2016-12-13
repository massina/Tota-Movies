namespace TotaMoviesRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConvinsionToNameInCustomersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
