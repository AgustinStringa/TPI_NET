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
using ClientService.Subject;
using ClientService.Commission;
using ClientService.Course;
using ClientService.StudentCourse;


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
			administrative = (user as Administrative) != null;
			student = (user as Student) != null;
			InitializeComponent();
			var services = new ServiceCollection();
			services.AddHttpClient<IAreaService, AreaService>();
			services.AddHttpClient<ICurriculumService, CurriculumService>();
			services.AddHttpClient<ISubjectService, SubjectService>();
			services.AddHttpClient<IUserService, UserService>();
			services.AddHttpClient<IStudentService, StudentService>();
			services.AddHttpClient<IAdministrativeService, AdministrativeService>();
			services.AddHttpClient<ITeacherService, TeacherService>();
			services.AddHttpClient<ICommissionService, CommissionService>();
			services.AddHttpClient<ICourseService, CourseService>();
			services.AddHttpClient<IStudentCourseService, StudentCourseService>();
			this.serviceProvider = services.BuildServiceProvider();
			GetUser();
		}

		private async void GetUser()
		{
			ApplicationCore.Model.Student userIsStudent = null;
			ApplicationCore.Model.Administrative userIsAdministrative = null;
			ApplicationCore.Model.Teacher userIsTeacher = null;
			userIsStudent = await (this.serviceProvider.GetRequiredService<IStudentService>()).GetById(user.Id);
			if (userIsStudent == null)
			{
				userIsAdministrative = await ((this.serviceProvider.GetRequiredService<IAdministrativeService>()).GetById(user.Id));
			}
			else if (userIsAdministrative == null && userIsStudent == null)
			{
				userIsTeacher = await ((this.serviceProvider.GetRequiredService<ITeacherService>()).GetById(user.Id));
			}
			administrative = userIsAdministrative != null;
			student = userIsStudent != null;
			SetUpWindowToolStrips();
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

		private void SetUpWindowToolStrips()
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
		private void frmMain_Shown(object sender, EventArgs e)
		{

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
			FrmSubject appCurr = new FrmSubject(this.serviceProvider);
			appCurr.ShowDialog();

		}
		private async void inscripcionACursadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (student)
			{
				var userStudent = await (this.serviceProvider.GetRequiredService<IStudentService>()).GetById(user.Id);
				FrmStudentCourseInscription appInscripcionCursado = new FrmStudentCourseInscription(userStudent, serviceProvider);
				appInscripcionCursado.ShowDialog();
			}
		}


		private void administrarCursadosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmCourse frm = new FrmCourse(this.serviceProvider);
			frm.ShowDialog();
		}

		private async void cursadosActivosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (student)
			{
				var userStudent = await(this.serviceProvider.GetRequiredService<IStudentService>()).GetById(user.Id);
				FrmMyCourses frm = new FrmMyCourses(userStudent, serviceProvider);
				frm.ShowDialog();
			}

		}

		private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FrmUser frm = new FrmUser(this.serviceProvider);
			frm.ShowDialog();
		}

		private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmCommissions appCom = new FrmCommissions(serviceProvider);
			appCom.ShowDialog();
		}

		private void cargarNotasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QualifyCourses appQualifyCourses = new QualifyCourses(serviceProvider);
			appQualifyCourses.ShowDialog();
		}

		private async void estadoAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (student)
			{
				var userStudent = await(this.serviceProvider.GetRequiredService<IStudentService>()).GetById(user.Id);

				FrmAcademicStatus frmAcademicStatus = new FrmAcademicStatus(userStudent, serviceProvider);
				frmAcademicStatus.ShowDialog();
			}
		}
	}
}