using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.BL.Constans;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }
    }
}
