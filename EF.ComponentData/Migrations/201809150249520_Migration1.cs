namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComponentCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ComponentItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ComponentCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ComponentCategory", t => t.ComponentCategory_ID)
                .Index(t => t.ComponentCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComponentItems", "ComponentCategory_ID", "dbo.ComponentCategory");
            DropIndex("dbo.ComponentItems", new[] { "ComponentCategory_ID" });
            DropTable("dbo.ComponentItems");
            DropTable("dbo.ComponentCategory");
        }
    }
}
