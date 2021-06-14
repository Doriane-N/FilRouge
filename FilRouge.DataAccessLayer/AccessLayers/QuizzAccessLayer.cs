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
    public class QuizzAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<Quizz> quizzs;

        public QuizzAccessLayer()
        {
            this.context = new FilRougeContext();
            this.quizzs = this.context.Set<Quizz>();
        }

        public List<Quizz> GetAll()
        {
            return this.quizzs.AsQueryable().AsNoTracking()
                .Include(q => q.Questions)
                .Include(q => q.Answers)
                //.Include(q => q.Report)
                //.Include(q => q.IngredientPizzas.Select(ip => ip.Ingredient))
                .ToList();
        }

        public Quizz Get(string id)
        {
            return this.quizzs.AsQueryable().AsNoTracking()
                 //.Include(q => q.Dough)
                 //.Include(q => q.IngredientPizzas)
                 //.Include(q => q.IngredientPizzas.Select(ip => ip.Ingredient))
                 .FirstOrDefault(q => q.Id == id);
        }

    }
}
