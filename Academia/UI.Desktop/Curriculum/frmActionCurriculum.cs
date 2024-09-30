using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientService.Area;
using ClientService.Curriculum;
using Microsoft.Extensions.DependencyInjection;
using UI.Desktop.Area;

namespace UI.Desktop.Curriculum
{
	public partial class FrmActionCurriculum : Form
	{

		private ApplicationCore.Model.Curriculum curriculum;
		private Mode mode;
		private IAreaService areaService;
		private ICurriculumService curriculumService;

		public FrmActionCurriculum(Mode mode, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.mode = mode;
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
				lblTitleFrmActionCurriculum.Text = "Crear Plan de Estudios";
				btnActionCurriculum.Text = "Crear Plan de Estudios";
				lblCurriculumId.Visible = false;
				lblCurriculumIdValue.Visible = false;
				lblTitleFrmActionCurriculum.Text = "Crear Plan de Estudios";
				LoadAreas();
			}
			else
			{
				this.Dispose();
			}

		}

		public FrmActionCurriculum(Mode mode, ApplicationCore.Model.Curriculum curriculum, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Edit)
			{

				InitializeComponent();

				this.curriculum = curriculum;
				this.mode = mode;
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
				LoadAreas();
				if (this.curriculum.SubjectsCount > 0)
				{
					cbAreas.Enabled = false;
					lblAreaError.Visible = true;
				}
				else
				{
					lblAreaError.Visible = false;
					cbAreas.Enabled = true;
				}
				btnActionCurriculum.Text = "Guardar Plan de Estudios";
				lblTitleFrmActionCurriculum.Text = "Editar Plan de Estudios";
				lblCurriculumIdValue.Visible = true;
				lblCurriculumIdValue.Text = this.curriculum.Id.ToString();
				lblCurriculumId.Visible = true;
				txtCurriculumDescription.Text = this.curriculum.Description;
				txtCurriculumYear.Text = this.curriculum.Year.ToString();
				txtCurriculumResolution.Text = this.curriculum.Resolution?.ToString().Trim();
				cbAreas.SelectedValue = this.curriculum.Area.Id;

			}
			else
			{
				this.Dispose();
			}
		}

		private async void LoadAreas()
		{
			try
			{
				if (this.mode == Mode.Edit)
				{
					Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAllAsync(), this.curriculum.AreaId);
				}
				else if (this.mode == Mode.Create)
				{
					Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAllAsync());

				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error al cargar las especialidades",
					"Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Events
		private async void btnActionCurriculum_Click(object sender, EventArgs e)
		{
			string description = txtCurriculumDescription.Text.Trim();
			int year = 0;
			string resolution = txtCurriculumResolution.Text.Trim();

			bool validYear = false;
			try
			{
				lblCurriculumYearError.Visible = false;
				year = Int32.Parse(txtCurriculumYear.Text);
				validYear = true;
			}
			catch (Exception ex)
			{
				validYear = false;
				lblCurriculumYearError.Visible = true;
			}

			bool validDescription = !String.IsNullOrEmpty(description);
			if (!validDescription)
			{
				lblCurriculumDescriptionError.Visible = true;
			}
			else
			{
				validDescription = true;
				lblCurriculumDescriptionError.Visible = false;
			}

			bool validArea = cbAreas.SelectedValue != null;

			if (validArea && validDescription && validYear)
			{
				int idArea = (int)cbAreas.SelectedValue;
				if (mode == Mode.Create)
				{
					ApplicationCore.Model.Curriculum newCurriculum = new ApplicationCore.Model.Curriculum
					{
						Description = description,
						AreaId = idArea,
						Year = year,
						Resolution = resolution
					};

					try
					{
						await curriculumService.CreateAsync(newCurriculum);
						MessageBox.Show("Plan de Estudios " + newCurriculum.Description + " creado correctamente.", "Crear Plan de Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DialogResult = DialogResult.OK;
						this.Close();
					}
					catch (Exception ex)
					{
						//TO DO: que errores puede haber aqui?
						if (ex.HResult == -2146233088)
						{
							MessageBox.Show("Plan de Estudios existente.", "No se ha podido crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
				else if (mode == Mode.Edit)
				{
					var area = cbAreas.SelectedItem as ApplicationCore.Model.Area;
					this.curriculum.Description = description;
					this.curriculum.Year = year;
					this.curriculum.Resolution = resolution;
					this.curriculum.AreaId = idArea;
					await curriculumService.UpdateAsync(this.curriculum);
					MessageBox.Show("Plan de Estudios actualizado correctamente", "Editar Plan de Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void FrmActionCurriculum_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnActionCurriculum.PerformClick();
			}
		}

		#endregion
	}
}
