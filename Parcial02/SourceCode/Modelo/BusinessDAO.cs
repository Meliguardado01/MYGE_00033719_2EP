using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Controlador;

namespace SourceCode.Modelo
{
    public class BusinessDAO
    {
        public static List<Business> getLista()
        {
            string sql = "select * from business";

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<Business> list = new List<Business>();
            foreach (DataRow fila in dt.Rows)
            {
                Business b = new Business();
                b.idbusiness =  Convert.ToInt32(fila[0].ToString());
                b.name = fila[1].ToString();
                b.description = fila[2].ToString();
                

                list.Add(b);
            }
            return list;
        }

       

        public static void crearNuevo(string name, string description)
        {
            string sql = String.Format(
                "insert into business(name,description) " +
                "values('{0}', '{1}');",
                name, description); 
            
            ConexionDB.RealizarAccion(sql);
        }
        
        
        public static void eliminar(string idbusiness)
        {
            string sql = String.Format(
                "delete from product where idbusiness ='{0}'; " +
                "delete from business where idbusiness ='{0}';",
                idbusiness);
            
            ConexionDB.RealizarAccion(sql);
        }
            
    }
}