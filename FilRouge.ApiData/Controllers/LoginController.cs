using FilRouge.DataAccessLayer.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FilRouge.ApiData.Controllers
{
    public class LoginController : Controller
    {
        private readonly RecruitmentAgentAccessLayer recruitmentAgentAccessLayer = new RecruitmentAgentAccessLayer();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Exists([FromBody] string login, string password)
        {
            var usersFound = recruitmentAgentAccessLayer.GetAll();

            var result = usersFound.Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
            if (result != null)
            {
                //return true;
            }

            //return false;

            this.Ok(result);

        }
    }
}