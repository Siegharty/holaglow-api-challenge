using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("/api")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository ??
               throw new ArgumentNullException(nameof(peopleRepository));
        }

        [Route("names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleModel>>> GetNamesAsync([FromQuery]PeopleValidationParams peopleParams)
        {
            var listOfPeople = await _peopleRepository.GetListOfNamesAsync(peopleParams.Name, peopleParams.Gender);
            return Ok(listOfPeople);
        }
    }
}
