using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService.Commission;
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

namespace UI.Desktop.Course
{
	public partial class FrmMyCourses : Form
	{
		private IStudentCourseService userCourseService;
		private ICommissionService commissionService;
		private ApplicationCore.Model.Student student;
		private IEnumerable<ApplicationCore.Model.StudentCourse> MyCourses;
		public FrmMyCourses(ApplicationCore.Model.Student student, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.student = student;
			this.userCourseService = serviceProvider.GetRequiredService<IStudentCourseService>();
			this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
			LoadCourses();
		}

		private async void LoadCourses()
		{
			MyCourses = await userCourseService.GetByUserId(this.student.Id);
			AdaptCoursesToListView(MyCourses);
		}
		private async void AdaptCoursesToListView(IEnumerable<ApplicationCore.Model.StudentCourse> courses)
		{
			foreach (var item in MyCourses)
			{
				var commission = await commissionService.GetById(item.Course.IdCommission);
				ListViewItem nuevoItem = new ListViewItem(commission.Description);
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Course.Subject.Description);
				nuevoItem.SubItems.Add(item.Course.CalendarYear);
				nuevoItem.SubItems.Add(item.Course.Subject.Level.ToString());
				lstvMyCourses.Items.Add(nuevoItem);
			}
		}
	}
}
