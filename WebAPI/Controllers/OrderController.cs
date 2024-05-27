using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.Entities.Concrete;
using CompanyOrderManagement.Entities.Dtos;
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
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;
        private readonly IValidator<Order> _validator;
      

        public OrderController(IOrderService orderService, IValidator<Order> validator, IProductService productService, ICompanyService companyService)
        {
            _orderService= orderService;
            _validator= validator;
            _productService= productService;
            _companyService= companyService;
            
        }

        //[HttpPost]
        //public async Task<int> Post([FromBody] Order order)
        //{
        //    var result = await _orderService.CreateAsync(order);
        //    if (result == null)
        //    {
        //        return (int)HttpStatusCode.NotFound;
        //    }
        //    else if (result == 0)
        //    {
        //        return (int)HttpStatusCode.NotImplemented;
        //    }
        //    return (int)HttpStatusCode.OK;
        //}

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var company = await _companyService.GetByIdAsync(createOrderDto.CompanyId);

            if (company == null)
            {
                return NotFound("Firma bulunamadı");
            }

            if (!company.IsApproved)
            {
                return BadRequest("Firma onaylı değil");
            }

            var currentHour = createOrderDto.OrderTime.TimeOfDay;

            if (currentHour < company.OrderStartTime || currentHour > company.OrderEndTime)
            {
                return BadRequest("Firma şu an sipariş almıyor");
            }

            var product = await _productService.GetByIdAsync(createOrderDto.ProductId);

            if (product == null || product.Stock < createOrderDto.Quantity)
            {
                return BadRequest("Ürün bulunamadı veya yeterli stok yok");
            }

            var order = new Order
            {
                CompanyId = createOrderDto.CompanyId,
                ProductId = createOrderDto.ProductId,
                CustomerName = createOrderDto.CustomerName,
                OrderDate = createOrderDto.OrderTime,
                Quantity = createOrderDto.Quantity
            };

            await _orderService.AddAsync(order);
            return Ok("Sipariş başarıyla oluşturuldu");
        }

    }
}
