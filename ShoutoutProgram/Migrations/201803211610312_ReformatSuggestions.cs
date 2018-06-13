namespace ShoutoutProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReformatSuggestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suggestions", "FirstName", c => c.String(maxLength: 30));
            AddColumn("dbo.Suggestions", "LastName", c => c.String(maxLength: 30));
            AddColumn("dbo.Suggestions", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Suggestions", "Name");
            DropColumn("dbo.Suggestions", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suggestions", "PhoneNumber", c => c.String());
            AddColumn("dbo.Suggestions", "Name", c => c.String(maxLength: 30));
            DropColumn("dbo.Suggestions", "DateTime");
            DropColumn("dbo.Suggestions", "LastName");
            DropColumn("dbo.Suggestions", "FirstName");
        }
    }
}
