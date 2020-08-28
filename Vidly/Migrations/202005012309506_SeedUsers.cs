namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8716aba1-6c30-4356-8dc0-b5fbbc91db07', N'guest@vidly.com', 0, N'AOS7/Y0QZc9zhztgfdm2YDoekOu3nULdrQWxYp3dvdCief7bFfa+yfsDAlz6UoGT1A==', N'2995b29f-5ef4-4aaa-af03-30aebf11937a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd17bdd95-3489-4fc8-952e-5e4c726ccfc0', N'admin@vidly.com', 0, N'AF2wlZNjtpwzGr/4zDYKMEi1C+2bGgtdT5/OYYhnWDP9zClxHC+CUWZaWPR4iJb/LA==', N'dbdc6bb6-fe5e-46c4-b0f2-5b14336e36cf', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf8236b2-64c0-42f4-a6c0-9d1db549e0b3', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd17bdd95-3489-4fc8-952e-5e4c726ccfc0', N'bf8236b2-64c0-42f4-a6c0-9d1db549e0b3')

             ");
        }
        
        public override void Down()
        {
        }
    }
}
