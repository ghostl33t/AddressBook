using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AddressBook.HelpClasses;

namespace AddressBook.Repositories.ContactRepository;
public class ContactRepository : IContactRepository
{
    public async Task<List<ContactGetDTO>> GetAllContactsAsync()
    {
        return await Task.FromResult(new List<ContactGetDTO>
        {
            new ContactGetDTO
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Marković",
                PhoneNumber = "061-123-456",
                Gender = Gender.Male,
                Email = "marko@example.com",
                CountryName = "Bosna i Hercegovina",
                CityName = "Sarajevo",
                BirthDate = new DateOnly(1990, 5, 15)
            },
            new ContactGetDTO
            {
                Id = 2,
                FirstName = "Ana",
                LastName = "Anić",
                PhoneNumber = "062-987-654",
                Gender = Gender.Female,
                Email = "ana@example.com",
                CountryName = "Srbija",
                CityName = "Beograd",
                BirthDate = new DateOnly(1985, 10, 23)
            }
        });
    }
    public async Task<bool> CreateNewContactAsync(Contact newContact)
    {
        //add to db
        try
        {
            //placeholder temp
            var listOfContacts = new List<Contact>();
            listOfContacts.Add(newContact);
            return await Task.FromResult(true);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.ToString()}");
            throw;
        }
        
    }
}
