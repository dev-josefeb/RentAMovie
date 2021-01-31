namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectGenreType2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreOld");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreOld", c => c.String());
        }
    }
}
