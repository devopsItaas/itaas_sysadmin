using Microsoft.Extensions.Configuration;

namespace Models.Settings;

// Implementación que lee la cadena de appsettings.json
public class DatabaseSettings : IDatabaseSettings
{
    public string ConnectionString { get; }

    public DatabaseSettings(IConfiguration configuration)
    {
        // Cambia "DefaultConnection" si renombraste la clave en appsettings.json
        ConnectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("No se encontró la cadena 'DefaultConnection'.");
    }
}
