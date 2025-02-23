using AddressBook.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Registracija servisa u Dependency Injection container
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// 2️⃣ Omogućavanje CORS-a za sve domene
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()  // Omogućava bilo koji origin
               .AllowAnyMethod()  // Omogućava bilo koji HTTP metod (GET, POST...)
               .AllowAnyHeader()); // Omogućava bilo koji header
});

// 3️⃣ Omogućavanje API kontrolera
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// 4️⃣ Omogućavanje CORS-a u pipeline-u
app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
