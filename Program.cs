var builder = WebApplication.CreateBuilder(args);

// Si quieres usar controladores (no Minimal APIs)
builder.Services.AddControllers();

// Swagger para probar endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de configuración de BD (lee la cadena del appsettings.json)
builder.Services.AddSingleton<Models.Settings.IDatabaseSettings, Models.Settings.DatabaseSettings>();

// Registro de Repository y Service para el recurso (cámbialos/duplica por cada entidad)
builder.Services.AddScoped<Data.EntityRepository>();
builder.Services.AddScoped<Services.EntityService>();
builder.Services.AddScoped<Data.PersonasRepository>();
builder.Services.AddScoped<Services.PersonasService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapea controladores (rutas /api/...)
app.MapControllers();

app.Run();
