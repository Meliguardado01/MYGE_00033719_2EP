using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Controlador;

namespace SourceCode.Modelo
{
    public class AdressDAO
    {
        public static List<Adress> getLista()
        {
            string sql = "select * from adress";

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<Adress> listAdress = new List<Adress>();
            foreach (DataRow fila in dt.Rows)
            {
                Adress ad = new Adress();
                ad.idadress =   fila[0].ToString();
                ad.iduser = fila[1].ToString();
                ad.address = fila[2].ToString();
              

                listAdress.Add(ad);
            }
            return listAdress;
        }

        public static void actualizarDireccion(string newadress , string adress)
        {
            string sql = String.Format(
                "update adress set address='{0}' where idadress ='{1}';",
                 newadress, adress);
                     
            ConexionDB.RealizarAccion(sql);
        }

        public static void crearNuevo(string iduser, string address)
        {
            string sql = String.Format(
                "insert into adress(iduser, address) " +
                "values('{0}', '{1}');" ,
                iduser, address);
            
            ConexionDB.RealizarAccion(sql);
        }
        
        
        public static void eliminar(string idadress)
        {
            string sql = String.Format(
                "delete from apporder where idadress ='{0}'; " +
                "delete from adress where idadress ='{0}';",
                idadress);
            
            ConexionDB.RealizarAccion(sql);
        }
        
        public static List<Adress> getListaAdress(string idur)
        {
            string sql = String.Format(
             "select ad.idadress, ad.address from adress ad where iduser = '{0}';",
             idur);
                            

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<Adress> listaAdress = new List<Adress>();
            foreach (DataRow fila in dt.Rows)
            {
                Adress a = new Adress();
                a.idadress =   fila[0].ToString();

                a.address = fila[1].ToString();
              

                listaAdress.Add(a);
            }
            return listaAdress;
        }
    }
}