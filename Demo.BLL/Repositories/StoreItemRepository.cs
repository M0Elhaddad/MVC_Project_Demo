using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class StoreItemRepository : GenericRepository<ItemStore>,IStoreItemRepository
    {
        public StoreItemRepository(AppDbContext dbContext) :base(dbContext)
        {
            
        }
    }
}
