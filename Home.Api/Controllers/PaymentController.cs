using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Home.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentController(IPaymentService service)
        {
            this.service = service;
        }

        [HttpGet("GetSummary")]
        [ProducesResponseType(typeof(PagedResult<PaymentSummaryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PagedResult<PaymentSummaryDTO>> GetSummary([FromQuery] PaymentSummaryFilter filter, CancellationToken cancellationToken)
        {
            return await service.GetSummary(filter, cancellationToken);
        }

        [HttpGet("GetDetails")]
        [ProducesResponseType(typeof(PagedResult<PaymentDetailDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PagedResult<PaymentDetailDTO>> GetDetails([FromQuery] PaymentDetailFilter filter, CancellationToken cancellationToken)
        {
            return await service.GetDetails(filter, cancellationToken);
        }
    }
}


