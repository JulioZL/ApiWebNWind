using Microsoft.EntityFrameworkCore;
using APIWebNWind.Data;

/*
 
$ de venta por mes para un periodo especifico

fecha inicio - fecha final

 */


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("NorthwindDB"))
);

builder.Services.AddCors(opts =>
{
    //ip de consumidor e ip de cliente
    opts.AddDefaultPolicy(politica => politica.WithOrigins("http://localhost:40", "http://127.0.0.1:5500", "http://192.168.43.142:5500")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

//alt+l+o
//alt+l+c

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
