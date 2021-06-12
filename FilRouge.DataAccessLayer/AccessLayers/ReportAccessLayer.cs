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
    public class ReportAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Report> report;

        public ReportAccessLayer()
        {
            this.context = new FilRougeContext();
            this.report = this.context.Set<Report>();
        }

        public List<Report> GetAll()
        {
            return this.report.AsQueryable().AsNoTracking()
                .Include(a => a.Quizz)
                .Include(a => a.GlobalGoodAnswersPercent)
                .Include(a => a.AnswerPercentLevels.Select(m => m.GoodAnswersPercent))
                .ToList();
        }
    }
}
