using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.DAL.Abstract;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Concrete
{
    public class CompanyManager : ManagerBase<Company>,ICompanyService
    {

        private readonly SqlDbContext _dbContext;

        public CompanyManager(SqlDbContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

    }
}
