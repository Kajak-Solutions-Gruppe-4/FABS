using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(int organisationId);
        T Get(int id, int organisationId);
        int Create(T t);
        
        // out of scope, regarding lack of time to implement
        bool Update(int id, T t);
        bool Delete(int id);
    }
}
