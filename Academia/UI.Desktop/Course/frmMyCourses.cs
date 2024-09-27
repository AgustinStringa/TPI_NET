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
	public partial class FrmMyCourses : Form
	{
		private UserCourseService _userCourseService;
		private ApplicationCore.Model.User user;
		private IEnumerable<ApplicationCore.Model.UserCourse> MyCourses;
		public FrmMyCourses(ApplicationCore.Model.User user)
		{
			InitializeComponent();
			this.user = user;
			this._userCourseService = new UserCourseService();
			LoadCourses();
		}

		private async void LoadCourses()
		{
			MyCourses = await _userCourseService.GetUserCoursesByUserId(this.user.Id);
			AdaptCoursesToListView(MyCourses);
		}
		private async void AdaptCoursesToListView(IEnumerable<ApplicationCore.Model.UserCourse> courses)
		{
			var service = new CommissionService();
			foreach (var item in MyCourses)
			{
				var commission = await service.GetById(item.Course.IdCommission);
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
