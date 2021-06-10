using FilRouge.DataAccessLayer.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilRouge.ApiData.Controllers

{
    using System.Web.Http;

    public class AgentController : ApiController
    {
        private readonly RecruitmentAgentAccessLayer recruitmentAgentAccessLayer = new RecruitmentAgentAccessLayer();

        // GET api/agent
        [HttpGet]
        public IHttpActionResult Get(string login, string psw)
        {
            var usersFound = recruitmentAgentAccessLayer.GetAll();

            var result = usersFound.Where(u => u.Login.Equals(login) && u.Password.Equals(psw)).FirstOrDefault();
  
            return this.Ok(result);

        }

  
    }
}