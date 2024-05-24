using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Abstract
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<int> CreateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> UpdateAsync(T entity);


        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetList();
        T TGetById(int id);

    }
}
