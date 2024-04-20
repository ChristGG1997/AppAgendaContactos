using AppAgendaContactosApi.Repositories;
using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AgendaContactosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//configuración del repo
builder.Services.AddScoped<IContactoRepository, ContactoRepository>();

// Configuración de CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder =>
//        {
//            builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//        });
//});

var app = builder.Build();

// Comentar o descomentar una vez se haya creado la base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AgendaContactosContext>();
    context.Database.EnsureCreated();
}

// Configuracion de HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("AllowAllOrigins");
app.UseCors(c =>
{
    c.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
