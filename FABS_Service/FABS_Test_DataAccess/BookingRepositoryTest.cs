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

namespace FABS_Test_DataAccess
{

    public class BookingRepositoryTest : IDisposable
    {
        //WIP code for when we start working on Booking
        //// The constroctur is called before every test
        //public BookingRepositoryTest()
        //{
        //    // calls this method to ensure the database filled with data for testing
        //    Seed();
        //}

        //// Populate the database for tests
        //private void Seed()
        //{
        //    using (var context = new FABSContext())
        //    {
        //        // TODO: never production database
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();

        //        //Database Table need to perform test
        //        List<object[]> data = GetData("Seed").ToList();

        //        //Populate Location related classes
        //        context.AddRange(
        //            //Status Classes
        //            data[0][0] as Status,
        //            //Organisation Classes
        //            data[0][0] as Country,
        //            data[0][0] as ZipcodeCountryCity,
        //            data[0][0] as Address,
        //            data[0][0] as Organisation,
        //            //Person Classes
        //            data[0][0] as Login,
        //            data[0][0] as Address,
        //            data[0][0] as Person,
        //            data[0][0] as OrganisationPerson,
        //            data[0][0] as Booking
        //            );

        //        context.SaveChanges();
        //    }
        //}

        //public static IEnumerable<object[]> GetData(string nameOfCaller)
        //{
        //    //Create Booking test objects
        //        //Status test objects
        //    Status status1 = new Status("Item Status", "Looking Good");
        //        //Zipcode/Country test objects
        //    Country country1 = new Country("Denmark");
        //    ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
        //        //Organisation test objects
        //    Address organisationAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        //    Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", organisationAddress1);
        //        //Person test objects
        //    Login login1 = new Login("test1@test.com", "1234");
        //    Address personAddress1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
        //    Person person1 = new Person("Peter", "Hahn", "20202020", false, personAddress1, login1);

        //        //Booking test objects
        //            //DateTime - year - month – day – hour – minute - second
        //    DateTime date1 = new DateTime(2021, 12, 1, 12, 0, 0);
        //    DateTime date2 = new DateTime(2021, 12 ,1 , 14, 0, 0);
        //    DateTime date3 = new DateTime(2021, 12, 1, 14, 0, 0);
        //    DateTime date4 = new DateTime(2021, 12, 1, 16, 0, 0);
        //    DateTime date5 = new DateTime(2021, 12, 1, 16, 0, 0);
        //    DateTime date6 = new DateTime(2021, 12, 1, 18, 0, 0);
        //    Booking booking1 = new Booking(date1, date2, person1, status1);
        //    Booking booking2 = new Booking(date3, date4, person1, status1);
        //    Booking booking3 = new Booking(date5, date6, person1, status1);

        //        //Join tables test objects
        //    List<OrganisationPerson> organisationPersonList = new List<OrganisationPerson>();
        //    OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
        //    organisationPersonList.Add(organisationPerson1);
        //    organisation1.OrganisationPeople = organisationPersonList;
        //    person1.OrganisationPeople = organisationPersonList;

        //    //adding test objects to list
        //    var allData.Add(new object[]);
        //    switch (nameOfCaller)
        //    {
        //        case "Seed":
        //            allData.Add(new object[]
        //            {

        //                //Status Classes
        //                status1,
        //                //Organisation Classes
        //                country1,
        //                zipcodeCountryCity1,
        //                organisationAddress1,
        //                organisation1,
        //                //Person Classes
        //                login1,
        //                personAddress1,
        //                person1,
        //                organisationPerson1,
        //                //Booking Classes
        //                booking1
        //            });
        //            break;

        //        case "ReadBooking":
        //            allData.Add(new object[] { 1, true });
        //            allData.Add(new object[] { 1, false });
        //            break;

        //        case "CreateBooking":
        //            allData.Add(new object[] { booking2, false });
        //            allData.Add(new object[] { booking3, true });
        //            break;
        //        default:
        //            break;
        //    }
        //    return allData;

        //}

