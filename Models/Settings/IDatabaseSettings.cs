namespace Models.Settings;

// 🔧 Contrato simple para exponer la cadena de conexión
public interface IDatabaseSettings
{
    string ConnectionString { get; }
}
