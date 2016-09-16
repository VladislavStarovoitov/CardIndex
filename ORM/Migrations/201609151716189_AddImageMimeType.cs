namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageMimeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImageMimeType");
        }
    }
}
