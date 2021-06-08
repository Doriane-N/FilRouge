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
    public class QuestionAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Question> questions;

        public QuestionAccessLayer()
        {
            this.context = new FilRougeContext();
            this.questions = this.context.Set<Question>();
        }

        public List<Question> GetAll()
        {
            return this.questions.AsQueryable().ToList();
        }

        public Question Get(int id)
        {
            return this.questions.AsQueryable().FirstOrDefault(p => p.Id == id);
        }

        public bool Add(Question question)
        {
            this.questions.Add(question);
            var result = this.context.SaveChanges();

            return result > 0;
        }

        public bool Update(Question question)
        {
            this.context.Entry(question).State = EntityState.Modified;
            var result = this.context.SaveChanges();

            return result > 0;
        }

        public bool Delete(int id)
        {
            var questionToRemove = this.questions.AsQueryable().FirstOrDefault(p => p.Id == id);
            this.questions.Remove(questionToRemove);
            var result = this.context.SaveChanges();

            return result > 0;
        }
    }
}
