namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveComponentSummaryID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComponentItems", "UserComponentSummary_ID", "dbo.UserComponentSummary");
            DropIndex("dbo.ComponentItems", new[] { "UserComponentSummary_ID" });
            DropColumn("dbo.ComponentItems", "UserComponentSummary_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComponentItems", "UserComponentSummary_ID", c => c.Int());
            CreateIndex("dbo.ComponentItems", "UserComponentSummary_ID");
            AddForeignKey("dbo.ComponentItems", "UserComponentSummary_ID", "dbo.UserComponentSummary", "ID");
        }
    }
}
