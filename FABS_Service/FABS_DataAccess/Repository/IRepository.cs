using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Create(T t);
        bool Update(int id, T t);
        bool Delete(int id);
    }
}
