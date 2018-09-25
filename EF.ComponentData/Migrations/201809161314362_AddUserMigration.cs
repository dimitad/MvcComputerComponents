namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserComponentSummary",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ComponentItems", "UserComponentSummary_ID", c => c.Int());
            CreateIndex("dbo.ComponentItems", "UserComponentSummary_ID");
            AddForeignKey("dbo.ComponentItems", "UserComponentSummary_ID", "dbo.UserComponentSummary", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComponentItems", "UserComponentSummary_ID", "dbo.UserComponentSummary");
            DropIndex("dbo.ComponentItems", new[] { "UserComponentSummary_ID" });
            DropColumn("dbo.ComponentItems", "UserComponentSummary_ID");
            DropTable("dbo.UserComponentSummary");
        }
    }
}
