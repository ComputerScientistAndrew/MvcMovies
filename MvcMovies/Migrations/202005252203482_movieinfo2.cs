namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieinfo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieInfoes", "Budget", c => c.Int(nullable: false));
            AddColumn("dbo.MovieInfoes", "OpeningWeekend", c => c.Int(nullable: false));
            AddColumn("dbo.MovieInfoes", "GrossUSA", c => c.Int(nullable: false));
            AddColumn("dbo.MovieInfoes", "GrossWorld", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieInfoes", "GrossWorld");
            DropColumn("dbo.MovieInfoes", "GrossUSA");
            DropColumn("dbo.MovieInfoes", "OpeningWeekend");
            DropColumn("dbo.MovieInfoes", "Budget");
        }
    }
}
