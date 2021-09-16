namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movie1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "IMDb", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "IMDb", c => c.Double(nullable: false));
        }
    }
}
