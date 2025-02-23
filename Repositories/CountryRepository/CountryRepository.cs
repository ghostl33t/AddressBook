using AddressBook.DTOs;

namespace AddressBook.Repositories.CountryRepository;
public class CountryRepository : ICountryRepository
{
    public async Task<List<CountryGetDTO>> GetAllCountriesAsync()
    {
        return await Task.FromResult(new List<CountryGetDTO>
        {
            new CountryGetDTO { CountryId = 1, CountryName = "Serbia" },
            new CountryGetDTO { CountryId = 2, CountryName = "Croatia" },
            new CountryGetDTO { CountryId = 3, CountryName = "Bosnia and Herzegovina" },
            new CountryGetDTO { CountryId = 4, CountryName = "Montenegro" }
        });
    }
}
