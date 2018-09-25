namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCategoryCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComponentCategory", "CategoryCode", c => c.String(maxLength: 50));
            DropColumn("dbo.ComponentCategory", "UrlFriendlyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComponentCategory", "UrlFriendlyName", c => c.String(maxLength: 100));
            DropColumn("dbo.ComponentCategory", "CategoryCode");
        }
    }
}
