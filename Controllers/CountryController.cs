using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Application.Countries;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _mediator.Send(new GetCountriesQuery());
            return Ok(countries);
        }
    }
}