﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhonebookWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonebookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PhonebookController> _logger;
        private readonly PhonebookRepository _repository;

        public PhonebookController(ILogger<PhonebookController> logger, PhonebookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Phonebook1> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Phonebook1
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("{name}/{phonenumber}")]
        public string PostEntry([FromRoute] string name, [FromRoute] string phoneNumber)
        {
            return $"Name = {name} - Number = {phoneNumber}";
        }
    }
}
