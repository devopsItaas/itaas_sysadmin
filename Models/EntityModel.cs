namespace SysAdmin_Inventario.Models
{
    public class EntityModels
    {
        // Modelo de ENTRADA (lo que recibe tu POST/PUT). Agrega/quita propiedades.
        public class InsertEntityModel
        {
            public int Tipo { get; set; }
            public string Nombre { get; set; } = "";
            public DateTime Fecha { get; set; }
            public string? Descripcion { get; set; }
        }

        // Modelo de SALIDA (lo que devuelves en GET). Agrega/quita propiedades.
        public class GetEntityModel
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Estado { get; set; }
            public string? FechaCreacion { get; set; }
        }
    }
}