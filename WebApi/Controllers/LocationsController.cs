using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sigmade.Application.Workers.Quieries;
using System.Threading;
using System.Threading.Tasks;

namespace Sigmade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations(CancellationToken cancellationToken)
        {
            var locations = await _mediator.Send(new GetAllLocationsQuery(), cancellationToken);

            return Ok(locations);
        }
    }
}
