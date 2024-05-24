using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Concrete
{
    public class ProductManager : ManagerBase<Product>, IProductService
    {
        private readonly SqlDbContext _dbContext;

        public ProductManager(SqlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
