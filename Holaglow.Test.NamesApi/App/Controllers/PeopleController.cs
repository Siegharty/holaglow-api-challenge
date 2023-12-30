using App.Data;

//using App.DbContexts;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository ??
               throw new ArgumentNullException(nameof(peopleRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleModel>>> GetNames()
        {
            var listOfPeople = await _peopleRepository.GetListOfNamesAsync();
            return Ok(listOfPeople);
        }
    }
}
