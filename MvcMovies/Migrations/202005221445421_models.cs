namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "IMDb", c => c.Double(nullable: false));
            AlterColumn("dbo.MovieInfoes", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieInfoes", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Movies", "IMDb", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
