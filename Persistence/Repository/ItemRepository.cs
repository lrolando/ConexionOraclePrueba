using Persistence.DBContext;
using Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ItemRepository : IRepository<ITEM>
    {

        private readonly ApiDBContext apiDBContext;

        public ItemRepository(ApiDBContext Api_DBContext)
        {
            apiDBContext = Api_DBContext;

        }

        public async Task<List<ITEM>> GetAll()
        {
            List<ITEM> ListTI = null;

            try
            {
                ListTI = await (from a in apiDBContext.Items
                                select a).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ListTI;
        }

        public async Task<ITEM> GetById(int Id)
        {
            ITEM it = null;

            try
            {
                it = await (from a in apiDBContext.Items
                            where a.ID == Id
                            select a).FirstAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return it;
        }

        public async Task<ITEM> Add(ITEM newItem)
        {

            try
            {
                apiDBContext.Items.Add(newItem);
                apiDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newItem;
        }

        public void Update(ITEM Item)
        {
            try
            {
                apiDBContext.Items.Update(Item);
                apiDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ITEM Item)
        {
            try
            {
                apiDBContext.Items.Remove(Item);
                apiDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
