namespace MovieRentalApp_ASP.NET_MVC_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMembershipTypeNamesInDataBase : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
