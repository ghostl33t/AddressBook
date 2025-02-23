using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Application.Contacts;
using AddressBook.DTOs;
using FluentValidation;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<ContactPostDTO> _postValidator;
        private readonly IValidator<ContactPatchDTO> _patchValidator;
        public ContactController(IMediator mediator, IValidator<ContactPostDTO> postValidator, IValidator<ContactPatchDTO> patchValidator)
        {
            _mediator = mediator;
            _postValidator = postValidator;
            _patchValidator = patchValidator;
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
            var validationResult = await _postValidator.ValidateAsync(newContact);
            if (!validationResult.IsValid)
            {
                var errMessage = "";
                foreach (var error in validationResult.Errors)
                    errMessage += $"Error: {error.ErrorMessage}!\n";

                return BadRequest(new { message = errMessage });
            }

            var command = new CreateContactCommand(newContact);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateContact([FromBody]ContactPatchDTO contactPatch)
        {
            var validationResult = await _patchValidator.ValidateAsync(contactPatch);
            if (!validationResult.IsValid)
            {
                var errMessage = "";
                foreach (var error in validationResult.Errors)
                    errMessage += $"Error: {error.ErrorMessage}!\n";

                return BadRequest(new { message = errMessage });
            }

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