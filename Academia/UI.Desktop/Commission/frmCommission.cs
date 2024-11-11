using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Commission;
using UI.Desktop.Curriculum;
using UI.Desktop;
using ClientService.Commission;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Desktop.Commission
{
	public partial class FrmCommissions : Form
	{
		private IEnumerable<ApplicationCore.Model.Commission> commissions = [];
		private IServiceProvider serviceProvider;
		private ICommissionService commissionService;
		public FrmCommissions(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.serviceProvider = serviceProvider;
			this.commissionService = serviceProvider.GetRequiredService<ICommissionService>();
			Utilities.StyleListViewHeader(lstvCommission, Color.FromArgb(184, 218, 255));
			LoadCommissions();
		}

		private void AdaptCommissionToListView(IEnumerable<ApplicationCore.Model.Commission> commissionList)
		{
			lstvCommission.Items.Clear();
			foreach (ApplicationCore.Model.Commission item in commissionList)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Curriculum.Description.ToString());
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Level.ToString());
				nuevoItem.SubItems.Add(item.Description);
				lstvCommission.Items.Add(nuevoItem);
			}
			lstvCommission.Refresh();
		}

		private async void LoadCommissions()
		{
			try
			{
				lstvCommission.Enabled = false;
				this.commissions = await commissionService.GetAllWithCurriculum();
				AdaptCommissionToListView(this.commissions);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error al cargar las comisiones", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				lstvCommission.Enabled = true;
			}
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionCommission frm = new FrmActionCommission(Mode.Create, this.serviceProvider);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				LoadCommissions();
			}

		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (lstvCommission.SelectedItems.Count > 0)
			{
				var selectedCommission = (ApplicationCore.Model.Commission)lstvCommission.SelectedItems[0].Tag;
				FrmActionCommission frm = new FrmActionCommission(Mode.Edit, selectedCommission, this.serviceProvider);
				var result = frm.ShowDialog();
				if (result == DialogResult.OK)
				{
					LoadCommissions();
				}
			}
			else
			{
				MessageBox.Show("Seleccione una comisión antes de editar", "Editar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private async void tsbtnRemove_Click(object sender, EventArgs e)
		{
			if (lstvCommission.SelectedItems.Count > 0)
			{
				try
				{
					if (Utilities.ConfirmDelete("esta comisión") != DialogResult.OK) return;
					ApplicationCore.Model.Commission selectedCommission = (ApplicationCore.Model.Commission)lstvCommission.SelectedItems[0].Tag;
					await commissionService.Delete(selectedCommission.Id);
					LoadCommissions();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error al eliminar", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
			}
			else
			{
				MessageBox.Show("Seleccione una comisión antes de eliminar", "Eliminar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			if (this.commissions.Count() > 0)
			{
				var commissionsFiltered = this.commissions.Where(a => a.Description.ToLower().Contains(((System.Windows.Forms.TextBox)sender).Text.ToLower()));
				AdaptCommissionToListView(commissionsFiltered);
			}
		}

	}
}
