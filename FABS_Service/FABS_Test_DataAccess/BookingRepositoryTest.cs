using FABS_API_Service.Controllers;
using FABS_DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using FABS_DataAccess.Repository;
using System.Collections;
using System.Configuration;

namespace FABS_Test_DataAccess
{

    public class BookingRepositoryTest : IDisposable
    {
        //private readonly string _connect = ConfigurationManager.ConnectionStrings["FABS_connectionstring"].ToString();
        ////WIP code for when we start working on Booking
        //// The constroctur is called before every test
        //public BookingRepositoryTest()
        //{
        //    // calls this method to ensure the database filled with data for testing
        //    Seed();
        //}

        public BookingRepositoryTest()
        {
            // calls this method to ensure the database filled with data for testing
            Seed();
        }

        // Populate the database for tests
        private void Seed()
        {
            using (var context = new FABSContext())
            {
                // TODO: never production database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Database Table need to perform test
                List<object[]> data = GetData("Seed").ToList();


                context.AddRange(data[0][0] as Organisation);
                context.SaveChanges();

            }
        }

        public static IEnumerable<object[]> GetData(string nameOfCaller)
        {
            //Create organisation
            Country country1 = new Country("Denmark");
            ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
            Address address = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
            Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address);

            //Create people
            Login login1 = new Login("test1@test.com", "1234");
            Login login2 = new Login("test2@test.com", "1234");
            Person person1 = new Person("Peter", "Hahn", "20202020", false, address, login1);
            Person person2 = new Person("Lars", "Andersen", "29292929", false, 1, login1);
            Person person3 = new Person("Rasmus", "Larsen", "28282828", false, 1, login2);
            
            //Create kayaks
            Warehouse warehouse1 = new Warehouse("Building A", address);
            Location location1 = new Location("1.2.3", "This is an awesome location spot 1", warehouse1, null, organisation1);
            KayakType kayakType1 = new KayakType("Red Kayaks Rule!", 120, 2.5m, 1, null);
            ItemType itemType1 = new ItemType("Kayak", kayakType1);
            Status status1 = new Status("Looking Good", "Item Status");
            Status status2 = new Status("Active", "Booking Status");

            Item item1 = new Item(organisation1, status1, location1, itemType1);
            Item item2 = new Item(organisation1, status1, location1, itemType1);
            Item item3 = new Item(organisation1, status1, location1, itemType1);
            organisation1.Items.Add(item1);
            organisation1.Items.Add(item2);
            organisation1.Items.Add(item3);

            //Create dateTime objects
            DateTime startDateTime1 = new DateTime(2021, 1, 24, 23, 12, 0);
            DateTime endDateTime1 = new DateTime(2021, 1, 25, 1, 0, 0);
            DateTime startDateTime2 = new DateTime(2021, 6, 6, 14, 17, 0);
            DateTime endDateTime2 = new DateTime(2021, 6, 6, 18, 17, 0);
            DateTime startDateTime3 = new DateTime(2021, 7, 7, 5, 47, 0);
            DateTime endDateTime3 = new DateTime(2021, 7, 7, 12, 17, 0);

            //Create bookings
            Booking booking1 = new Booking(startDateTime1, endDateTime1, person1, status2);
            Booking booking2 = new Booking(startDateTime2, endDateTime2, person2, status2);
            Booking booking3 = new Booking(startDateTime3, endDateTime3, person3, status2);
            
            BookingLine line1 = new BookingLine(booking1, item1);

            booking1.BookingLines.Add(line1);
            person1.Bookings.Add(booking1);
            
            OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
            OrganisationPerson organisationPerson2 = new OrganisationPerson(organisation1, person2);
            OrganisationPerson organisationPerson3 = new OrganisationPerson(organisation1, person3);
            organisation1.OrganisationPeople.Add(organisationPerson1);


