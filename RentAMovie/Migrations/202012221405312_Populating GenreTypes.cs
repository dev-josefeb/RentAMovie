namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Drama')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (6, 'Thriller')");
        }

        public override void Down()
        {
        }
    }
}
