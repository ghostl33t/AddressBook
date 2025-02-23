using AddressBook.Domain.Models;
using AddressBook.DTOs;

namespace AddressBook.Repositories.CityRepository;
public class CityRepository : ICityRepository
{
    public Task<List<CityGetDTO>> GetCitiesForCountryAsync(int countryId)
    {
        var cities = countryId switch
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
    public async Task<City> GetCityByIdAsync(int cityId)
    {
        throw new NotImplementedException();
        //var cities = new List<City>
        //{
        //    new City { Id = 1, Name = "Belgrade", CountryId = 1 },
        //    new City { Id = 2, Name = "Novi Sad", CountryId = 1 },
        //    new City { Id = 3, Name = "Zagreb", CountryId = 2 },
        //    new City { Id = 4, Name = "Split", CountryId = 2 },
        //    new City { Id = 5, Name = "Sarajevo", CountryId = 3 },
        //    new City { Id = 6, Name = "Mostar", CountryId = 3 },
        //    new City { Id = 7, Name = "Podgorica", CountryId = 4 },
        //    new City { Id = 8, Name = "Nikšić", CountryId = 4 }
        //};

        //return await Task.FromResult(cities.First(city => city.Id == cityId));
    }
}
