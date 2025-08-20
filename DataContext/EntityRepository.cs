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
public class EntityRepository
{
    private readonly string _connection;

    public EntityRepository(IDatabaseSettings settings)
    {
        _connection = settings.ConnectionString;
    }

    // INSERT: ajusta nombre del SP y parámetros según tu BD.
    public string Insert(EntityModels.InsertEntityModel model)
    {
        var parametros = new ArrayList();
        var dac = new DbDataAccess(_connection);

        // Agrega aquí los parámetros EXACTOS que espera tu SP
        parametros.Add(new SqlParameter("@pTipo", SqlDbType.Int) { Value = model.Tipo });
        parametros.Add(new SqlParameter("@pNombre", SqlDbType.VarChar) { Value = model.Nombre });
        parametros.Add(new SqlParameter("@pFecha", SqlDbType.DateTime) { Value = model.Fecha });
        parametros.Add(new SqlParameter("@pDescripcion", SqlDbType.VarChar) { Value = (object?)model.Descripcion ?? DBNull.Value });

        // Cambia "sp_InsertEntity" por tu SP real
        DataSet ds = dac.Fill("sp_InsertEntity", parametros);

        // Adapta la lectura del mensaje/resultado según lo que devuelva tu SP
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0]["Mensaje"]?.ToString() ?? "Sin mensaje";

        return "Sin respuesta desde la base de datos";
    }

    // SELECT: mapea columnas de tu consulta/SP a tu modelo de salida
    public List<EntityModels.GetEntityModel> GetAll()
    {
        var lista = new List<EntityModels.GetEntityModel>();
        var dac = new DbDataAccess(_connection);

        // Cambia "sp_GetEntities" por tu SP real
        var ds = dac.Fill("sp_GetEntities", new ArrayList());

        if (ds.Tables.Count == 0) return lista;

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            lista.Add(new EntityModels.GetEntityModel
            {
                Id = int.TryParse(row["ID"]?.ToString(), out var id) ? id : 0,
                Nombre = row["NOMBRE"]?.ToString(),
                Estado = row["ESTADO"]?.ToString(),
                FechaCreacion = row["FECHA_CREACION"]?.ToString(),
                // 🔧 Agrega mapeos según tus columnas
            });
        }

        return lista;
    }
}
// Modelos de entrada y salida para tus operaciones