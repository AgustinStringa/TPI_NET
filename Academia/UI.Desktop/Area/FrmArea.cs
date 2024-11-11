using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;
using UI.Desktop.Area;
using Microsoft.Extensions.DependencyInjection;
using ClientService.Area;

namespace UI.Desktop.Area
{


	public partial class FrmArea : Form
	{
		#region Fields
		private IEnumerable<ApplicationCore.Model.Area> areas;
		private IServiceProvider serviceProvider;
		private IAreaService _areaService;
		#endregion
		public FrmArea(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
			this._areaService = serviceProvider.GetRequiredService<IAreaService>();
			InitializeComponent();
			LoadAreas();
			StartLayoutPanel();
		}

		#region Methods
		private async void LoadAreas()
		{
			try
			{
				lstvAreas.Enabled = false;
				this.areas = await _areaService.GetAll();
				AdaptAreasToListView(areas);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Erorr de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally { 
				lstvAreas.Enabled = true;
			}
		}
		#endregion


		#region Events 
		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionArea frm = new FrmActionArea(Mode.Create, _areaService);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadAreas();
			}
		}
		private void tsbtnEdit_Click(object sender, EventArgs e)
		{

			if (lstvAreas.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Area selectedArea = (ApplicationCore.Model.Area)lstvAreas.SelectedItems[0].Tag;
				FrmActionArea frm = new FrmActionArea(Mode.Edit, selectedArea, _areaService);
				var result = frm.ShowDialog();
				if (result == DialogResult.OK)
				{
					LoadAreas();
				}

			}
			else
			{
				MessageBox.Show("Seleccione una especialidad antes de editar", "Editar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private async void tsbtnRemove_Click(object sender, EventArgs e)
		{

			if (lstvAreas.SelectedItems.Count > 0)
			{
				try
				{
					if (Utilities.ConfirmDelete($"la especialidad '{((ApplicationCore.Model.Area)lstvAreas.SelectedItems[0].Tag).Description}'") != DialogResult.OK) return;
					ApplicationCore.Model.Area selectedArea = (ApplicationCore.Model.Area)lstvAreas.SelectedItems[0].Tag;
					await _areaService.Delete(selectedArea.Id);
					LoadAreas();
					MessageBox.Show("Especialidad " + selectedArea.Description + " eliminada correctamente.", "Eliminar especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{

					if (ex.HResult == -2146233088)
					{
						MessageBox.Show("No puedes eliminar una especialidad con Datos asociados.\n Elimina todos los planes de estudios que referencien a esta especialidad antes de eliminar.", "No se ha podido eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

			}
			else
			{
				MessageBox.Show("Seleccione una especialidad antes de eliminar", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void AdaptAreasToListView(IEnumerable<ApplicationCore.Model.Area> areas)
		{
			lstvAreas.Items.Clear();
			foreach (ApplicationCore.Model.Area item in areas)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Id.ToString());
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Description);
				lstvAreas.Items.Add(nuevoItem);
			}
			lstvAreas.Refresh();
		}
        private void txtSearchArea_TextChanged(object sender, EventArgs e)
        {
            if (this.areas != null && this.areas.Count() > 0)
            {
				var search = Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower());

                var areasFiltradas = this.areas.Where(a =>
                    Utilities.DeleteDiacritic(a.Description.ToLower()).Contains(search)
                );

                AdaptAreasToListView(areasFiltradas);
            }
        }

        #endregion

        private void StartLayoutPanel()
		{
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
			tableLayoutPanel.ColumnCount = 1;
			tableLayoutPanel.RowCount = 3;
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
			label1.Padding = new Padding(0, 60, 0, 20);
			txtSearchArea.Padding = new Padding(40, 40, 0, 0);
			lstvAreas.Padding = new Padding(40, 40, 0, 0);
			tableLayoutPanel.Controls.Add(label1, 0, 0); //(col, row)
			tableLayoutPanel.Controls.Add(txtSearchArea, 0, 1);
			tableLayoutPanel.Controls.Add(lstvAreas, 0, 2);
			tableLayoutPanel.Padding = new Padding(10);
			this.Controls.Add(tableLayoutPanel);
		}
	}
}
