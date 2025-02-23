using AddressBook.Domain.Models;
using AddressBook.DTOs;

namespace AddressBook.Repositories.ContactRepository;
public interface IContactRepository
{
    public Task<List<ContactGetDTO>> GetAllContactsAsync();
    public Task<bool> CreateNewContactAsync(Contact newContact);
    public Task<bool> DeleteContactAsync(int contactId);
}
