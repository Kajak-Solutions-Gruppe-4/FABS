using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.DataAccess
{
    public class PersonRepository : IRepository<Person>
    {
        private FABSContext _context = new FABSContext();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            var p = _context.People.Find(id);
            return p;

        }

        public IEnumerable<Person> GetAll()
        {
            var p = _context.People;
            return p;
        }

        public bool Insert(Person entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
