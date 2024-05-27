using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Abstract
{
    public interface ICompanyService:IGenericService<Company>
    {
        Task<Company> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task<int> UpdateAsync(Company company);
    }
}
