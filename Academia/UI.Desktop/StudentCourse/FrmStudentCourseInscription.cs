using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore.Model;
namespace UI.Desktop
{
	public partial class FrmStudentCourseInscription : Form
	{
		private ApplicationCore.Model.User user;
		private IEnumerable<ApplicationCore.Model.Course> courses;
		private List<ApplicationCore.Model.Subject> subjects = new List<ApplicationCore.Model.Subject>();
		public FrmStudentCourseInscription(ApplicationCore.Model.User user)
		{
			this.user = user;
			InitializeComponent();
			LoadCourses();
		}
		private async void LoadCourses()
		{
			var courseService = new CourseService();
			this.courses = await courseService.GetAvailableCourses(user.Id);

			foreach (var course in this.courses)
			{
				if (course.Subject != null && !this.subjects.Contains(course.Subject))
				{
					this.subjects.Add(course.Subject);
				}
			}

			if (this.subjects.Count == 0)
			{
				MessageBox.Show("No hay materias disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Dispose();
				return;
			}

			cmbSubject.Items.Clear();
			cmbSubject.DataSource = this.subjects;
			cmbSubject.ValueMember = "Id";
			cmbSubject.DisplayMember = "Description";
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (cmbSubject.SelectedIndex != -1)
			{
				var selectedSubject = (cmbSubject.SelectedItem as ApplicationCore.Model.Subject);
				MessageBox.Show($"Info de la materia. \n Horas semanales: {selectedSubject.WeeklyHours} \n horas totales: {selectedSubject.TotalHours} \n", $"{selectedSubject.Description}", MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

		private void cmbSubjects_SelectedValueChanged(object sender, EventArgs e)
		{

			if (cmbSubject.SelectedItem == null)
			{
				return;
			}
			int subjectId = ((ApplicationCore.Model.Subject)(cmbSubject.SelectedItem)).Id;
			var filteredCourses = this.courses.Where(c => c.Subject.Id == subjectId);
			cmbCourse.DataSource = filteredCourses.ToList();
			cmbCourse.ValueMember = "Id";
			cmbCourse.DisplayMember = "ToStringProperty";
		}

		private async void btnInscription_Click(object sender, EventArgs e)
		{
			try
			{
				if (cmbCourse.SelectedItem == null || cmbSubject.SelectedItem == null)
				{
					MessageBox.Show("Debe seleccionar un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var userCourse = new ApplicationCore.Model.StudentCourse()
				{
					UserId = this.user.Id,
					CourseId = ((ApplicationCore.Model.Course)cmbCourse.SelectedItem).Id,
					Status = "inscripto"
				};

				var userCourseService = new ApplicationCore.Services.StudentCourseService();
				await userCourseService.Create(userCourse);

				MessageBox.Show("Inscripción realizada con éxito", "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


	}
}
