using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCInfoApi.Models;
using UFCInfoApi.Services;

namespace UFCInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly UFCDataService _service;

        public EventsController(UFCDataService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("upcoming")]
        public async Task<ActionResult<List<Event>>> GetUpcomingEvents()
        {
            var events = await _service.GetUpcomingEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var ufcEvent = await _service.GetEventDetailsAsync(id);
            if (ufcEvent == null) return NotFound();
            return Ok(ufcEvent);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] Event ufcEvent)
        {
            var createdEvent = await _service.AddEventAsync(ufcEvent);
            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event ufcEvent)
        {
            if (id != ufcEvent.Id) return BadRequest();

            var updatedEvent = await _service.UpdateEventAsync(ufcEvent);
            if (updatedEvent == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _service.DeleteEventAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
