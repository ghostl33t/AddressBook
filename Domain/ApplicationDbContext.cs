using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Domain;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
