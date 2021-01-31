namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreType_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreType_Name");
        }
    }
}
