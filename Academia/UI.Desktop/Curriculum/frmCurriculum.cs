using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Area;
using UI.Desktop;

namespace UI.Desktop.Curriculum
{
	public partial class FrmCurriculum : Form
	{
		private IEnumerable<ApplicationCore.Model.Curriculum> curriculums;
		public FrmCurriculum()
		{
			InitializeComponent();
			Utilities.StyleListViewHeader(lstvCurriculum, Color.FromArgb(184, 218, 255));
			LoadCurriculums();
		}
		#region Methods
		private void AdaptCurriculumsToListView(IEnumerable<ApplicationCore.Model.Curriculum> curriculumList)
		{
			lstvCurriculum.Items.Clear();
			foreach (ApplicationCore.Model.Curriculum item in curriculumList)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Id.ToString());
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Description);
				nuevoItem.SubItems.Add(item.Area.Description);
				nuevoItem.SubItems.Add(item.Year.ToString());
				nuevoItem.SubItems.Add(item.Resolution);
				lstvCurriculum.Items.Add(nuevoItem);
			}
			lstvCurriculum.Refresh();
		}

		private async void LoadCurriculums()
		{
			try
			{
				var service = new ApplicationCore.Services.CurriculumService();
				this.curriculums = await service.GetAll();
				AdaptCurriculumsToListView(curriculums);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		#endregion

		#region Events
		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Create);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadCurriculums();
			}
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (lstvCurriculum.SelectedItems.Count > 0)
			{
				var selectedCurriculum = (ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
				var service = new ApplicationCore.Services.CurriculumService();
				FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Edit, selectedCurriculum);
				var result = frm.ShowDialog();
				if (result == DialogResult.OK)
				{
					LoadCurriculums();
				}
			}
			else
			{
				MessageBox.Show("Seleccione un plan de estudios antes de editar", "Editar Plan de Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private async void tsbtnRemove_Click(object sender, EventArgs e)
		{
			if (lstvCurriculum.SelectedItems.Count > 0)
			{
				try
				{
					ApplicationCore.Model.Curriculum selectedCurriulum = (ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
					ApplicationCore.Services.CurriculumService service = new ApplicationCore.Services.CurriculumService();
					await service.Delete(selectedCurriulum.Id);
					LoadCurriculums();
					MessageBox.Show("Plan de estudios " + selectedCurriulum.Description + "eliminada correctamente.", "Eliminar plan de estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					if (ex.InnerException is Microsoft.Data.SqlClient.SqlException inner && inner.ErrorCode == -2146232060)
					{
						MessageBox.Show("No puedes eliminar un Plan de Estudios con Datos asociados.", "No se ha podido eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("Seleccione un Plan de Estudios antes de eliminar", "Eliminar Plan de Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtSearchCurriculum_TextChanged(object sender, EventArgs e)
		{
			var filteredCurriculums = this.curriculums.Where(a => Utilities.DeleteDiacritic(a.Description.ToLower()).Contains(Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower())));
			AdaptCurriculumsToListView(filteredCurriculums);
		}
		#endregion
	}
}
