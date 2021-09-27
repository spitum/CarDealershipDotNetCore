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
    public class AdminController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IGenericRepository<Model> _modelRepository;
        private readonly IGenericRepository<Make> _makeRepository;
        private readonly IGenericRepository<Special> _specialRepository;

        public AdminController(IVehicleRepository vehicleRepository, IGenericRepository<Model> modelRepository, IGenericRepository<Make> makeRepository, IGenericRepository<Special> specialRepository)
        {
            _vehicleRepository = vehicleRepository;
            _modelRepository = modelRepository;
            _makeRepository = makeRepository;
            _specialRepository = specialRepository;
        }

        [Route("/api/[controller]/vehicles")]
        [HttpGet]
        public IActionResult Inventory(decimal? minPrice, decimal? maxPrice, string quickSearch, int? maxYear, int? minYear)
        {
            try
            {
                var parameters = new InventorySearchParameters()
                {
                    QuickSearch = quickSearch,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    Condition = null

                };


                var result = _vehicleRepository.GetSelectInventory(parameters);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
