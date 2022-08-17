using GoodReads.Api.Startup;
using GoodReads.EntityFrameworkCore;
using GoodReads.EntityFrameworkCore.Repositories;
using GoodReads.Services.Books;
using GoodReads.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IUserBookRepository, UserBookRepository>();
builder.Services.AddTransient<IUserBookService, UserBookService>();

builder.Services.AddDbContext<GoodReadsDbContext>(x => x.UseSqlServer("name=ConnectionStrings:Default"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