        //[Theory]
        //[MemberData(nameof(GetData), parameters: "ReadBooking")]
        //public void ReadBooking(int id, bool expectedSuccess)
        //{
        //    using (var context = new FABSContext())
        //    {
        //        var BookingRepository = new BookingRepository();

        //        Booking booking = BookingRepository.Get(id, 1);

        //        if(expectedSuccess == true)
        //        {
        //            //Person
        //            Assert.Equal("Peter", booking.People.FirstName);
        //            Assert.Equal("Hahn", booking.People.LastName);
        //            Assert.Equal("20202020", booking.People.TelephoneNumber);
        //            Assert.False(booking.People.IsAdmin);
        //            //login
        //            Assert.Equal("test1@test.com", booking.People.Login.Email);
        //            Assert.Equal("1234", booking.People.Login.Password);
        //            //Person Address
        //            Assert.Equal("Sofiendalsvej", booking.People.Addresses.StreetName);
        //            Assert.Equal("60", booking.People.Addresses.StreetNumber);
        //            Assert.Null(booking.People.Addresses.ApartmentNumber);
        //            Assert.Equal("9000", booking.People.Addresses.ZipcodeCountryCity.Zipcode);
        //            Assert.Equal("Aalborg", booking.People.Addresses.ZipcodeCountryCity.City);
        //            Assert.Equal("Denmark", booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

        //            //Organisation
        //            Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
        //            Assert.Equal("12341234", booking.People.OrganisationPeople.ToList()[0].Organisations.Name);
        //        }

        //        else if(expectedSuccess == false)
        //        {
        //            Assert.Null(booking);
        //        }
        //    }
        //}

        //[Theory]
        //[MemberData(nameof(GetData), parameters: "CreateBooking")]
        //public void CreateBooking(Booking booking, bool expectedSuccess)
        //{
        //    using (var context = new FABSContext())
        //    {
        //        //arrange: some happens in GetData method
        //        BookingRepository bookingRepository = new BookingRepository();

        //        //act
        //        int returnedID = locationRepository.Create(booking);
        //        var result = locationRepository.Get(returnedID, 1);

        //        //assert
        //        if (expectedSuccess == true && returnedID > 0)
        //        {
        //            //Person
        //            Assert.Equal(result.booking.People.FirstName, booking.People.FirstName);
        //            Assert.Equal(result.booking.People.LastName, booking.People.LastName);
        //            Assert.Equal(result.booking.People.TelephoneNumber, booking.People.TelephoneNumber);
        //            Assert.Equal(result.booking.People.IsAdmin, booking.People.IsAdmin);
        //            //login
        //            Assert.Equal(result.booking.People.Login.Email, booking.People.Login.Email);
        //            Assert.Equal(result.booking.People.Login.Password, booking.People.Login.Password);
        //            //Person Address
        //            Assert.Equal(result.booking.People.Addresses.StreetName, booking.People.Addresses.StreetName);
        //            Assert.Equal(result.booking.People.Addresses.StreetNumber, booking.People.Addresses.StreetNumber);
        //            Assert.Equal(result.People.Addresses.ApartmentNumber, booking.People.Addresses.ApartmentNumber);
        //            Assert.Equal(result.booking.People.Addresses.ZipcodeCountryCity.Zipcode, booking.People.Addresses.ZipcodeCountryCity.Zipcode);
        //            Assert.Equal(result.booking.People.Addresses.ZipcodeCountryCity.City, booking.People.Addresses.ZipcodeCountryCity.City);
        //            Assert.Equal(result.booking.People.Addresses.ZipcodeCountryCity.Countries.Name, booking.People.Addresses.ZipcodeCountryCity.Countries.Name);

        //            if (booking.People.OrganisationPeople.Count > 0)
        //            {
        //                Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Cvr, booking.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
        //                Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Name, booking.People.OrganisationPeople.ToList()[0].Organisations.Name);
        //            }
        //        }

        //        else if (expectedSuccess == false)
        //        {
        //            Assert.Equal(-1, returnedID);
        //        }

        //        else Assert.True(false, "Was supposed to create Booking, but failed");
        //    }
        //}

        //public void Dispose()
        //{
        //    RepopulateDatabase.Seed();
        //}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}