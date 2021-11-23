using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FABS_DataAccess.Model;

namespace FABS_DataAccess.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly FABSContext _context;

        public AddressRepository()
        {
            _context = new FABSContext();
        }

        public int Create(Address t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PrimaryKey pk)
        {
            throw new NotImplementedException();
        }

        public PrimaryKey FindPrimaryKey(Address address)
        {
            int foundId = 0;
            try
            {
                foundId = _context.Addresses
                    .Where(a => 
                        a.StreetName == address.StreetName &&
                        a.StreetNumber == address.StreetNumber &&
                        a.ApartmentNumber == address.ApartmentNumber &&
                        a.CountriesId == address.CountriesId &&
                        a.Zipcode ==  address.Zipcode
                        )
                    .Single()
                    .Id;
            }
            catch(System.InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            return new PrimaryKey(foundId);
        }

        public Address Get(PrimaryKey pk, int organisationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll(int organisationId)
        {
            throw new NotImplementedException();
        }

        public bool Update(PrimaryKey pk, Address t)
        {
            throw new NotImplementedException();
        }
    }
}
