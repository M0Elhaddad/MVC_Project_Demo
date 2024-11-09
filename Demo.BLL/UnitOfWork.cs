using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IitemRepository ItemRepository { get; set; }
        public IStoreRepository StoreRepository { get; set; }
        public IStoreItemRepository StoreItemRepository { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ItemRepository = new ItemRepository(_dbContext);
            StoreRepository = new StoreRepository(_dbContext);
            StoreItemRepository = new StoreItemRepository(_dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
