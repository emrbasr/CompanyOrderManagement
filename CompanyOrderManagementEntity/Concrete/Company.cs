using CompanyOrderManagement.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.Entities.Concrete
{
    public enum ApprovalStatus
    {
        Active = 1,
        Passive = 2
      
    }
    public class Company:BaseEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ApprovalStatus ApprovalStatus { get; set;}=ApprovalStatus.Active;
        public DateTime? OrderStartTiime { get; set; }
        public DateTime? OrderEndTiime { get; set; }

    }
}
