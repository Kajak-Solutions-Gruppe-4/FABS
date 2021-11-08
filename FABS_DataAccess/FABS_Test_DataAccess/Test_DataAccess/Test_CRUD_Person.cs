using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;



namespace FABS_Test_DataAccess.Test_DataAccess
{
    public class Test_CRUD_Person
    {
        //The repository we want to test

        private PersonRepository _personRepository = new PersonRepository();

        


        [Fact]
        private void TestGetPersonRepository()
        {
            //Arrange
            var p1 = new Person() 
            {
                FirstName = "Lars", 
                LastName = "Andersen", 
                TelephoneNumber = "29292929", 
                AdressesId = 2, 
                LoginsId = 1, 
                IsAdmin = false 
            };

            //Act
            var p2 = _personRepository.Get(3);

            //Assert
            //TODO: Find out how to assert two differnet objects are equal in their properties
            Assert.Equal(p1.FirstName, p2.FirstName);

        }
        [Fact]
        private void TestCreatePersonRepository()
        {
            //Arrange
            var p = new Person() { FirstName = "John", LastName = "Deer", TelephoneNumber = "30303030" };

            //Act

            var i = _personRepository.Add(p);

            //Assert

            Assert.Equal(_personRepository.Get(i).LastName, p.LastName); 
        }
    }
}
