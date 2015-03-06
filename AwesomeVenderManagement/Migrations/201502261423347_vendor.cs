namespace AwesomeVenderManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        OfficePhone = c.String(),
                        CellPhone = c.String(),
                        CreatedDate = c.DateTime(),
                        LastDateOfActivity = c.DateTime(),
                        IsLockedOut = c.Boolean(),
                        IsActive = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VendorCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false, maxLength: 255, unicode: false),
                        VendorDescription = c.String(maxLength: 1000, unicode: false),
                        VendorCreatedDate = c.DateTime(nullable: false),
                        VendorCreatedById = c.String(maxLength: 128),
                        IsActiveVendor = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedById = c.String(maxLength: 128),
                        ContactPerson_Id = c.Int(),
                        VenderCategory_Id = c.Int(),
                        VendorAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VendorContactPerson", t => t.ContactPerson_Id)
                .ForeignKey("dbo.VendorCategory", t => t.VenderCategory_Id)
                .ForeignKey("dbo.Address", t => t.VendorAddress_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VendorCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.VendorCreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ContactPerson_Id)
                .Index(t => t.VenderCategory_Id)
                .Index(t => t.VendorAddress_Id);
            
            CreateTable(
                "dbo.VendorContactPerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255, unicode: false),
                        MiddleName = c.String(nullable: false, maxLength: 255, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 30, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        HomePhone = c.String(maxLength: 255, unicode: false),
                        CellPhone = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false, maxLength: 255, unicode: false),
                        Address2 = c.String(maxLength: 255, unicode: false),
                        City = c.String(maxLength: 255, unicode: false),
                        State = c.String(maxLength: 255, unicode: false),
                        ZipCode = c.String(maxLength: 30, unicode: false),
                        Country = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendor", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vendor", "VendorCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vendor", "VendorAddress_Id", "dbo.Address");
            DropForeignKey("dbo.Vendor", "VenderCategory_Id", "dbo.VendorCategory");
            DropForeignKey("dbo.Vendor", "ContactPerson_Id", "dbo.VendorContactPerson");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Vendor", new[] { "VendorAddress_Id" });
            DropIndex("dbo.Vendor", new[] { "VenderCategory_Id" });
            DropIndex("dbo.Vendor", new[] { "ContactPerson_Id" });
            DropIndex("dbo.Vendor", new[] { "ModifiedById" });
            DropIndex("dbo.Vendor", new[] { "VendorCreatedById" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropTable("dbo.Address");
            DropTable("dbo.VendorContactPerson");
            DropTable("dbo.Vendor");
            DropTable("dbo.VendorCategory");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
