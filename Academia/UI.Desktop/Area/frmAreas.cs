using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Area;

namespace UI.Desktop
{
    public partial class frmAreas : Form
    {
        private List<Entities.Area> areas = [];
        public frmAreas()
        {
            InitializeComponent();
            LoadAreas();
        }


        private void LoadAreas()
        {
            DataTable dataTable = new DataTable();
            DataColumn column_id = new DataColumn("id");
            dataTable.Columns.Add(column_id);
            DataColumn column_name = new DataColumn("Name");
            dataTable.Columns.Add(column_name);
            int i = 0;
            foreach (Entities.Area area in areas)
            {
                var row = dataTable.NewRow();
                row["Name"] = area.Name;
                row["Id"] = i;
                i++;
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
            if (frm.ShowDialog() != DialogResult.OK)
            {
                //this.Dispose();
            }
            areas.Add(frm.newArea);
            LoadAreas();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            frmActionArea frm = new frmActionArea(Mode.Edit);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                //this.Dispose();
            }
            LoadAreas();
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAreas.SelectedRows.Count > 0)
            {
                var row = dgvAreas.SelectedRows[0];
                areas.Remove(areas[0]);
                LoadAreas();
            }
        }
    }
}
