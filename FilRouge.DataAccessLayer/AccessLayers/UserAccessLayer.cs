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
    public class UserAccessLayer
    {
        private readonly FilRougeContext context;
        private readonly DbSet<User> users;

        public UserAccessLayer()
        {
            this.context = new FilRougeContext();
            this.users = this.context.Set<User>();
        }


        public bool Add(User user)
        {
            this.users.Add(user);
            var result = this.context.SaveChanges();

            return result > 0;
        }


    }
}
