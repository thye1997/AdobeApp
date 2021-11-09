namespace TrainingApp.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmmendTaskStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskStatus", c => c.Int(nullable: false));
        }
    }
}
