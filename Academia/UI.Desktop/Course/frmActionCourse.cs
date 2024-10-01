using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService.Area;
using ClientService.Commission;
using ClientService.Course;
using ClientService.Curriculum;
using ClientService.Subject;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace UI.Desktop.Course
{
	public partial class FrmActionCourse : Form
	{

		private List<ApplicationCore.Model.Teacher> selectedTeachers = new List<ApplicationCore.Model.Teacher>();
		private Mode mode;
		private ApplicationCore.Model.Course course;
		public ApplicationCore.Model.Teacher newTeacher;
		private IServiceProvider serviceProvider;
		private IAreaService areaService;
		private ICurriculumService curriculumService;
		private ISubjectService subjectService;
		private ICommissionService commissionService;
		private ICourseService courseService;

		public FrmActionCourse(Mode mode, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.mode = mode;
				this.serviceProvider = serviceProvider;
				GetServices(this.serviceProvider);
				this.Text = "Crear Curso";
				btnActionCourse.Text = "Crear Curso";
				LoadAreas();
			}
			else
			{
				this.Dispose();
			}

		}

		public FrmActionCourse(Mode mode, ApplicationCore.Model.Course course, IServiceProvider serviceProvider)
		{
			if (this.mode == Mode.Edit)
			{
				InitializeComponent();
				this.mode = mode;
				this.serviceProvider = serviceProvider;
				GetServices(this.serviceProvider);
				this.course = course;
				this.Text = "Editar Curso";
				btnActionCourse.Text = "Guardar Curso";
				txtCapacity.Text = course.Capacity.ToString();
				txtCalendarYear.Text = course.CalendarYear.ToString();
				this.selectedTeachers = course.Teachers.ToList();
				LoadAreas();
				this.FillSelectedTeachers();
			}
		}

		private void GetServices(IServiceProvider serviceProvider)
		{
			this.areaService = serviceProvider.GetRequiredService<IAreaService>();
			this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
			this.subjectService = serviceProvider.GetRequiredService<ISubjectService>();
			this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
			this.courseService = serviceProvider.GetRequiredService<ICourseService>();
		}

		private async void btnActionCourse_Click(object sender, EventArgs e)
		{
			int capacity;
			bool validCapacity = false;
			try
			{

				int.TryParse(txtCapacity.Text, out capacity);
				validCapacity = validateCapacity(capacity);

			}
			catch (Exception)
			{
				throw;
			}

			var calendarYear = txtCalendarYear.Text.Trim();
			var validCalendarYear = validateCalendarYear(calendarYear);

			var selectedSubejct = (ApplicationCore.Model.Subject)cmbSubjects.SelectedItem;
			var validSubject = validateSubject(selectedSubejct);


			var selectedCommission = (ApplicationCore.Model.Commission)cmbComissions.SelectedItem;
			var validCommission = validateCommission(selectedCommission);


			if (validCapacity && validCalendarYear && validCommission && validSubject)
			{


				if (this.mode == Mode.Create)
				{
					try
					{
						var newCourse = new ApplicationCore.Model.Course
						{
							CalendarYear = calendarYear,
							Capacity = capacity,
							IdCommission = selectedCommission.Id,
							IdSubject = selectedSubejct.Id,
						};
						if (this.selectedTeachers.Count > 0)
						{
							newCourse.Teachers = this.selectedTeachers;
						}
						await courseService.CreateAsync(newCourse);
						MessageBox.Show("Cursado creado exitosamente", "Crear Cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					catch (Exception)
					{
						MessageBox.Show("Error al crear cursado", "Crear Cursado", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw;
					}

				}
				else if (this.mode == Mode.Edit)
				{

					try
					{
						/*probando con un objeto nuevo por las colecciones populadas*/
						var courseToUpdate = new ApplicationCore.Model.Course
						{
							Id = this.course.Id,
							CalendarYear = calendarYear,
							Capacity=capacity,
							IdCommission = selectedCommission.Id,
							IdSubject = selectedSubejct.Id,
							Teachers = this.selectedTeachers,
						};

						//this.course.Capacity = capacity;
						//this.course.CalendarYear = calendarYear;
						//this.course.IdCommission = selectedCommission.Id;
						//this.course.IdSubject = selectedSubejct.Id;
						//this.course.Teachers = this.selectedTeachers;
						await courseService.UpdateAsync(courseToUpdate);
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					catch (Exception)
					{
						MessageBox.Show("Error al actualizar cursado", "Crear Cursado", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw;
					}

				}
			}
			//SI se esta creando validar que no exista ya un cursado para esa materia, esa comision y ese año calendario 
		}

		private async void cmbAreas_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbAreas.SelectedIndex != -1)
			{
				ApplicationCore.Model.Area selectedArea = (ApplicationCore.Model.Area)cmbAreas.SelectedItem;
				var curriculums = await curriculumService.GetAllByAreaId(selectedArea.Id);

				if (curriculums.Count() > 0)
				{
					cmbCurriculums.DataSource = curriculums;
					cmbCurriculums.ValueMember = "Id";
					cmbCurriculums.DisplayMember = "Description";
					if (this.mode == Mode.Edit)
					{
						cmbCurriculums.SelectedValue = course.Subject.IdCurriculum;
					}
					else
					{
						cmbCurriculums.SelectedIndex = 0;
					}
				}
				else
				{
					cmbCurriculums.DataSource = null;
				}
			}
			else
			{
				cmbCurriculums.DataSource = null;
			}
		}

		private async void cmbCurriculums_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbCurriculums.SelectedIndex != -1)
			{
				ApplicationCore.Model.Curriculum selectedCurriculum = (ApplicationCore.Model.Curriculum)cmbCurriculums.SelectedItem;
				var subjects = await subjectService.GetAllByCurriculumId(selectedCurriculum.Id);

				if (subjects.Count() > 0)
				{
					cmbSubjects.DataSource = subjects;
					cmbSubjects.ValueMember = "Id";
					cmbSubjects.DisplayMember = "Description";
					if (this.mode == Mode.Edit)
					{
						cmbSubjects.SelectedValue = course.IdSubject;
					}
					else
					{
						cmbSubjects.SelectedIndex = 0;
					}
				}
				else
				{
					cmbSubjects.DataSource = null;
				}
			}
			else
			{
				cmbSubjects.DataSource = null;
				cmbComissions.DataSource = null;
			}
		}

		private async void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (cmbSubjects.SelectedIndex != -1 && cmbCurriculums.SelectedIndex != -1)
			{
				ApplicationCore.Model.Curriculum selectedCurriculum = (ApplicationCore.Model.Curriculum)cmbCurriculums.SelectedItem;
				ApplicationCore.Model.Subject selectedSubject = (ApplicationCore.Model.Subject)cmbSubjects.SelectedItem;
				var commissions = await commissionService.GetAllByCurriculumIdAndLevel(selectedCurriculum.Id, selectedSubject.Level);
				if (commissions.Count() > 0)
				{
					cmbComissions.DataSource = commissions;
					cmbComissions.ValueMember = "Id";
					cmbComissions.DisplayMember = "Description";
					if (this.mode == Mode.Edit)
					{
						cmbComissions.SelectedValue = course.IdCommission;
					}
					else
					{
						cmbComissions.SelectedIndex = 0;
					}
				}
				else
				{
					cmbComissions.DataSource = null;
				}
			}
			else
			{
				cmbComissions.DataSource = null;
			}
		}

		private bool validateCapacity(int capacity)
		{
			if (capacity > 0)
			{
				lblCapacityError.Visible = false;
				return true;

			}
			lblCapacityError.Visible = true;
			return false;
		}

		private bool validateCalendarYear(string calendarYear)
		{
			if (!String.IsNullOrEmpty(calendarYear))
			{
				lblCalendarYearError.Visible = false;
				return true;
			}
			lblCalendarYearError.Visible = true;
			return false;
		}

		private bool validateCommission(ApplicationCore.Model.Commission commission)
		{
			if (commission != null)
			{
				return true;
			}
			return false;
		}

		private bool validateSubject(ApplicationCore.Model.Subject subject)
		{
			if (subject != null)
			{
				return true;
			}
			return false;
		}

		private async void btnAddTeacher_Click(object sender, EventArgs e)
		{
			var service = new TeacherService();
			var teachers = await service.GetAll();
			var teacherlist = new FrmTeachersList(teachers, this);
			var result = teacherlist.ShowDialog();
			if (result == DialogResult.OK)
			{
				var exists = this.selectedTeachers.Any(t => t.Id == newTeacher.Id);
				if (newTeacher != null && !exists)
				{
					this.selectedTeachers.Add(newTeacher);
					FillSelectedTeachers();
				}

			}
		}

		private void FillSelectedTeachers()
		{
			lstSelectedTeachers.Items.Clear();
			foreach (var item in this.selectedTeachers)
			{
				ListViewItem newItem = new ListViewItem(item.Name + " " + item.Lastname);
				newItem.Tag = item;
				lstSelectedTeachers.Items.Add(newItem);
			}
			lstSelectedTeachers.Refresh();
		}

		private void btnDeleteTeacher_Click(object sender, EventArgs e)
		{
			if (lstSelectedTeachers.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Student teacherToDelete = (ApplicationCore.Model.Student)lstSelectedTeachers.SelectedItems[0].Tag;
				this.selectedTeachers = this.selectedTeachers.Where(t => t.Id != teacherToDelete.Id).ToList();
				FillSelectedTeachers();
			}
		}

		private async void LoadAreas()
		{
			if (this.mode == Mode.Create)
			{
				Utilities.AdaptAreasToCb(cmbAreas, await areaService.GetAllAsync());
			}
			else if (this.mode == Mode.Edit)
			{
				Utilities.AdaptAreasToCb(cmbAreas, await areaService.GetAllAsync(), course.Subject.Curriculum.AreaId);
			}
		}
	}
}
