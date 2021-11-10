using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        FABSContext _Context;
        public PeopleRepository()
        {
            _Context = new FABSContext();
        }

        public PeopleRepository(FABSContext context)
        {
            _Context = context;
        }

        public Person Get(int id)
        {
            Person foundPerson;
            try
            {
                foundPerson = _Context.People.Find(id);
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
                listPerson = _Context.People;

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
                var res = _Context.Add(p);
                _Context.SaveChanges();
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
                var p = _Context.People.Find(id);
                var res = _Context.Remove(p);
                _Context.SaveChanges();
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
                using (_Context)

                {
                    //Get the context entity form DB so we can change it.
                    var personResultEntity = _Context.People.Find(id);
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

                    _Context.SaveChanges();
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
