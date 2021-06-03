namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreflink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "RefLink", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "RefLink");
        }
    }
}
