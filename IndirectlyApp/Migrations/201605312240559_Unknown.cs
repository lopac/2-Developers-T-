namespace IndirectlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unknown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DateTimeCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Mosaics", "DateTimeCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mosaics", "DateTimeCreated");
            DropColumn("dbo.Comments", "DateTimeCreated");
        }
    }
}
