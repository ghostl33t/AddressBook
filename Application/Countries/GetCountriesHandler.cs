using AddressBook.DTOs;
using AddressBook.Repositories.CountryRepository;
using MediatR;

namespace AddressBook.Application.Countries;
public class GetCountriesQuery : IRequest<List<CountryGetDTO>>
{
}
public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, List<CountryGetDTO>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountriesHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<List<CountryGetDTO>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetAllCountriesAsync();
    }
}