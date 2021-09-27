using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class InteriorColorController : Controller
    {
        private readonly IGenericRepository<InteriorColor> _InteriorColorRepository;

        public InteriorColorController(IGenericRepository<InteriorColor> InteriorColorRepository)
        {
            _InteriorColorRepository = InteriorColorRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetInteriorColor()
        {
            return Ok(_InteriorColorRepository.GetAll());
        }


    }
}
