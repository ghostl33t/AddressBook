using AddressBook.DTOs;

namespace AddressBook.Repositories.ContactRepository;
public interface IContactRepository
{
    public Task<List<ContactGetDTO>> GetAllContactsAsync();
}
