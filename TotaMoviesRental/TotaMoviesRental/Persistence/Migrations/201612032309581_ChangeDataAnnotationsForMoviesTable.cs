namespace TotaMoviesRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataAnnotationsForMoviesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "YoutubeTrailerUrl", c => c.String(maxLength: 400));
            AlterColumn("dbo.Movies", "PosterImageUrl", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "PosterImageUrl", c => c.String());
            AlterColumn("dbo.Movies", "YoutubeTrailerUrl", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}
