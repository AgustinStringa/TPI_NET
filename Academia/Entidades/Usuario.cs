namespace Entidades
{
    public class Usuario
    {
        private string _Nombre;
        private string _Apellido;
        private string _Clave;
        private string _Email;
        private bool _Habilitado;
        private string _NombreUsuario;


        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }




        public Usuario(string nombreUsuario, string clave, string nombre, string apellido, string email) { 
            _NombreUsuario = nombreUsuario;
            _Clave = clave;
            _Nombre = nombre;
            _Apellido = apellido;
            _Email = email;
            _Habilitado = true;
        }

        public string getDescription() {
            string description = "";
            description += _Nombre+" ";
            description += _Apellido+" ";
            description += _NombreUsuario+" ";
            description += _Email+" ";

            return description;
        }
    }
}
