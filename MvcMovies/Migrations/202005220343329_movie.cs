namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false),
                        IMDb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rated = c.String(nullable: false, maxLength: 5),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(),
                        Director = c.String(),
                        Production = c.String(),
                        Synopsis = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeadRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.String(),
                        Watched = c.Boolean(nullable: false),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovies", "MovieId", "dbo.Movies");
            DropIndex("dbo.UserMovies", new[] { "MovieId" });
            DropTable("dbo.UserMovies");
            DropTable("dbo.MovieInfoes");
            DropTable("dbo.Movies");
        }
    }
}
