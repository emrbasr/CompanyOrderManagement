using CompanyOrderManagement.DAL.Abstract;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.DAL.Repository;
using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.DAL.Concrete
{
    public class ProductDal:RepositoryBase<Product>,IProductDal
    {
        public ProductDal(SqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}
