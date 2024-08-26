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

namespace UI.Desktop.Commission
{
    public partial class frmCommissions : Form
    {
        private List<Entities.Commission> commissions = [];
        public frmCommissions()
        {
            InitializeComponent();
            LoadCommissions();
        }


        private async void LoadCommissions()
        {
            DataTable dataTable = new DataTable();
            DataColumn column_id = new DataColumn("id");
            dataTable.Columns.Add(column_id);
            DataColumn column_description = new DataColumn("Description");
            dataTable.Columns.Add(column_description);
            DataColumn column_year = new DataColumn("Year");
            dataTable.Columns.Add(column_year);
            commissions = await Business.Commission.FindAll();
            foreach (Entities.Commission commission in commissions)
            {
                var row = dataTable.NewRow();
                row["Description"] = commission.Description;
                row["Year"] = commission.Year;
                row["Id"] = commission.IdCommission;

                dataTable.Rows.Add(row);
            }
            dgvCommissions.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = dgvCommissions.SelectedRows.Count.ToString();
        }


        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionCommission frm = new frmActionCommission(Mode.Create);
            frm.ShowDialog();
            LoadCommissions();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {

            if (dgvCommissions.SelectedRows.Count > 0)
            {
                var row = dgvCommissions.SelectedRows[0];
                label1.Text = row.Cells[0].Value.ToString();
                int id = Int32.Parse(row.Cells[0].Value.ToString());
                frmActionCommission frm = new frmActionCommission(Mode.Edit, id);
                frm.ShowDialog();
                LoadCommissions();
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCommissions.SelectedRows.Count > 0)
            {
                var row = dgvCommissions.SelectedRows[0];
                int id = Int32.Parse(row.Cells[0].Value.ToString());
                await Business.Commission.Delete(id);
                LoadCommissions();
            }
        }

        private void dgvCommissions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCommissions.SelectedRows.Count <= 0)
            {
                tsbtnEdit.Enabled = false;
                tsbtnRemove.Enabled = false;
            }
            else
            {
                tsbtnEdit.Enabled = true;
                tsbtnRemove.Enabled = true;
            }
        }

    }
}
