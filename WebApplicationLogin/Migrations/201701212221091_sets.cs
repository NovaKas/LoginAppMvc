namespace WebApplicationLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Weight = c.Int(nullable: false),
                        DateGrade = c.DateTime(nullable: false),
                        MySubjectID = c.Int(nullable: false),
                        userID = c.String(maxLength: 128),
                        GradeListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.GradeLists", t => t.GradeListID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.userID)
                .Index(t => t.GradeListID);
            
            CreateTable(
                "dbo.MySubjects",
                c => new
                    {
                        MySubjectID = c.Int(nullable: false, identity: true),
                        userID = c.String(maxLength: 128),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MySubjectID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.userID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MySubjectID = c.Int(nullable: false),
                        SClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.SClasses",
                c => new
                    {
                        SClassID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        userID = c.String(),
                    })
                .PrimaryKey(t => t.SClassID)
                .ForeignKey("dbo.AspNetUsers", t => t.SClassID)
                .Index(t => t.SClassID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        userID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        GoodAnswer = c.String(),
                        BadAnswer = c.String(),
                        Points = c.Int(nullable: false),
                        userID = c.String(maxLength: 128),
                        QuizID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.userID)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizID);
            
            CreateTable(
                "dbo.SClassSubjects",
                c => new
                    {
                        SClass_SClassID = c.String(nullable: false, maxLength: 128),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SClass_SClassID, t.Subject_SubjectID })
                .ForeignKey("dbo.SClasses", t => t.SClass_SClassID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID, cascadeDelete: true)
                .Index(t => t.SClass_SClassID)
                .Index(t => t.Subject_SubjectID);
            
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.News", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.MySubjects", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.MySubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.SClasses", "SClassID", "dbo.AspNetUsers");
            DropForeignKey("dbo.SClassSubjects", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.SClassSubjects", "SClass_SClassID", "dbo.SClasses");
            DropForeignKey("dbo.Grades", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grades", "GradeListID", "dbo.GradeLists");
            DropIndex("dbo.SClassSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.SClassSubjects", new[] { "SClass_SClassID" });
            DropIndex("dbo.Questions", new[] { "QuizID" });
            DropIndex("dbo.Questions", new[] { "userID" });
            DropIndex("dbo.News", new[] { "userID" });
            DropIndex("dbo.SClasses", new[] { "SClassID" });
            DropIndex("dbo.MySubjects", new[] { "SubjectID" });
            DropIndex("dbo.MySubjects", new[] { "userID" });
            DropIndex("dbo.Grades", new[] { "GradeListID" });
            DropIndex("dbo.Grades", new[] { "userID" });
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropTable("dbo.SClassSubjects");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.News");
            DropTable("dbo.SClasses");
            DropTable("dbo.Subjects");
            DropTable("dbo.MySubjects");
            DropTable("dbo.Grades");
        }
    }
}
