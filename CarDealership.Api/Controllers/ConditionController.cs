using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class ConditionController : Controller
    {
        private readonly IGenericRepository<Condition> _ConditionRepository;

        public ConditionController(IGenericRepository<Condition> ConditionRepository)
        {
            _ConditionRepository = ConditionRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetCondition()
        {
            return Ok(_ConditionRepository.GetAll());
        }


    }
}
