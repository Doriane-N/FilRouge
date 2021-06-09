using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilRouge.DataAccessLayer.AccessLayers;
using FilRouge.DataAccessLayer.Context;
using FilRouge.DataAccessLayer.Models;

namespace FilRouge.Web.Controllers
{
    public class AgentController : Controller
    {
        private FilRougeContext db = new FilRougeContext();


        private RecruitmentAgentAccessLayer recruitmentAgentAccessLayer = new RecruitmentAgentAccessLayer();
        private UserAccessLayer userAccessLayer = new UserAccessLayer();

        public ActionResult Login()
        {
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RecruitmentAgent agent)
        {
            if (ModelState.IsValid)
            {
                //if Exists API
                var userFound = db.recruitmentAgents.Where(a => a.Login.Equals(agent.Login) && a.Password.Equals(agent.Password)).FirstOrDefault();
                if (userFound != null)
                {
                        Session["ID"] = userFound.Id.ToString();
                        Session["Login"] = userFound.Login.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(agent);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = dbP.Get((int)id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }


        // GET: Agent
        public ActionResult Index()
        {
            return View(db.RecruitmentAgents.ToList());
        }

        // GET: Agent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentAgent recruitmentAgent = db.RecruitmentAgents.Find(id);
            if (recruitmentAgent == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentAgent);
        }

        // GET: Agent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agent/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsAdmin,Login,Password")] RecruitmentAgent recruitmentAgent)
        {
            if (ModelState.IsValid)
            {
                db.RecruitmentAgents.Add(recruitmentAgent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruitmentAgent);
        }

        // GET: Agent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentAgent recruitmentAgent = db.RecruitmentAgents.Find(id);
            if (recruitmentAgent == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentAgent);
        }

        // POST: Agent/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsAdmin,Login,Password")] RecruitmentAgent recruitmentAgent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruitmentAgent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruitmentAgent);
        }

        // GET: Agent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitmentAgent recruitmentAgent = db.RecruitmentAgents.Find(id);
            if (recruitmentAgent == null)
            {
                return HttpNotFound();
            }
            return View(recruitmentAgent);
        }

        // POST: Agent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruitmentAgent recruitmentAgent = db.RecruitmentAgents.Find(id);
            db.RecruitmentAgents.Remove(recruitmentAgent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
