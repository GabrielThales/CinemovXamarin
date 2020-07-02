using Cinemov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Cinemov.Domain.Interfaces
{
    public interface IRepository<T>  where T : EntityBase
    {
        void Create(T Entity);
        void SaveChanges();
        IEnumerable<T>GetAll();
        void Update(T Entity);
        void Delete(T Entity);
        T Read(Guid id);

    }
}
