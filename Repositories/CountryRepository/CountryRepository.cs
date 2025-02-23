using AddressBook.Domain;
using AddressBook.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repositories.CountryRepository;
public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public CountryRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<List<CountryGetDTO>> GetAllCountriesAsync()
    {
        var countries = await _dbContext.Countries
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<CountryGetDTO>>(countries);
    }
}
