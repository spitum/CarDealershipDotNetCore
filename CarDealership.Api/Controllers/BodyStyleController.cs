using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class BodyStyleController : Controller
    {
        private readonly IGenericRepository<BodyStyle> _bodystyleRepository;

        public BodyStyleController(IGenericRepository<BodyStyle> bodystyleRepository)
        {
            _bodystyleRepository = bodystyleRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetBodystyle()
        {
            return Ok(_bodystyleRepository.GetAll());
        }


    }
}
