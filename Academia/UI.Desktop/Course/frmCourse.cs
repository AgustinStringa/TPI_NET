using ApplicationCore.Model;
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

namespace UI.Desktop.Course
{
	public partial class FrmCourse : Form
	{
		private IEnumerable<ApplicationCore.Model.Course> courses;
		public FrmCourse()
		{
			InitializeComponent();
			LoadCourses();
		}

		private async void LoadCourses()
		{
			var service = new ApplicationCore.Services.CourseService();
			this.courses = await service.GetAll();
			AdaptCoursesToListView(this.courses);
		}

		private void AdaptCoursesToListView(IEnumerable<ApplicationCore.Model.Course> coursesList)
		{
			lstvCourses.Items.Clear();
			foreach (ApplicationCore.Model.Course item in coursesList)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Subject.Curriculum.Description);
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Commission.Description);
				nuevoItem.SubItems.Add(item.Subject.Description);
				nuevoItem.SubItems.Add(item.CalendarYear);
				nuevoItem.SubItems.Add(item.Capacity.ToString());
				lstvCourses.Items.Add(nuevoItem);
			}
		}

		private void lstvAreas_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			var orderFilter = lstvCourses.Columns[e.Column].Tag.ToString();

			IEnumerable<ApplicationCore.Model.Course> orderedCourses = new List<ApplicationCore.Model.Course>();
			if (orderFilter == "Subject.Description")
			{
				orderedCourses = this.courses.ToList().OrderBy(c => c.Subject.Description);
			}
			else if (orderFilter == "Capacity")
			{
				orderedCourses = this.courses.ToList().OrderBy(c => c.Capacity);
			}
			else if (orderFilter == "CalendarYear")
			{
				orderedCourses = this.courses.ToList().OrderBy(c => c.CalendarYear);
			}
			AdaptCoursesToListView(orderedCourses);
		}

		private void tsbtnAddCourse_Click(object sender, EventArgs e)
		{
			FrmActionCourse frm = new FrmActionCourse(Mode.Create);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				this.LoadCourses();
			}
		}

		private void tsbtnEditCourse_Click(object sender, EventArgs e)
		{
			if (lstvCourses.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Course selectedCourse = (ApplicationCore.Model.Course)lstvCourses.SelectedItems[0].Tag;
				FrmActionCourse frm = new FrmActionCourse(Mode.Edit, selectedCourse);
				var result = frm.ShowDialog();
				if (result == DialogResult.OK)
				{
					this.LoadCourses();
				}
			}
		}

		private async void tsbtnRemoveCourse_Click(object sender, EventArgs e)
		{
			if (lstvCourses.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Course selectedCourse = (ApplicationCore.Model.Course)lstvCourses.SelectedItems[0].Tag;
				var service = new CourseService();
				await service.Delete(selectedCourse);
				this.LoadCourses();
			}
		}
	}
}
