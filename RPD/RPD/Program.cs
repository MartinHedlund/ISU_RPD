using RPD.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("FirstDbConnectionString");
// добавляем контекст Dbservice в качестве сервиса в приложение
builder.Services.AddDbContext<DbService>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<DbService>();


// получаем строку подключения из файла конфигурации
string SecondConnection = builder.Configuration.GetConnectionString("SecondDbConnectionString");
// добавляем контекст Dbservice в качестве сервиса в приложение
builder.Services.AddDbContext<DbSecondService>(options => options.UseSqlServer(SecondConnection));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = int.MaxValue; // Установите максимальный размер тела запроса для загрузки файлов
});

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc().AddControllersAsServices();


//Куки Сессия
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();
//куки
app.UseSession();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Autoriz}/{action=authorization}/{id?}");
//pattern: "{controller=Home}/{action=authorization}/{id?}");
//pattern: "{controller=Mtod}/{action=LiterT}/{id?}");
//pattern: "{controller=Content}/{action=Index}/{id?}");
//pattern: "{controller=Titul}/{action=Index}/{id?}");

app.Run();