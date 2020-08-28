namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTybe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTybes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTybeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTybeId");
            AddForeignKey("dbo.Customers", "MembershipTybeId", "dbo.MembershipTybes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTybeId", "dbo.MembershipTybes");
            DropIndex("dbo.Customers", new[] { "MembershipTybeId" });
            DropColumn("dbo.Customers", "MembershipTybeId");
            DropTable("dbo.MembershipTybes");
        }
    }
}
