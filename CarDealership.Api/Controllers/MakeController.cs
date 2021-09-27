using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class MakeController : Controller
    {
        private readonly IGenericRepository<Make> _makeRepository;

        public MakeController(IGenericRepository<Make> makeRepository)
        {
            _makeRepository = makeRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetMakes()
        {
            return Ok(_makeRepository.GetAll());
        }


        [HttpPost]
        public IActionResult CreateMake([FromBody] Make make)
        {
            if (make == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMake = _makeRepository.AddAsync(make);

            return Created("make", createdMake);
        }
    }
}
