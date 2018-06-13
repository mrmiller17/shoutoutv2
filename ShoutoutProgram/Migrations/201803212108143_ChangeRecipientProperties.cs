namespace ShoutoutProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRecipientProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shoutouts", "RecipientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shoutouts", "RecipientId");
            AddForeignKey("dbo.Shoutouts", "RecipientId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Shoutouts", "Recipient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoutouts", "Recipient", c => c.String(nullable: false));
            DropForeignKey("dbo.Shoutouts", "RecipientId", "dbo.AspNetUsers");
            DropIndex("dbo.Shoutouts", new[] { "RecipientId" });
            DropColumn("dbo.Shoutouts", "RecipientId");
        }
    }
}
