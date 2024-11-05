using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Web.Data;
using Web.Services;

var builder = WebApplication.CreateBuilder();

// ���������� ��������� ���� ������ � �������������� SQL Server
builder.Services.AddDbContext<FormsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine, LogLevel.Information)); 

// ���������� ������������ � ���������������
builder.Services.AddControllersWithViews();
var app = builder.Build();

// ��������� �������������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();