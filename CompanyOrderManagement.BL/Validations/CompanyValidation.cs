using CompanyOrderManagement.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Validations
{
    public class CompanyValidation:AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(x=>x.Name).NotEmpty();
            
        }
    }
}
