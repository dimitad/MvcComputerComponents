namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComponentToSummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComponentSummary", "ComponentItem_ID", c => c.Int());
            CreateIndex("dbo.UserComponentSummary", "ComponentItem_ID");
            AddForeignKey("dbo.UserComponentSummary", "ComponentItem_ID", "dbo.ComponentItems", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComponentSummary", "ComponentItem_ID", "dbo.ComponentItems");
            DropIndex("dbo.UserComponentSummary", new[] { "ComponentItem_ID" });
            DropColumn("dbo.UserComponentSummary", "ComponentItem_ID");
        }
    }
}
