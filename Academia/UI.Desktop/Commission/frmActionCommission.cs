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
			
		public FrmActionCommission(Mode mode)
		{
			this.mode = mode;
			InitializeComponent();
			switch (mode)
			{
				case Mode.Create:
					this.Text = "Crear Comisión";
					btnActionCommission.Text = "Crear Comisión";
					Utilities.LoadCurriculums(curriculums, cbCurriculum);
					break;
			}
		}
		public FrmActionCommission(Mode mode, ApplicationCore.Model.Commission comm)
		{
			this.commission = comm;
			InitializeComponent();
			Utilities.LoadCurriculums(curriculums, cbCurriculum, comm.Curriculum.Id);
			this.mode = mode;
			switch (mode)
			{
				case Mode.Edit:
					this.Text = "Editar Comisión";
					btnActionCommission.Text = "Guardar comisión";
					txtCommissionDescription.Text = commission.Description.ToString();
					cbCurriculum.SelectedValue = commission.Curriculum.Id;
					numLevel.Value = commission.Level;
					break;
			}

		}


		private async void btnActionCommission_Click(object sender, EventArgs e)
		{
			var level = (int)numLevel.Value;
			string description = txtCommissionDescription.Text.Trim();
			ApplicationCore.Model.Curriculum selectedCurriculum = (ApplicationCore.Model.Curriculum)cbCurriculum.SelectedItem;

			bool validCurriculum = validateCurriculum(selectedCurriculum);
			bool validDescription = validateDescription(description);
			bool validLevel = validateLevel(level);
			if (validLevel && validCurriculum && validCurriculum)
			{
				int idCurriculum = (int)cbCurriculum.SelectedValue;
				var service = new ApplicationCore.Services.CommissionService();
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
						CreateCommission(newCommission, service);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						throw ex;
					}
				}
				else if (mode == Mode.Edit)
				{
					EditCommission(description, selectedCurriculum, level, service);
				}
			}
		}

		private async void CreateCommission(ApplicationCore.Model.Commission newCommission, ApplicationCore.Services.CommissionService service)
		{
			await service.Create(newCommission);
			MessageBox.Show("Comisión " + newCommission.Description + " creada correctamente", "Crear Comisióin", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Dispose();
		}

		private async void EditCommission(string description, ApplicationCore.Model.Curriculum selectedCurriculum, int level, ApplicationCore.Services.CommissionService service)
		{
			try
			{
				this.commission.Description = description;
				this.commission.IdCurriculum = selectedCurriculum.Id;
				this.commission.Curriculum = selectedCurriculum;
				this.commission.Level = level;
				await service.Update(this.commission);
				MessageBox.Show("Comisión " + this.commission.Description + " actualizada correctamente", "Editar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Dispose();
			}
			catch (Exception)
			{
				throw;
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
