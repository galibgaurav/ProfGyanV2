namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommonDetails", "HighestQualification", c => c.String(maxLength: 50));
            DropColumn("dbo.CommonDetails", "ComDetailId");
            DropColumn("dbo.Trainers", "TrDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "TrDetailId", c => c.String(maxLength: 128));
            AddColumn("dbo.CommonDetails", "ComDetailId", c => c.String(maxLength: 128));
            DropColumn("dbo.CommonDetails", "HighestQualification");
        }
    }
}
