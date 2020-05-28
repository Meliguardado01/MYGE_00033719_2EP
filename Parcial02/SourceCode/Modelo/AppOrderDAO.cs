using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Modelo
{
    public class AppOrderDAO
    {
        public static List<AppOrder> getLista()
        {
            string sql = "select * from apporder";

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<AppOrder> listOrders = new List<AppOrder>();
            foreach (DataRow fila in dt.Rows)
            {
                AppOrder ap = new AppOrder();
                ap.idorder =   fila[0].ToString();
                ap.createdate = Convert.ToDateTime(fila[1].ToString());
                ap.idproduct = fila[2].ToString();
                ap.idadress = fila[3].ToString();
              

                listOrders.Add(ap);
            }
            return listOrders;
        }

    

            public static void crearNuevo(string Fecha, string idproduct, string idaddress)
                   {
                       string sql = String.Format(
                           "insert into apporder(createDate,idproduct,idadress) " +
                           "values('{0}','{1}','{2}');" ,
                           Fecha,idproduct,idaddress);
                           
                       ConexionDB.RealizarAccion(sql);
                   }
          
       
        
        
        public static void eliminar(string idorder)
        {
            string sql = String.Format(
               
                "delete from apporder where idorder ='{0}';",
                idorder);
            
            ConexionDB.RealizarAccion(sql);
        }
        
        public static List<AppOrder> getListaAppOrder(string iduser)
        {
            string sql = String.Format(
                "SELECT ao.idorder, ao.createdate, pr.name, au.fullname, ad.address " +
                "FROM APPORDER ao, ADRESS ad, PRODUCT pr, APPUSER au " +
                $"WHERE ao.idproduct =pr.idproduct " +
                $"AND ao.idadress =ad.idadress " +
                $"AND ad.iduser =au.iduser " +
                $"AND au.iduser ='{0}'; ", iduser);
                
                            

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<AppOrder> listaAppOrders = new List<AppOrder>();
            foreach (DataRow fila in dt.Rows)
            {
                AppOrder qp = new AppOrder();
                qp.idorder = fila[0].ToString();
                qp.createdate = Convert.ToDateTime(fila[1].ToString());
                qp.idproduct = fila[2].ToString();
                qp.idadress =fila[3].ToString();
                
                
                listaAppOrders.Add(qp);
            }
            return listaAppOrders;
        }
    }
}