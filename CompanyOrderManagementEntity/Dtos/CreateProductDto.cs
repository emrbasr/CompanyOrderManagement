using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Dtos
{
    public class CreateProductDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}
