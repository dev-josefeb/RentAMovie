namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'62598c76-0778-4e25-9c70-407027892661', N'admin@vidly.com', 0, N'AJ4+xW6pl/FQ0vzDX965VRKmBYGemJlAA7WKk70pue6ilyiqWY+pPeI7xAkkhHKjIw==', N'9ee262f4-bf82-4e76-a393-c2dd7770ea19', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa61c619-d5c4-4259-828d-73b29c043326', N'guest@vidly.com', 0, N'AByqYYYjvL/bIssmo8zASukPnrt+8vCJT+PUojuXehV7WS7sUWHeSTV/qC2Dx/noDg==', N'b656dadb-5545-4dde-80de-c2cfa66d4fdd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4b65068e-08d8-4b35-8ad0-bee9e4b11422', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'62598c76-0778-4e25-9c70-407027892661', N'4b65068e-08d8-4b35-8ad0-bee9e4b11422')


");
        }
        
        public override void Down()
        {
        }
    }
}
