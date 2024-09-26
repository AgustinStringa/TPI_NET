using ApplicationCore.Services;
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

namespace UI.Desktop.Commission
{
	public partial class FrmCommissions : Form
	{
		private IEnumerable<ApplicationCore.Model.Commission> commissionsList = [];
		public FrmCommissions()
		{
			InitializeComponent();
			LoadCommissions();
		}

		private void AdaptCommissionToListView(IEnumerable<ApplicationCore.Model.Commission> commissionList)
		{
			foreach (ApplicationCore.Model.Commission item in commissionList)
			{
				ListViewItem nuevoItem = new ListViewItem(item.Curriculum.Description.ToString());
				nuevoItem.Tag = item;
				nuevoItem.SubItems.Add(item.Level.ToString());
				nuevoItem.SubItems.Add(item.Description);
				lstvCommission.Items.Add(nuevoItem);
			}
		}

		private async void LoadCommissions()
		{
			try
			{
				var service = new ApplicationCore.Services.CommissionService();
				this.commissionsList = await service.GetAll();
				AdaptCommissionToListView(this.commissionsList);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				throw e;
			}
		}

		private async void tsbtnAdd_Click(object sender, EventArgs e)
		{
			FrmActionCommission frm = new FrmActionCommission(Mode.Create);
			frm.ShowDialog();
			var service = new ApplicationCore.Services.CommissionService();
			lstvCommission.Items.Clear();
			AdaptCommissionToListView(await service.GetAll());
			lstvCommission.Refresh();
			lstvCommission.Items.Clear();
			LoadCommissions();
		}

		private async void tsbtnEdit_Click(object sender, EventArgs e)
		{
			if (lstvCommission.SelectedItems.Count > 0)
			{
				var selectedCommission = (ApplicationCore.Model.Commission)lstvCommission.SelectedItems[0].Tag;
				var service = new ApplicationCore.Services.CommissionService();
				FrmActionCommission frm = new FrmActionCommission(Mode.Edit, selectedCommission);
				frm.ShowDialog();
				lstvCommission.Items.Clear();
				lstvCommission.Refresh();
				AdaptCommissionToListView(await service.GetAll());
				lstvCommission.Refresh();
				lstvCommission.Items.Clear();
				LoadCommissions();
			}
			else
			{
				MessageBox.Show("Seleccione una comisión antes de editar","Editar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private async void tsbtnRemove_Click(object sender, EventArgs e)
		{
			if (lstvCommission.SelectedItems.Count > 0)
			{
				ApplicationCore.Model.Commission selectedCommission = (ApplicationCore.Model.Commission)lstvCommission.SelectedItems[0].Tag;
				ApplicationCore.Services.CommissionService service = new ApplicationCore.Services.CommissionService();
				service.Delete(selectedCommission.Id);
				lstvCommission.Items.Clear();
				AdaptCommissionToListView(await service.GetAll());
				lstvCommission.Refresh();
			}
			else
			{
				MessageBox.Show("Seleccione una comisión antes de eliminar", "Eliminar Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			var commissionsFiltered = this.commissionsList.Where(a => a.Description.ToLower().Contains(((System.Windows.Forms.TextBox)sender).Text.ToLower()));
			lstvCommission.Items.Clear();
			AdaptCommissionToListView(commissionsFiltered);
			lstvCommission.Refresh();
		}

	}
}
