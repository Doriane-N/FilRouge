﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilRouge.DataAccessLayer.Context;
using FilRouge.DataAccessLayer.Models;
using FilRouge.Web.Services;
using FilRouge.Web.Models;

namespace FilRouge.Web.Controllers
{
    public class QuizzController : Controller
    {
        private readonly QuizzService quizservice = new QuizzService();
        private readonly AgentService agentservice = new AgentService();
        private readonly DifficultyLevelService difficultylevel = new DifficultyLevelService();

        // GET: Quizz
        public async Task<ActionResult> Index(/*string sortOrder*/)
        {


            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "GlobalGoodAnswersPercent" : "";
            //ViewBag.DateSortParm = sortOrder == "Lastname" ? "lastname_desc" : "Lastname";
            //var listQuiz = await quizservice.GetAll().ConfigureAwait(false);
            //switch (sortOrder)
            //{
            //    case "GlobalGoodAnswersPercent":
            //        listQuiz = (IList<Quizz>)listQuiz.OrderBy(s => s.Report.GlobalGoodAnswersPercent);
            //        break;
            //    case "Lastname":
            //        listQuiz = (IList<Quizz>)listQuiz.OrderBy(s => s.Candidate.User.LastName);
            //        break;
            //    case "lastname_desc":
            //        listQuiz = (IList<Quizz>)listQuiz.OrderByDescending(s => s.Candidate.User.LastName);
            //        break;
            //    default:
            //        listQuiz = (IList<Quizz>)listQuiz.OrderByDescending(s => s.Report.GlobalGoodAnswersPercent);
            //        break;
            //}
            return View(await quizservice.GetAll());
        }



        //// GET: Quizz/Create
        public async Task<ActionResult> Create()
        {
            var agents = new SelectList(await agentservice.GetAll(), "Id", "User.LastName");
            var levels = new SelectList(await difficultylevel.GetAll(), "Id", "Level");
            var viewmodel = new CreateViewModel
            {
                AvailableAgents = agents,
                AvailableLevels = levels
            };
            return View(viewmodel);
        }

        // POST: Quizz/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateViewModel viewmodel)
        {
            viewmodel.Quizz.StartDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                viewmodel.Quizz.RecruitmentAgent = new RecruitmentAgent { Id = viewmodel.SelectedAgentId };
                viewmodel.Quizz.DifficultyLevel = new DifficultyLevel { Id = viewmodel.SelectedDifficultyId };


                if (await quizservice.Create(viewmodel.Quizz))
                {
                    Content("<script language='javascript' type='text/javascript'>alert('Quiz ajouté');</script>");
                    return RedirectToAction("Index");
                }
            }
            return View(viewmodel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,StartDate,EndDate,QuestionsNb,AnsweredQuestionsNb")] Quizz quizz)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Quizzs.Add(quizz);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Id = new SelectList(db.Reports, "Id", "Id", quizz.Id);
        //    return View(quizz);
        //}

        //// GET: Quizzs/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quizz quizz = await db.Quizzs.FindAsync(id);
        //    if (quizz == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Id = new SelectList(db.Reports, "Id", "Id", quizz.Id);
        //    return View(quizz);
        //}

        //// POST: Quizzs/Edit/5
        //// Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //// plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,StartDate,EndDate,QuestionsNb,AnsweredQuestionsNb")] Quizz quizz)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(quizz).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(db.Reports, "Id", "Id", quizz.Id);
        //    return View(quizz);
        //}

        //// GET: Quizzs/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quizz quizz = await db.Quizzs.FindAsync(id);
        //    if (quizz == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizz);
        //}

        //// POST: Quizzs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Quizz quizz = await db.Quizzs.FindAsync(id);
        //    db.Quizzs.Remove(quizz);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
