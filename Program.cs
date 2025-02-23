using AddressBook.Repositories.ContactRepository;
using AddressBook.Repositories.CountryRepository;
using AddressBook.Repositories.CityRepository;
using Microsoft.EntityFrameworkCore;
using AddressBook.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    try
    {
        options.UseSqlServer(mainConnectionString);
        Console.WriteLine($"Connected to the SQL Server!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"DB Connection Error {ex.ToString()}");
        throw;
    }
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
