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
using ClientService.Curriculum;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Desktop.Curriculum
{
	public partial class FrmCurriculum : Form
	{
		private IEnumerable<ApplicationCore.Model.Curriculum> curriculums;
		private ICurriculumService curriculumService;
		private IServiceProvider serviceProvider;
		public FrmCurriculum(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.serviceProvider = serviceProvider;
			this.curriculumService = serviceProvider.GetRequiredService<ICurriculumService>();
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
				lstvCurriculum.Enabled = false;
				this.curriculums = await curriculumService.GetAllWithAreaAsync();
				AdaptCurriculumsToListView(curriculums);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally { 
				lstvCurriculum.Enabled = true;
			}
		}
		#endregion

		#region Events
		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Create, serviceProvider);
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
				FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Edit, selectedCurriculum, serviceProvider);
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
					if (Utilities.ConfirmDelete($"el plan de estudios' {((ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag).Description}' ") != DialogResult.OK) return;

					ApplicationCore.Model.Curriculum selectedCurriulum = (ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
					await curriculumService.DeleteAsync(selectedCurriulum.Id);
					LoadCurriculums();
					MessageBox.Show("Plan de estudios " + selectedCurriulum.Description + "eliminada correctamente.", "Eliminar plan de estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					if (ex.Message != null && ex.Message == "Can't delete a Curriculum with related Subjects, Students or Commissions")
					{
						MessageBox.Show("No puedes eliminar un Plan de Estudios con Datos (alumnos, materias, comisiones) asociados.", "No se ha podido eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			if (this.curriculums != null && this.curriculums.Count() > 0)
			{
				var filteredCurriculums = this.curriculums.Where(a => Utilities.DeleteDiacritic(a.Description.ToLower()).Contains(Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower())));
				AdaptCurriculumsToListView(filteredCurriculums);
			}
		}
		#endregion
	}
}
