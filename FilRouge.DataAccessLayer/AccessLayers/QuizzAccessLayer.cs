using FilRouge.DataAccessLayer.Context;
using FilRouge.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.AccessLayers
{
    public class QuizzAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Quizz> quizzSet;

        public QuizzAccessLayer()
        {
            this.context = new FilRougeContext();
            this.quizzSet = this.context.Set<Quizz>();
        }

        public List<Quizz> GetAll()
        {
            return this.quizzSet.AsQueryable().AsNoTracking()
                .Include(a => a.Report)
                .Include(a => a.Report.AnswerPercentLevels)
                .Include(a => a.RecruitmentAgent)
                .Include(a => a.RecruitmentAgent.User)
                .Include(a => a.DifficultyLevel)
                .Include(a => a.Candidate)
                .Include(a => a.Candidate.User)
                
                .ToList();
        }
        public async Task<bool> AddAsync(Quizz quizz)
        {
            this.quizzSet.Add(quizz);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

    }
}
