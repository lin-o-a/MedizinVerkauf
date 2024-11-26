using Microsoft.EntityFrameworkCore;
using MedizinVerkauf.Models;
using MedizinVerkauf.DomainLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container e.g. effects
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Medicine"));

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
///<summary>
///configure the routing for Razor Pages to recognize/respond to requests for Razor Pages
///</summary>
app.MapRazorPages();

app.Run();

public static class SeedData {
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        // Check if the database has been seeded
        if (context.Medicine.Any())
        {
            return;   // DB has been seeded
        }

        context.Medicine.AddRange(
            new Medicine { Name = "Mavacamten", ATCCode = "C01EB24" },
            new Medicine { Name = "Meldonium", ATCCode = "C01EB22" },
            new Medicine { Name = "Ibuprofen", ATCCode = "C01EB16" }
        );

        context.SaveChanges();
    }
}