            //adding test obejcts to list
            var allData = new List<object[]>();
            switch (nameOfCaller)
            {
                case "Seed":
                    allData.Add(new object[] { organisation1 });
                    break;

                case "ReadBooking":
                    allData.Add(new object[] { 1, true });
                    allData.Add(new object[] { 1, true });
                    break;

                case "CreateBooking":
                    allData.Add(new object[] { booking2, true });
                    allData.Add(new object[] { booking3, false });
                    break;
                default:
                    break;
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReadBooking")]
        public void ReadBooking(int id, bool expectedSuccess)
        {
            //throw new NotImplementedException();

            using (var context = new FABSContext())
            {
                var bookingRepository = new BookingRepository();
                Booking booking = bookingRepository.Get(id, 1);

                if (expectedSuccess == true)
                {
                    //Booking
                    Assert.Equal("2021-01-24 23:12:00.000", booking.StartDatetime.ToString());
                    Assert.Equal("2021-01-25 01:00:00.000", booking.EndDatetime.ToString());
                    Assert.Equal("Booking Status", booking.Statuses.Category);
                    Assert.Equal("Active", booking.Statuses.Name);

                    //Booking lines
                    //Item location
                    Assert.Equal("Building A", booking.BookingLines.First().Items.Locations.Warehouses.Name);
                    Assert.Equal("Sofiendalsvej", booking.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetName);
                    Assert.Equal("60", booking.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetNumber);
                    Assert.Null(booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ApartmentNumber);
                    Assert.Equal("9000", booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Danmark", booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Item type
                    Assert.Equal("Red Kayaks Rule!", booking.BookingLines.First().Items.ItemTypes.KayakType.Description);
                    Assert.Equal(120, booking.BookingLines.First().Items.ItemTypes.KayakType.WeightLimit);
                    Assert.Equal(2.5m, booking.BookingLines.First().Items.ItemTypes.KayakType.LengthMeter);
                    Assert.Equal(1, booking.BookingLines.First().Items.ItemTypes.KayakType.PersonCapacity);

                    //Pick location
                    Assert.Equal("1.2.3", booking.BookingLines.First().Items.Locations.PickLocation);
                    Assert.Equal("This is an awesome location spot 1", booking.BookingLines.First().Items.Locations.Description);
                
                    //Person
                    Assert.Equal("Peter", booking.People.FirstName);
                    Assert.Equal("Hahn", booking.People.LastName);
                    Assert.Equal("20202020", booking.People.TelephoneNumber);
                    Assert.False(booking.People.IsAdmin);

                    //login
                    Assert.Equal("test1@test.com", booking.People.Login.Email);
                    Assert.Equal("1234", booking.People.Login.Password);

                    //Person Address
                    Assert.Equal("Sofiendalsvej", booking.People.Addresses.StreetName);
                    Assert.Equal("60", booking.People.Addresses.StreetNumber);
                    Assert.Null(booking.People.Addresses.ApartmentNumber);
                    Assert.Equal("9000", booking.People.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", booking.People.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Organisation
                    Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
                    Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Name);
                }

                else if (expectedSuccess == false)
                {
                    Assert.Null(booking);
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "CreateBooking")]
        public void CreateBooking(Booking booking, bool expectedSuccess)
        {
            BookingRepository bookingRepository = new BookingRepository();

            int returnedId = bookingRepository.Create(booking);
            var result = bookingRepository.Get(returnedId, 1);
            if (expectedSuccess == true && returnedId > 0)
            {
                //Booking
                Assert.Equal(result.StartDatetime.ToString(), booking.StartDatetime.ToString());
                Assert.Equal(result.EndDatetime.ToString(), booking.EndDatetime.ToString());
                Assert.Equal(result.Statuses.Category, booking.Statuses.Category);
                Assert.Equal(result.Statuses.Name, booking.Statuses.Name);

                //Booking lines
                //Item location
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Name, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Name);
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetName, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetName);
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetNumber, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Addresses.StreetNumber);
                Assert.Null(booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ApartmentNumber);
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.City, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.City);
                Assert.Equal(result.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name, 
                    booking.BookingLines.First().Items.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                //Item type
                Assert.Equal(result.BookingLines.First().Items.ItemTypes.KayakType.Description, 
                    booking.BookingLines.First().Items.ItemTypes.KayakType.Description);
                Assert.Equal(result.BookingLines.First().Items.ItemTypes.KayakType.WeightLimit, 
                    booking.BookingLines.First().Items.ItemTypes.KayakType.WeightLimit);
                Assert.Equal(result.BookingLines.First().Items.ItemTypes.KayakType.LengthMeter, 
                    booking.BookingLines.First().Items.ItemTypes.KayakType.LengthMeter);
                Assert.Equal(result.BookingLines.First().Items.ItemTypes.KayakType.PersonCapacity, 
                    booking.BookingLines.First().Items.ItemTypes.KayakType.PersonCapacity);

                //Pick location
                Assert.Equal(result.BookingLines.First().Items.Locations.PickLocation, 
                    booking.BookingLines.First().Items.Locations.PickLocation);
                Assert.Equal(result.BookingLines.First().Items.Locations.Description, 
                    booking.BookingLines.First().Items.Locations.Description);

                //Person
                Assert.Equal(result.People.FirstName, booking.People.FirstName);
                Assert.Equal(result.People.LastName, booking.People.LastName);
                Assert.Equal(result.People.TelephoneNumber, booking.People.TelephoneNumber);
                Assert.False(booking.People.IsAdmin);

                //login
                Assert.Equal(result.People.Login.Email, booking.People.Login.Email);
                Assert.Equal(result.People.Login.Password, booking.People.Login.Password);

                //Person Address
                Assert.Equal(result.People.Addresses.StreetName, booking.People.Addresses.StreetName);
                Assert.Equal(result.People.Addresses.StreetNumber, booking.People.Addresses.StreetNumber);
                Assert.Null(booking.People.Addresses.ApartmentNumber);
                Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Zipcode, 
                    booking.People.Addresses.ZipcodeCountryCity.Zipcode);
                Assert.Equal(result.People.Addresses.ZipcodeCountryCity.City, 
                    booking.People.Addresses.ZipcodeCountryCity.City);
                Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Countries.Name, 
                    booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

            }
            else if (expectedSuccess == false)
            {
                Assert.Equal(-1, returnedId);
            }
            else
            {
                Assert.True(false, "Was supposed to create booking, but failed");
            }

        }

















