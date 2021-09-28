using Cardealership.Shared.Queries;
using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _PurchaseRepository;

        public PurchaseController(IPurchaseRepository PurchaseRepository)
        {
            _PurchaseRepository = PurchaseRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_PurchaseRepository.GetAll());
        }

        [HttpGet("/api/[controller]/salesreport")]
        public IActionResult GetSales(string userName,DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var parameters = new SalesReportSearchParameters()
                {
                    UserName = userName,
                    FromDate = fromDate,
                    ToDate = toDate

                };


                var result = _PurchaseRepository.GetSalesReport(parameters);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePurchase([FromBody] Purchase Purchase)
        {
            if (Purchase == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPurchase = _PurchaseRepository.AddAsync(Purchase);

            return Created("Purchase", createdPurchase);
        }
    }   
}
