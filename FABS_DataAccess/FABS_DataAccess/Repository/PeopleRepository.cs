using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        private FABSContext _dbAccess = new FABSContext();
        
        public int Create(Person entity)
        {
            
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            //SKRIV TEST!!! SKRIV FOR FANDEN!
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            var p = _dbAccess.People.Find(id);
            return p;
        }

        public IEnumerable<Person> GetAll()
        {
            //SKRIV TEST!!! SKRIV FOR FANDEN!

            throw new NotImplementedException();
        }

        public bool Update(Person entity)
        {
            //SKRIV TEST!!! SKRIV FOR FANDEN!

            throw new NotImplementedException();
        }
    }
}
