using Microsoft.EntityFrameworkCore;
using Movies.contract;
using Movies.Data;
using Movies.Repository;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("MYSQLCONNECTION");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(ConnectionString);
});

builder.Services.AddScoped(typeof(IGenericRespository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<IMovieDetailRepository, MovieDetailRepository>();
builder.Services.AddScoped<ITheatreDetailsRepository, TheatreDetailsRepository>();
builder.Services.AddScoped<ISeatTypeRespository, SeatTypeRespository>();
builder.Services.AddScoped<ISeatsRepository, SeatsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
