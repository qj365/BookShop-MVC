namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voucher", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voucher", "Discount", c => c.Decimal(nullable: false, precision: 10, scale: 2));
        }
    }
}
