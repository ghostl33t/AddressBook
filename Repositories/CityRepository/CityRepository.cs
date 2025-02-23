using AddressBook.Domain;
using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repositories.CityRepository;
public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CityRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<List<CityGetDTO>> GetCitiesForCountryAsync(int countryId)
    {
        var cities = await _dbContext.Cities
            .Where(x => x.CountryId == countryId)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<CityGetDTO>>(cities);
    }
    public async Task<City> GetCityByIdAsync(int cityId)
    {
        var city = await _dbContext.Cities.Where(x => x.Id == cityId).FirstAsync();
        return city;
    }
}
