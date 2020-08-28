namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateNameColumnForMembershiptypeTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTybes SET Name = 'Annual' WHERE id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
