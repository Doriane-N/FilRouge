namespace FilRouge.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerPercentLevels", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.AnswerPercentLevels", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Candidates", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Questions", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Quizzs", "DifficultyLevel_Id", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Quizzs", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Quizzs", "RecruitmentAgent_Id", "dbo.RecruitmentAgents");
            DropForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs");
            DropIndex("dbo.AnswerPercentLevels", new[] { "Report_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Quizzs", new[] { "Candidate_Id" });
            DropIndex("dbo.Quizzs", new[] { "RecruitmentAgent_Id" });
            DropIndex("dbo.Reports", new[] { "Quizz_Id" });
            AddColumn("dbo.AnswerPercentLevels", "DifficultyLevel_Id1", c => c.Int());
            AddColumn("dbo.Candidates", "DifficultyLevel_Id1", c => c.Int());
            AddColumn("dbo.Questions", "DifficultyLevel_Id1", c => c.Int());
            AddColumn("dbo.Quizzs", "DifficultyLevel_Id1", c => c.Int());
            AlterColumn("dbo.AnswerPercentLevels", "Report_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DifficultyLevels", "Level", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Answers", "Text", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Answers", "Question_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Quizzs", "Candidate_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Quizzs", "RecruitmentAgent_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.RecruitmentAgents", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.RecruitmentAgents", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reports", "Quizz_Id", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.AnswerPercentLevels", "DifficultyLevel_Id1");
            CreateIndex("dbo.AnswerPercentLevels", "Report_Id");
            CreateIndex("dbo.Candidates", "DifficultyLevel_Id1");
            CreateIndex("dbo.Questions", "DifficultyLevel_Id1");
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Quizzs", "Candidate_Id");
            CreateIndex("dbo.Quizzs", "RecruitmentAgent_Id");
            CreateIndex("dbo.Quizzs", "DifficultyLevel_Id1");
            CreateIndex("dbo.RecruitmentAgents", "Login", unique: true);
            CreateIndex("dbo.Reports", "Quizz_Id");
            AddForeignKey("dbo.AnswerPercentLevels", "DifficultyLevel_Id1", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.AnswerPercentLevels", "Report_Id", "dbo.Reports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "DifficultyLevel_Id1", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.Questions", "DifficultyLevel_Id1", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.Quizzs", "DifficultyLevel_Id1", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quizzs", "Candidate_Id", "dbo.Candidates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quizzs", "RecruitmentAgent_Id", "dbo.RecruitmentAgents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "RecruitmentAgent_Id", "dbo.RecruitmentAgents");
            DropForeignKey("dbo.Quizzs", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Quizzs", "DifficultyLevel_Id1", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Questions", "DifficultyLevel_Id1", "dbo.DifficultyLevels");
            DropForeignKey("dbo.Candidates", "DifficultyLevel_Id1", "dbo.DifficultyLevels");
            DropForeignKey("dbo.AnswerPercentLevels", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.AnswerPercentLevels", "DifficultyLevel_Id1", "dbo.DifficultyLevels");
            DropIndex("dbo.Reports", new[] { "Quizz_Id" });
            DropIndex("dbo.RecruitmentAgents", new[] { "Login" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyLevel_Id1" });
            DropIndex("dbo.Quizzs", new[] { "RecruitmentAgent_Id" });
            DropIndex("dbo.Quizzs", new[] { "Candidate_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "DifficultyLevel_Id1" });
            DropIndex("dbo.Candidates", new[] { "DifficultyLevel_Id1" });
            DropIndex("dbo.AnswerPercentLevels", new[] { "Report_Id" });
            DropIndex("dbo.AnswerPercentLevels", new[] { "DifficultyLevel_Id1" });
            AlterColumn("dbo.Reports", "Quizz_Id", c => c.String(maxLength: 10));
            AlterColumn("dbo.RecruitmentAgents", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.RecruitmentAgents", "Login", c => c.String(maxLength: 50));
            AlterColumn("dbo.Quizzs", "RecruitmentAgent_Id", c => c.Int());
            AlterColumn("dbo.Quizzs", "Candidate_Id", c => c.Int());
            AlterColumn("dbo.Answers", "Question_Id", c => c.Int());
            AlterColumn("dbo.Answers", "Text", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Questions", "Text", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.DifficultyLevels", "Level", c => c.String(maxLength: 50));
            AlterColumn("dbo.AnswerPercentLevels", "Report_Id", c => c.Int());
            DropColumn("dbo.Quizzs", "DifficultyLevel_Id1");
            DropColumn("dbo.Questions", "DifficultyLevel_Id1");
            DropColumn("dbo.Candidates", "DifficultyLevel_Id1");
            DropColumn("dbo.AnswerPercentLevels", "DifficultyLevel_Id1");
            CreateIndex("dbo.Reports", "Quizz_Id");
            CreateIndex("dbo.Quizzs", "RecruitmentAgent_Id");
            CreateIndex("dbo.Quizzs", "Candidate_Id");
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.AnswerPercentLevels", "Report_Id");
            AddForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs", "Id");
            AddForeignKey("dbo.Quizzs", "RecruitmentAgent_Id", "dbo.RecruitmentAgents", "Id");
            AddForeignKey("dbo.Quizzs", "Candidate_Id", "dbo.Candidates", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Quizzs", "DifficultyLevel_Id", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.Questions", "DifficultyLevel_Id", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.Candidates", "DifficultyLevel_Id", "dbo.DifficultyLevels", "Id");
            AddForeignKey("dbo.AnswerPercentLevels", "Report_Id", "dbo.Reports", "Id");
            AddForeignKey("dbo.AnswerPercentLevels", "DifficultyLevel_Id", "dbo.DifficultyLevels", "Id");
        }
    }
}
