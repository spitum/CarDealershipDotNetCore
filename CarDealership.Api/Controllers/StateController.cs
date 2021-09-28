using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class StateController : Controller
    {
        private readonly IGenericRepository<State> _stateRepository;

        public StateController(IGenericRepository<State> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetStates()
        {
            return Ok(_stateRepository.GetAll());
        }


    }
}
