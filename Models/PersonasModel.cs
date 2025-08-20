namespace SysAdmin_Inventario.Models
{
    public class PersonasModel
    {
        // Modelo de ENTRADA (lo que recibe tu POST/PUT). Agrega/quita propiedades.
        public class InsertPersona
        {
            public int id { get; set; }
            public string nombre { get; set; } 
            public int edad { get; set; }
            public string email { get; set; }
        }

        // Modelo de SALIDA (lo que devuelves en GET). Agrega/quita propiedades.
        public class GetPersonas
        {
            public int id { get; set; }
            public string nombre { get; set; } 
            public int edad { get; set; }
            public string email { get; set; }
        }
    }
}