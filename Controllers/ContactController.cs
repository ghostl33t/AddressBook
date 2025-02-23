using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Application.Contacts;
using AddressBook.DTOs;
using System.Text.RegularExpressions;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _mediator.Send(new GetContactsQuery());
            return Ok(contacts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewContact(ContactPostDTO newContact)
        {
            var emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            var phonePattern = @"^\d{3}/\d{3}-\d{3}$";

            if (!Regex.IsMatch(newContact.EmailAddress, emailPattern))
                return BadRequest("Invalid email format.");

            if (!Regex.IsMatch(newContact.PhoneNumber, phonePattern))
                return BadRequest("Invalid phone number format.");

            var command = new CreateContactCommand(newContact);
            await _mediator.Send(command);

            return Ok();
        }
    }
}