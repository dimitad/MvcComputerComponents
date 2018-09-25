namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToSummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComponentSummary", "ComponentCategory_ID", c => c.Int());
            CreateIndex("dbo.UserComponentSummary", "ComponentCategory_ID");
            AddForeignKey("dbo.UserComponentSummary", "ComponentCategory_ID", "dbo.ComponentCategory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComponentSummary", "ComponentCategory_ID", "dbo.ComponentCategory");
            DropIndex("dbo.UserComponentSummary", new[] { "ComponentCategory_ID" });
            DropColumn("dbo.UserComponentSummary", "ComponentCategory_ID");
        }
    }
}
