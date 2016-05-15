using Infrastructure.Db;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Generic query method
        /// </summary>
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }


        /// <summary>
        /// Add new entity
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            this.SaveChanges();
        }


        /// <summary>
        /// Update an existing entity
        /// </summary>
        public void Update<T>(T entityToUpdate) where T : class
        {
            _db.Set<T>().Update(entityToUpdate);
            this.SaveChanges();
        }


        /// <summary>
        /// Delete an existing entity
        /// </summary>
        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }


        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _db.Set<T>().FromSql(sql, parameters);
        }


        /// <summary>
        /// Save changes to the database
        /// </summary>
        public void SaveChanges()
        {
            _db.SaveChanges();
        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }


    /// <summary>
    /// This class promotes the Include() method from the entity framework so it
    /// can be used at a higher layer. You might not want to reference in the Entity Framework
    /// in your presentation layer.
    /// </summary>
    //public static class GenericRepositoryExtensions
    //{
    //    public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable, Expression<Func<T, TProperty>> relatedEntity) where T : class
    //    {
    //        return Microsoft.Data.Entity.EntityFrameworkQueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
    //    }
    //}

    public interface IGenericRepository
    {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(T entityToDelete) where T : class;
        void Dispose();
        IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
        IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        void Update<T>(T entityToUpdate) where T : class;
    }

}