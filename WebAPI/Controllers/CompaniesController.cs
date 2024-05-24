using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyOrderManagement.DAL.Context;
using CompanyOrderManagement.Entities.Concrete;
using CompanyOrderManagement.BL.Abstract;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IValidator<Company> _validator;

        public CompaniesController(ICompanyService companyService, IValidator<Company> validator)
        {
            _companyService = companyService;
            _validator= validator;
        }

        //GET: api/Products
       [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyService.TGetList();
            if (result==null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Company company)
        {
            var result = await _companyService.CreateAsync(company);
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

        [HttpPut]
        public async Task<IActionResult> Put(Company company) // Update-Put
        {
            var sonuc = await _companyService.UpdateAsync(company);
            if (sonuc > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(sonuc);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Company company)
        {
            var sonuc = await _companyService.DeleteAsync(company);
            if (sonuc > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(sonuc);
            }
        }
    }
}
