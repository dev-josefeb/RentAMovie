namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectGenreType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreOld", c => c.String());
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            DropColumn("dbo.Movies", "GenreOld");
        }
    }
}
