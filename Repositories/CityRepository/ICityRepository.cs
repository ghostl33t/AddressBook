using AddressBook.DTOs;

namespace AddressBook.Repositories.CityRepository;
public interface ICityRepository
{
    public Task<List<CityGetDTO>> GetCitiesForCountry(int id);
}
