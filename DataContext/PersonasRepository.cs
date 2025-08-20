using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;
using Models;
using Models.Settings;
using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;

using SysAdmin_Inventario.Models;

namespace Data;

// SOLO acceso a datos (SQL/SP). Nada de lógica de negocio aquí.
public class PersonasRepository
{
    private readonly string _connection;

    public PersonasRepository(IDatabaseSettings settings)
    {
        _connection = settings.ConnectionString;
    }

    // INSERT: ajusta nombre del SP y parámetros según tu BD.
    public string Insert(PersonasModel.InsertPersona model)
    {
        var parametros = new ArrayList();
        var dac = new DbDataAccess(_connection);

        // Agrega aquí los parámetros EXACTOS que espera tu SP
        parametros.Add(new SqlParameter("@pNombre", SqlDbType.VarChar) { Value = model.nombre });
        parametros.Add(new SqlParameter("@pEdad", SqlDbType.Int) { Value = model.edad });
        parametros.Add(new SqlParameter("@pEmail", SqlDbType.VarChar) { Value = model.email });

        // Cambia "sp_InsertEntity" por tu SP real
        DataSet ds = dac.Fill("sp_InsertPersonas", parametros);

        // Adapta la lectura del mensaje/resultado según lo que devuelva tu SP
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["Mensaje"]?.ToString() ?? "Sin mensaje";

        return "Sin respuesta desde la base de datos";
    }

    // SELECT: mapea columnas de tu consulta/SP a tu modelo de salida
    public List<PersonasModel.GetPersonas> GetAll()
    {
        var lista = new List<PersonasModel.GetPersonas>();
        var dac = new DbDataAccess(_connection);

        // Cambia "sp_GetEntities" por tu SP real
        var ds = dac.Fill("sp_GetPersonas", new ArrayList());

        if (ds.Tables.Count == 0) return lista;

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            lista.Add(new PersonasModel.GetPersonas
            {
                id = int.TryParse(row["ID"]?.ToString(), out var id) ? id : 0,
                nombre = row["Nombre"]?.ToString(),
                edad = int.TryParse(row["Edad"]?.ToString(), out var edad) ? edad : 0,
                email = row["Email"]?.ToString(),
                // 🔧 Agrega mapeos según tus columnas
            });
        }

        return lista;
    }
}
// Modelos de entrada y salida para tus operaciones