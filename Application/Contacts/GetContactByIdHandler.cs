using AddressBook.DTOs;
using AddressBook.Repositories.ContactRepository;
using MediatR;

namespace AddressBook.Application.Contacts;
public class GetContactByIdQuery : IRequest<ContactGetDTO>
{
    public int ContactId { get; set; }

    public GetContactByIdQuery(int contactId)
    {
        ContactId = contactId;
    }
}

public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactGetDTO>
{
    private readonly IContactRepository _contactRepository;

    public GetContactByIdHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ContactGetDTO> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        return await _contactRepository.GetContactByIdAsync(request.ContactId);
    }
}