        //public BookingRepositoryTest()
        //{

        //    //Copied test data from other tests
        //    //Country country1 = new Country("Danmark");
        //    //ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
        //    //Address address1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        //    //Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address1);
        //    //Login login1 = new Login("test1@test.com", "1234");
        //    //Login login2 = new Login("test2@test.com", "1234");

        //    //Person person1 = new Person("Peter", "Hahn", "20202020", false, address1, login1);
        //    //Person person2 = new Person("Lars", "Andersen", "29292929", false, 1, login1);
        //    //Person person3 = new Person("Rasmus", "Larsen", "28282828", false, 1, login2);

        //    //Warehouse warehouse1 = new Warehouse("Building A", address1);
        //    //Location location1 = new Location("1.2.3", "This is an awesome location spot 1", warehouse1, null, organisation1);

        //    //KayakType kayakType1 = new KayakType("Red Kayaks Rule!", 120, 2.5m, 1, null);
        //    //ItemType itemType1 = new ItemType("Kayak", kayakType1);

        //    //Status status1 = new Status("Item Status", "Looking Good");

        //    //Item item1 = new Item(organisation1, status1, location1, itemType1);
        //    //Item item2 = new Item(organisation1, status1, location1, itemType1);
        //    //Item item3 = new Item(organisation1, status1, location1, itemType1);

        //    //Location location2 = new Location("1.2.4", "This is an awesome location spot 2", warehouse1, null, organisation1);
        //    //Location location3 = new Location("1.2.5", "This is an awesome location spot 3", warehouse1, null, organisation1);

        //    Status status1 = new Status("Item Status", "Looking Good");
        //    //Zipcode/Country test objects
        //    Country country1 = new Country("Denmark");
        //    ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
        //    //Organisation test objects
        //    Address organisationAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        //    Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", organisationAddress1);
        //    //Person test objects
        //    Login login1 = new Login("test1@test.com", "1234");
        //    Address personAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        //    Person person1 = new Person("Peter", "Hahn", "20202020", false, personAddress1, login1);
        //}

