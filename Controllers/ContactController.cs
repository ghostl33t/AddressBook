using AddressBook.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/contact
        [HttpGet("all")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            return Ok(contacts);
        }
    }
}
