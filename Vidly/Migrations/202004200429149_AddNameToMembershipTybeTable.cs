namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipTybeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTybes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTybes", "Name");
        }
    }
}
