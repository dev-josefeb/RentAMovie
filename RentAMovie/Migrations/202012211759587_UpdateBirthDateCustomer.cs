namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateCustomer2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '1955-10-07' WHERE Id =3");
            Sql("UPDATE Customers SET BirthDate = '1985-05-01' WHERE Id =5");
        }
        
        public override void Down()
        {
        }
    }
}
