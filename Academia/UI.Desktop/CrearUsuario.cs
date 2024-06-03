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
        private Entities.Area[] areas;
        public CrearUsuario()
        {
            InitializeComponent();
            //debería cargar los planes aqui??
            LoadAreas();
            cbCurriculums.Enabled = false;
            cbAreas.Enabled = false;
            
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
            if (rbtnUserStudent.Checked)
            {
                cbAreas.Enabled = true;
                cbAreas.Items.Clear();
                LoadAreas();
                cbAreas.SelectedIndex = 0;
                cbCurriculums.Enabled = true;
            }
            else
            {
                cbAreas.Enabled = false;
                cbCurriculums.Enabled = false;
                cbAreas.ResetText();
                cbCurriculums.ResetText();

            }
        }

        private void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbCurriculums.Enabled = true;

            lblOutput.Text = cbAreas.SelectedItem.ToString();
            lblOutput.Text = cbAreas.SelectedIndex.ToString();
            var area = areas[cbAreas.SelectedIndex];
            var curriculums = area.GetCurriculums();
            cbCurriculums.Items.Clear();
            foreach (var curr in curriculums)
            {
                cbCurriculums.Items.Add(curr.Description);
            }
            cbCurriculums.SelectedIndex = 0; // cant find a better solution 

        }

        private void cbCurriculums_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void rbtnUserTeacher_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnUserAdministrative_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadAreas() {
            Entities.Area isi = new Entities.Area("Sistemas");
            Entities.Area iq = new Entities.Area("Quimica");
            areas = [isi, iq];
            IList<string> areasDescription = [];
            foreach (var area in areas)
            {
                cbAreas.Items.Add(area.Description);
                //areasDescription.Add(area.Description);
            }
        }
    }
}
