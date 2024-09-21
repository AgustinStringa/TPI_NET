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
using UI.Desktop.Commission;
using Domain.Model;
using UI.Desktop.Subject;
using UI.Desktop.Course;
using UI.Desktop.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using ClientService;


namespace UI.Desktop
{
    public partial class FrmMain : Form
    {
        private bool administrative = false;
        private bool student = false;
        private Domain.Model.User user;

        public FrmMain(Domain.Model.User user)
        {
            this.user = user;
            administrative = (user.UserType == 1);
            student = (user.UserType == 3);
            InitializeComponent();
        }

        public FrmMain()
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
            crearUsuarioToolStripMenuItem.Visible = administrative;
            cursadosActivosToolStripMenuItem.Visible = student;
            materiasToolStripMenuItem.Visible = administrative;
            comisionesToolStripMenuItem.Visible = administrative;
            crearCursadoToolStripMenuItem.Visible = administrative;
            inscripcionACursadoToolStripMenuItem.Visible = student;
            cursadosActivosToolStripMenuItem.Visible = student;
            administrarCursadosToolStripMenuItem.Visible = administrative;
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            services.AddHttpClient<IAreaService, AreaService>(); 
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IAreaService>(); FrmArea appLogin = new FrmArea(service);
            appLogin.ShowDialog();

        }

        private void planesDeEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCurriculum appCurr = new FrmCurriculum();
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
            FrmSubject appCurr = new FrmSubject();
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

        private void cursadosActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyCourses frm = new frmMyCourses(user);
            frm.ShowDialog();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCommissions appCom = new frmCommissions();
            appCom.ShowDialog();

        }
    }
}