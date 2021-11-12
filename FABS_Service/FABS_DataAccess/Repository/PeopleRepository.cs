﻿using FABS_DataAccess.Model;
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
        FABSContext _Context;
        public PeopleRepository()
        {
            _Context = new FABSContext();
        }

        public PeopleRepository(FABSContext context)
        {
            _Context = context;
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
                // eager loading
                foundPerson = _Context.People
                    .Include(a => a.Adresses)
                    .ThenInclude(z => z.ZipcodeCountryCity)
                    .Include(l => l.Logins)
                    .Include(ap => ap.AssociationPeople)
                    .ThenInclude(a => a.Association)
                    .FirstOrDefault(x => x.Id == id);
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
