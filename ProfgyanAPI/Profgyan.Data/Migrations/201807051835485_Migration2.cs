namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "UserIdentity", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "UserIdentity");
        }
    }
}
