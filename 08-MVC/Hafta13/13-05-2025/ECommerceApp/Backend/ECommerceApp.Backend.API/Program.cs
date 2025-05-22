using System.Text;
using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Business.Concrete;
using ECommerceApp.Backend.Business.Mappings;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Data.Concrete;
using ECommerceApp.Backend.Data.Concrete.Context;
using ECommerceApp.Backend.Data.Concrete.Repositories;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.Configurations.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext'imizi containere ekliyoruz.
builder.Services.AddDbContext<AppDbContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Servislerimizi Ekliyoruz
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Repository'lerimizi ekliyoruz.
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

//AutoMapper
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(CartMappingProfile));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));

// Identity ayarları
builder.Services.AddIdentity<AppUser,IdentityRole>(options=>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase=true;
    options.Password.RequireNonAlphanumeric=true;
    options.Password.RequireUppercase=true;
    options.Password.RequiredLength=8;
    options.User.RequireUniqueEmail=true;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
JwtConfig? jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

// JWT Authentication ayarları
builder.Services.AddAuthentication(options=>{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options=>{
    options.TokenValidationParameters=new TokenValidationParameters{
        ValidateIssuer = true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer=jwtConfig?.Issuer,
        ValidAudience=jwtConfig?.Audience,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.Secret??""))
    };
});
    



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // wwwroot klasörüne izin verildi.

app.UseAuthentication();// Biz ekledik.
app.UseAuthorization();

app.MapControllers();

app.Run();
