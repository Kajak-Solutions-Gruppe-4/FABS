using FABS_DataAccess.Model;
using FABS_DataAccess.Repository;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FABS_Test_DataAccess
{
    public class UnitTest1
    {
        
            [Fact]
        public void Test1()
        {
             var pRep = new PeopleRepository(_configuration);

            var res = pRep.Get(3);

            Assert.Equal( "Lars", res.FirstName);

        }
    }
}
