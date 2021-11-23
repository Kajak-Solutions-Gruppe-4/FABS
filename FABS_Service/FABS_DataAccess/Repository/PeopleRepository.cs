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
        private readonly FABSContext _context;

        public PeopleRepository()
        {
            _context = new FABSContext();
        }


        /// <summary>
        /// Finds person in database via id.
        /// </summary>
        /// <param name="id">The id of the person to find in database.</param>
        /// <returns>Returns the person object or NULL if nothing was found.</returns>
        public Person Get(PrimaryKey pk, int organisationId)
        {
            Person foundPerson;
            try
            {
                    int id = GetPrimaryKeyValue(pk);
                    // eager loading
                    foundPerson = _context.People
                    .Include(a => a.Addresses)
                    .ThenInclude(z => z.ZipcodeCountryCity)
                    .ThenInclude(c => c.Countries)
                    .Include(l => l.Login)
                    .Include(op => op.OrganisationPeople)
                    .ThenInclude(a => a.Organisations)
                    .FirstOrDefault(x => x.Id == id);
                
            }
            catch
            {
                foundPerson = null;
            }

            return foundPerson;
        }


        public IEnumerable<Person> GetAll(int organisationId)
        {
            IEnumerable<Person> listPerson;
           
            try
            {

                listPerson = _context.People
                .Where(p => p.OrganisationPeople.Any(op => op.OrganisationsId == organisationId))
                .Include(a => a.Addresses)
                .ThenInclude(z => z.ZipcodeCountryCity)
                .ThenInclude(c => c.Countries)
                .Include(l => l.Login)
                .Include(op => op.OrganisationPeople)
                .ThenInclude(a => a.Organisations);


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
                
                    var res = _context.People.Add(p);
                    _context.SaveChanges();
                    insertedId = res.Entity.Id;
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(PrimaryKey pk)
        {
            bool wasDeleted = false;

            try
            {
                int id = GetPrimaryKeyValue(pk);
                var p = _context.People.Find(id);
                var res = _context.Remove(p);
                _context.SaveChanges();
                wasDeleted = true;
                
            }
            catch
            {
                wasDeleted = false;
            }

            return wasDeleted;
        }
        public bool Update(PrimaryKey pk, Person p)
        {
            //throw new NotImplementedException();
            //TO DO: Get update to work in EF

            bool wasUpdated;

            try
            {
                int id = GetPrimaryKeyValue(pk);
                //Get the context entity form DB so we can change it.
                var personResultEntity = _context.People.Find(id);
                //Update the context entity with the date recieved from the update object
                    //Person
                personResultEntity.FirstName = p.FirstName;
                personResultEntity.LastName = p.LastName;
                personResultEntity.TelephoneNumber = p.TelephoneNumber;
                personResultEntity.AddressesId = p.AddressesId;
                personResultEntity.IsAdmin = p.IsAdmin;
                personResultEntity.Addresses = p.Addresses;
                personResultEntity.Login = p.Login;
                    //Other
                personResultEntity.OrganisationPeople = p.OrganisationPeople;
                personResultEntity.Bookings = p.Bookings;
                personResultEntity.Locations = p.Locations;

                _context.SaveChanges();
                

                wasUpdated = true;
            }
            catch
            {
                wasUpdated = false;
            }

            return wasUpdated;

        }

        private int GetPrimaryKeyValue(PrimaryKey pk) => (int) pk.KeyValues.First();

        public PrimaryKey FindPrimaryKey(Person t)
        {
            throw new NotImplementedException();
        }
    }
}
