using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.Repository
{
    public class ItemTypeRepository : IRepository<ItemType>
    {

        private readonly FABSContext _context;

        public ItemTypeRepository()
        {
            _context = new FABSContext();
        }

        public ItemType Get(int id, int organisationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemType> GetAll(int organisationId)
        {
            IEnumerable<ItemType> listItemTypes;
            try
            {
                listItemTypes = _context.ItemTypes
                    .Where(p => p.Items.Any(op => op.OrganisationsId == organisationId))
                    .Include(k => k.KayakType)
                    
                    


                    ;


            }
            catch
            {
                listItemTypes = null;
            }

            return listItemTypes;
        }

        public int Create(ItemType t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }



        public bool Update(int id, ItemType t)
        {
            throw new NotImplementedException();
        }
    }
}
