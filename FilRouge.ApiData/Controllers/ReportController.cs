using FilRouge.ApiData.Models;
using FilRouge.DataAccessLayer.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FilRouge.ApiData.Controllers
{
    public class ReportController : ApiController
    {
        private readonly ReportAccessLayer reportAccessLayer = new ReportAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = reportAccessLayer.GetAll().Select(p => new Report
            {
                Id = p.Id,
                Quizz = new Quizz
                {
                    Id = p.Quizz.Id,
                    StartDate = p.Quizz.StartDate,
                    EndDate = p.Quizz.EndDate,
                    QuestionsNb = p.Quizz.QuestionsNb,
                    DifficultyLevel = new DifficultyLevel
                    {
                        Id = p.Quizz.DifficultyLevel.Id,
                        Level = p.Quizz.DifficultyLevel.Level
                    },
                    RecruitmentAgent = new RecruitmentAgent
                    {
                        Id = p.Quizz.RecruitmentAgent.Id,
                        User = new User
                        {
                            Id = p.Quizz.RecruitmentAgent.User.Id,
                            LastName = p.Quizz.RecruitmentAgent.User.LastName,
                            FirstName = p.Quizz.RecruitmentAgent.User.FirstName,
                        }
                    },
                    Candidate = new Candidate
                    {
                        Id = p.Quizz.Candidate.Id,
                        User = new User
                        {
                            Id = p.Quizz.Candidate.User.Id,
                            LastName = p.Quizz.Candidate.User.LastName,
                            FirstName = p.Quizz.Candidate.User.FirstName,
                        }
                    }
                }
            });

            return this.Ok(result);
        }
    }
}