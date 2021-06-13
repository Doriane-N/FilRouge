using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
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

        public bool alreadyExist { get; set; }

        public ActionResult Login()
        {
            return View();
        }

        //Méthode de connexion, création du "Session"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(RecruitmentAgent agent)
        {
            var foundAgent = await agentService.Get(agent.Login);

            if (foundAgent != null && Crypto.VerifyHashedPassword(foundAgent.Password, agent.Password)) 
            {
                Session["Login"] = foundAgent.Login.ToString();
                Session["Id"] = foundAgent.Id.ToString();
                Session["Name"] = $"{foundAgent.User.FirstName.ToString()} {foundAgent.User.LastName.ToString()}";
                if (foundAgent.IsAdmin)
                {
                    Session["Admin"] = "admin";
                }

                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Tentative de connexion non valide.");

            return View(agent);
        }

        //Méthode de déconnexion
        public ActionResult Logout()
        {
            Session["Name"] = null;
            Session["Login"] = null;
            Session["Id"] = null;
            Session["Admin"] = null;

            return RedirectToAction("Login", "Agent");
        }


        // GET: Agents // Affiche la liste des agents de recrutement
        public async Task<ActionResult> Manage()
        {
            return await AuthenticationController.GetInstance().AuthenticationAdminAsync(
                async () =>
                {
                    var list = await agentService.GetAll();
                    return View(list);
                }
            );
        }

        // GET: Agents/Create
        public async Task<ActionResult> Create()
        {
            return await AuthenticationController.GetInstance().AuthenticationAdminAsync(
                async () =>
                {
                    return View();
                }
            );
        }

        // POST: Agents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RecruitmentAgent agent)
        {
            if (ModelState.IsValid)
            {
                var hash = Crypto.HashPassword(agent.Password);
                agent.Password = hash;

                HttpResponseMessage response = await agentService.Create(agent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Manage");
                } else
                {
                    if (response.StatusCode.Equals(HttpStatusCode.Conflict))
                    {
                        ModelState.AddModelError(nameof(RecruitmentAgent.Login), "Login existe déjà");
                    }
                    else
                    {
                        ModelState.AddModelError("", "L'ajout n'a pas été effectué");
                    }
                }

            }
            return View(agent);
        }

        // GET: Agents/Edit/{id}
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var agent = await agentService.Get((int) id);
            if (agent == null)
            {
                return HttpNotFound();
            }

            return View(agent);
        }

        // POST: Agents/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RecruitmentAgent agent)
        {
            HttpResponseMessage response = await agentService.Update(agent.Id, agent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Manage");
            }
            else
            {
                if (response.StatusCode.Equals(HttpStatusCode.Conflict))
                {
                    ModelState.AddModelError(nameof(RecruitmentAgent.Login), "Login existe déjà");
                }
                else
                {
                    ModelState.AddModelError("", "La modification n'a pas été effectuée");
                }
            }

            return View(agent);
        }

        // GET: Agents/EditPassword
        public async Task<ActionResult> EditPassword()
        {
            var agent = await agentService.Get(Int32.Parse(Session["Id"].ToString()));
            if (agent == null)
            {
                return HttpNotFound();
            }

            return View(agent);
        }

        //Méthode de modification du mot de passe accessible par l'agent
        // POST: Agents/EditPassword
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditPassword()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HttpResponseMessage response = await agentService.Update(agent);

        //        if (response.StatusCode.Equals(HttpStatusCode.Conflict))
        //        {
        //            ModelState.AddModelError(nameof(RecruitmentAgent.Login), "Login existe déjà");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "L'ajout n'a pas été effectué");
        //        }

        //    }

        //    return View(agent);
        //}

        // GET: Agents/Delete/{id}
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var agent = await agentService.Get((int) id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await agentService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Manage");
        }
    }
}
