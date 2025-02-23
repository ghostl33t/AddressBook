using AddressBook.HelpClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Models;
public class Contact
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(11)")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "bit")]
    public Gender Gender { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "date")]
    public DateOnly BirthDate { get; set; }

    [Required]
    [ForeignKey("City")]
    public int CityId { get; set; }
    public required City City { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
