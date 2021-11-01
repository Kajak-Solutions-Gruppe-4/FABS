using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.DataAccess
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
