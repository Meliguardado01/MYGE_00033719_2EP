using System.Data;
using Npgsql;

namespace Preparcial.Controlador
{
    public static class ConexionBD
    {
        // Cadena de conexion
        //CORRECCION: Cambie los datos para que mi BD pudiera enlazarse.
        private static string cadenaC = "Server=localhost;" +
                                        "Port=1234;" +
                                        "UserId=postgres;" +
                                        "Password=melissita1;" +
                                        "Database=preparcial;";

        // Ejecutar consulta (Comando SELECT)
        public static DataTable EjecutarConsulta(string consulta)
        {
            var conn = new NpgsqlConnection(cadenaC);
            var ds = new DataSet();

            conn.Open();
            var da = new NpgsqlDataAdapter(consulta, conn);
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }

        // Ejecutar comando (UPDATE, INSERT, DELETE, ETC)
        public static void EjecutarComando(string comando)
        {
            var conn = new NpgsqlConnection(cadenaC);

            conn.Open();
            var comm = new NpgsqlCommand(comando, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}