using Domain.Services;
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

namespace UI.Desktop.Commission
{
    public partial class frmCommissions : Form
    {
        private IEnumerable<Domain.Model.Commission> commissionsList = [];
        public frmCommissions()
        {
            InitializeComponent();
            LoadCommissions();
        }

        private void AdaptCommissionToListView(IEnumerable<Domain.Model.Commission> commissionList)
        {
            foreach (Domain.Model.Commission item in commissionList)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Id.ToString());
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Description);
                nuevoItem.SubItems.Add(item.Curriculum.Description.ToString());
                lstvCommission.Items.Add(nuevoItem);
            }
        }

        private async void LoadCommissions()
        {
            try
            {
                var service = new Domain.Services.CommissionService();
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
            frmActionCommission frm = new frmActionCommission(Mode.Create);
            frm.ShowDialog();
            var service = new Domain.Services.CommissionService();
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
                var selectedCommission = (Domain.Model.Commission)lstvCommission.SelectedItems[0].Tag;
                var service = new Domain.Services.CommissionService();
                frmActionCommission frm = new frmActionCommission(Mode.Edit, selectedCommission);
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
                MessageBox.Show("Seleccione una comisión antes de editar");
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (lstvCommission.SelectedItems.Count > 0)
            {
                Domain.Model.Commission selectedCommission = (Domain.Model.Commission)lstvCommission.SelectedItems[0].Tag;
                Domain.Services.CommissionService service = new Domain.Services.CommissionService();
                service.Delete(selectedCommission.Id);
                lstvCommission.Items.Clear();
                AdaptCommissionToListView(await service.GetAll());
                lstvCommission.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione una comisión antes de remover");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filteredCommissions = this.commissionsList.Where(a => Data.Util.DeleteDiacritic(a.Description.ToLower()).Contains(Data.Util.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower())));
            lstvCommission.Items.Clear();
            AdaptCommissionToListView(filteredCommissions);
            lstvCommission.Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var commissionsFiltered = this.commissionsList.Where(a => a.Description.ToLower().Contains(((System.Windows.Forms.TextBox)sender).Text.ToLower()));
            lstvCommission.Items.Clear();
            AdaptCommissionToListView(commissionsFiltered);
            lstvCommission.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstvCommission.Items.Clear();
            LoadCommissions();
        }
    }
}
