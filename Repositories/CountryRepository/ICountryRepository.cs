using AddressBook.DTOs;

namespace AddressBook.Repositories.CountryRepository;
public interface ICountryRepository
{
    public Task<List<CountryGetDTO>> GetAllCountriesAsync();
}
