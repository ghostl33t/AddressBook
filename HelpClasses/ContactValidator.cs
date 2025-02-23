using AddressBook.DTOs;
using AddressBook.Repositories.ContactRepository;
using FluentValidation;

namespace AddressBook.HelpClasses;
public abstract class BaseContactValidator<T> : AbstractValidator<T> where T : ContactBaseEditDTO
{
    protected readonly IContactRepository _contactRepository;

    protected BaseContactValidator(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;

        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{3}/\d{3}-\d{3}$").WithMessage("Bad phone number format.");

        RuleFor(c => c.EmailAddress)
            .NotEmpty().WithMessage("Email is required.")
            .Matches(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$").WithMessage("Invalid email format.");

        RuleFor(c => c.Gender)
            .InclusiveBetween(0, 1).WithMessage("Gender must be 0 (Male) or 1 (Female).");

        RuleFor(c => c.BirthDate)
            .NotEmpty().WithMessage("Birth date is required.")
            .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Birth date must be in the past.");

        RuleFor(c => c.CityId)
            .GreaterThan(0).WithMessage("City ID must be greater than zero.");
    }
}

public class ContactValidator : BaseContactValidator<ContactPostDTO>
{
    public ContactValidator(IContactRepository contactRepository) : base(contactRepository)
    {
        RuleFor(c => c.PhoneNumber)
            .MustAsync(async (phoneNumber, cancellation) => !await _contactRepository.IsPhoneNumberInUse(phoneNumber))
            .WithMessage("Phone number is already in use.")
            .When(c => c is ContactPostDTO);

        RuleFor(c => c.EmailAddress)
            .MustAsync(async (email, cancellation) => !await _contactRepository.IsEmailInUse(email))
            .WithMessage("Email is already in use.")
            .When(c => c is ContactPostDTO);
    }
}

public class ContactPatchValidator : BaseContactValidator<ContactPatchDTO>
{
    public ContactPatchValidator(IContactRepository contactRepository) : base(contactRepository)
    {
        RuleFor(c => c.PhoneNumber)
            .MustAsync(async (c, phoneNumber, cancellation) => !await _contactRepository.IsPhoneNumberInUse(phoneNumber, c.ContactId))
            .WithMessage("Phone number is already in use.")
            .When(c => c is ContactPatchDTO);

        RuleFor(c => c.EmailAddress)
            .MustAsync(async (c, email, cancellation) => !await _contactRepository.IsEmailInUse(email, c.ContactId))
            .WithMessage("Email is already in use.")
            .When(c => c is ContactPatchDTO);
    }
}