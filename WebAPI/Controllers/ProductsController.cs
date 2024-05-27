using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.Entities.Concrete;
using CompanyOrderManagement.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var product = new Product
            {
                CompanyId = createProductDto.CompanyId,
                ProductName = createProductDto.Name,
                Stock = createProductDto.Stock,
                Price = (int)createProductDto.Price
            };

            await _productService.AddAsync(product);
            return Ok("Ürün başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            var product = await _productService.GetByIdAsync(updateProductDto.Id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            product.CompanyId = updateProductDto.CompanyId;
            product.ProductName = updateProductDto.Name;
            product.Stock = updateProductDto.Stock;
            product.Price = (int)updateProductDto.Price;

            await _productService.UpdateAsync(product);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            await _productService.DeleteAsync(product);
            return Ok("Ürün başarıyla silindi.");
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            return Ok(product);
        }
    }
}
