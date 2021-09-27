using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class SpecialController : Controller
    {
        private readonly IGenericRepository<Special> _specialRepository;

        public SpecialController(IGenericRepository<Special> specialRepository)
        {
            _specialRepository = specialRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetSpecials()
        {
            return Ok(_specialRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecial(int id)
        {
            if (id == 0)
                return BadRequest();

            var specialToDelete = _specialRepository.GetById(id);
            if (specialToDelete == null)
                return NotFound();

            _specialRepository.DeleteAsync(specialToDelete);

            return NoContent();//success
        }

        [HttpPost]
        public IActionResult CreateSpecial([FromBody] Special special)
        {
            if (special == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSpecial = _specialRepository.AddAsync(special);

            return Created("special", createdSpecial);
        }
    }
}
