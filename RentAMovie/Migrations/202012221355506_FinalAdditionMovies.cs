namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalAdditionMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Movies",
             c => new
             {
                 Id = c.Int(nullable: false, identity: true),
             })
             .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movies", "GenreType_Name", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "QuantityInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Name");
            DropColumn("dbo.Movies", "QuantityInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "GenreType_Name");
        }
    }
}
