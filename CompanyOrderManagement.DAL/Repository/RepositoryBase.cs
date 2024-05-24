using CompanyOrderManagement.DAL.Abstract;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        public readonly SqlDbContext _dbContext;

        public RepositoryBase(SqlDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter = null)
        {
            using var c = new SqlDbContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            using var context = new SqlDbContext();
            return context.Set<T>().Find(id);

        }

        public List<T> GetList()
        {
            using var c = new SqlDbContext();
            return c.Set<T>().ToList();

        }

        public void Insert(T entity)
        {
            using var c = new SqlDbContext();
            c.Add(entity);
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            using var c = new SqlDbContext();
            c.Update(entity);
            c.SaveChanges();
        }

        public async virtual Task<int> CreateAsync(T entity)
        {
            using var c = new SqlDbContext();
            try
            {
                await c.Set<T>().AddAsync(entity);
                return await c.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public async virtual Task<int> DeleteAsync(T entity)
        {
            using var c = new SqlDbContext();
            var model = c.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (model != null)
            {
                c.Set<T>().Remove(model);
                return await c.SaveChangesAsync();
            }
            return 0;
        }
        public async virtual Task<int> UpdateAsync(T entity)
        {
            using var c = new SqlDbContext();
            c.Set<T>().Update(entity);
            return await c.SaveChangesAsync();
        }


    }
}
