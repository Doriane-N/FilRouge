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
        private readonly DbSet<Quizz> report;

        public QuizzAccessLayer()
        {
            this.context = new FilRougeContext();
            this.report = this.context.Set<Quizz>();
        }

        public List<Quizz> GetAll()
        {
            return this.report.AsQueryable().AsNoTracking()
                .Include(a => a.Report)
                .Include(a => a.RecruitmentAgent)
                .Include(a => a.DifficultyLevel)
                .Include(a => a.Candidate)
                .ToList();
        }

    }
}
