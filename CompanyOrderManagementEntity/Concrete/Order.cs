using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Concrete
{
    public class Order:BaseEntity
    {
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string PersonName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
