using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Concrete
{
    
    public class Company:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderEndTime { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
