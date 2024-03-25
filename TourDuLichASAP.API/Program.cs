using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddDbContext<AuthDbContext>(options =>
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
builder.Services.AddScoped<ITokenRepository,TokenRepository>();


builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TourDuLichASAP")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            AuthenticationType = "Jwt",
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey =
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


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

app.UseAuthentication();
app.UseAuthorization();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/uploads"
});

app.MapControllers();

app.Run();
