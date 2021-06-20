using FilRouge.ApiData.Models;
using FilRouge.DataAccessLayer.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace FilRouge.ApiData.Controllers
{
    public class QuizzController : ApiController
    {
        private readonly QuizzAccessLayer quizzAccessLayer = new QuizzAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = quizzAccessLayer.GetAll().Select(p => new Quizz
            {
                Id = p.Id,
                StartDate = p.StartDate,
                EndDate = p.EndDate,             
                Report = new Report
                {
                    Id = p.Report.Id,
                    GlobalGoodAnswersPercent = p.Report.GlobalGoodAnswersPercent,
                    AnswerPercentLevels = p.Report.AnswerPercentLevels.Select(x => new AnswerPercentLevel
                    {
                        Id = x.Id,
                        GoodAnswersPercent = x.GoodAnswersPercent
                    }).ToList(),                                      
                },
                RecruitmentAgent = new RecruitmentAgent
                {
                    Id = p.RecruitmentAgent.Id,

                    User = new User
                    {
                        Id = p.RecruitmentAgent.User.Id,
                        LastName = p.RecruitmentAgent.User.LastName,
                        FirstName = p.RecruitmentAgent.User.FirstName,
                    }
                },
                DifficultyLevel = new DifficultyLevel
                {
                    Id = p.DifficultyLevel.Id,
                    Level = p.DifficultyLevel.Level
                },
                Candidate = new Candidate
                {
                    Id = p.Candidate.Id,
                    User = new User
                    {
                        Id = p.Candidate.User.Id,
                        LastName = p.Candidate.User.LastName,
                        FirstName = p.Candidate.User.FirstName,
                    }
                }
            });

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Quizz quizz)
        {
            var quizzToAdd = new DataAccessLayer.Models.Quizz
            {
                StartDate = quizz.StartDate,
                QuestionsNb = quizz.QuestionsNb,               
                DifficultyLevel = new DataAccessLayer.Models.DifficultyLevel
                {
                    Level = quizz.DifficultyLevel.Level
                },
                RecruitmentAgent = new DataAccessLayer.Models.RecruitmentAgent
                {
                    User = new DataAccessLayer.Models.User
                    {
                        LastName = quizz.RecruitmentAgent.User.LastName
                    }
                },
                AnsweredQuestionsNb = 0,
                Candidate = new DataAccessLayer.Models.Candidate
                {
                    User = new DataAccessLayer.Models.User
                    {
                        LastName = quizz.Candidate.User.LastName,
                        FirstName = quizz.Candidate.User.FirstName
                    }
                }
            };

            await quizzAccessLayer.AddAsync(quizzToAdd);
            return this.Ok("created");
        }
    }
}