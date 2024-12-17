
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
            var respons = polls.Adapt<IEnumerable<Createpollrequest>>();
            return  Ok(respons);
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetByid([FromRoute] int id,CancellationToken cancellationToken = default)
        {
            var s =await _pollservices.Getasync(id,cancellationToken);

            if (s == null) return NotFound();
            var respons = s.Adapt<CreatePollRespons>();
            return Ok(respons);
        }

        [HttpPost("")]
        public async Task< IActionResult> add([FromBody] Createpollrequest request,CancellationToken cancellationToken=default)
        {
            var newpoll = await _pollservices.addasync(request.Adapt<Poll>(), cancellationToken);
            return CreatedAtAction(nameof(GetByid), new { id = newpoll.Id }, newpoll.Adapt<CreatePollRespons>());
        }

        [HttpPut("{id}")]
        public async Task< IActionResult> update([FromRoute] int id, [FromBody] Createpollrequest request,CancellationToken cancellationToken=default)
        {
            bool s =await _pollservices.updateasync(id, request.Adapt<Poll>(), cancellationToken);
            if (!s) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> update([FromRoute] int id ,CancellationToken cancellationToken=default)
        {
            bool s =await _pollservices.deleteasync(id);
            if (!s) return NotFound();
            return NoContent();
        }
        [HttpPut("{id}/tologgpuplish")]
        public async Task<IActionResult> puplish(int id, CancellationToken cancellationToken = default)
        {
            bool s= await _pollservices.togglepublishstatusasync(id,cancellationToken);
            if (s == false) return NotFound();
            return NoContent();
        }
    }
}