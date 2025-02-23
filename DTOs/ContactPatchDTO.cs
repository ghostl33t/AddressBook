namespace AddressBook.DTOs;
public class ContactPatchDTO
{
    public int ContactId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Gender { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public int CityId { get; set; }
}
