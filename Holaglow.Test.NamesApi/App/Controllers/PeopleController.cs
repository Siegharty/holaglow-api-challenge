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
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(IPeopleRepository peopleRepository, ILogger<PeopleController> logger)
        {
            _peopleRepository = peopleRepository ??
               throw new ArgumentNullException(nameof(peopleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene todos los nombres.
        /// </summary>
        /// <param name="peopleParams">Objeto que recibe el nombre de la persona y su genero.</param>
        [Route("names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleModel>>> GetNamesAsync([FromQuery] PeopleValidationParams peopleParams)
        {
            try
            {
                var listOfPeople = await _peopleRepository.GetListOfNamesAsync(peopleParams.Name, peopleParams.Gender);

                if (listOfPeople.Count() == 0)
                {
                    _logger.LogInformation($"No hay datos o no se ha encontrado ninguna persona con esos parametros Nombre: {peopleParams.Name} Genero: {peopleParams.Gender}");
                    return NotFound();
                }

                return Ok(listOfPeople);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Hubo un error al traer el listado de nombres con los siguientes parametros Nombre: {peopleParams.Name} Genero: {peopleParams.Gender}", ex);
                return StatusCode(500, "Hubo un problema al traer este recurso.");
            }
        }
    }
}
