using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        FABSContext _FABSContext;
        public PeopleRepository(IConfiguration configuration)
        {
            _FABSContext = new FABSContext(configuration);
        }


        public Person Get(int id)
        {
            Person foundPerson;
            try
            {
                foundPerson = _FABSContext.People.Find(id);
            }
            catch
            {
                foundPerson = null;
            }

            return foundPerson;
        }

        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> listPerson;
            try
            {
                listPerson = _FABSContext.People;

            }
            catch
            {
                listPerson = null;
            }
            return listPerson;
        }
        public int Create(Person p)
        {
            int insertedId;
            try
            {
                var res = _FABSContext.Add(p);
                _FABSContext.SaveChanges();
                insertedId = res.Entity.Id;
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int id)
        {
            bool wasDeleted = false;

            try
            {
                var p = _FABSContext.People.Find(id);
                var res = _FABSContext.Remove(p);
                _FABSContext.SaveChanges();
                wasDeleted = true;
            }
            catch
            {
                wasDeleted = false;
            }

            return wasDeleted;
        }
        public bool Update(int id, Person p)
        {
            //throw new NotImplementedException();
            //TO DO: Get update to work in EF

            bool wasUpdated;

            try
            {
                using (_FABSContext)

                {
                    //Get the context entity form DB so we can change it.
                    var personResultEntity = _FABSContext.People.Find(id);
                    //Update the context entity with the date recieved from the update object
                    personResultEntity.FirstName = p.FirstName;
                    personResultEntity.LastName = p.LastName;
                    personResultEntity.TelephoneNumber = p.TelephoneNumber;
                    personResultEntity.AdressesId = p.AdressesId;
                    personResultEntity.LoginsId = p.LoginsId;
                    personResultEntity.IsAdmin = p.IsAdmin;
                    personResultEntity.Adresses = p.Adresses;
                    personResultEntity.Logins = p.Logins;
                    personResultEntity.AssociationPeople = p.AssociationPeople;
                    personResultEntity.Bookings = p.Bookings;
                    personResultEntity.Locations = p.Locations;

                    _FABSContext.SaveChanges();
                }

                wasUpdated = true;
            }
            catch
            {
                wasUpdated = false;
            }

            return wasUpdated;

        }
    }
}
