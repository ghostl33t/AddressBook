namespace AddressBook.DTOs;
public class CityGetDTO
{
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
}
