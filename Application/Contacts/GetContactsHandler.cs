using AddressBook.DTOs;
using AddressBook.Repositories.ContactRepository;
using MediatR;

namespace AddressBook.Application.Contacts;
public class GetContactsQuery : IRequest<List<ContactGetDTO>>
{
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;

    public GetContactsQuery(string? firstName = null, string? lastName = null, string? phoneNumber = null)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}
public class GetContactsHandler : IRequestHandler<GetContactsQuery, List<ContactGetDTO>>
{
    private readonly IContactRepository _contactRepository;

    public GetContactsHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<List<ContactGetDTO>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        return await _contactRepository.GetAllContactsAsync();
    }
}
