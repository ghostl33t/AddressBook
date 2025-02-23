using AddressBook.DTOs;

namespace AddressBook.Repositories;
public interface IContactRepository
{
    public Task<List<ContactGetDTO>> GetAllContactsAsync();
}
