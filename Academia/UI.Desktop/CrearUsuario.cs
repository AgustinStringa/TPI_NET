using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace UI.Desktop
{
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
            //debería cargar los planes aqui??
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string clave = mtbClave.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            var nuevoestudiante = new Entities.Student("stri24", "mypass", "correo@correo",
                "agusitn", "stringa", "san martin1763", "346715212", DateTime.Now, "51338");

            lblOutput.Text = nuevoestudiante.getDescription();
            lblOutput.Text = rbtnUserTeacher.Checked.ToString();

            //var nuevoUsuario = new Usuario(username, clave, nombre, apellido, email); ;

            //lblOutput.Text = nuevoUsuario.getDescription();
            //lblOutput.Text = nuevoUsuario.ToString();
        }

        private void rbtnUserStudent_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnUserStudent.Checked)
            {
                cbCurriculums.Enabled = true;
            } else
            {
                cbCurriculums.Enabled = false;

            }
        }
    }
}
