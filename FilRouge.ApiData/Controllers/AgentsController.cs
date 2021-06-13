using FilRouge.DataAccessLayer.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilRouge.ApiData.Controllers

{
    using FilRouge.DataAccessLayer.Models;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class AgentsController : ApiController
    {
        private readonly RecruitmentAgentAccessLayer recruitmentAgentAccessLayer = new RecruitmentAgentAccessLayer();
        private readonly UserAccessLayer userAccessLayer = new UserAccessLayer();


        // GET api/agent
        [HttpGet]
        public IHttpActionResult Get(string login)
        {
            var usersFound = recruitmentAgentAccessLayer.GetAll();

            var result = usersFound.Where(u => u.Login.Equals(login)).FirstOrDefault();

            return this.Ok(result);
        }

        // GET api/agent
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var usersFound = recruitmentAgentAccessLayer.GetAll();

            var result = usersFound.Where(u => u.Id.Equals(id)).FirstOrDefault();

            return this.Ok(result);
        }

        // GET api/agents
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = recruitmentAgentAccessLayer.GetAll().Select(a => new RecruitmentAgent
            {
                Id = a.Id,
                Login = a.Login,
                Password = a.Password,
                IsAdmin = a.IsAdmin,
                User = new User { Id = a.User.Id, FirstName = a.User.FirstName, LastName = a.User.LastName, Email = a.User.Email }
            });

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] RecruitmentAgent agent)
        {
            var foundAgent = recruitmentAgentAccessLayer.Get(agent.Login);
            if(foundAgent != null)
            {
                return this.Conflict();
            }

            var agentToAdd = new DataAccessLayer.Models.RecruitmentAgent
            {
                IsAdmin = agent.IsAdmin,
                Login = agent.Login,
                Password = agent.Password,
                User = new User { 
                    FirstName = agent.User.FirstName,
                    LastName = agent.User.LastName,
                    Email = agent.User.Email
                },
            };

            await recruitmentAgentAccessLayer.AddAsync(agentToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] RecruitmentAgent agent)
        {
            //Autre agent a déjà ce login ?
            var foundAgent = recruitmentAgentAccessLayer.Get(agent.Login);
            if (foundAgent != null && foundAgent.Id != id)
            {
                return this.Conflict();
            }

            var agentToUpdate = new DataAccessLayer.Models.RecruitmentAgent
            {
                Id = agent.Id,
                IsAdmin = agent.IsAdmin,
                Login = agent.Login,
                User = new User
                {
                    FirstName = agent.User.FirstName,
                    LastName = agent.User.LastName,
                    Email = agent.User.Email
                },
            };

            await recruitmentAgentAccessLayer.UpdateAsync(agentToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var agentToDelete = recruitmentAgentAccessLayer.Get(id);

            if (agentToDelete == null)
            {
                return this.NotFound();
            }

            await recruitmentAgentAccessLayer.DeleteAsync(id);
            await userAccessLayer.DeleteAsync(agentToDelete.User.Id);
            return this.Ok("Delete");
        }
    }
}