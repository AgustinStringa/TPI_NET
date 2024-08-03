using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Curriculum;
using UI.Desktop.Area;
using Domain.Model;
namespace UI.Desktop
{
    public partial class frmMain : Form
    {
        private bool administrative = false;

        public frmMain(User user)
        {
            InitializeComponent();
            administrative = (user.UserType == 1);
        }

        public frmMain() {
            InitializeComponent();
        }


        private void frmSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            usuariosToolStripMenuItem.Visible = administrative;
            especialidadesToolStripMenuItem.Visible = administrative;
            planesDeEstudioToolStripMenuItem.Visible = administrative;
            profesoresToolStripMenuItem.Visible = administrative;
            //frmMain appLogin = new frmMain();
            //if (appLogin.ShowDialog() != DialogResult.OK)
            //{
            //    this.Dispose();
            //}
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreas appLogin = new frmAreas();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void planesDeEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurriculum appCurr = new frmCurriculum();
            if (appCurr.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearUsuario appUser = new frmCrearUsuario();
            if (appUser.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos appStudents = new frmAlumnos();
            if (appStudents.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
