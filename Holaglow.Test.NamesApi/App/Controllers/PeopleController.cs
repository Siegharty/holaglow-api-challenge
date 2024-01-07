using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


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
        /// Get all Names.
        /// </summary>
        /// <param name="peopleParams">Object that receive name, gender, page, size</param>
        [Route("names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeopleModel>>> GetNamesAsync([FromQuery] PeopleValidationParams peopleParams)
        {
            try
            {
                var (listOfPeople, paginationMetaData) = await _peopleRepository.GetListOfNamesAsync(peopleParams);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

                if (listOfPeople.Count() == 0)
                {
                    _logger.LogInformation($"No hay datos o no se ha encontrado ninguna persona con esos parametros Nombre: {peopleParams.Name} Genero: {peopleParams.Gender}");
                    return Ok(listOfPeople);
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
