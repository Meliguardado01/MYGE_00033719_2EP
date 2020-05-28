using System.Data;
using Npgsql;


namespace SourceCode.Modelo
{
    public static class ConexionDB
    {
        private static string CadenaConexion = 
            "Server=localhost;Port=1234;User Id=postgres;Password=melissita1;Database=foodBusiness";


        public static DataTable RealizarConsulta(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            DataSet ds = new DataSet();
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            
            return ds.Tables[0];
        }
           
        public static void RealizarAccion(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            
            conn.Open();
            NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
            nc.ExecuteNonQuery();
            conn.Close();
        }
    }
}