using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.DAL.Abstract;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.DAL.Repository;
using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Concrete
{
    public class ManagerBase<T> : IGenericService<T> where T : BaseEntity, new()
    {
        public RepositoryBase<T> Repository { get; set; }
        public ManagerBase(SqlDbContext dbContext)
        {
            Repository = new RepositoryBase<T>(dbContext);
        }
        
        public void TAdd(T entity)
        {
             Repository.Insert(entity);
        }

        public void TDelete(T entity)
        {
            Repository.Delete(entity);
        }

        public T TGetById(int id)
        {
          return Repository.GetById(id);
        }

        public List<T> TGetList()
        {
            return Repository.GetList(); 
        }

        public void TUpdate(T entity)
        {
            Repository.Update(entity);
        }

        public async virtual Task<int> CreateAsync(T entity)
        {
            return await Repository.CreateAsync(entity);
        }

        

        public async virtual Task<int> UpdateAsync(T entity)
        {
            return await Repository.UpdateAsync(entity);
        }

      

        public async virtual Task<int> DeleteAsync(T entity)
        {
            return await Repository.DeleteAsync(entity);
        }

    }
}
