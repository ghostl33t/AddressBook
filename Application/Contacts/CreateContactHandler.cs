using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AddressBook.HelpClasses;
using AddressBook.Repositories.CityRepository;
using AddressBook.Repositories.ContactRepository;
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

    public CreateContactHandler(IContactRepository contactRepository, ICityRepository cityRepository)
    {
        _contactRepository = contactRepository;
        _cityRepository = cityRepository;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetCityByIdAsync(request.ContactPostDTO.CityId);
        var contact = new Contact
        {
            FirstName = request.ContactPostDTO.FirstName,
            LastName = request.ContactPostDTO.LastName,
            PhoneNumber = request.ContactPostDTO.PhoneNumber,
            Gender = (Gender)request.ContactPostDTO.Gender,
            EmailAddress = request.ContactPostDTO.EmailAddress,
            BirthDate = request.ContactPostDTO.BirthDate,
            City = city,
            CityId = request.ContactPostDTO.CityId
        };

        await _contactRepository.CreateNewContactAsync(contact);

        return contact.Id;
    }
}