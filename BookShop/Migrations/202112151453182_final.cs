namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Author", "Diachi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author", "Diachi", c => c.String());
        }
    }
}
