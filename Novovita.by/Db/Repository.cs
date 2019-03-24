using Microsoft.EntityFrameworkCore;
using Novovita.by.Context;
using Novovita.by.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novovita.by.Db
{
    public class Repository
    {
        public static List<TEntity> Get<TEntity>(Func<TEntity, bool> predicate = null) where TEntity : Base
        {
            return EfGet(predicate).ToList();
        }

        private static List<TEntity> EfGet<TEntity>(Func<TEntity, bool> predicate = null) where TEntity : Base
        {
            var (entities, EfContext) = CreateEfDB<TEntity>();
            var returnValue = predicate == null ? entities.ToList() : entities.Where(predicate).ToList();
            EfContext.Dispose();
            return returnValue;
        }
        private static (DbSet<TEntity> Entities, EfContext EfContext) CreateEfDB<TEntity>() where TEntity : Base
        {
            var context = new EfContext();
            var dbSet = context.Set<TEntity>();
            return (dbSet, context);
        }



    }
}
