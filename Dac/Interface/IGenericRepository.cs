using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IGenericRepository<T> where T:class
    {
        IDbConnection conn { get; set; }
        int Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(T entity);
    }
}
