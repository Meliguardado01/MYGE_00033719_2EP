using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Controlador;

namespace SourceCode.Modelo
{
    public class AppUserDAO
    {
        public static List<AppUser> getLista()
        {
            string sql = "select * from appuser";

            DataTable dt = ConexionDB.RealizarConsulta(sql);

            List<AppUser> lista = new List<AppUser>();
            foreach (DataRow fila in dt.Rows)
            {
                AppUser us = new AppUser();
                us.iduser =   fila[0].ToString();
                us.fullname = fila[1].ToString();
                us.username = fila[2].ToString();
                us.password = fila[3].ToString();
                us.usertype = Convert.ToBoolean(fila[4].ToString());

                lista.Add(us);
            }
            return lista;
        }

        public static void actualizarContra(string username, string newpassword)
                 {
                     string sql = String.Format(
                         "update appuser set password='{0}' where iduser ='{1}';",
                         newpassword, username);
                     
                     ConexionDB.RealizarAccion(sql);
                 }

        public static void crearNuevo(string fullname, string username)
        {
            string sql = String.Format(
                "insert into appuser(fullname, username, password, usertype) " +
                "values('{0}', '{1}', '{2}', false);" ,
                fullname, username , Encriptador.CrearMD5(username));
            
            ConexionDB.RealizarAccion(sql);
        }
        
        
        public static void eliminar(string username)
        {
            string sql = String.Format(
                "delete from adress where iduser ='{0}'; " +
                "delete from appuser where iduser ='{0}';",
                username);
            
            ConexionDB.RealizarAccion(sql);
        }
    }
}