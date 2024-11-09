using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
            => _dbContext = dbContext;
        public void Add(T entity)
            => _dbContext.Set<T>().Add(entity);
        public void Update(T entity)
            => _dbContext.Set<T>() .Update(entity);
        public void Delete(T entity)
            => _dbContext.Set<T>().Remove(entity);
        

        public T Get(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }
    }
}
