using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Repositories.Implementation;
using TourDuLichASAP.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<ITourDuLichRepositories, TourDuLichRepositories>();
builder.Services.AddScoped<INhanVienRepositories, NhanVienRepositories>();
builder.Services.AddScoped<IKhachHangRepositories, KhachHangRepositories>();
builder.Services.AddScoped<IDatTourRepositories, DatTourRepositories>();
builder.Services.AddScoped<IAnhTourRepositories, AnhTourRepositories>();
builder.Services.AddScoped<IDoiTacRepositories, DoiTacRepositories>();
builder.Services.AddScoped<IThanhToanRepositories, ThanhToanRepositories>();
builder.Services.AddScoped<IDichVuRepositories,DichVuRepositories>();
builder.Services.AddScoped<IDichVuChiTietRepositories,DichVuChiTietRepositories>();
builder.Services.AddScoped<IDanhGiaRepositories, DanhGiaRepositories>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

//app.UseCors(options =>
//{
//    options.WithOrigins("http://localhost:4200")
//           .AllowAnyHeader()
//           .AllowAnyMethod();
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
