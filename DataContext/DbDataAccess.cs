using System.Data;
using Microsoft.Data.SqlClient;

namespace Data;

//Helper genérico para ejecutar SPs y devolver DataSet. Úsalo desde tus Repositorios.
public class DbDataAccess
{
    private readonly string _connectionString;

    public DbDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataSet Fill(string storedProcedure, System.Collections.ArrayList parametros)
    {
        var ds = new DataSet();

        using var cn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(storedProcedure, cn) { CommandType = CommandType.StoredProcedure };

        if (parametros != null)
        {
            foreach (var p in parametros)
            {
                if (p is SqlParameter sp)
                    cmd.Parameters.Add(sp);
            }
        }

        using var da = new SqlDataAdapter(cmd);
        cn.Open();
        da.Fill(ds);
        return ds;
    }
}
