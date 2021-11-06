namespace TrainingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmmendGradeColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Grade", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Grade", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
