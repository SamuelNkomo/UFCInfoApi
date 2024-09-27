using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UFCInfoApi.Models;
using UFCInfoApi.Services;

namespace UFCInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightersController : ControllerBase
    {
        private readonly UFCDataService _service;

        public FightersController(UFCDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fighter>>> GetFighters()
        {
            var fighters = await _service.GetFightersAsync();
            return Ok(fighters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fighter>> GetFighter(int id)
        {
            var fighter = await _service.GetFighterDetailsAsync(id);
            if (fighter == null) return NotFound();
            return Ok(fighter);
        }

        [HttpPost]
        public async Task<ActionResult<Fighter>> CreateFighter([FromBody] Fighter fighter)
        {
            var createdFighter = await _service.AddFighterAsync(fighter);
            return CreatedAtAction(nameof(GetFighter), new { id = createdFighter.Id }, createdFighter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFighter(int id, [FromBody] Fighter fighter)
        {
            if (id != fighter.Id) return BadRequest();

            var updatedFighter = await _service.UpdateFighterAsync(fighter);
            if (updatedFighter == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFighter(int id)
        {
            var result = await _service.DeleteFighterAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
