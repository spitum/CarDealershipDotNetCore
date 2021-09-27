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
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }


        [Route("/api/[controller]/vehicles")]
        [HttpGet]
        public IActionResult Inventory(decimal? minPrice, decimal? maxPrice, string quickSearch, int? maxYear, int? minYear,string condition)
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
                    Condition = condition

                };


                var result = _vehicleRepository.GetSelectInventory(parameters);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            return Ok(_vehicleRepository.GetById(id));
        }

        [HttpGet("/api/[controller]/featured")]
        public IActionResult GetFeaturedVehicles()
        {
            return Ok(_vehicleRepository.GetFeaturedVehicles());
        }

        [HttpGet("/api/[controller]/inventory")]
        public IActionResult GetInventoryReport(string condition)
        {
            return Ok(_vehicleRepository.GetInventoryReport(condition));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            if (id == 0)
                return BadRequest();

            var vehicleToDelete = _vehicleRepository.GetById(id);
            if (vehicleToDelete == null)
                return NotFound();

            _vehicleRepository.DeleteAsync(vehicleToDelete);

            return NoContent();//success
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVehicle = _vehicleRepository.AddAsync(vehicle);

            return Created("vehicle", createdVehicle);
        }
    }
}
