namespace TrainingApp.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHourRate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "UserId", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "UserId" });
            AddColumn("dbo.Users", "HourRate", c => c.Int(nullable: false));
            DropTable("dbo.Courses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(maxLength: 50),
                        Grade = c.String(maxLength: 10),
                        IsPassed = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "HourRate");
            CreateIndex("dbo.Courses", "UserId");
            AddForeignKey("dbo.Courses", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
