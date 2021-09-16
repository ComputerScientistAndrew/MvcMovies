namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieinfo3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieInfoes", "Budget", c => c.Int());
            AlterColumn("dbo.MovieInfoes", "OpeningWeekend", c => c.Int());
            AlterColumn("dbo.MovieInfoes", "GrossUSA", c => c.Int());
            AlterColumn("dbo.MovieInfoes", "GrossWorld", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieInfoes", "GrossWorld", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieInfoes", "GrossUSA", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieInfoes", "OpeningWeekend", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieInfoes", "Budget", c => c.Int(nullable: false));
        }
    }
}
