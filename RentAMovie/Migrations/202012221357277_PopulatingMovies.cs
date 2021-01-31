namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreType_Name, ReleaseDate, DateAdded, QuantityInStock) VALUES ('Hangover' , 'Comedy', '2009-11-06','2020-12-21','5')");
            Sql("INSERT INTO Movies (Name, GenreType_Name, ReleaseDate, DateAdded, QuantityInStock) VALUES ('Die Hard' , 'Action', '1988-12-05','2020-11-1','2')");
            Sql("INSERT INTO Movies (Name, GenreType_Name, ReleaseDate, DateAdded, QuantityInStock) VALUES ('The Terminator' , 'Action', '1995-10-16','2020-10-10','1')");
            Sql("INSERT INTO Movies (Name, GenreType_Name, ReleaseDate, DateAdded, QuantityInStock) VALUES ('Toy Story' , 'Family', '2000-05-01','2020-12-11','6')");
            Sql("INSERT INTO Movies (Name, GenreType_Name, ReleaseDate, DateAdded, QuantityInStock) VALUES ('Titanic' , 'Romance', '1992-11-15','2020-12-21','22')");
        }
        
        public override void Down()
        {
        }
    }
}