        ////// Populate the database for tests
        ////private void Seed()
        ////{
        ////    using (var context = new FABSContext())
        ////    {
        ////        // TODO: never production database
        ////        context.Database.EnsureDeleted();
        ////        context.Database.EnsureCreated();

        ////        //Database Table need to perform test
        ////        List<object[]> data = GetData("Seed").ToList();

        ////        //Populate Location related classes
        ////        context.AddRange(
        ////            //Status Classes
        ////            data[0][0] as Status,
        ////            //Organisation Classes
        ////            data[0][0] as Country,
        ////            data[0][0] as ZipcodeCountryCity,
        ////            data[0][0] as Address,
        ////            data[0][0] as Organisation,
        ////            //Person Classes
        ////            data[0][0] as Login,
        ////            data[0][0] as Address,
        ////            data[0][0] as Person,
        ////            data[0][0] as OrganisationPerson,
        ////            data[0][0] as Booking
        ////            );

        ////        context.SaveChanges();
        ////    }
        ////}

        ////public static IEnumerable<object[]> GetData(string nameOfCaller)
        ////{
        ////    //Create Booking test objects
        ////    //Status test objects
        ////    Status status1 = new Status("Item Status", "Looking Good");
        ////    //Zipcode/Country test objects
        ////    Country country1 = new Country("Denmark");
        ////    ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
        ////    //Organisation test objects
        ////    Address organisationAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        ////    Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", organisationAddress1);
        ////    //Person test objects
        ////    Login login1 = new Login("test1@test.com", "1234");
        ////    Address personAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        ////    Person person1 = new Person("Peter", "Hahn", "20202020", false, personAddress1, login1);

        ////    //Booking test objects
        ////    //DateTime - year - month – day – hour – minute - second
        ////    DateTime date1 = new DateTime(2021, 12, 1, 12, 0, 0);
        ////    DateTime date2 = new DateTime(2021, 12, 1, 14, 0, 0);
        ////    DateTime date3 = new DateTime(2021, 12, 1, 14, 0, 0);
        ////    DateTime date4 = new DateTime(2021, 12, 1, 16, 0, 0);
        ////    DateTime date5 = new DateTime(2021, 12, 1, 16, 0, 0);
        ////    DateTime date6 = new DateTime(2021, 12, 1, 18, 0, 0);
        ////    Booking booking1 = new Booking(date1, date2, person1, status1);
        ////    Booking booking2 = new Booking(date3, date4, person1, status1);
        ////    Booking booking3 = new Booking(date5, date6, person1, status1);

        ////    //Join tables test objects
        ////    List<OrganisationPerson> organisationPersonList = new List<OrganisationPerson>();
        ////    OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
        ////    organisationPersonList.Add(organisationPerson1);
        ////    organisation1.OrganisationPeople = organisationPersonList;
        ////    person1.OrganisationPeople = organisationPersonList;

        ////    //adding test objects to list
        ////    var allData.Add(new object[0]);
        ////    switch (nameOfCaller)
        ////    {
        ////        case "Seed":
        ////            allData.Add(new object[]
        ////            {

        ////                //Status Classes
        ////                status1,
        ////                //Organisation Classes
        ////                country1,
        ////                zipcodeCountryCity1,
        ////                organisationAddress1,
        ////                organisation1,
        ////                //Person Classes
        ////                login1,
        ////                personAddress1,
        ////                person1,
        ////                organisationPerson1,
        ////                //Booking Classes
        ////                booking1
        ////            });
        ////            break;

        ////        case "ReadBooking":
        ////            allData.Add(new object[] { 1, true });
        ////            allData.Add(new object[] { 1, false });
        ////            break;

        ////        case "CreateBooking":
        ////            allData.Add(new object[] { booking2, false });
        ////            allData.Add(new object[] { booking3, true });
        ////            break;
        ////        default:
        ////            break;
        ////    }
        ////    return allData;

