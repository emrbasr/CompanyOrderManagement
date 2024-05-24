using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.DAL.Abstract
{
    public interface IOrderDal:IRepositoryBase<Order>
    {
    }
}
