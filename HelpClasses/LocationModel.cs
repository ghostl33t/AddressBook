using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.HelpClasses;
public class LocationModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; } = string.Empty;
}
