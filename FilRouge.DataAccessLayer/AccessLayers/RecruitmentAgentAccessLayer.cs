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
        private readonly DbSet<User> users;


        public RecruitmentAgentAccessLayer()
        {
            this.context = new FilRougeContext();
            this.recruitmentAgents = this.context.Set<RecruitmentAgent>();
            this.users = this.context.Set<User>();
        }

        public RecruitmentAgent Get(string login)
        {
            return this.recruitmentAgents.AsQueryable().AsNoTracking()
                .Include(a => a.User)
                //.Include(a => a.Quizz)
                .FirstOrDefault(a => a.Login == login);
        }

        public RecruitmentAgent Get(int id)
        {
            return this.recruitmentAgents.AsQueryable().AsNoTracking()
                .Include(a => a.User)
                //.Include(a => a.Quizz)
                .FirstOrDefault(a => a.Id == id);
        }

        public List<RecruitmentAgent> GetAll()
        {
            return this.recruitmentAgents.AsQueryable().AsNoTracking()
                .Include(a => a.User)
                //.Include(a => a.Quizz)
                .ToList();
        }

        public async Task<bool> AddAsync(RecruitmentAgent agent)
        {
            this.recruitmentAgents.Add(agent);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateAsync(RecruitmentAgent agent)
        {
            var agentToEdit = this.recruitmentAgents.Include(a => a.User).FirstOrDefault(a => a.Id == agent.Id);

            if (agentToEdit == null)
                return false;

            agentToEdit.IsAdmin = agent.IsAdmin;
            agentToEdit.Login = agent.Login;
            agentToEdit.User.FirstName = agent.User.FirstName;
            agentToEdit.User.LastName = agent.User.LastName;
            agentToEdit.User.Email = agent.User.Email;

            if (agent.Password != null)
            {
                agentToEdit.Password = agent.Password;
            }

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var agentToRemove = this.recruitmentAgents.AsQueryable().FirstOrDefault(p => p.Id == id);
            this.recruitmentAgents.Remove(agentToRemove);
            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
    }
}
