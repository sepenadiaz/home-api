using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService service;

        public CreditCardController(ICreditCardService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CreditCardDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CreditCardDTO>>> Get([FromQuery] CreditCardFilter filter, CancellationToken ct)
        {
            var res = await service.Get(filter, ct);
            return Ok(res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CreditCardDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreditCardDTO>> GetById(int id, CancellationToken ct)
        {
            var res = await service.GetById(id, ct);
            return res != null ? Ok(res) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreditCardDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreditCardDTO>> Post([FromBody] CreditCardPostDTO dto, CancellationToken ct)
        {
            var created = await service.Add(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CreditCardDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreditCardDTO>> Put(int id, [FromBody] CreditCardPostDTO dto, CancellationToken ct)
        {
            var updated = await service.Update(id, dto, ct);
            return updated != null ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var ok = await service.Delete(id, ct);
            return ok ? NoContent() : NotFound();
        }
    }
}


