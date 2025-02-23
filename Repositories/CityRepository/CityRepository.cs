using AddressBook.DTOs;

namespace AddressBook.Repositories.CityRepository;
public class CityRepository : ICityRepository
{
    public Task<List<CityGetDTO>> GetCitiesForCountry(int id)
    {
        var cities = id switch
        {
            1 => new List<CityGetDTO>
        {
            new CityGetDTO { CountryId = 1, CityId = 1, CityName = "Belgrade" },
            new CityGetDTO { CountryId = 1, CityId = 2, CityName = "Novi Sad" }
        },
            2 => new List<CityGetDTO>
        {
            new CityGetDTO { CountryId = 2, CityId = 3, CityName = "Zagreb" },
            new CityGetDTO { CountryId = 2, CityId = 4, CityName = "Split" }
        },
            3 => new List<CityGetDTO>
        {
            new CityGetDTO { CountryId = 3, CityId = 5, CityName = "Sarajevo" },
            new CityGetDTO { CountryId = 3, CityId = 6, CityName = "Mostar" }
        },
            4 => new List<CityGetDTO>
        {
            new CityGetDTO { CountryId = 4, CityId = 7, CityName = "Podgorica" },
            new CityGetDTO { CountryId = 4, CityId = 8, CityName = "Nikšić" }
        },
            _ => new List<CityGetDTO>()
        };

        return Task.FromResult(cities);
    }
}
