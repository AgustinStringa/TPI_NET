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
		private IStudentCourseService studentCourseService;
		private ICommissionService commissionService;
		private ApplicationCore.Model.Student student;
		private IEnumerable<ApplicationCore.Model.StudentCourse> MyCourses;
		public FrmMyCourses(ApplicationCore.Model.Student student, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.student = student;
			this.studentCourseService = serviceProvider.GetRequiredService<IStudentCourseService>();
			this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
			LoadCourses();
		}

		private async void LoadCourses()
		{
			try
			{
				lstvMyCourses.Items.Clear();
				MyCourses = (await studentCourseService.GetByUserId(this.student.Id)).Where(sc => sc.Grade == null);
				AdaptCoursesToListView(MyCourses);
				lstvMyCourses.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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

		private async void btnCancelInscription_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstvMyCourses.SelectedItems.Count > 0)
				{
					if (Utilities.ConfirmDelete("este cursado") != DialogResult.OK) return;
					var selectedCourse = (StudentCourse)lstvMyCourses.SelectedItems[0].Tag;
					await this.studentCourseService.Delete(selectedCourse.Id);
					MessageBox.Show("Inscripcion a cursado eliminada", "Eliminar inscripcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.LoadCourses();
				}
				else
				{
					MessageBox.Show("Selecciona un cursado", "Eliminar Cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
