namespace WebApplicationLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class app_users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradeLists", "GradeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GradeLists", "GradeID");
        }
    }
}
