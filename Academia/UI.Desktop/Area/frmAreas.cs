using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;
using UI.Desktop.Area;

namespace UI.Desktop.Area
{

    public enum Mode { Edit, Create };
    public partial class frmAreas : Form
    {
        private List<Entities.Area> areas = [];
        public frmAreas()
        {
            InitializeComponent();
            LoadAreas();
        }


        private async void LoadAreas()
        {
            DataTable dataTable = new DataTable();
            DataColumn column_id = new DataColumn("id");
            dataTable.Columns.Add(column_id);
            DataColumn column_name = new DataColumn("Name");
            dataTable.Columns.Add(column_name);
            areas = await Business.Area.FindAll();
            foreach (Entities.Area area in areas)
            {
                var row = dataTable.NewRow();
                row["Name"] = area.Name;
                row["Id"] = area.IdArea;

                dataTable.Rows.Add(row);
            }
            dgvAreas.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = dgvAreas.SelectedRows.Count.ToString();
        }


        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionArea frm = new frmActionArea(Mode.Create);
            frm.ShowDialog();
            LoadAreas();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {

            if (dgvAreas.SelectedRows.Count > 0)
            {
                var row = dgvAreas.SelectedRows[0];
                label1.Text = row.Cells[0].Value.ToString();
                int id = Int32.Parse(row.Cells[0].Value.ToString());
                frmActionArea frm = new frmActionArea(Mode.Edit,id);
                frm.ShowDialog();
                LoadAreas();
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count > 0)
            {
                var row = dgvAreas.SelectedRows[0];
                int id = Int32.Parse(row.Cells[0].Value.ToString());
                await Business.Area.Delete(id);
                LoadAreas();
            }
        }

        private void dgvAreas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count <= 0)
            {
                tsbtnEdit.Enabled = false;
                tsbtnRemove.Enabled = false;
            }
            else {
                tsbtnEdit.Enabled = true;
                tsbtnRemove.Enabled = true;
            }
        }
    }
}
