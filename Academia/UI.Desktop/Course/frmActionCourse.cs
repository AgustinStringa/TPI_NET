using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService.Area;
using ClientService.Commission;
using ClientService.Course;
using ClientService.Curriculum;
using ClientService.Subject;
using ClientService.Teacher;
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
		private ITeacherService teacherService;
		private bool updatingCbAreas;
		private bool updatingCbCurriculums;
		private bool updatingCbSubjects;
		private bool updatingCbCommissions;

		public FrmActionCourse(Mode mode, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.mode = mode;
				this.serviceProvider = serviceProvider;
				GetServices(this.serviceProvider);
				this.Text = "Crear Curso";
				lblTitle.Text = "Crear Curso";
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
				lblTitle.Text = "Editar Curso";
				btnActionCourse.Text = "Guardar Curso";
				txtCapacity.Text = course.Capacity.ToString();
				txtCalendarYear.Text = course.CalendarYear.ToString();
				this.selectedTeachers = course.Teachers.ToList();
				LoadComboboxes();
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
			this.teacherService = serviceProvider.GetRequiredService<ITeacherService>();
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


			var selectedCommission = (ApplicationCore.Model.Commission)cmbCommissions.SelectedItem;
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
						this.course.Capacity = capacity;
						this.course.CalendarYear = calendarYear;
						this.course.IdCommission = selectedCommission.Id;
						this.course.IdSubject = selectedSubejct.Id;
						this.course.Teachers.Clear();
						foreach (var item in this.selectedTeachers)
						{
							var newTeacher = await teacherService.GetById(item.Id);
							this.course.Teachers.Add(newTeacher);
						}
						this.course.Commission = null;
						this.course.Subject = null;
						await courseService.UpdateAsync(this.course);
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
			if (!updatingCbAreas)
			{

				if (cmbAreas.SelectedIndex != -1)
				{
					try
					{
						updatingCbCurriculums = true;
						var curriculums = await curriculumService.GetAllByAreaId(((ApplicationCore.Model.Area)(cmbAreas.SelectedItem)).Id);
						cmbCurriculums.DataSource = curriculums;
						cmbCurriculums.ValueMember = "Id";
						cmbCurriculums.DisplayMember = "Description";
					}
					finally
					{
						cmbCurriculums.SelectedIndex = -1;
						updatingCbCurriculums = false;
						if (cmbCurriculums.Items.Count > 0)
						{
							cmbCurriculums.SelectedIndex = 0;
						}
						else
						{
							cmbCurriculums.DataSource = null;
							cmbSubjects.DataSource = null;
							cmbCommissions.DataSource = null;
						}
					}
				}
				else
				{
					cmbCurriculums.DataSource = null;
				}
			}
		}

		private async void cmbCurriculums_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingCbCurriculums)
			{
				if (cmbCurriculums.SelectedIndex != -1)
				{
					try
					{
						updatingCbSubjects = true;
						var subjects = await subjectService.GetAllByCurriculumId(((ApplicationCore.Model.Curriculum)(cmbCurriculums.SelectedItem)).Id);
						cmbSubjects.DataSource = subjects;
						cmbSubjects.ValueMember = "Id";
						cmbSubjects.DisplayMember = "Description";
					}
					finally
					{
						cmbSubjects.SelectedIndex = -1;
						updatingCbSubjects = false;

						if (cmbSubjects.Items.Count > 0)
						{
							cmbSubjects.SelectedIndex = 0;
						}
						else
						{
							cmbSubjects.DataSource = null;
							cmbCommissions.DataSource = null;
						}
					}
				}
				else
				{
					cmbSubjects.DataSource = null;
				}
			}
		}

		private async void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!updatingCbSubjects)
			{
				if (cmbCurriculums.SelectedIndex != -1 && cmbSubjects.SelectedIndex != -1)
				{
					try
					{
						var commissions = await commissionService.GetAllByCurriculumIdAndLevel(((ApplicationCore.Model.Curriculum)(cmbCurriculums.SelectedItem)).Id
							, ((ApplicationCore.Model.Subject)(cmbSubjects.SelectedItem)).Level
							);
						cmbCommissions.DataSource = commissions;
						cmbCommissions.ValueMember = "Id";
						cmbCommissions.DisplayMember = "Description";
						if (commissions.Count() > 0)
						{
							cmbCommissions.SelectedIndex = 0;
						}
						else
						{
							cmbCommissions.DataSource = null;
						}
					}
					finally
					{
					}
				}
				else
				{
					cmbCommissions.DataSource = null;
				}
			}
		}

		private bool validateCapacity(int capacity)
		{
			if (capacity > 0)
			{
				Utilities.SetDefaultStyle(lblCapacity, txtCapacity);
				lblCapacityError.Visible = false;
				return true;

			}
			Utilities.SetErrorStyle(lblCapacity, txtCapacity);
			lblCapacityError.Visible = true;
			this.lblCapacityError.ForeColor = Color.FromArgb(220, 53, 69);
			return false;
		}

		private bool validateCalendarYear(string calendarYear)
		{
			if (!String.IsNullOrEmpty(calendarYear))
			{
				Utilities.SetDefaultStyle(lblCalendarYear, txtCalendarYear);
				lblCalendarYearError.Visible = false;
				return true;
			}
			Utilities.SetErrorStyle(lblCalendarYear, txtCalendarYear);
			lblCalendarYearError.Visible = true;
			this.lblCalendarYearError.ForeColor = Color.FromArgb(220, 53, 69);
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
			var teachers = await teacherService.GetAllAsync();
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
			Utilities.AdaptAreasToCb(cmbAreas, await areaService.GetAllAsync());
		}

		private async void LoadComboboxes()
		{
			IEnumerable<ApplicationCore.Model.Area> areas = [];
			IEnumerable<ApplicationCore.Model.Curriculum> curriculums = [];
			IEnumerable<ApplicationCore.Model.Subject> subjects = [];
			IEnumerable<ApplicationCore.Model.Commission> commissions = [];

			try
			{
				updatingCbAreas = true;
				updatingCbCurriculums = true;
				updatingCbSubjects = true;
				updatingCbCommissions = true;

				areas = await areaService.GetAllAsync();
				cmbAreas.DataSource = areas;
				//al modificar prop DataSource -> se lanza evento selectedindexchange
				cmbAreas.DisplayMember = "Description";
				cmbAreas.ValueMember = "Id";
				cmbAreas.SelectedValue = this.course.Subject.Curriculum.AreaId;

				curriculums = await curriculumService.GetAllByAreaId(this.course.Subject.Curriculum.AreaId);
				cmbCurriculums.DataSource = curriculums;
				cmbCurriculums.DisplayMember = "Description";
				cmbCurriculums.ValueMember = "Id";
				cmbCurriculums.SelectedValue = this.course.Subject.IdCurriculum;

				subjects = await subjectService.GetAllByCurriculumId(this.course.Subject.IdCurriculum);
				cmbSubjects.DataSource = subjects;
				cmbSubjects.DisplayMember = "Description";
				cmbSubjects.ValueMember = "Id";
				cmbSubjects.SelectedValue = this.course.IdSubject;

				commissions = await commissionService.GetAllByCurriculumIdAndLevel(this.course.Subject.IdCurriculum, this.course.Commission.Level);
				cmbCommissions.DataSource = commissions;
				cmbCommissions.DisplayMember = "Description";
				cmbCommissions.ValueMember = "Id";
				cmbCommissions.SelectedValue = this.course.Commission.Id;
			}
			finally
			{
				updatingCbAreas = false;
				updatingCbCurriculums = false;
				updatingCbSubjects = false;
				updatingCbCommissions = false;
			}
		}
	}
}
