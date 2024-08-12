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
using UI.Desktop.Subject;
using UI.Desktop.Course;


namespace UI.Desktop
{
    public partial class frmMain : Form
    {
        private bool administrative = false;
        private bool student = false;
        private User user;

        public frmMain(User user)
        {
            this.user = user;
            administrative = (user.UserType == 1);
            student = (user.UserType == 3);
            InitializeComponent();
        }

        public frmMain()
        {
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
            crearUsuarioToolStripMenuItem.Visible = administrative;
            cursadosActivosToolStripMenuItem.Visible = student;
            materiasToolStripMenuItem.Visible = administrative;
            comisionesToolStripMenuItem.Visible = administrative;
            crearCursadoToolStripMenuItem.Visible = administrative;
            inscripcionACursadoToolStripMenuItem.Visible = student;
            cursadosActivosToolStripMenuItem.Visible = student;
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreas appLogin = new frmAreas();
            appLogin.ShowDialog();

        }

        private void planesDeEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurriculum appCurr = new frmCurriculum();
            appCurr.ShowDialog();

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearUsuario appUser = new frmCrearUsuario();
            appUser.ShowDialog();

        }


        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos appStudents = new frmAlumnos();
            appStudents.ShowDialog();



        }
        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateria appCurr = new frmMateria();
            appCurr.ShowDialog();

        }
        private void inscripcionACursadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInscripcionCursado appInscripcionCursado = new frmInscripcionCursado(this.user);
            appInscripcionCursado.ShowDialog();
        }

        private void administrarCursadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse frm = new frmCourse();
            frm.ShowDialog();
        }
    }
}