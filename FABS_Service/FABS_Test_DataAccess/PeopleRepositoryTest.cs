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
    public class PeopleRepositoryTest : IDisposable
    {
        // The constroctur is called before every test
        public PeopleRepositoryTest()
        {
            // calls this method to ensure the database filled with data for testing
            Seed();
        }

        /// <summary>
        /// Populate the database for tests
        /// </summary>
        private void Seed()
        {
            using (var context = new FABSContext())
            {
                // TODO: never production database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<object[]> data = GetData("Seed").ToList();

                context.AddRange(data[0][0] as Organisation);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Generates data for testing. The method generates data based on which test is calling.
        /// </summary>
        /// <param name="nameOfCaller">Name of the method calling</param>
        public static IEnumerable<object[]> GetData(string nameOfCaller)
        {
            Country country1 = new Country("Danmark");
            ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
            Address address1 = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
            Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address1);
            Login login1 = new Login("test1@test.com", "1234");
            Login login2 = new Login("test2@test.com", "1234");

            Person person1 = new Person("Peter", "Hahn", "20202020", false, address1, login1);
            Person person2 = new Person("Lars", "Andersen", "29292929", false, 1, login1);
            Person person3 = new Person("Rasmus", "Larsen", "28282828", false, 1, login2);

            OrganisationPerson organisationPerson1 = new OrganisationPerson(organisation1, person1);
            organisation1.OrganisationPeople.Add(organisationPerson1);

            var allData = new List<object[]>();
            switch (nameOfCaller)
            {
                case "Seed":
                    allData.Add(new object[] { organisation1 });
                    break;
                case "ReadPerson":
                    allData.Add(new object[] { 1, true });
                    allData.Add(new object[] { 2, false });
                    break;
                case "CreatePerson":
                    allData.Add(new object[] { person2, false });
                    allData.Add(new object[] { person3, true });
                    break;
                default:
                    break;
            }

            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReadPerson")]
        public void ReadPerson(int id, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                var peopleRepository = new PeopleRepository();

                Person person = peopleRepository.Get(id);

                if (expectedSuccess == true)
                {
                    Assert.Equal("Peter", person.FirstName);
                    Assert.Equal("Hahn", person.LastName);
                    Assert.Equal("20202020", person.TelephoneNumber);
                    Assert.False(person.IsAdmin);
                    Assert.Equal("Sofiendalsvej", person.Addresses.StreetName);
                    Assert.Equal("60", person.Addresses.StreetNumber);
                    Assert.Null(person.Addresses.ApartmentNumber);
                    Assert.Equal("9000", person.Addresses.Zipcode);
                    Assert.Equal("Danmark", person.Addresses.ZipcodeCountryCity.Countries.Name);
                    Assert.Equal("Aalborg", person.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("test1@test.com", person.Login.Email);
                    Assert.Equal("1234", person.Login.Password);
                    Assert.Equal("12341234", person.OrganisationPeople.ToList()[0].Organisations.Cvr);
                    Assert.Equal("UCN Kajakker", person.OrganisationPeople.ToList()[0].Organisations.Name);
                }
                else if(expectedSuccess == false)
                {
                    Assert.Null(person);
                }

            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "CreatePerson")]
        public void CreatePerson(Person person, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                //arrange: some happens in GetData method
                PeopleRepository peopleRepository = new PeopleRepository();

                //act
                int returnedID = peopleRepository.Create(person);
                var result = peopleRepository.Get(returnedID);

                //more arranging after creating
                if (person.Addresses == null)
                {
                    person.Addresses = context.Addresses
                                              .Include(z => z.ZipcodeCountryCity)
                                              .Single(x => x.Id == person.AddressesId);
                }

                //assert
                if (expectedSuccess == true && returnedID > 0)
                {
                    Assert.Equal(result.FirstName, person.FirstName);
                    Assert.Equal(result.LastName, person.LastName);
                    Assert.Equal(result.TelephoneNumber, person.TelephoneNumber);
                    Assert.Equal(result.IsAdmin, person.IsAdmin);
                    Assert.Equal(result.Addresses.StreetName, person.Addresses.StreetName);
                    Assert.Equal(result.Addresses.StreetNumber, person.Addresses.StreetNumber);
                    Assert.Equal(result.Addresses.ApartmentNumber, person.Addresses.ApartmentNumber);
                    Assert.Equal(result.Addresses.Zipcode, person.Addresses.Zipcode);
                    Assert.Equal(result.Addresses.Countries, person.Addresses.Countries);
                    Assert.Equal(result.Addresses.ZipcodeCountryCity.City, person.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Login.Email, person.Login.Email);
                    Assert.Equal(result.Login.Password, person.Login.Password);
                    if(person.OrganisationPeople.Count > 0)
                    {
                        Assert.Equal(result.OrganisationPeople.ToList()[0].Organisations.Cvr, person.OrganisationPeople.ToList()[0].Organisations.Cvr);
                        Assert.Equal(result.OrganisationPeople.ToList()[0].Organisations.Name, person.OrganisationPeople.ToList()[0].Organisations.Name);
                    }
                } 
                else if(expectedSuccess == false)
                {
                    Assert.Equal(-1, returnedID);
                }
                else
                {
                    Assert.True(false, "Was supposed to create person, but failed");
                }
            }
        }

        public void Dispose()
        {
            RepopulateDatabase.Seed();
        }
    }
}
