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

namespace UI.Desktop.Curriculum
{
    public partial class frmCurriculum : Form
    {
        public frmCurriculum()
        {
            InitializeComponent();
            LoadCurriculums();
        }

        private async void LoadCurriculums()
        {

            var curriculums = await Data.Curriculum.FindAll();
            DataTable dataTable = new DataTable();
            DataColumn column_id = new DataColumn("id");
            dataTable.Columns.Add(column_id);
            DataColumn column_description = new DataColumn("description");
            dataTable.Columns.Add(column_description);
            DataColumn column_resolucion = new DataColumn("resolucion");
            dataTable.Columns.Add(column_resolucion);
            DataColumn column_anio = new DataColumn("anio");
            dataTable.Columns.Add(column_anio);
            //
            DataColumn columm_area = new DataColumn("especialidad");
            dataTable.Columns.Add(columm_area);
            foreach (var curriculum in curriculums)
            {
                var row = dataTable.NewRow();
                row["id"] = curriculum.Id;
                row["description"] = curriculum.Description;
                row["resolucion"] = curriculum.Resolution;
                row["anio"] = curriculum.Year;
                row["especialidad"] = curriculum.Area.Description;
                dataTable.Rows.Add(row);
            }
            dgvCurriculums.DataSource = dataTable;


        }
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionCurriculum frm = new frmActionCurriculum(Mode.Create);
            frm.ShowDialog();
            LoadCurriculums();
        }

        private async void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCurriculums.SelectedRows[0] != null)
            {

                var id = (dgvCurriculums.SelectedRows[0].Cells[0].Value).ToString().Trim();
                var curr = await Business.Curriculum.FindOne(Int32.Parse(id));
                frmActionCurriculum frm = new frmActionCurriculum(Mode.Edit, curr);
                frm.ShowDialog();
                LoadCurriculums();
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCurriculums.SelectedRows[0] != null)
            {

                var id = (dgvCurriculums.SelectedRows[0].Cells[0].Value).ToString().Trim();
                var curr = await Data.Curriculum.Delete(Int32.Parse(id));
                LoadCurriculums();
            }
        }
    }
}
