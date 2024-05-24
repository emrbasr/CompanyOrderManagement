using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.BL.Constans;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Concrete
{
    public class OrderManager: ManagerBase<Order>,IOrderService
    {
        private readonly SqlDbContext _dbContext;

        public OrderManager(SqlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async virtual Task<string> CreateAsync(Order entity)
        {
            Company company = new Company();
            if (company.ApprovalStatus==ApprovalStatus.Active)
            {
                if (DateTime.Now.Hour == 22)
                {
                    return (Messages.MaintenanceTime);
                }
                await Repository.CreateAsync(entity);
                return ( Messages.ProductAdded);
            }
            return null;
        }
    }
}
