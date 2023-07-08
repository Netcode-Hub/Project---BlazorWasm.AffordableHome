using BlazorWasm.AffordableHomes.Server.Data;
using BlazorWasm.AffordableHomes.Server.Repositories.HouseRepositories;
using BlazorWasm.AffordableHomes.Server.Repositories.ModeRepositories;
using BlazorWasm.AffordableHomes.Shared.Converters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Database connection string 'DefaultConnection' doesnt not exist"));
});
builder.Services.AddScoped<IHouseRepo, HouseRepo>();
builder.Services.AddScoped<IModeRepository, ModeRepository>();
builder.Services.AddScoped<IFromDtoToEntity, FromDtoToEntity>();
builder.Services.AddScoped<IFromEntityToDto, FromEntityToDto>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
    });
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

