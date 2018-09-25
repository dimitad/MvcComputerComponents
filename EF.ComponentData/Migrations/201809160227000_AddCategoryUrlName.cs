namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryUrlName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComponentCategory", "UrlFriendlyName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComponentCategory", "UrlFriendlyName");
        }
    }
}
