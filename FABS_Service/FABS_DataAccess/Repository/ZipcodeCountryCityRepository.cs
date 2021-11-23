using FABS_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FABS_DataAccess.Repository
{
    public class ZipcodeCountryCityRepository : IRepository<ZipcodeCountryCity>
    {
        private readonly FABSContext _context;

        public ZipcodeCountryCityRepository()
        {
            _context = new FABSContext();
        }

        public int Create(ZipcodeCountryCity t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PrimaryKey pk)
        {
            throw new NotImplementedException();
        }

        public PrimaryKey FindPrimaryKey(ZipcodeCountryCity zipcodeCountryCity)
        {
            ZipcodeCountryCity foundObject = null;
            try
            {
                foundObject = _context.ZipcodeCountryCities
                    .Where(zcc =>
                        zcc.Zipcode == zipcodeCountryCity.Zipcode &&
                        zcc.CountriesId == zipcodeCountryCity.CountriesId &&
                        zcc.City == zipcodeCountryCity.City
                        )
                    .Single();
            }
            catch(System.InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            PrimaryKey pk = null;
            if(foundObject != null)
            {
                pk = new PrimaryKey(new object[] { foundObject.Zipcode, foundObject.CountriesId });
            }

            return pk;
        }

        public ZipcodeCountryCity Get(PrimaryKey pk, int organisationId)
        {
            ZipcodeCountryCity foundZipcodeCountryCity;
            try
            {
                Object[] keys = GetPrimaryKeyValue(pk);
                // eager loading
                foundZipcodeCountryCity = _context.ZipcodeCountryCities
                    .Where(zcc => 
                        zcc.Zipcode == (string) keys[0] && 
                        zcc.CountriesId == (int) keys[1])
                    .Single();

            }
            catch
            {
                foundZipcodeCountryCity = null;
            }

            return foundZipcodeCountryCity;
        }

        public IEnumerable<ZipcodeCountryCity> GetAll(int organisationId)
        {
            throw new NotImplementedException();
        }

        public bool Update(PrimaryKey pk, ZipcodeCountryCity t)
        {
            throw new NotImplementedException();
        }

        private Object[] GetPrimaryKeyValue(PrimaryKey pk) => pk.KeyValues.ToArray();
    }
}
