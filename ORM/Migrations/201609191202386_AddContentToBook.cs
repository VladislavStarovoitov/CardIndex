namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Cover", c => c.Binary());
            AddColumn("dbo.Books", "CoverMimeType", c => c.String());
            AddColumn("dbo.Books", "Content", c => c.Binary());
            AddColumn("dbo.Books", "ContentMimeType", c => c.String());
            DropColumn("dbo.Books", "Image");
            DropColumn("dbo.Books", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ImageMimeType", c => c.String());
            AddColumn("dbo.Books", "Image", c => c.Binary());
            DropColumn("dbo.Books", "ContentMimeType");
            DropColumn("dbo.Books", "Content");
            DropColumn("dbo.Books", "CoverMimeType");
            DropColumn("dbo.Books", "Cover");
        }
    }
}
