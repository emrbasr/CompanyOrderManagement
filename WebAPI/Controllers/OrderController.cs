using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IValidator<Order> _validator;

        public OrderController(IOrderService orderService, IValidator<Order> validator )
        {
            _orderService= orderService;
            _validator= validator;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Order order)
        {
            var result = await _orderService.CreateAsync(order);
            if (result == null)
            {
                return (int)HttpStatusCode.NotFound;
            }
            else if (result == 0)
            {
                return (int)HttpStatusCode.NotImplemented;
            }
            return (int)HttpStatusCode.OK;
        }
    }
}
