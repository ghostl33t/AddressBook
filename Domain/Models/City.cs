using AddressBook.HelpClasses;

namespace AddressBook.Domain.Models;
public class City : LocationModel
{
    public int CountryId { get; set; }
    public required Country Country { get; set; }
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
