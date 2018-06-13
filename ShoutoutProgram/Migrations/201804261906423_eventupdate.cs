namespace ShoutoutProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsTicker", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsTicker");
        }
    }
}
