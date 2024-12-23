﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore.Model;
using ClientService.Course;
using ClientService.Subject;
using ClientService.StudentCourse;
using Microsoft.Extensions.DependencyInjection;
namespace UI.Desktop
{
	public partial class FrmStudentCourseInscription : Form
	{
		private ApplicationCore.Model.Student student;
		private IEnumerable<ApplicationCore.Model.Course> courses;
		private List<ApplicationCore.Model.Subject> subjects = new List<ApplicationCore.Model.Subject>();
		private ICourseService courseService;
		private ISubjectService subjectService;
		private IStudentCourseService studentCourseService;
		public FrmStudentCourseInscription(ApplicationCore.Model.Student student, IServiceProvider serviceProvider)
		{
			this.student = student;
			this.courseService = serviceProvider.GetRequiredService<ICourseService>();
			this.subjectService = serviceProvider.GetRequiredService<ISubjectService>();
			this.studentCourseService = serviceProvider.GetRequiredService<IStudentCourseService>();
			InitializeComponent();
			LoadCourses();
		}
		private async void LoadCourses()
		{
			this.courses = await courseService.GetAvailableCourses(student);
			this.subjects = this.courses.Select(c => c.Subject).DistinctBy(s => s.Description).ToList();
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
		private void btnShowDetails_Click(object sender, EventArgs e)
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
			var filteredCourses = this.courses.Where(c => c.IdSubject == subjectId);
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
					MessageBox.Show("Debe seleccionar un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				var studentCourse = new ApplicationCore.Model.StudentCourse()
				{
					UserId = this.student.Id,
					CourseId = ((ApplicationCore.Model.Course)cmbCourse.SelectedItem).Id,
					Status = "inscripto"
				};


				await studentCourseService.Create(studentCourse);

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
