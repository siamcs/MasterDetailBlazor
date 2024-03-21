using Blazor.Server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDBContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();//
builder.Services.AddControllersWithViews();//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();//
}

app.UseAuthorization();
app.UseStaticFiles();//
app.UseBlazorFrameworkFiles();//
app.MapFallbackToFile("index.html");//
app.MapControllers();

app.Run();