        ////}

        ////[Theory]
        ////[MemberData(nameof(GetData), parameters: "ReadBooking")]
        ////public void ReadBooking(int id, bool expectedSuccess)
        ////{
        ////    using (var context = new FABSContext())
        ////    {
        ////        var BookingRepository = new BookingRepository();

        ////        Booking booking = BookingRepository.Get(id, 1);

        ////        if (expectedSuccess == true)
        ////        {
        ////            //Person
        ////            Assert.Equal("Peter", booking.People.FirstName);
        ////            Assert.Equal("Hahn", booking.People.LastName);
        ////            Assert.Equal("20202020", booking.People.TelephoneNumber);
        ////            Assert.False(booking.People.IsAdmin);
        ////            //login
        ////            Assert.Equal("test1@test.com", booking.People.Login.Email);
        ////            Assert.Equal("1234", booking.People.Login.Password);
        ////            //Person Address
        ////            Assert.Equal("Sofiendalsvej", booking.People.Addresses.StreetName);
        ////            Assert.Equal("60", booking.People.Addresses.StreetNumber);
        ////            Assert.Null(booking.People.Addresses.ApartmentNumber);
        ////            Assert.Equal("9000", booking.People.Addresses.ZipcodeCountryCity.Zipcode);
        ////            Assert.Equal("Aalborg", booking.People.Addresses.ZipcodeCountryCity.City);
        ////            Assert.Equal("Denmark", booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

        ////            //Organisation
        ////            Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
        ////            Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Name);
        ////        }

        ////        else if (expectedSuccess == false)
        ////        {
        ////            Assert.Null(booking);
        ////        }
        ////    }
        ////}

        ////[Theory]
        ////[MemberData(nameof(GetData), parameters: "CreateBooking")]
        ////public void CreateBooking(Booking booking, bool expectedSuccess)
        ////{
        ////    using (var context = new FABSContext())
        ////    {
        ////        //arrange: some happens in GetData method
        ////        BookingRepository bookingRepository = new BookingRepository();

        ////        //act
        ////        int returnedID = bookingRepository.Create(booking);
        ////        var result = bookingRepository.Get(returnedID, 1);

        ////        //assert
        ////        if (expectedSuccess == true && returnedID > 0)
        ////        {
        ////            //Person
        ////            Assert.Equal(result.People.FirstName, booking.People.FirstName);
        ////            Assert.Equal(result.People.LastName, booking.People.LastName);
        ////            Assert.Equal(result.People.TelephoneNumber, booking.People.TelephoneNumber);
        ////            Assert.Equal(result.People.IsAdmin, booking.People.IsAdmin);
        ////            //login
        ////            Assert.Equal(result.People.Login.Email, booking.People.Login.Email);
        ////            Assert.Equal(result.People.Login.Password, booking.People.Login.Password);
        ////            //Person Address
        ////            Assert.Equal(result.People.Addresses.StreetName, booking.People.Addresses.StreetName);
        ////            Assert.Equal(result.People.Addresses.StreetNumber, booking.People.Addresses.StreetNumber);
        ////            Assert.Equal(result.People.Addresses.ApartmentNumber, booking.People.Addresses.ApartmentNumber);
        ////            Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Zipcode, booking.People.Addresses.ZipcodeCountryCity.Zipcode);
        ////            Assert.Equal(result.People.Addresses.ZipcodeCountryCity.City, booking.People.Addresses.ZipcodeCountryCity.City);
        ////            Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Countries.Name, booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

        ////            if (booking.People.OrganisationPeople.Count > 0)
        ////            {
        ////                Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Cvr, booking.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
        ////                Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Name, booking.People.OrganisationPeople.ToList()[0].Organisations.Name);
        ////            }
        ////        }

        ////        else if (expectedSuccess == false)
        ////        {
        ////            Assert.Equal(-1, returnedID);
        ////        }

        ////        else Assert.True(false, "Was supposed to create Booking, but failed");
        ////    }
        ////}

        public void Dispose()
        {
            RepopulateDatabase.Seed();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}