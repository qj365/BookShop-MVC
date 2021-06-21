namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class def : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Information", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Information", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Information", "Sdt", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Information", "Sdt", c => c.String(maxLength: 10));
            AlterColumn("dbo.Information", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Information", "Name", c => c.String(maxLength: 50));
        }
    }
}
