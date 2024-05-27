using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Dtos
{
    public class CreateOrderDto
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public int Quantity { get; set; }
    }
}
