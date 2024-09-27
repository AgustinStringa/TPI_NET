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

namespace UI.Desktop
{
	public partial class QualifyCourses : Form
	{
		private IEnumerable<ApplicationCore.Model.User> students;
		public QualifyCourses()
		{
			InitializeComponent();
			LoadUsers();
			//Cargar alumnos con su plan de estudio y su especialidad
		}

		private void AdaptUsersToListView(IEnumerable<ApplicationCore.Model.User> users)
		{
			lstUsers.Items.Clear();
			foreach (ApplicationCore.Model.User user in users)
			{
				ListViewItem item = new ListViewItem(user.Curriculum.Area.Description);
				item.Tag = user;
				item.SubItems.Add(user.Name + " " + user.Name);
				lstUsers.Items.Add(item);
			}
			lstUsers.Refresh();
		}
		private void AdaptUserCoursesToListView(IEnumerable<ApplicationCore.Model.UserCourse> usersCourses)
		{
			lstUserCourses.Items.Clear();
			foreach (ApplicationCore.Model.UserCourse userCourse in usersCourses)
			{
				ListViewItem item = new ListViewItem(userCourse.Course.Subject.Description);
				item.Tag = userCourse;
				item.SubItems.Add(userCourse.Course.Commission.Description);
				var grade = userCourse.Grade.ToString() != null ? userCourse.Grade.ToString() : "-";
				item.SubItems.Add(grade);
				lstUserCourses.Items.Add(item);
			}
			lstUserCourses.Refresh();
		}

		private async void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			//get selected users
			if (lstUsers.SelectedItems.Count == 1)
			{
				var selectedUser = lstUsers.SelectedItems[0].Tag as ApplicationCore.Model.User;
				UserCourseService service = new UserCourseService();
				var usersCourses = await service.GetUserCoursesByUserId(selectedUser.Id);
				AdaptUserCoursesToListView(usersCourses);
			}
		}

		private void lstUserCourses_SelectedIndexChanged(object sender, EventArgs e)
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

		private async void LoadUsers()
		{
			var service = new UserService();
			this.students = await service.GetStudents();
			AdaptUsersToListView(this.students);
		}

		private async void btnLoadGrade_Click(object sender, EventArgs e)
		{
			if (lstUserCourses.SelectedItems.Count == 1)
			{
				var selectedUserCourse = lstUserCourses.SelectedItems[0].Tag as ApplicationCore.Model.UserCourse;

				int currentGrade = (int)(selectedUserCourse.Grade == null ? 0 : selectedUserCourse.Grade);
				var frmInputGrade = new FrmInputGrade(currentGrade);
				var result = frmInputGrade.ShowDialog();
				if (result == DialogResult.OK)
				{
					if (currentGrade != frmInputGrade._currentGrade)
					{
						var userCourseService = new UserCourseService();
						selectedUserCourse.Grade = frmInputGrade._currentGrade;
						await userCourseService.Update(selectedUserCourse);
						var selectedUser = lstUsers.SelectedItems[0].Tag as ApplicationCore.Model.User;
						AdaptUserCoursesToListView(await new UserCourseService().GetUserCoursesByUserId(selectedUser.Id));
					}

				}
			}
		}

	}
}
