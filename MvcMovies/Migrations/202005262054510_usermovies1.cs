namespace MvcMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermovies1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserMovies", "Watched");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserMovies", "Watched", c => c.Boolean(nullable: false));
        }
    }
}
