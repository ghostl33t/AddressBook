using AddressBook.HelpClasses;

namespace AddressBook.Domain.Models;

public class Country : LocationModel
{
    public ICollection<City>? Cities { get; set; }
}
