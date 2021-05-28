namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'635f9966-e486-4968-b569-2bcd8e0dbb44', N'admin@vidly.com', 0, N'ALjbdeLeJpwptyzgR6/StyJTvc3MkzP9pvsmN0cr9e8caV/xpWcGR0aq6vSn/Jxajg==', N'20350f9c-e363-45e4-9e42-e50ef0ba3dab', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'78a0218b-2081-4687-a5cb-3b09ccfe3238', N'guest@vidly.com', 0, N'AB25eXbxtS5h36sNDMohePRv4EBXfVDRBDFAVjJKE9qCIMBN0UFPtt6YfA9WKA71vw==', N'da9ccbd3-aebc-4f38-a53b-12b41cfecb65', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'70481664-2be1-4699-8db9-3dda1fbf1678', N'CanManageMovies')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'635f9966-e486-4968-b569-2bcd8e0dbb44', N'70481664-2be1-4699-8db9-3dda1fbf1678')");
        }
        
        public override void Down()
        {
        }
    }
}
