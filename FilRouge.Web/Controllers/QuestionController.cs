using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilRouge.DataAccessLayer.Context;
using FilRouge.DataAccessLayer.Models;

namespace FilRouge.Web.Controllers
{
    public class QuestionController : Controller
    {

        //// GET: Question
        //public ActionResult Index()
        //{
        //    return View(db.Questions.ToList());
        //}

        //// GET: Question/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}

        // GET: Question/Create
        public ActionResult Create()
        {
            List<Answer> answers = new List<Answer>();


            return View();
        }

        //// POST: Question/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Text,AnswersNb,GoodAnswersNb,Type")] Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Questions.Add(question);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(question);
        //}

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (Request.Form["addAnswer"] != null)
            {
                question.Answers.Add(new Answer
                {
                    Id = question.Answers.Count + 1,
                    Text = ""
                });
            }
            else if (Request.Form["rmAnswer"] != null)
            {
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    ModelState.Remove("Answers[" + i + "].Text");
                    ModelState.Remove("Answers[" + i + "].IsGood");
                }
                int index = int.Parse(Request.Form["rmAnswer"]);
                Answer answerToRemove = question.Answers.ToList()[index];
                question.Answers.Remove(answerToRemove);
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Champs requis 1");
                    ModelState.AddModelError("", "Champs requis 2");

                }
            }

            return View(question);
        }

        //// GET: Question/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}

        //// POST: Question/Edit/5
        //// Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //// plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Text,AnswersNb,GoodAnswersNb,Type")] Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(question).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(question);
        //}

        //// GET: Question/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}

        //// POST: Question/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Question question = db.Questions.Find(id);
        //    db.Questions.Remove(question);
        //    db.SaveChanges();
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
