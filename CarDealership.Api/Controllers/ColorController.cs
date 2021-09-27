using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class ColorController : Controller
    {
        private readonly IGenericRepository<Color> _ColorRepository;

        public ColorController(IGenericRepository<Color> ColorRepository)
        {
            _ColorRepository = ColorRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetColor()
        {
            return Ok(_ColorRepository.GetAll());
        }


    }
}
