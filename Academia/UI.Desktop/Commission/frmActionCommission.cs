using ClientService.Commission;
using ClientService.Curriculum;
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


namespace UI.Desktop.Commission
{
	public partial class FrmActionCommission : Form
	{
		private Mode mode;
		public ApplicationCore.Model.Commission commission;
		public IEnumerable<ApplicationCore.Model.Curriculum> curriculums = new List<ApplicationCore.Model.Curriculum>();
		private ICurriculumService curriculumService;
		private ICommissionService commissionService;


		public FrmActionCommission(Mode mode, IServiceProvider serviceProvider)
		{

			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.mode = mode;
				this.Text = "Crear Comisión";
				btnActionCommission.Text = "Crear Comisión";
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
				this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
				LoadCurriculums();
			}
			else
			{
				this.Dispose();
			}
		}
		public FrmActionCommission(Mode mode, ApplicationCore.Model.Commission commission, IServiceProvider serviceProvider)
		{

			if (mode == Mode.Edit)
			{
				InitializeComponent();
				this.mode = mode;
				this.Text = "Editar Comisión";
				this.commission = commission;
				this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
				this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
				LoadCurriculums();
				btnActionCommission.Text = "Guardar comisión";
				txtCommissionDescription.Text = this.commission.Description.ToString();
				cbCurriculum.SelectedValue = this.commission.Curriculum.Id;
				numLevel.Value = this.commission.Level;
			}
			else
			{
				this.Dispose();
			}

		}

		private async void LoadCurriculums()
		{
			try
			{
				if (this.mode == Mode.Edit)
				{
					Utilities.AdaptCurriculumsToCb(cbCurriculum, await curriculumService.GetAll(), commission.IdCurriculum);
				}
				else if (this.mode == Mode.Create)
				{
					Utilities.AdaptCurriculumsToCb(cbCurriculum, await curriculumService.GetAll());
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error al cargar los planes de estudio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void btnActionCommission_Click(object sender, EventArgs e)
		{
			var level = (int)numLevel.Value;
			string description = txtCommissionDescription.Text.Trim();
			ApplicationCore.Model.Curriculum selectedCurriculum = (ApplicationCore.Model.Curriculum)cbCurriculum.SelectedItem;

			bool validCurriculum = validateCurriculum(selectedCurriculum);
			bool validDescription = validateDescription(description);
			if (!validDescription)
			{
				Utilities.SetErrorStyle(lblDescription, txtCommissionDescription);
				lblDescriptionError.Visible = true;
			}
			else { 
				Utilities.SetDefaultStyle(lblDescription, txtCommissionDescription);
				lblDescriptionError.Visible = false;

			}
			bool validLevel = validateLevel(level);


			if (validLevel && validCurriculum && validDescription)
			{
				int idCurriculum = (int)cbCurriculum.SelectedValue;
				if (mode == Mode.Create)
				{
					ApplicationCore.Model.Commission newCommission = new ApplicationCore.Model.Commission
					{
						Description = description,
						Level = level,
						IdCurriculum = idCurriculum
					};
					try
					{
						CreateCommission(newCommission);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						throw ex;
					}
				}
				else if (mode == Mode.Edit)
				{
					EditCommission(description, selectedCurriculum, level);
				}
			}
		}

		private async void CreateCommission(ApplicationCore.Model.Commission newCommission)
		{
			try
			{
				await commissionService.Create(newCommission);
				MessageBox.Show("Comisión " + newCommission.Description + " creada correctamente", "Crear Comisióin", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("Violation of UNIQUE"))
				{
					MessageBox.Show("Comisión Existente", "Crear Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else { 
				MessageBox.Show(ex.Message, "Crear Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private async void EditCommission(string description, ApplicationCore.Model.Curriculum selectedCurriculum, int level)
		{
			try
			{
				this.commission.Description = description;
				this.commission.IdCurriculum = selectedCurriculum.Id;
				this.commission.Level = level;
				await commissionService.Update(this.commission);
				MessageBox.Show("Comisión " + this.commission.Description + " actualizada correctamente", "Editar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("Violation of UNIQUE"))
				{
					MessageBox.Show("Comisión Existente", "Crear Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show(ex.Message, "Crear Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void txtCommissionDescription_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnActionCommission.PerformClick();
			}
		}

		private bool validateLevel(int level)
		{
			if (level >= 1)
			{
				lblLevelError.Visible = false;
				return true;
			}
			lblLevelError.Visible = true;
			return false;
		}

		private bool validateDescription(string description)
		{
			if (String.IsNullOrEmpty(description))
			{
				lblDescriptionError.Visible = true;
				return false;
			}
			else
			{
				lblDescriptionError.Visible = false;
				return true;
			}
		}

		private bool validateCurriculum(ApplicationCore.Model.Curriculum selectedCurriculum)
		{
			if (selectedCurriculum != null)
			{
				lblIdCurriculumError.Visible = false;
				return true;

			}
			lblIdCurriculumError.Visible = true;
			return false;
		}
	}
}
