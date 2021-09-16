namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieInfoes", "IMDb", c => c.Double(nullable: false));
            DropColumn("dbo.MovieInfoes", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieInfoes", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.MovieInfoes", "IMDb");
        }
    }
}
