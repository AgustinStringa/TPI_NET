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
        private Entities.Area[] areas = [new Entities.Area("Sistemas")];
        public frmAreas()
        {
            InitializeComponent();
            loadAreas();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCreateArea frm = new frmCreateArea();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                //this.Dispose();
            }
                label1.Text = frm.newArea.Name;
        }

        private void loadAreas() {
            DataTable dataTable = new DataTable();
            
            foreach (Entities.Area area in areas)
            {
                DataColumn column_name = new DataColumn("Name");
                dataTable.Columns.Add(column_name);
                var row = dataTable.NewRow();
                row["Name"] = area.Name;
                dataTable.Rows.Add(row);
            }
            dgvAreas.DataSource = dataTable;
        }
    }
}
