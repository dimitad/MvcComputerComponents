namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ComponentItems", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComponentItems", "CategoryId", c => c.Int(nullable: false));
        }
    }
}
