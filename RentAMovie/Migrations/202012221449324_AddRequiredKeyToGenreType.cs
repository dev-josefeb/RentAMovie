namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredKeyToGenreType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GenreTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GenreTypes", "Name", c => c.String());
        }
    }
}
