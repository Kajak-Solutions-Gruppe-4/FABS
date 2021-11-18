using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;

namespace FABS_Test_DataAccess
{
    public class RepopulateDatabase
    {
        public static void Seed()
        {
            using (var context = new FABSContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Country country1 = new Country("Danmark");
                ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
                Address address1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
                Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address1);
                Login login1 = new Login("test1@test.com", "1234");
                Login login2 = new Login("test2@test.com", "1234");
                Login login3 = new Login("test3@test.com", "1234");

                Person person1 = new Person("Peter", "Hahn", "20202020", false, 1, login1);
                Person person2 = new Person("Lars", "Andersen", "29292929", false, 1, login2);
                Person person3 = new Person("Rasmus", "Larsen", "28282828", false, 1, login3);

                List<OrganisationPerson> organisationPersonList = new List<OrganisationPerson>();
                OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
                OrganisationPerson organisationPerson2 = new OrganisationPerson(organisation1, person2);
                OrganisationPerson organisationPerson3 = new OrganisationPerson(organisation1, person3);
                organisationPersonList.Add(organisationPerson1);
                organisationPersonList.Add(organisationPerson2);
                organisationPersonList.Add(organisationPerson3);
                organisation1.OrganisationPeople = organisationPersonList;
                person1.OrganisationPeople.Add(organisationPerson1);
                person2.OrganisationPeople.Add(organisationPerson2);
                person3.OrganisationPeople.Add(organisationPerson3);

                context.AddRange(country1,
                                 zipcodeCountryCity1,
                                 address1);
                context.SaveChanges();
                // Saves address first, and it suddenly works.
                // Don't know why it's needed here and not other places
                context.AddRange(organisation1,
                                 login1,
                                 login2,
                                 login3,
                                 person1,
                                 person2,
                                 person3);
                context.SaveChanges();
            }
        }
    }
}
