using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class ModelController : Controller
    {
        private readonly IGenericRepository<Model> _ModelRepository;

        public ModelController(IGenericRepository<Model> ModelRepository)
        {
            _ModelRepository = ModelRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetModels()
        {
            return Ok(_ModelRepository.GetAll());
        }


        [HttpPost]
        public IActionResult CreateModel([FromBody] Model Model)
        {
            if (Model == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdModel = _ModelRepository.AddAsync(Model);

            return Created("Model", createdModel);
        }
    }
}
