using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Modelo
{
    public class ProductDAO
    {
        public static List<Product> getLista()
                {
                    string sql = "select * from product";
        
                    DataTable dt = ConexionDB.RealizarConsulta(sql);
        
                    List<Product> lis = new List<Product>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        Product p = new Product();
                        p.idproduct =  fila[0].ToString();
                        p.idbusiness = fila[1].ToString();
                        p.name = fila[2].ToString();
                        
        
                        lis.Add(p);
                    }
                    return lis;
                }
        
               
        
                public static void crearNuevo(string idbusiness, string name)
                {
                    string sql = String.Format(
                        "insert into product( idbusiness, name) " +
                        "values('{0}', '{1}');",
                         idbusiness, name); 
                    
                    ConexionDB.RealizarAccion(sql);
                }
                
                
                public static void eliminar(string idproduct)
                {
                    string sql = String.Format(
                        "delete from apporder where idproduct = {0};  " +
                        "delete from product where idproduct= {0}; " ,
                        idproduct);
                    
                    ConexionDB.RealizarAccion(sql);
                }
    }
}