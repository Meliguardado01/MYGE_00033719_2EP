namespace Preparcial.Modelo
{
    public class Usuario
    {
        //CORRECCION: Se eliminaron setters innecesarios.
        public string IdUsuario { get; }

        public string NombreUsuario { get; }

        public string Contrasena { get; }

        public bool Admin { get; }

        public Usuario(string idUsuario, string nombreUsuario, string contrasenia, bool admin)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasenia;
            Admin = admin;
        }
    }
}
