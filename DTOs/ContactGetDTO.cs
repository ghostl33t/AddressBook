namespace AddressBook.DTOs;
public class ContactGetDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string CityName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public int Age => DateTime.Now.Year - BirthDate.Year;
}
