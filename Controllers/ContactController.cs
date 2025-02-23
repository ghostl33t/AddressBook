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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery(id));
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewContact(ContactPostDTO newContact)
        {
            var emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            var phonePattern = @"^\d{3}/\d{3}-\d{3}$";

            if (!Regex.IsMatch(newContact.EmailAddress, emailPattern))
                return BadRequest(new { message = "Invalid email format." });

            if (!Regex.IsMatch(newContact.PhoneNumber, phonePattern))
                return BadRequest(new { message = "Bad phone number format." });

            var command = new CreateContactCommand(newContact);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateContact([FromBody]ContactPatchDTO contactPatch)
        {
            var emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            var phonePattern = @"^\d{3}/\d{3}-\d{3}$";

            if (!Regex.IsMatch(contactPatch.EmailAddress, emailPattern))
                return BadRequest(new { message = "Invalid email format." });

            if (!Regex.IsMatch(contactPatch.PhoneNumber, phonePattern))
                return BadRequest(new { message = "Bad phone number format." });

            var command = new UpdateContactCommand(contactPatch);
            var result = await _mediator.Send(command);

            if (result)
                return Ok(new { message = "Contact updated successfully." });

            return NotFound(new { message = "Contact not found." });
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            var result = await _mediator.Send(new DeleteContactCommand(contactId));

            if (result)
                return Ok(new { message = "Contact deleted successfully." });

            return NotFound(new { message = "Contact not found." });
        }
    }
}