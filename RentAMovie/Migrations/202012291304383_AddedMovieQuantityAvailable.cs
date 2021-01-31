namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMovieQuantityAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "QuantityAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "QuantityAvailable");
        }
    }
}
