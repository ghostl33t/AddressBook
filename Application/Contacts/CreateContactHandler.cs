using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AddressBook.Repositories.CityRepository;
using AddressBook.Repositories.ContactRepository;
using AutoMapper;
using MediatR;

namespace AddressBook.Application.Contacts;
public class CreateContactCommand : IRequest<int>
{
    public ContactPostDTO ContactPostDTO { get; set; }

    public CreateContactCommand(ContactPostDTO contactPostDTO)
    {
        ContactPostDTO = contactPostDTO;
    }
}

public class CreateContactHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IContactRepository _contactRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateContactHandler(IContactRepository contactRepository, ICityRepository cityRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetCityByIdAsync(request.ContactPostDTO.CityId);
        var contact = _mapper.Map<Contact>(request.ContactPostDTO);
        contact.City = city;

        await _contactRepository.CreateNewContactAsync(contact);

        return contact.Id;
    }
}