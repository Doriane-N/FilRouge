namespace FilRouge.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerPercentLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodAnswersPercent = c.Int(nullable: false),
                        DifficultyLevel_Id = c.Int(),
                        Report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DifficultyLevels", t => t.DifficultyLevel_Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.DifficultyLevel_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.DifficultyLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DifficultyLevel_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DifficultyLevels", t => t.DifficultyLevel_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.DifficultyLevel_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 1000),
                        AnswersNb = c.Int(nullable: false),
                        GoodAnswersNb = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        DifficultyLevel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DifficultyLevels", t => t.DifficultyLevel_Id)
                .Index(t => t.DifficultyLevel_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 1000),
                        IsGood = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        QuestionsNb = c.Int(nullable: false),
                        AnsweredQuestionsNb = c.Int(nullable: false),
                        Candidate_Id = c.Int(),
                        DifficultyLevel_Id = c.Int(),
                        RecruitmentAgent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.DifficultyLevels", t => t.DifficultyLevel_Id)
                .ForeignKey("dbo.RecruitmentAgents", t => t.RecruitmentAgent_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.DifficultyLevel_Id)
                .Index(t => t.RecruitmentAgent_Id);
            
            CreateTable(
                "dbo.RecruitmentAgents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAdmin = c.Boolean(nullable: false),
                        Login = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GlobalGoodAnswersPercent = c.Int(nullable: false),
                        Quizz_Id = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_Id)
                .Index(t => t.Quizz_Id);
            
            CreateTable(
                "dbo.QuizzAnswers",
                c => new
                    {
                        Quizz_Id = c.String(nullable: false, maxLength: 10),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quizz_Id, t.Answer_Id })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .Index(t => t.Quizz_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        Quizz_Id = c.String(nullable: false, maxLength: 10),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quizz_Id, t.Question_Id })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Quizz_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs");
            DropForeignKey("dbo.AnswerPercentLevels", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Questions", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.RecruitmentAgents", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Quizzs", "RecruitmentAgent_Id", "dbo.RecruitmentAgents");
            DropForeignKey("dbo.QuizzQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Quizz_Id", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Quizzs", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.QuizzAnswers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.QuizzAnswers", "Quizz_Id", "dbo.Quizzs");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Candidates", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Candidates", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.AnswerPercentLevels", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropIndex("dbo.QuizzQuestions", new[] { "Question_Id" });
            DropIndex("dbo.QuizzQuestions", new[] { "Quizz_Id" });
            DropIndex("dbo.QuizzAnswers", new[] { "Answer_Id" });
            DropIndex("dbo.QuizzAnswers", new[] { "Quizz_Id" });
            DropIndex("dbo.Reports", new[] { "Quizz_Id" });
            DropIndex("dbo.RecruitmentAgents", new[] { "User_Id" });
            DropIndex("dbo.Quizzs", new[] { "RecruitmentAgent_Id" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyLevel_Id" });
            DropIndex("dbo.Quizzs", new[] { "Candidate_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "DifficultyLevel_Id" });
            DropIndex("dbo.Candidates", new[] { "User_Id" });
            DropIndex("dbo.Candidates", new[] { "DifficultyLevel_Id" });
            DropIndex("dbo.AnswerPercentLevels", new[] { "Report_Id" });
            DropIndex("dbo.AnswerPercentLevels", new[] { "DifficultyLevel_Id" });
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.QuizzAnswers");
            DropTable("dbo.Reports");
            DropTable("dbo.RecruitmentAgents");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Users");
            DropTable("dbo.Candidates");
            DropTable("dbo.DifficultyLevels");
            DropTable("dbo.AnswerPercentLevels");
        }
    }
}
