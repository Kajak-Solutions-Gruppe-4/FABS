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
    public class WarehouseRepositoryTest
    {
        // The constroctur is called before every test
        public WarehouseRepositoryTest()
        {
            // calls this method to ensure the database filled with data for testing
            Seed();
        }

        private void Seed()
        {
            using (var context = new FABSContext())
            {
                // TODO: never production database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<object[]> data = GetData("Seed").ToList();
                context.AddRange(
                    data[0][0] as ZipcodeCountryCity,
                    data[0][1] as Address,
                    data[0][2] as Organisation,
                    data[0][3] as Address,
                    data[0][4] as Warehouse,
                    data[0][5] as OrganisationWarehouse
                    );
                    context.SaveChanges();
            }
        }

        public static IEnumerable<object[]> GetData(string nameOfCaller)
        {
            ZipcodeCountryCity zipcodeCountryCity1 = new ZipcodeCountryCity("9000", "Denmark", "Aalborg");
            Address organisationAddress = new Address("Sofiendalsvej", "60", null, zipcodeCountryCity1);
            Organisation organisation1 = new Organisation("12341234", "UCN Kajakker", organisationAddress);

            Address warehouseAddress = new Address("Sofiendalsvej", "85", null, zipcodeCountryCity1);
            Warehouse warehouse1 = new Warehouse("Building A", organisationAddress);
            Warehouse warehouse2 = new Warehouse("Building B", 1);
            Warehouse warehouse3 = new Warehouse("Building C", 1);



            List<OrganisationWarehouse> organisationWarehouseList = new List<OrganisationWarehouse>();
            OrganisationWarehouse organisationWarehouse1 = new OrganisationWarehouse(organisation1, warehouse1);
            organisationWarehouseList.Add(organisationWarehouse1);
            organisation1.OrganisationWarehouses = organisationWarehouseList;
            warehouse1.OrganisationWarehouses = organisationWarehouseList;

            var allData = new List<object[]>();
            switch (nameOfCaller)
            {
                case "Seed":
                    allData.Add(new object[]
                    {
                        zipcodeCountryCity1,
                        organisationAddress,
                        organisation1,
                        warehouseAddress,
                        warehouse1,
                        organisationWarehouse1
                    });
                    break;
                case "ReadWarehouse":
                    allData.Add(new object[] { 1, true });
                    allData.Add(new object[] { 2, false });
                    break;
                case "CreateWarehouse":
                    allData.Add(new object[] { warehouse2, false });
                    allData.Add(new object[] { warehouse3, true });
                    break;
                default:
                    break;
            }

            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "ReadWarehouse")]
        public void ReadWarehouse(int id, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                //arrange: some happens in GetData method
                //act: perform test
                var warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(id);

                //assert
                if(expectedSuccess == true)
                {
                    Assert.Equal("Building A", warehouse.Name);
                    Assert.Equal("Sofiendalsvej", warehouse.Addresses.StreetName);
                    Assert.Equal("85", warehouse.Addresses.StreetNumber);
                    Assert.Null(warehouse.Addresses.ApartmentNumber);
                    Assert.Equal("9000", warehouse.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", warehouse.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", warehouse.Addresses.ZipcodeCountryCity.Country);

                    Assert.Equal("12341234", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Cvr);
                    Assert.Equal("Sofiendalsvej", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetName);
                    Assert.Equal("60", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetNumber);
                    Assert.Null(warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ApartmentNumber);
                    Assert.Equal("9000", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal("Aalborg", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal("Denmark", warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Country);
                }
                else if(expectedSuccess == false)
                {
                    Assert.Null(warehouse);
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "CreateWarehouse")]
        public void CreateWarehouse(Warehouse warehouse, bool expectedSuccess)
        {
            using (var context = new FABSContext())
            {
                //arrange: some happens in GetData method
                WarehouseRepository warehouseRepository = new WarehouseRepository();

                //act
                int returnedID = warehouseRepository.Create(warehouse);
                var result = warehouseRepository.Get(returnedID);

                //more arranging after creating
                if (warehouse.Addresses == null)
                {
                    warehouse.Addresses = context.Addresses
                        .Include(z => z.ZipcodeCountryCity)
                        .Single(x => x.Id == warehouse.AddressesId);
                }

                //assert
                if (expectedSuccess == true && returnedID > 0)
                {
                    Assert.Equal(result.Name, warehouse.Name);
                    Assert.Equal(result.Addresses.StreetName, warehouse.Addresses.StreetName);
                    Assert.Equal(result.Addresses.StreetNumber, warehouse.Addresses.StreetNumber);
                    Assert.Equal(result.Addresses.ApartmentNumber, warehouse.Addresses.ApartmentNumber);
                    Assert.Equal(result.Addresses.ZipcodeCountryCity.Zipcode, warehouse.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.Addresses.ZipcodeCountryCity.City, warehouse.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.Addresses.ZipcodeCountryCity.Country, warehouse.Addresses.ZipcodeCountryCity.Country);

                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Cvr, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Cvr);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetName, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetName);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetNumber, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.StreetNumber);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ApartmentNumber, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ApartmentNumber);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Zipcode, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Zipcode);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.City, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.City);
                    Assert.Equal(result.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Country, warehouse.OrganisationWarehouses.ToList()[0].Organisations.Addresses.ZipcodeCountryCity.Country);

                }
                else if (expectedSuccess == false)
                {
                    Assert.Equal(-1, returnedID);
                }
                else
                {
                    Assert.True(false, "Was supposed to create Warehouse, but failed");
                }

            }
        }

        public void Dispose()
        {
            Seed();
        }
    }
}
