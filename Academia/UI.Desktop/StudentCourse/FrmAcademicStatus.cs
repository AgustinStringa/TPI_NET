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
using ApplicationCore.Services;
using ClientService.Curriculum;
using ClientService.StudentCourse;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Desktop
{
	public partial class FrmAcademicStatus : Form
	{
		private IStudentCourseService studentCourse;
		private IEnumerable<AcademicStatusItem> academicStatus;
		private Student student;

		public FrmAcademicStatus(ApplicationCore.Model.Student student, IServiceProvider serviceProvider)
		{
			this.studentCourse = serviceProvider.GetRequiredService<IStudentCourseService>();
			this.student = student;
			InitializeComponent();
			lstAcademicStatus.Enabled = false;
			lblName.Text = $"{student.Name} {student.Lastname} ({student.StudentId}) a las  {DateTime.Now.ToString()}";
			LoadAcademicStatus();
		}

		public async void LoadAcademicStatus()
		{
			try
			{
				this.academicStatus = await studentCourse.GetAcademicStatus(this.student.Id);
				lstAcademicStatus.Items.Clear();
				foreach (AcademicStatusItem item in this.academicStatus)
				{
					var nuevo = new ListViewItem(item.SubjectDescription);
					nuevo.SubItems.Add(item.Condition);
					nuevo.SubItems.Add(item.Grade.ToString());
					nuevo.SubItems.Add(item.CalendarYear);
					nuevo.SubItems.Add(item.SubjectLevel.ToString());
					lstAcademicStatus.Items.Add(nuevo);
				}
				lstAcademicStatus.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				GetStatistics();
			}
		}

		public void GetStatistics()
		{
			int totatSubjects = academicStatus.Count();
			int passedSubjects = academicStatus.Count(item => item.Grade >= 6);
			int failedSubjects = academicStatus.Count(item => item.Grade < 6);

			double passedSubjectPerc = passedSubjects * 100 / totatSubjects;
			double failedSubjectPerc = failedSubjects * 100 / totatSubjects;

			lblCountPassedSubjects.Text = $"Materias Aprobadas: {passedSubjects.ToString()} ({passedSubjectPerc.ToString()} porciento)";
			lblCountFailedSubjects.Text = $"Materias Reprobadas: {failedSubjects.ToString()} ({failedSubjectPerc.ToString()} porciento)";
		}
	}
}
