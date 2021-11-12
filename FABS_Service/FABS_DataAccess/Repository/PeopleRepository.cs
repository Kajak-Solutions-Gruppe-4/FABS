using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        public PeopleRepository()
        {
        }

        /// <summary>
        /// Finds person in database via id.
        /// </summary>
        /// <param name="id">The id of the person to find in database.</param>
        /// <returns>Returns the person object or NULL if nothing was found.</returns>
        public Person Get(int id)
        {
            Person foundPerson;
            try
            {
                using (var context = new FABSContext())
                {
                    // eager loading
                    foundPerson = context.People
                    .Include(a => a.Addresses)
                    .ThenInclude(z => z.ZipcodeCountryCity)
                    .Include(l => l.Login)
                    .Include(ap => ap.AssociationPeople)
                    .ThenInclude(a => a.Association)
                    .FirstOrDefault(x => x.Id == id);
                }
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
                using (var context = new FABSContext())
                {
                    listPerson = context.People;
                }

            }
            catch
            {
                listPerson = null;
            }
            return listPerson;
        }

        /// <summary>
        /// Creates a person in the database.
        /// </summary>
        /// <param name="p">The person objcet</param>
        /// <returns>The ID if the person added to the database. Returns -1 if the person could not be added.</returns>
        public int Create(Person p)
        {
            int insertedId;
            try
            {
                using (var context = new FABSContext())
                {
                    var res = context.People.Add(p);
                    context.SaveChanges();
                    insertedId = res.Entity.Id;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int id)
        {
            bool wasDeleted = false;

            try
            {
                using (var context = new FABSContext())
                {
                    var p = context.People.Find(id);
                    var res = context.Remove(p);
                    context.SaveChanges();
                    wasDeleted = true;
                }
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
                using (var context = new FABSContext())
                {
                    //Get the context entity form DB so we can change it.
                    var personResultEntity = context.People.Find(id);
                    //Update the context entity with the date recieved from the update object
                    personResultEntity.FirstName = p.FirstName;
                    personResultEntity.LastName = p.LastName;
                    personResultEntity.TelephoneNumber = p.TelephoneNumber;
                    personResultEntity.AdressesId = p.AdressesId;
                    personResultEntity.LoginsId = p.LoginsId;
                    personResultEntity.IsAdmin = p.IsAdmin;
                    personResultEntity.Addresses = p.Addresses;
                    personResultEntity.Login = p.Login;
                    personResultEntity.AssociationPeople = p.AssociationPeople;
                    personResultEntity.Bookings = p.Bookings;
                    personResultEntity.Locations = p.Locations;

                    context.SaveChanges();
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
