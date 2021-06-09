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
    public class RecruitmentAgentAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<RecruitmentAgent> recruitmentAgents;

        public RecruitmentAgentAccessLayer()
        {
            this.context = new FilRougeContext();
            this.recruitmentAgents = this.context.Set<RecruitmentAgent>();
        }

        public RecruitmentAgent Get(string login)
        {
            return this.recruitmentAgents.AsQueryable().AsNoTracking()
                .Include(a => a.User)
                //.Include(a => a.Quizz)
                .FirstOrDefault(a => a.Login == login);
        }

        public List<RecruitmentAgent> GetAll()
        {
            return this.recruitmentAgents.AsQueryable().AsNoTracking()
                .Include(a => a.User)
                //.Include(a => a.Quizz)
                .ToList();
        }


    }
}
