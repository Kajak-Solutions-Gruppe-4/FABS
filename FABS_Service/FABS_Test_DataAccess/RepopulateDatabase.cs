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

                ItemType itemType1 = new ItemType("Kayak - A for Awesome");
                ItemType itemType2 = new ItemType("Kayak - B for Best");
                KayakType kayakType1 = new KayakType("Floats on water", 100, 5.1m, 1, itemType1);
                KayakType kayakType2 = new KayakType("Floats on water", 80, 4.95m, 1, itemType2);
                itemType1.KayakType = kayakType1; // letting itemType know kayak has come to existence, so entity framework 
                                                  // can find kayakType through itemType.
                itemType2.KayakType = kayakType2;

                Status status1 = new Status("Ready for use", "Item");
                Status status2 = new Status("Not ready for use", "Item");
                Status status3 = new Status("In use", "Item");

                Item item1 = new Item(organisation1, itemType1);
                Item item2 = new Item(organisation1, itemType1);
                Item item3 = new Item(organisation1, itemType2);
                Item item4 = new Item(organisation1, itemType2);
                Item item5 = new Item(organisation1, itemType2);
                item1.Statuses = status1;
                item2.Statuses = status2;
                item4.Statuses = status3;

                Location location1 = new Location("Plads 1", organisation1);
                Location location2 = new Location("Plads 2", organisation1);

                item3.Locations = location1;

                Address address2 = new Address("Sofiendalsvej", "65", null, zipcodeCountryCity1);
                Warehouse warehouse1 = new Warehouse("Lager 1", address2);

                location1.Warehouses = warehouse1;

                Login login1 = new Login("test1@test.com", "1234");
                Login login2 = new Login("test2@test.com", "1234");
                Login login3 = new Login("test3@test.com", "1234");

                Person person1 = new Person("Peter", "Hahn", "20202020", false, address1, login1);
                Person person2 = new Person("Lars", "Andersen", "29292929", false, address1, login2);
                Person person3 = new Person("Rasmus", "Larsen", "28282828", false, address1, login3);

                Status status4 = new Status("Bekræftet", "Booking");
                Booking booking1 = new Booking(new DateTime(2021, 11, 19, 13, 0, 0), new DateTime(2021, 11, 19, 16, 0, 0), person1, status4);
                BookingLine bookingLine1 = new BookingLine(booking1, item4);
                booking1.BookingLines.Add(bookingLine1);
                person1.Bookings.Add(booking1); // adding booking to person, so organisation1 can see the booking through him.

                // adding the missing pieces to organisation, so entity framework can create everything from this object.
                OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
                OrganisationPerson organisationPerson2 = new OrganisationPerson(organisation1, person2);
                OrganisationPerson organisationPerson3 = new OrganisationPerson(organisation1, person3);
                organisation1.OrganisationPeople.Add(organisationPerson1);
                organisation1.OrganisationPeople.Add(organisationPerson2);
                organisation1.OrganisationPeople.Add(organisationPerson3);
                organisation1.Items.Add(item1);
                organisation1.Items.Add(item2);
                organisation1.Items.Add(item3);
                organisation1.Items.Add(item4);
                organisation1.Items.Add(item5);
                organisation1.Locations.Add(location1);
                organisation1.Locations.Add(location2);

                //You only need to add one element, as long as it's connected with all other elements
                context.Add(organisation1);
                context.SaveChanges();
            }
        }
    }
}
