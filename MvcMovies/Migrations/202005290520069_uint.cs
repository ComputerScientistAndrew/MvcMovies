namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _uint : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieInfoes", "GrossWorld");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieInfoes", "GrossWorld", c => c.Int());
        }
    }
}
