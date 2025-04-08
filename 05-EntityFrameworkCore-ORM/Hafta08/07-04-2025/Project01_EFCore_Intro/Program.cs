using Microsoft.EntityFrameworkCore;
using Project01_EFCore_Intro.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
ORM-Object-Relational Mapping
ORM veri tabanındaki varlıklarımızla uygulamamız içinde sınıflarımızın birbirleriyle eşleştirerek database operasyonlarının kolayca yapılmasını sağlamayı amaçlar.
Faydaları:
1)Nesne tabanlı dillerde(c#) ilişkisel veri tabanlarında farklı model yapılarını rahatlıkla eşleştirelbilir,uyumlu hale getirilebilir.
2)CRUD işlemlerinin soyutlanması konusunda ciddi katkılar sağlar
3)Veritabanı bağımsız şekilde kod geliştirmeyi sağlar.
*/