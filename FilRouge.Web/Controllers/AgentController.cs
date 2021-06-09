using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FilRouge.DataAccessLayer.AccessLayers;
using FilRouge.DataAccessLayer.Context;
using FilRouge.DataAccessLayer.Models;
using FilRouge.Web.Services;

namespace FilRouge.Web.Controllers
{
    public class AgentController : Controller
    {
        private readonly AgentService agentService = new AgentService();

        public ActionResult Login()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(RecruitmentAgent agent)
        {
            var foundAgent = await agentService.Get(agent.Login);

            if (foundAgent != null && foundAgent.Password.Equals(agent.Password))
            {
                Session["Login"] = foundAgent.Login.ToString();
                Session["isAdmin"] = foundAgent.IsAdmin;
                return RedirectToAction("Index" , "Home");

            }

            // TODO to disconnect Session["Login"] = null
            // TODO to disconnect Session["isAdmin"] = null

            return View(agent);
        }

    }
}
