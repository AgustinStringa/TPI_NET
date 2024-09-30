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
using ApplicationCore.Model;
using UI.Desktop.Subject;
using UI.Desktop.Course;
using UI.Desktop.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using ClientService;
using ClientService.Student;
using ClientService.Area;
using ClientService.Administrative;
using ClientService.Teacher;
using ClientService.Curriculum;


namespace UI.Desktop
{
    public partial class FrmMain : Form
	{
		private bool administrative = false;
		private bool student = false;
		private ApplicationCore.Model.User user;
		private ServiceProvider serviceProvider;
		public FrmMain(ApplicationCore.Model.User user)
		{
			this.user = user;
			
			administrative = user as Administrative != null;
			student = user as Student != null;
			InitializeComponent();
			var services = new ServiceCollection();
			services.AddHttpClient<IAreaService, AreaService>();
			services.AddHttpClient<ICurriculumService, CurriculumService>();
			services.AddHttpClient<IUserService, UserService>();
			services.AddHttpClient<IStudentService, StudentService>();
			services.AddHttpClient<IAdministrativeService, AdministrativeService>();
			services.AddHttpClient<ITeacherService, TeacherService>();
			this.serviceProvider = services.BuildServiceProvider();
		}

		//TO DO: only for develop, remove in production
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
			cursadosActivosToolStripMenuItem.Visible = student;
			materiasToolStripMenuItem.Visible = administrative;
			comisionesToolStripMenuItem.Visible = administrative;
			inscripcionACursadoToolStripMenuItem.Visible = student;
			cursadosActivosToolStripMenuItem.Visible = student;
			administrarCursadosToolStripMenuItem.Visible = administrative;
			cargarNotasToolStripMenuItem.Visible = administrative;
			estadoAcademicoToolStripMenuItem.Visible = student;
		}
		private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmArea appLogin = new FrmArea(this.serviceProvider);
			appLogin.ShowDialog();
		}


		private void planesDeEstudioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmCurriculum appCurr = new FrmCurriculum(this.serviceProvider);
			appCurr.ShowDialog();
		}


		private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmActionUser appUser = new FrmActionUser(Mode.Create, this.serviceProvider);
			appUser.ShowDialog();
		}

		private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmSubject appCurr = new FrmSubject();
			appCurr.ShowDialog();

		}
		private void inscripcionACursadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmUserCourseInscription appInscripcionCursado = new FrmUserCourseInscription(this.user);
			appInscripcionCursado.ShowDialog();
		}


		private void administrarCursadosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmCourse frm = new FrmCourse();
			frm.ShowDialog();
		}

		private void cursadosActivosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmMyCourses frm = new FrmMyCourses(user);
			frm.ShowDialog();
		}

		private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FrmUser frm = new FrmUser(this.serviceProvider);
			frm.ShowDialog();
		}

		private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmCommissions appCom = new FrmCommissions();
			appCom.ShowDialog();
		}

		private void cargarNotasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QualifyCourses appQualifyCourses = new QualifyCourses();
			appQualifyCourses.ShowDialog();
		}

		private void estadoAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (user.GetType() == (new Student()).GetType())
			{
				FrmAcademicStatus frmAcademicStatus = new FrmAcademicStatus((Student)user);
				frmAcademicStatus.ShowDialog();
			}
		}
	}
}