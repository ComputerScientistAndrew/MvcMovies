namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieinfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieInfoes", "TrailerURL", c => c.String());
            AddColumn("dbo.MovieInfoes", "Movie_ID", c => c.Int());
            CreateIndex("dbo.MovieInfoes", "Movie_ID");
            AddForeignKey("dbo.MovieInfoes", "Movie_ID", "dbo.Movies", "ID");
            DropColumn("dbo.MovieInfoes", "IMDb");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieInfoes", "IMDb", c => c.Double(nullable: false));
            DropForeignKey("dbo.MovieInfoes", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.MovieInfoes", new[] { "Movie_ID" });
            DropColumn("dbo.MovieInfoes", "Movie_ID");
            DropColumn("dbo.MovieInfoes", "TrailerURL");
        }
    }
}
