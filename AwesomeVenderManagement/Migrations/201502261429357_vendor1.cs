namespace AwesomeVenderManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendor1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendor", "VenderCategory_Id", "dbo.VendorCategory");
            DropIndex("dbo.Vendor", new[] { "VenderCategory_Id" });
            RenameColumn(table: "dbo.Vendor", name: "VenderCategory_Id", newName: "VendorCategoryId");
            AlterColumn("dbo.Vendor", "VendorCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendor", "VendorCategoryId");
            AddForeignKey("dbo.Vendor", "VendorCategoryId", "dbo.VendorCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendor", "VendorCategoryId", "dbo.VendorCategory");
            DropIndex("dbo.Vendor", new[] { "VendorCategoryId" });
            AlterColumn("dbo.Vendor", "VendorCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Vendor", name: "VendorCategoryId", newName: "VenderCategory_Id");
            CreateIndex("dbo.Vendor", "VenderCategory_Id");
            AddForeignKey("dbo.Vendor", "VenderCategory_Id", "dbo.VendorCategory", "Id");
        }
    }
}
