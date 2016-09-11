namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationDateToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "CreationDate");
        }
    }
}
