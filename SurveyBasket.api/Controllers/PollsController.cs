
using SurveyBasket.api.Errors;

namespace SurveyBasket.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PollsController(Ipollservices pollservices) : ControllerBase
    {
        private readonly Ipollservices _pollservices= pollservices;
        [HttpGet("")]
        public async Task< IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var polls= await _pollservices.GetallAsync(cancellationToken);
            var respons = polls.Adapt<IEnumerable<CreatePollRespons>>();
            return  Ok(respons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _pollservices.Getasync(id, cancellationToken);
            return result.IsSuccess ?
                Ok(result.Value) :
                 result.ToProblem(StatusCodes.Status404NotFound);
        }

        [HttpPost("")]
        public async Task<IActionResult> add([FromBody] Createpollrequest request, CancellationToken cancellationToken = default)
        {
            var newpoll = await _pollservices.addasync(request, cancellationToken);
            return CreatedAtAction(nameof(GetByid), new { id = newpoll.Id }, newpoll);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] Createpollrequest request, CancellationToken cancellationToken = default)
        {
            var result = await _pollservices.updateasync(id,request,cancellationToken);
           return result.IsSuccess ?
                NoContent() :
               result.ToProblem(StatusCodes.Status404NotFound);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _pollservices.deleteasync(id);
            return result.IsSuccess ?
                NoContent() :
                result.ToProblem(StatusCodes.Status404NotFound);
        }
        [HttpPut("{id}/tologgpuplish")]
        public async Task<IActionResult> puplish(int id, CancellationToken cancellationToken = default)
        {
            var result = await _pollservices.togglepublishstatusasync(id, cancellationToken);
            return result.IsSuccess ?
                NoContent() :
                result.ToProblem(StatusCodes.Status404NotFound);
        }
    }
}