namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _long : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieInfoes", "GrossWorld", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieInfoes", "GrossWorld");
        }
    }
}
