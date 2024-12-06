using Mapster;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SurveyBasket.api.contracts.Request;
using SurveyBasket.api.contracts.Respons;
using SurveyBasket.api.Services;
namespace SurveyBasket.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(Ipollservices pollservices) : ControllerBase
    {
        private readonly Ipollservices _pollservices= pollservices;
        [HttpGet]
        public IActionResult GetAll()
        {
            var polls=_pollservices.Getall();
            var respons = polls.Adapt<IEnumerable<Createpollrequest>>();
            return Ok(respons);
        }

        [HttpGet("{id}")]
        public IActionResult GetByid([FromRoute]int id)
        {
            var s = _pollservices.Get(id);

            if(s==null)return NotFound();
            var respons = s.Adapt<CreatePollRespons>();
            return Ok(respons);
        }

        [HttpPost("")]
        public IActionResult add([FromBody]Createpollrequest request)
        {
            var newpoll=_pollservices.add(request.Adapt<Poll>());
            return CreatedAtAction(nameof(GetByid), new { id = newpoll.Id }, newpoll);
        }

        [HttpPut("{id}")]
        public IActionResult update([FromRoute]int id,[FromBody]Createpollrequest request) { 
           bool s=_pollservices.update(id, request.Adapt<Poll>());
            if(!s)return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult update([FromRoute]int id)
        {
            bool s = _pollservices.delete(id);
            if (!s) return NotFound();
            return NoContent();
        }
    }
}