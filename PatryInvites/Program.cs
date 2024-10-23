using Microsoft.EntityFrameworkCore;
using PatryInvites.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������
builder.Services.AddControllersWithViews(); // ����������� ���� ����� ��� MVC

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // ��������� ��������
});

var app = builder.Build();

// ��������� middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // ����������� Routing

app.UseAuthorization(); // ���� �� ����������� �����������

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
