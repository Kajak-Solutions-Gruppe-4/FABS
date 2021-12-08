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
    public class LocationRepositoryTest : IDisposable
    {
        // The constroctur is called before every test
        public LocationRepositoryTest()
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
            //Create Location test objects
            //Zipcode/Country test objects
            Country country1 = new Country("Denmark");
            ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
            //Organisation test objects
            Address address1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
            Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address1);
            //Person test objects
            Login login1 = new Login("test1@test.com", "1234");
            Login login2 = new Login("test2@test.com", "1234");

            Person person1 = new Person("Peter", "Hahn", "20202020", false, address1, login1);

            OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
            //organisation1.OrganisationPeople.Add(organisationPerson1);


            //Warehouse test objects
            Address warehouseAddress1 = new Address("Sofiendalsvej", "60A", null, zipcodeCountryCity1);
            Warehouse warehouse1 = new Warehouse("Building A", warehouseAddress1);
            //Location test objects
            Location location1 = new Location("1.2.3", "This is an awesome location spot 1", warehouse1, null, organisation1);
            Location location2 = new Location("1.2.4", "This is an awesome location spot 2", warehouse1, null, organisation1);
            Location location3 = new Location("1.2.5", "This is an awesome location spot 3", warehouse1, null, organisation1);

            organisation1.Locations.Add(location1);

            //adding test obejcts to list
            var allData = new List<object[]>();
            switch (nameOfCaller)
            {
                case "Seed":
                    allData.Add(new object[] { organisation1 });
                    break;

                case "ReadLocation":
                    allData.Add(new object[] { 1, true });
                    allData.Add(new object[] { 1, true });
                    break;

                case "CreateLocation":
                    allData.Add(new object[] { location2, true });
                    allData.Add(new object[] { location3, false });
                    break;
                default:
                    break;
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReadLocation")]
        public void ReadLocation(int id, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                var locationRepository = new LocationRepository("Local");

                Location location = locationRepository.Get(id, 1);

                if (expectedSuccess == true)
                {
                    //Location
                    Assert.Equal("1.2.3", location.PickLocation);
                    Assert.Equal("This is an awesome location spot 1", location.Description);

                    //Warehouse
                    Assert.Equal("Building A", location.Warehouses.Name);
                    //Warehouse Address
                    Assert.Equal("Sofiendalsvej", location.Warehouses.Addresses.StreetName);
                    Assert.Equal("60A", location.Warehouses.Addresses.StreetNumber);
                    Assert.Null(location.Warehouses.Addresses.ApartmentNumber);
                    Assert.Equal("9000", location.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", location.Warehouses.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", location.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                    //// See comment at line 187
                    ////Person
                    //Assert.Equal("Peter", location.People.FirstName);
                    //Assert.Equal("Hahn", location.People.LastName);
                    //Assert.Equal("20202020", location.People.TelephoneNumber);
                    //Assert.False(location.People.IsAdmin);
                    ////login
                    //Assert.Equal("test1@test.com", location.People.Login.Email);
                    //Assert.Equal("1234", location.People.Login.Password);
                    ////Person Address
                    //Assert.Equal("Sofiendalsvej", location.People.Addresses.StreetName);
                    //Assert.Equal("60", location.People.Addresses.StreetNumber);
                    //Assert.Null(location.People.Addresses.ApartmentNumber);
                    //Assert.Equal("9000", location.People.Addresses.ZipcodeCountryCity.Zipcode);
                    //Assert.Equal("Aalborg", location.People.Addresses.ZipcodeCountryCity.City);
                    //Assert.Equal("Denmark", location.People.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Organisation
                    Assert.Equal("12341234", location.Organisations.Cvr);
                    Assert.Equal("UCN Kajakker", location.Organisations.Name);
                    //Organisation Address
                    Assert.Equal("Sofiendalsvej", location.Organisations.Addresses.StreetName);
                    Assert.Equal("60", location.Organisations.Addresses.StreetNumber);
                    Assert.Null(location.Organisations.Addresses.ApartmentNumber);
                    Assert.Equal("9000", location.Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", location.Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", location.Organisations.Addresses.ZipcodeCountryCity.Countries.Name);
                    //Assert.Equal("12341234", location.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
                    //Assert.Equal("12341234", location.People.OrganisationPeople.ToList()[0].Organisations.Name);
                }
                else if (expectedSuccess == false)
                {
                    Assert.Null(location);
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "CreateLocation")]
        public void CreateLocation(Location location, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                //arrange: some happens in GetData method
                LocationRepository locationRepository = new LocationRepository("Local");

                //act
                int returnedID = locationRepository.Create(location);
                var result = locationRepository.Get(returnedID, 1);

                //assert
                if (expectedSuccess == true && returnedID > 0)
                {
                    //Location
                    Assert.Equal(result.PickLocation, location.PickLocation);
                    Assert.Equal(result.Description, location.Description);

                    //Warehouse
                    Assert.Equal(result.Warehouses.Name, location.Warehouses.Name);
                    //Warehouse Address
                    Assert.Equal(result.Warehouses.Addresses.StreetName, location.Warehouses.Addresses.StreetName);
                    Assert.Equal(result.Warehouses.Addresses.StreetNumber, location.Warehouses.Addresses.StreetNumber);
                    Assert.Equal(result.Warehouses.Addresses.ApartmentNumber, location.Warehouses.Addresses.ApartmentNumber);
                    Assert.Equal(result.Warehouses.Addresses.ZipcodeCountryCity.Zipcode, location.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.Warehouses.Addresses.ZipcodeCountryCity.City, location.Warehouses.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name, location.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                    ////Comented out because if we create a location that has been setup with at person object (see Line 65-67)
                    ////it tries to create them in DB and throw and duplicate error
                    ////Person
                    //Assert.Equal(result.People.FirstName, location.People.FirstName);
                    //Assert.Equal(result.People.LastName, location.People.LastName);
                    //Assert.Equal(result.People.TelephoneNumber, location.People.TelephoneNumber);
                    //Assert.Equal(result.People.IsAdmin, location.People.IsAdmin);
                    ////login
                    //Assert.Equal(result.People.Login.Email, location.People.Login.Email);
                    //Assert.Equal(result.People.Login.Password, location.People.Login.Password);
                    ////Person Address
                    //Assert.Equal(result.People.Addresses.StreetName, location.People.Addresses.StreetName);
                    //Assert.Equal(result.People.Addresses.StreetNumber, location.People.Addresses.StreetNumber);
                    //Assert.Equal(result.People.Addresses.ApartmentNumber, location.People.Addresses.ApartmentNumber);
                    //Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Zipcode, location.People.Addresses.ZipcodeCountryCity.Zipcode);
                    //Assert.Equal(result.People.Addresses.ZipcodeCountryCity.City, location.People.Addresses.ZipcodeCountryCity.City);
                    //Assert.Equal(result.People.Addresses.ZipcodeCountryCity.Countries.Name, location.People.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Organisation
                    Assert.Equal(result.Organisations.Cvr, location.Organisations.Cvr);
                    Assert.Equal(result.Organisations.Name, location.Organisations.Name);
                    //Organisation Address
                    Assert.Equal(result.Organisations.Addresses.StreetName, location.Organisations.Addresses.StreetName);
                    Assert.Equal(result.Organisations.Addresses.StreetNumber, location.Organisations.Addresses.StreetNumber);
                    Assert.Equal(result.Organisations.Addresses.ApartmentNumber, location.Organisations.Addresses.ApartmentNumber);
                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.Zipcode, location.Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.City, location.Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.Countries.Name, location.Organisations.Addresses.ZipcodeCountryCity.Countries.Name);

                    ////Commented out for same reason as person
                    //if (location.People.OrganisationPeople.Count > 0)
                    //{
                    //    Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Cvr, location.People.OrganisationPeople.ToList()[0].Organisations.Cvr);
                    //    Assert.Equal(result.People.OrganisationPeople.ToList()[0].Organisations.Name, location.People.OrganisationPeople.ToList()[0].Organisations.Name);
                    //}
                }
                else if (expectedSuccess == false)
                {
                    Assert.Equal(-1, returnedID);
                }
                else
                {
                    Assert.True(false, "Was supposed to create Location, but failed");
                }
            }
        }

        public void Dispose()
        {
            RepopulateDatabase.Seed();
        }
    }
}
