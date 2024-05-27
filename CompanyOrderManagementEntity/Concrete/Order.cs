﻿using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Concrete
{
    public class Order:BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
