using ApplicationCore.Model;
using ApplicationCore.Services;
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
using UI.Desktop.Curriculum;

namespace UI.Desktop.Subject
{

	public partial class FrmActionSubject : Form
	{

		#region Fields
		private ApplicationCore.Model.Subject subject;
		private IEnumerable<ApplicationCore.Model.Curriculum> curriculums;
		private Mode Mode;
		private ICurriculumService curriculumService;
		private ISubjectService subjectService;
		private IServiceProvider serviceProvider;
		#endregion

		#region Constructors
		public FrmActionSubject(Mode mode, ApplicationCore.Model.Subject subj, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Edit)
			{
				InitializeComponent();
				subject = subj;
				btnAccept.Text = "Guardar Materia";
				this.Text = "Editar Materia";
				this.Mode = mode;
				this.serviceProvider = serviceProvider;
				this.subjectService = serviceProvider.GetRequiredService<ISubjectService>();
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();

				LoadCurriculums();
				txtDescription.Text = subject.Description;
				txtTotalHours.Text = subject.TotalHours.ToString();
				txtWeeklyHours.Text = subject.WeeklyHours.ToString();
				numLevel.Value = subject.Level;
				//LoadCorrelatives();
			}
			else
			{
				this.Dispose();
			}
		}
		public FrmActionSubject(Mode mode, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.Mode = mode;
				this.serviceProvider = serviceProvider;
				this.subjectService = serviceProvider.GetRequiredService<ISubjectService>();
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
				btnAccept.Text = "Crear Materia";
				this.Text = "Crear Materia";
				LoadCurriculums();
			}
			else
			{
				this.Dispose();
			}

			this.serviceProvider = serviceProvider;
		}
		#endregion

		#region Methods

		private async void LoadCurriculums()
		{
			if (this.Mode == Mode.Create)
			{
				Utilities.AdaptCurriculumsToCb(cbCurriculums, await curriculumService.GetAll());
			}
			else if (this.Mode == Mode.Edit)
			{
				Utilities.AdaptCurriculumsToCb(cbCurriculums, await curriculumService.GetAll(), subject.IdCurriculum);
			}
		}
		private void LoadCorrelatives()
		{
			lstCorrelativesChildren.Items.Clear();
			lstCorrelativesParent.Items.Clear();
			foreach (ApplicationCore.Model.Correlative item in subject.CorrelativesChildren)
			{
				lstCorrelativesChildren.Items.Add(new ListBoxItem { DisplayText = item.CorrelativeSubject.Description, Tag = item });
			}
			foreach (ApplicationCore.Model.Correlative item in subject.CorrelativesParents)
			{
				lstCorrelativesParent.Items.Add(new ListBoxItem { DisplayText = item.Subject.Description, Tag = item });
			}
		}
		#endregion

		#region Events
		private async void btnAccept_Click(object sender, EventArgs e)
		{
			try
			{
				string description = txtDescription.Text.Trim();
				int totalHours = int.Parse(txtTotalHours.Text.Trim());
				int weeklyHours = int.Parse(txtWeeklyHours.Text.Trim());
				int level = (int)numLevel.Value;
				ApplicationCore.Model.Curriculum curriculum = (ApplicationCore.Model.Curriculum)cbCurriculums.SelectedItem;
				switch (Mode)
				{
					case Mode.Edit:
						try
						{
							subject.Description = description;
							subject.TotalHours = totalHours;
							subject.WeeklyHours = weeklyHours;
							subject.Level = level;
							subject.IdCurriculum = curriculum.Id;
							await subjectService.Update(new ApplicationCore.Model.Subject
							{
								Description = description,
								TotalHours = totalHours,
								WeeklyHours = weeklyHours,
								Level = level,
								IdCurriculum = curriculum.Id,
								Id = subject.Id
							});
							MessageBox.Show("Materia actualizada correctamente", "Editar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
							DialogResult = DialogResult.OK;
							this.Close();
							break;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message ?? "Error al actualizar la materia", "Actualizar Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}
					case Mode.Create:
						try
						{
							var newSubject = new ApplicationCore.Model.Subject
							{
								Description = description,
								TotalHours = totalHours,
								WeeklyHours = weeklyHours,
								Level = level,
								IdCurriculum = curriculum.Id,
							};
							await subjectService.Create(newSubject);
							MessageBox.Show("Materia creada correctamente", "Crear Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);

							DialogResult = DialogResult.OK;
							this.Close();
							break;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message ?? "Error al actualizar la materia");
							break;
						}
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void btnAddCorrelativeParent_Click(object sender, EventArgs e)
		{
			SubjectList frm = new SubjectList(subject, CorrelativeType.Parent);
			frm.ShowDialog();
			LoadCorrelatives();
		}

		private void btnAddCorrelativeChildren_Click(object sender, EventArgs e)
		{
			SubjectList frm = new SubjectList(subject, CorrelativeType.Children);
			frm.ShowDialog();
			LoadCorrelatives();
		}

		private void btnRemoveCorrelativeParent_Click(object sender, EventArgs e)
		{
			if (lstCorrelativesParent.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Correlative correlativeToDelete = ((ListBoxItem)lstCorrelativesParent.SelectedItems[0]).Tag;
				var service = new CorrelativeService();
				service.Delete(correlativeToDelete);
				subject.CorrelativesParents.Remove(correlativeToDelete);
			}
			LoadCorrelatives();

		}

		private void btnRemoveCorrelativeChildren_Click(object sender, EventArgs e)
		{
			if (lstCorrelativesChildren.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Correlative correlativeToDelete = ((ListBoxItem)lstCorrelativesChildren.SelectedItems[0]).Tag;
				var service = new CorrelativeService();
				service.Delete(correlativeToDelete);
				subject.CorrelativesChildren.Remove(correlativeToDelete);
			}
			LoadCorrelatives();
		}
		#endregion
	}
}
