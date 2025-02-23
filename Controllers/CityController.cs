using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Application.Cities;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cities-for-country/{countryId}")]
        public async Task<IActionResult> GetCitiesForCountry(int countryId)
        {
            var cities = await _mediator.Send(new GetCitiesQuery(countryId));
            return Ok(cities);
        }
    }
}