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
    public class DifficultyLevelAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<DifficultyLevel> difficultyLevel;

        public DifficultyLevelAccessLayer()
        {
            this.context = new FilRougeContext();
            this.difficultyLevel = this.context.Set<DifficultyLevel>();
        }

        public List<DifficultyLevel> GetAll()
        {
            return this.difficultyLevel.AsQueryable().ToList();
        }

        public DifficultyLevel Get(int id)
        {
            return this.difficultyLevel.AsQueryable().FirstOrDefault(p => p.Id == id);
        }

        public bool Add(DifficultyLevel difficultyLevel)
        {
            this.difficultyLevel.Add(difficultyLevel);
            var result = this.context.SaveChanges();

            return result > 0;
        }

        public bool Update(DifficultyLevel difficultyLevel)
        {
            this.context.Entry(difficultyLevel).State = EntityState.Modified;
            var result = this.context.SaveChanges();

            return result > 0;
        }

        public bool Delete(int id)
        {
            var difficultyLevelToRemove = this.difficultyLevel.AsQueryable().FirstOrDefault(p => p.Id == id);
            this.difficultyLevel.Remove(difficultyLevelToRemove);
            var result = this.context.SaveChanges();

            return result > 0;
        }
    }
}
