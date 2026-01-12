using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService service;

        public PurchaseController(IPurchaseService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PurchaseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PurchaseDTO> Add(
            PurchasePostDTO purchase,
            CancellationToken cancellationToken
        )
        {
            return await service.Add(purchase, cancellationToken);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PurchaseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<PurchaseDTO>> Get(
            [FromQuery] PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await service.Get(filter, cancellationToken);
        }
    }
}


