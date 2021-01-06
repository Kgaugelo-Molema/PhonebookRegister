using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        //[EnableCors("AllowOrigin")] 
        public IEnumerable<dynamic> Get()
        {
            var entries = _repository.GetEntries();
            return entries;
        }

        [HttpPost("{name}/{phonenumber}/{phonebook}")]
        public int PostEntry([FromRoute] string name, [FromRoute] string phoneNumber, [FromRoute] string phoneBook)
        {
            var entryId = Guid.NewGuid();
            var saveEntry = _repository.SaveEntry(new Contact {Id = entryId, Name = name, PhoneNumber = phoneNumber});
            var savePhonebook = _repository.SavePhonebook(new Phonebook {Name = phoneBook, EntryId = entryId});
            return saveEntry * savePhonebook;
        }
    }
}
