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
    public class ItemRepositoryTest : IDisposable
    {
        // The constroctur is called before every test
        public ItemRepositoryTest()
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
            //Create Item test objects



            //Zipcode/Country test objects
            Country country1 = new Country("Denmark");
            ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", country1, "Aalborg");
            //Organisation test objects
            Address address = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
            Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", address);
            //Location test objects

            Warehouse warehouse1 = new Warehouse("Building A", address);
            Location location1 = new Location("1.2.3", "This is an awesome location spot 1", warehouse1, null, organisation1);

            // Creating kajak item
            KayakType kayakType1 = new KayakType("Red Kayaks Rule!", 120, 2.5m, 1, null);
            ItemType itemType1 = new ItemType("Kayak", kayakType1);

            //Status test objects
            Status status1 = new Status("Item Status", "Looking Good");
            //ItemType test objects
            Item item1 = new Item(organisation1, status1, location1, itemType1);
            Item item2 = new Item(organisation1, status1, location1, itemType1);
            Item item3 = new Item(organisation1, status1, location1, itemType1);
            organisation1.Items.Add(item1);

            //adding test objects to list
            var allData = new List<object[]>();
            switch (nameOfCaller)
            {
                case "Seed":
                    allData.Add(new object[] { organisation1 });
                    break;

                case "ReadItem":
                    allData.Add(new object[] { 1, true });
                    allData.Add(new object[] { 1, true });
                    break;

                case "CreateItem":
                    allData.Add(new object[] { item2, true });
                    allData.Add(new object[] { item3, false });
                    break;
                default:
                    break;
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReadItem")]
        public void ReadItem(int id, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                var itemRepository = new ItemRepository("Local");

                Item item = itemRepository.Get(id, 1);

                if (expectedSuccess == true)
                {
                    //Type
                    //NONE Imidit data
                    //Organisation
                    Assert.Equal("12341234", item.Organisations.Cvr);
                    Assert.Equal("UCN Kajakker", item.Organisations.Name);

                    Assert.Equal("Sofiendalsvej", item.Organisations.Addresses.StreetName);
                    Assert.Equal("60", item.Organisations.Addresses.StreetNumber);
                    Assert.Null(item.Organisations.Addresses.ApartmentNumber);

                    Assert.Equal("9000", item.Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", item.Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", item.Organisations.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Status
                    Assert.Equal("Item Status", item.Statuses.Name);
                    Assert.Equal("Looking Good", item.Statuses.Category);

                    //Location
                    Assert.Equal("1.2.3", item.Locations.PickLocation);
                    Assert.Equal("This is an awesome location spot 1", item.Locations.Description);
                    Assert.Null(item.Locations.People);
                    

                    //Warehouse
                    Assert.Equal("Building A", item.Locations.Warehouses.Name);

                    Assert.Equal("Sofiendalsvej", item.Locations.Warehouses.Addresses.StreetName);
                    Assert.Equal("60", item.Locations.Warehouses.Addresses.StreetNumber);
                    Assert.Null(item.Locations.Warehouses.Addresses.ApartmentNumber);

                    Assert.Equal("9000", item.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", item.Locations.Warehouses.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", item.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                    //ItemType
                    Assert.Equal("Kayak", item.ItemTypes.Name);

                    Assert.Equal("Red Kayaks Rule!", item.ItemTypes.KayakType.Description);
                    Assert.Equal(120, item.ItemTypes.KayakType.WeightLimit);
                    Assert.Equal(2.5m, item.ItemTypes.KayakType.LengthMeter);
                    Assert.Equal(1, item.ItemTypes.KayakType.PersonCapacity);
                    
                }
                else if (expectedSuccess == false)
                {
                    Assert.Null(item);
                }
            }



        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "CreateItem")]
        public void CreateItem(Item item, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                //arrange: some happens in GetData method
                ItemRepository itemRepository = new ItemRepository("Local");

                //act
                int returnedID = itemRepository.Create(item);
                var result = itemRepository.Get(returnedID, 1);

                //assert
                if (expectedSuccess == true && returnedID > 0)
                {
                    //Type
                    //NONE Imidit data
                    //Organisation
                    Assert.Equal(result.Organisations.Cvr, item.Organisations.Cvr);
                    Assert.Equal(result.Organisations.Name, item.Organisations.Name);

                    Assert.Equal(result.Organisations.Addresses.StreetName, item.Organisations.Addresses.StreetName);
                    Assert.Equal(result.Organisations.Addresses.StreetNumber, item.Organisations.Addresses.StreetNumber);
                    Assert.Equal(result.Organisations.Addresses.ApartmentNumber, item.Organisations.Addresses.ApartmentNumber);

                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.Zipcode, item.Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.City, item.Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Organisations.Addresses.ZipcodeCountryCity.Countries.Name, item.Organisations.Addresses.ZipcodeCountryCity.Countries.Name);

                    //Status
                    Assert.Equal(result.Statuses.Name, item.Statuses.Name);
                    Assert.Equal(result.Statuses.Category, item.Statuses.Category);

                    //Location
                    Assert.Equal(result.Locations.PickLocation, item.Locations.PickLocation);
                    Assert.Equal(result.Locations.Description, item.Locations.Description);
                    Assert.Equal(result.Locations.People, item.Locations.People);
                    Assert.Equal(result.Locations.Organisations, item.Locations.Organisations);

                    //Warehouse
                    Assert.Equal(result.Locations.Warehouses.Name, item.Locations.Warehouses.Name);

                    Assert.Equal(result.Locations.Warehouses.Addresses.StreetName, item.Locations.Warehouses.Addresses.StreetName);
                    Assert.Equal(result.Locations.Warehouses.Addresses.StreetNumber, item.Locations.Warehouses.Addresses.StreetNumber);
                    Assert.Equal(result.Locations.Warehouses.Addresses.ApartmentNumber, item.Locations.Warehouses.Addresses.ApartmentNumber);

                    Assert.Equal(result.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode, item.Locations.Warehouses.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.Locations.Warehouses.Addresses.ZipcodeCountryCity.City, item.Locations.Warehouses.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name, item.Locations.Warehouses.Addresses.ZipcodeCountryCity.Countries.Name);

                    //ItemType
                    Assert.Equal(result.ItemTypes.Name, item.ItemTypes.Name);

                    Assert.Equal(result.ItemTypes.KayakType.Description, item.ItemTypes.KayakType.Description);
                    Assert.Equal(result.ItemTypes.KayakType.WeightLimit, item.ItemTypes.KayakType.WeightLimit);
                    Assert.Equal(result.ItemTypes.KayakType.LengthMeter, item.ItemTypes.KayakType.LengthMeter);
                    Assert.Equal(result.ItemTypes.KayakType.PersonCapacity, item.ItemTypes.KayakType.PersonCapacity);
                    Assert.Equal(result.ItemTypes.KayakType.ItemType, item.ItemTypes.KayakType.ItemType);
                }
                else if (expectedSuccess == false)
                {
                    Assert.Equal(-1, returnedID);
                }
                else
                {
                    Assert.True(false, "Was supposed to create item, but failed");
                }
            }
        }

        public void Dispose()
        {
            RepopulateDatabase.Seed(); 
        }
    }
}
