namespace ShoutoutProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShoutoutModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shoutouts", "SelectedRecipient", c => c.String(nullable: false));
            DropColumn("dbo.Shoutouts", "Recipient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoutouts", "Recipient", c => c.String(nullable: false));
            DropColumn("dbo.Shoutouts", "SelectedRecipient");
        }
    }
}
