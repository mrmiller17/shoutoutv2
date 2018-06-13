namespace ShoutoutProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class work : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "IsTicker");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "IsTicker", c => c.Boolean(nullable: false, defaultValue: false));
        }
    }
}
