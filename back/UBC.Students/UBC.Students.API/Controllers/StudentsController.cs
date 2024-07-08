using Microsoft.AspNetCore.Mvc;
using System.Net;
using UBC.Students.Application.Interfaces;
using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Commands;


namespace UBC.Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;


        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id, [FromServices] IStudentService service)
        {
            try
            {
                var query = await service.Get(id, new System.Threading.CancellationToken());

                if (query == null)
                    return NotFound();

                return Ok(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromServices] IStudentService service)
        {
            try
            {
                var query = await service.GetAll(new System.Threading.CancellationToken());

                if (query == null)
                    return NotFound();

                return Ok(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.Created)]
        public IActionResult Post(
            [FromBody] CreateStudentViewModel request,
            [FromServices] IStudentService service
        )
        {
            try
            {
                var command = service.Create(request, new System.Threading.CancellationToken());

                if (command == null)
                    return NotFound();


                return Created("Post", command.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Delete(int id, [FromServices] IStudentService service)
        {
            try
            {
                var command = await service.Delete(id, new System.Threading.CancellationToken());

                if (command == null)
                    return NotFound();

                return Created("Delete", command) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.Created)]
        public IActionResult Put(
            int id,
            [FromBody] CreateStudentViewModel request,
            [FromServices] IStudentService service
        )
        {
            try
            {
                var command = service.Update(id, request, new System.Threading.CancellationToken());

                if (command == null)
                    return NotFound();

                return Created("Put", command.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

    }
}
