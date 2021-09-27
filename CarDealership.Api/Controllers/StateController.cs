using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class TransmissionController : Controller
    {
        private readonly IGenericRepository<Transmission> _TransmissionRepository;

        public TransmissionController(IGenericRepository<Transmission> TransmissionRepository)
        {
            _TransmissionRepository = TransmissionRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetTransmission()
        {
            return Ok(_TransmissionRepository.GetAll());
        }


    }
}
