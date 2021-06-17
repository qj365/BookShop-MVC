namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themReason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Reason", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Reason");
        }
    }
}
