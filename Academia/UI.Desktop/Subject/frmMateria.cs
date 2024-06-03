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

namespace UI.Desktop.Subject
{
    public partial class frmMateria : Form
    {
        public frmMateria()
        {
            InitializeComponent();
            LoadSubject();
            //private List<Entities.Subject> areas = [];


    }
        private async void LoadSubject()
        {
            DataTable dataTable = new DataTable();
            DataColumn column_id = new DataColumn("id");
            dataTable.Columns.Add(column_id);
            DataColumn column_name = new DataColumn("Name");
            dataTable.Columns.Add(column_name);

        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionSubject frm = new frmActionSubject(Mode.Create);
            frm.ShowDialog();
            LoadSubject();
        }

    }
}
