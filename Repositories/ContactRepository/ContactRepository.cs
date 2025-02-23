using AddressBook.Domain;
using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repositories.ContactRepository;
public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public ContactRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ContactGetDTO>> GetAllContactsAsync()
    {
        var contacts = await _dbContext.Contacts.Include(x => x.City).Include(x => x.City.Country).ToListAsync();

        return _mapper.Map<List<ContactGetDTO>>(contacts);
    }

    public async Task<ContactGetDTO> GetContactByIdAsync(int contactId)
    {
        var contact = await _dbContext.Contacts.Include(x => x.City).FirstAsync(x => x.Id == contactId);
        var contactDto = _mapper.Map<ContactGetDTO>(contact);
        contactDto.CountryId = contact.City.CountryId;

        return contactDto;
    }

    public async Task<bool> CreateNewContactAsync(Contact newContact)
    {
        try
        {
            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Insert Failed - Exception occured: {ex.ToString()}");
            throw;
        }
    }

    public async Task<bool> UpdateContactAsync(ContactPatchDTO contactPatch)
    {
        try
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactPatch.ContactId);

            if (contact == null)
                return false;

            _mapper.Map(contactPatch, contact);
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Update Failed - Exception occured: {ex.ToString()}");
            throw;
        }
    }

    public async Task<bool> DeleteContactAsync(int contactId)
    {
        try
        {
            var contact = await _dbContext.Contacts.FirstAsync(x => x.Id == contactId);
            _dbContext.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Delete Failed - Exception occured: {ex.ToString()}");
            throw;
        }
    }

    public async Task<bool> IsEmailInUse(string email) => await _dbContext.Contacts.Where(x => x.EmailAddress == email).AnyAsync();
    public async Task<bool> IsPhoneNumberInUse(string phoneNumber) => await _dbContext.Contacts.Where(x => x.PhoneNumber == phoneNumber).AnyAsync();

    public async Task<bool> IsEmailInUse(string email, int contactId) => 
        await _dbContext.Contacts.Where(x => x.EmailAddress == email && x.Id != contactId).AnyAsync();
    public async Task<bool> IsPhoneNumberInUse(string phoneNumber, int contactId) => 
        await _dbContext.Contacts.Where(x => x.PhoneNumber == phoneNumber && x.Id != contactId).AnyAsync();
}
