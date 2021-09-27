using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class PurchaseTypeController : Controller
    {
        private readonly IGenericRepository<PurchaseType> _PurchaseTypeRepository;

        public PurchaseTypeController(IGenericRepository<PurchaseType> PurchaseTypeRepository)
        {
            _PurchaseTypeRepository = PurchaseTypeRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetPurchaseType()
        {
            return Ok(_PurchaseTypeRepository.GetAll());
        }


    }
}
