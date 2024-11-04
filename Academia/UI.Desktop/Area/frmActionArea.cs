using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ClientService.Area;

namespace UI.Desktop.Area
{
    public partial class FrmActionArea : Form
	{
		private Mode mode;
		private ApplicationCore.Model.Area area;
		private IAreaService areaService;
		public FrmActionArea(Mode mode, IAreaService service)
		{
			if (mode == Mode.Create)
			{
				InitializeComponent();
				this.mode = mode;
				this.areaService = service;
				this.Text = "Crear Especialidad";
				btnActionArea.Text = "Crear Especialidad";
				lblId.Visible = false;
				txtId.Visible = false;
			}
			else
			{
				this.Dispose();
			}
		}
		public FrmActionArea(Mode mode, ApplicationCore.Model.Area area, IAreaService service)
		{
			if (mode == Mode.Edit)
			{
				InitializeComponent();
				this.mode = mode;
				this.areaService = service;
				this.area = area;
				this.Text = "Editar Especialidad";
				btnActionArea.Text = "Guardar Especialidad";
				lblId.Visible = true;
				lblIdValue.Visible = true;
				lblIdValue.Text = area.Id.ToString();
				txtId.Visible = false;
				txtArea.Text = area.Description.ToString();
			}
			else
			{
				this.Dispose();
			}
		}


		private async void CreateArea(ApplicationCore.Model.Area newArea)
		{
			try
			{
				await areaService.CreateAsync(newArea);
				MessageBox.Show("Especialidad " + newArea.Description + " creada correctamente.", "Crear especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception e)
			{
				if (e.HResult == -2146233088)
				{
					MessageBox.Show("Nombre de especialidad existente.", "No se ha podido crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private async void EditArea(string areaDescription)
		{
			try
			{
				this.area.Description = areaDescription;
				await areaService.UpdateAsync(area);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception e)
			{
				if (e.HResult == -2146233088)
				{
					MessageBox.Show("Nombre de especialidad existente.", "No se ha podido crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnActionArea.PerformClick();
			}
		}

		private async void btnActionArea_Click(object sender, EventArgs e)
		{
			string areaDescription = txtArea.Text.Trim();
			if (String.IsNullOrEmpty(areaDescription))
			{
				return;
			}
			else
			{
				if (mode == Mode.Create)
				{
					CreateArea(new ApplicationCore.Model.Area { Description = areaDescription });
				}
				else if (mode == Mode.Edit)
				{
					EditArea(areaDescription);
				}
			}
		}
	}
}
