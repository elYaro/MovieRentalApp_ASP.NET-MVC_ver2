namespace MovieRentalApp_ASP.NET_MVC_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTableAddedGenresColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
