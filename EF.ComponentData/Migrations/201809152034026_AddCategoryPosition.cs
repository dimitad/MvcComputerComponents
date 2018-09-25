namespace EF.ComponentData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComponentCategory", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComponentCategory", "Position");
        }
    }
}
