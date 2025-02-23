using AddressBook.Repositories.ContactRepository;
using MediatR;

namespace AddressBook.Application.Contacts;
public class DeleteContactCommand : IRequest<bool>
{
    public int ContactId { get; set; }

    public DeleteContactCommand(int contactId)
    {
        ContactId = contactId;
    }
}
public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, bool>
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await _contactRepository.DeleteContactAsync(request.ContactId);

        return isDeleted;
    }
}