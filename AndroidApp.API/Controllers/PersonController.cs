using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AndroidApp.Application.DTO;
using AndroidApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AndroidApp.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;  

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult allPerson()
        {
            var result = Json(_personService.GetAllPerson());
            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult onePerson(int id)
        {
            var result = Json(_personService.GetPerson(id));
            return Ok(result);
        }
        [HttpDelete("id")]
        public IActionResult DeletePerson(int id)
        {
            var result = Json(_personService.DeletePerson(id));
            return Ok(result);
        }
        [HttpPut("id")]
        public IActionResult PutPerson(int id, PersonDTO personDTO)
        {
            var result = Json(_personService.PutPerson(id, personDTO));
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreatePerson(PersonDTO personDTO)
        {
            var result = Json(_personService.CreatePerson(personDTO));
            return Ok(result);
        }
    }
}
