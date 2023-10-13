using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Common.Exceptions;

namespace Timelogger.Data
{
    public static class ExtensionMethods
    {
        public static T FindOrThrow<T>(this DbSet<T> dbset, object id) where T:class
        {
            var entity = dbset.Find(id);
            if (entity == null)
            {
                throw new NotFoundException($"Entity of type {typeof(T).Name} with id {id} does not exist");
            }
            return entity;        
        }

        public static T FirstOrThrow<T>(this IQueryable<T> queryable) where T : class
        {            
            return queryable.FirstOrDefault() ?? throw new NotFoundException($"Entity of type {typeof(T).Name} does not exist");
        }
    }
}
