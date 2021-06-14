namespace FilRouge.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportPropertyToQuizz : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs");
            AddForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs");
            AddForeignKey("dbo.Reports", "Quizz_Id", "dbo.Quizzs", "Id", cascadeDelete: true);
        }
    }
}
