using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T entity);
        bool Update(T entity);
        bool Delete(int id);

    }
}
