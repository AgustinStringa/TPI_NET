using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UI.Desktop
{
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string clave = mtbClave.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            var nuevoUsuario = new Usuario(username, clave, nombre, apellido, email); ;

            lblOutput.Text = nuevoUsuario.getDescription();
            //lblOutput.Text = nuevoUsuario.ToString();
        }

    }
}
