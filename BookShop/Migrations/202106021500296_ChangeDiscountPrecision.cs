namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDiscountPrecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voucher", "Discount", c => c.Decimal(nullable: false, precision: 10, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voucher", "Discount", c => c.Decimal(nullable: false, precision: 3, scale: 2));
        }
    }
}
