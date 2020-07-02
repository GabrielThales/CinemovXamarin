using Cinemov.Domain.Entities;
using Cinemov.Domain.Interfaces;
using Cinemov.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.Infra.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public CinemovSQLiteContext db;

        protected RepositoryBase(CinemovSQLiteContext db)
        {
            this.db = db;
        }

        public void Delete(T Entity)
        {
            db.Set<T>().Remove(Entity);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T Read(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T Entity)
        {
            db.Set<T>().Update(Entity);
        }

        public void Create(T Entity)
        {
            db.Set<T>().Add(Entity);
        }
    }
}
