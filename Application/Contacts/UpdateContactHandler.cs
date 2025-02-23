using AddressBook.DTOs;
using AddressBook.Repositories.ContactRepository;
using MediatR;

namespace AddressBook.Application.Contacts;

public class UpdateContactCommand : IRequest<bool>
{
    public ContactPatchDTO ContactPatchDTO { get; set; }

    public UpdateContactCommand(ContactPatchDTO contactPatchDTO)
    {
        ContactPatchDTO = contactPatchDTO;
    }
}

public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, bool>
{
    private readonly IContactRepository _contactRepository;

    public UpdateContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        return await _contactRepository.UpdateContactAsync(request.ContactPatchDTO);
    }
}
