using CompanyOrderManagement.BL.Abstract;
using CompanyOrderManagement.BL.Concrete;
using CompanyOrderManagement.BL.Validations;
using CompanyOrderManagement.DAL.Abstract;
using CompanyOrderManagement.DAL.Concrete;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("companyManagement")));
            builder.Services.AddScoped<IValidator<Company>, CompanyValidation>();
            builder.Services.AddScoped<IValidator<Order>, OrderValidation>();
            builder.Services.AddScoped<IValidator<Product>, ProductValidation>();

            builder.Services.AddScoped<ICompanyService, CompanyManager>();
            builder.Services.AddScoped<ICompanyDal, CompanyDal>();

            builder.Services.AddScoped<IOrderService, OrderManager>();
            builder.Services.AddScoped<IOrderDal, OrderDal>();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDal, ProductDal>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}