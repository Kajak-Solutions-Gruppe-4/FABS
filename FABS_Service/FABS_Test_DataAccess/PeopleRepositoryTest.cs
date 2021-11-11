using FABS_API_Service.Controllers;
using FABS_DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using FABS_DataAccess.Repository;

namespace FABS_Test_DataAccess
{
    public class PeopleRepositoryTest
    {
        // The constroctur is called before every test
        public PeopleRepositoryTest()
        {
            // calls this method to ensure the database filled with data for testing
            Seed();
        }

        private void Seed()
        {
            using (var context = new FABSContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                ZipcodeCountryCity zip1 = new ZipcodeCountryCity("9000", "Danmark", "Aalborg");
                Address add1 = new Address("Sofiendalsvej", "60", null, zip1);
                Association asso1 = new Association("12341234", "UCN Kajakker", add1);
                Login log1 = new Login("test@test.com", "1234");
                Person per1 = new Person("Peter", "Hahn", "20202020", false, add1, log1);
                List<AssociationPerson> assoPer = new List<AssociationPerson>();
                AssociationPerson assoPer1 = new AssociationPerson(asso1, per1);
                assoPer.Add(assoPer1);
                asso1.AssociationPeople = assoPer;
                per1.AssociationPeople = assoPer;

                context.AddRange(zip1, add1, asso1, log1, per1, assoPer1);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Can_read_person()
        {
            using (var context = new FABSContext())
            {
                var peopleRepository = new PeopleRepository();

                Person person = peopleRepository.Get(1);

                Assert.Equal("Peter", person.FirstName);
                Assert.Equal("Hahn", person.LastName);
                Assert.Equal("20202020", person.TelephoneNumber);
                Assert.False(person.IsAdmin);
                Assert.Equal("Sofiendalsvej", person.Adresses.StreetName);
                Assert.Equal("60", person.Adresses.StreetNumber);
                Assert.Null(person.Adresses.ApartmentNumber);
                Assert.Equal("9000", person.Adresses.Zipcode);
                Assert.Equal("Danmark", person.Adresses.Country);
                Assert.Equal("Aalborg", person.Adresses.ZipcodeCountryCity.City);
                Assert.Equal("test@test.com", person.Logins.Email);
                Assert.Equal("1234", person.Logins.Password);
                Assert.Equal("12341234", person.AssociationPeople.ToList()[0].Association.Cvr);
                Assert.Equal("UCN Kajakker", person.AssociationPeople.ToList()[0].Association.Name);
                
            }
        }
    }
}
