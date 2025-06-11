using Microsoft.EntityFrameworkCore;
using MiniStokTakipAPI.Data; // DbContext için

var builder = WebApplication.CreateBuilder(args);

// EF Core + MySQL bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 3, 0))));

// ✨ Eksik olan burası:
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✨ Eksik olan burası:
app.MapControllers();

app.Run();
