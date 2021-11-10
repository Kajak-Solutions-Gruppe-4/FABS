using FABS_API_Service.Controllers;
using FABS_DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace FABS_Test_DataAccess
{
    public class PeopleControllerTest
    {
        // The constroctur is called before every test
        public PeopleControllerTest()
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

                context.AddRange(zip1, add1, asso1, log1, per1);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Can_read_person()
        {
            using (var context = new FABSContext())
            {
                var controller = new PeopleController(context);
                List<Person> persons = controller.Get().Value.ToList();

                Assert.Single(persons);
                Assert.Equal("Peter", persons[0].FirstName);
                Assert.Equal("Hahn", persons[0].LastName);
                Assert.Equal("20202020", persons[0].TelephoneNumber);
                Assert.False(persons[0].IsAdmin);
                Assert.Equal("Sofiendalsvej", persons[0].Adresses.StreetName);
                Assert.Equal("60", persons[0].Adresses.StreetNumber);
                Assert.Null(persons[0].Adresses.ApartmentNumber);
                Assert.Equal("9000", persons[0].Adresses.Zipcode);
                Assert.Equal("Danmark", persons[0].Adresses.Country);
                Assert.Equal("Aalborg", persons[0].Adresses.ZipcodeCountryCity.City);
                Assert.Equal("test@test.com", persons[0].Logins.Email);
                Assert.Equal("1234", persons[0].Logins.Password);
            }
        }
    }
}
