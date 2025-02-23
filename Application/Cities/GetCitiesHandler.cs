using AddressBook.DTOs;
using AddressBook.Repositories.CityRepository;
using MediatR;

namespace AddressBook.Application.Cities;
public class GetCitiesQuery : IRequest<List<CityGetDTO>>
{
    public GetCitiesQuery(int countryId)
    {
        CountryId = countryId;
    }
    public int CountryId;
}

public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, List<CityGetDTO>>
{
    private readonly ICityRepository _cityRepository;

    public GetCitiesHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<CityGetDTO>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        return await _cityRepository.GetCitiesForCountry(request.CountryId);
    }
}