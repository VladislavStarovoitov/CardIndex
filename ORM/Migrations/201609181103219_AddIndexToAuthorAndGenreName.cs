namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToAuthorAndGenreName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Authors", "Name", unique: true);
            CreateIndex("dbo.Genres", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Authors", new[] { "Name" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
