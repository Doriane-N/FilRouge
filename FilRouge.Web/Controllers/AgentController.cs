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

        //Méthode de connexion, création du "Session"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(RecruitmentAgent agent)
        {
            var foundAgent = await agentService.Get(agent.Login, agent.Password);

            if (foundAgent != null)
            {
                Session["Login"] = $"{foundAgent.User.FirstName.ToString()} {foundAgent.User.LastName.ToString()}";
                if (foundAgent.IsAdmin)
                {
                    Session["Admin"] = true;
                }

                return RedirectToAction("Index" , "Home");

            }

            ModelState.AddModelError("", "Tentative de connexion non valide.");

            return View(agent);
        }

        //Méthode de déconnexion
        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session["Admin"] = null;

            return RedirectToAction("Login", "Agent");
        }
    }
}
