using AddressBook.Domain.Models;
using AddressBook.DTOs;

namespace AddressBook.Repositories.CityRepository;
public interface ICityRepository
{
    public Task<List<CityGetDTO>> GetCitiesForCountryAsync(int countryId);
    public Task<City> GetCityByIdAsync(int cityId);
}
