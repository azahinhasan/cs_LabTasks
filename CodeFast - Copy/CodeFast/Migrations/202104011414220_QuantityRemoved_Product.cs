namespace CodeFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    //add-migration QuantityRemoved_Product
    //update-database
    public partial class QuantityRemoved_Product : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
    }
}
