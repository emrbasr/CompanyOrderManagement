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
    public class OrderDal:RepositoryBase<Order>,IOrderDal
    {
        public OrderDal(SqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}
