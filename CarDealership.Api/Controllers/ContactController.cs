using CarDealership.Data.Repositories;
using CarDealership.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    public class ContactController : Controller
    {
        private readonly IGenericRepository<Contact> _ContactRepository;

        public ContactController(IGenericRepository<Contact> ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        [HttpGet("/api/[controller]")]
        public IActionResult GetContacts()
        {
            return Ok(_ContactRepository.GetAll());
        }


        [HttpPost]
        public IActionResult CreateContact([FromBody] Contact Contact)
        {
            if (Contact == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdContact = _ContactRepository.AddAsync(Contact);

            return Created("Contact", createdContact);
        }
    }
}
