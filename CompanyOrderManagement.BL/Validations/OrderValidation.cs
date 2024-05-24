using CompanyOrderManagement.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.BL.Validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Lütfen isim giriniz");
           
        }
    }
}
