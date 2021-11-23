using System;
using System.Collections.Generic;
using System.Text;
using FABS_DataAccess.Model;

namespace FABS_DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(int organisationId);
        T Get(PrimaryKey pk, int organisationId);
        int Create(T t);
        PrimaryKey FindPrimaryKey(T t);
        
        // out of scope, regarding lack of time to implement
        bool Update(PrimaryKey pk, T t);
        bool Delete(PrimaryKey pk);
    }
}
