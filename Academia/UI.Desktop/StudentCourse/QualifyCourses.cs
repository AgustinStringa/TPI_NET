using ApplicationCore.Services;
using ClientService.Student;
using ClientService.StudentCourse;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
	public partial class QualifyCourses : Form
	{
		private IServiceProvider serviceProvider;
		private IStudentCourseService studentCourseService;
		private IEnumerable<ApplicationCore.Model.Student> students;
		private IStudentService studentService;
		public QualifyCourses(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.studentService = serviceProvider.GetRequiredService<IStudentService>();	
			this.studentCourseService = serviceProvider.GetRequiredService<IStudentCourseService>();
			LoadUsers();
		}

		private void AdaptUsersToListView(IEnumerable<ApplicationCore.Model.Student> students)
		{
			lstUsers.Items.Clear();
			foreach (ApplicationCore.Model.Student student in students)
			{
				ListViewItem item = new ListViewItem(student.Curriculum.Area.Description);
				item.Tag = student;
				item.SubItems.Add(student.Name + " " + student.Lastname);
				lstUsers.Items.Add(item);
			}
			lstUsers.Refresh();
		}
		private void AdaptUserCoursesToListView(IEnumerable<ApplicationCore.Model.StudentCourse> usersCourses)
		{
			lstUserCourses.Items.Clear();
			foreach (ApplicationCore.Model.StudentCourse userCourse in usersCourses)
			{
				ListViewItem item = new ListViewItem(userCourse.Course.Subject.Description);
				item.Tag = userCourse;
				item.SubItems.Add(userCourse.Course.Commission.Description);
				var grade = userCourse.Grade.ToString() != "" ? userCourse.Grade.ToString() : "-";
				item.SubItems.Add(grade);
				lstUserCourses.Items.Add(item);
			}
			lstUserCourses.Refresh();
		}

		private async void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstUsers.SelectedItems.Count == 1)
			{
				var selectedUser = lstUsers.SelectedItems[0].Tag as ApplicationCore.Model.Student;
				var usersCourses = await studentCourseService.GetByUserId(selectedUser.Id);
				AdaptUserCoursesToListView(usersCourses);
			}
		}


		private async void LoadUsers()
		{
			this.students = await studentService.GetAllAsync();
			AdaptUsersToListView(this.students);
		}

		private async void btnLoadGrade_Click(object sender, EventArgs e)
		{
			if (lstUserCourses.SelectedItems.Count == 1)
			{
				var selectedUserCourse = lstUserCourses.SelectedItems[0].Tag as ApplicationCore.Model.StudentCourse;

				int currentGrade = (int)(selectedUserCourse.Grade == null ? 0 : selectedUserCourse.Grade);
				var frmInputGrade = new FrmInputGrade(currentGrade);
				var result = frmInputGrade.ShowDialog();
				if (result == DialogResult.OK)
				{
					if (currentGrade != frmInputGrade._currentGrade)
					{
						
						CalificationCourse newCalification = new CalificationCourse
						{ 
						Grade = frmInputGrade._currentGrade,
						Status = frmInputGrade._currentGrade >= 6 ? "aprobado" : "reprobado"
						};
						await studentCourseService.QualifyCourse(selectedUserCourse.Id, newCalification);
						var selectedUser = lstUsers.SelectedItems[0].Tag as ApplicationCore.Model.Student;
						AdaptUserCoursesToListView(await studentCourseService.GetByUserId(selectedUser.Id));
					}

				}
			}
		}

		private void lstUserCourses_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (lstUserCourses.SelectedItems.Count == 1)
			{
				btnLoadGrade.Enabled = true;
			}
			else
			{
				btnLoadGrade.Enabled = false;
			}
		}
	}
}
