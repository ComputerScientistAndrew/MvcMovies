namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMovies", "MovieInfo_Id", c => c.Int());
            CreateIndex("dbo.UserMovies", "MovieInfo_Id");
            AddForeignKey("dbo.UserMovies", "MovieInfo_Id", "dbo.MovieInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovies", "MovieInfo_Id", "dbo.MovieInfoes");
            DropIndex("dbo.UserMovies", new[] { "MovieInfo_Id" });
            DropColumn("dbo.UserMovies", "MovieInfo_Id");
        }
    }
}
