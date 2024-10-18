using Microsoft.EntityFrameworkCore;
using PatryInvites.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

builder.Services.AddDbContext<DataContext>(options =>
{
options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConntecting"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseDeveloperExceptionPage(); //7
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseMvcWithDefaultRoute();


app.Run();
