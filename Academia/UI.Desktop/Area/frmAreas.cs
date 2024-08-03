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
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.Desktop.Area
{

    public enum Mode { Edit, Create };
    public partial class frmAreas : Form
    {
        //private List<Entities.Area> areas = [];
        private IEnumerable<Domain.Model.Area> areasList;
        public frmAreas()
        {
            InitializeComponent();
            
            LoadAreas();
        }


        private async void LoadAreas()
        {
            var service = new Domain.Services.AreaService();
             this.areasList = service.GetAll();


            AdaptAreas(areasList);
            
            //DataTable dataTable = new DataTable();
            //DataColumn column_id = new DataColumn("id");
            //dataTable.Columns.Add(column_id);
            //DataColumn column_name = new DataColumn("Description");
            //dataTable.Columns.Add(column_name);
            //areas = await Business.Area.FindAll();
            //foreach (Entities.Area area in areas)
            //{
            //    var row = dataTable.NewRow();
            //    row["Description"] = area.Description;
            //    row["Id"] = area.IdArea;

            //    dataTable.Rows.Add(row);
            //}
            //dgvAreas.DataSource = dataTable;
        }



        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionArea frm = new frmActionArea(Mode.Create);
            frm.ShowDialog();
            var service = new Domain.Services.AreaService();
            lstvAreas.Items.Clear();
            AdaptAreas(service.GetAll());
            lstvAreas.Refresh();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {

            //if (dgvAreas.SelectedRows.Count > 0)
            //{
            //    var row = dgvAreas.SelectedRows[0];
            //    int id = Int32.Parse(row.Cells[0].Value.ToString());
            //    frmActionArea frm = new frmActionArea(Mode.Edit, id);
            //    frm.ShowDialog();
            //    lstvAreas.Refresh();
            //    //LoadAreas();
            //}

            if (lstvAreas.SelectedItems.Count > 0)
            {
                Domain.Model.Area selectedArea = (Domain.Model.Area)lstvAreas.SelectedItems[0].Tag;
                var service = new Domain.Services.AreaService();


                frmActionArea frm = new frmActionArea(Mode.Edit, selectedArea.Id);
                frm.ShowDialog();
                lstvAreas.Items.Clear();
                AdaptAreas(service.GetAll());
                lstvAreas.Refresh();
                //var row = dgvAreas.SelectedRows[0];
                //int id = Int32.Parse(row.Cells[0].Value.ToString());
                //await Business.Area.Delete(id);
                //LoadAreas();
            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de edit");
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            //if (dgvAreas.SelectedRows.Count > 0)
            //{
            //    var row = dgvAreas.SelectedRows[0];
            //    int id = Int32.Parse(row.Cells[0].Value.ToString());
            //    await Business.Area.Delete(id);
            //    LoadAreas();
            //}
            
            if (lstvAreas.SelectedItems.Count > 0)
            {
                Domain.Model.Area selectedArea = (Domain.Model.Area)lstvAreas.SelectedItems[0].Tag;
                var service = new Domain.Services.AreaService();
                
                lstvAreas.Text = service.Delete(selectedArea.Id).ToString();
                lstvAreas.Items.Clear();
                AdaptAreas(service.GetAll());
                lstvAreas.Refresh();
                //var row = dgvAreas.SelectedRows[0];
                //int id = Int32.Parse(row.Cells[0].Value.ToString());
                //await Business.Area.Delete(id);
                //LoadAreas();
            }
            else {
                MessageBox.Show("Seleccione 1 area antes de remover");
            }
        }

        //private void dgvAreas_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvAreas.SelectedRows.Count <= 0)
        //    {
        //        tsbtnEdit.Enabled = false;
        //        tsbtnRemove.Enabled = false;
        //    }
        //    else
        //    {
        //        tsbtnEdit.Enabled = true;
        //        tsbtnRemove.Enabled = true;
        //    }
        //}

        private void AdaptAreas(IEnumerable<Domain.Model.Area> areas) {
            foreach (Domain.Model.Area item in areas)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Id.ToString());
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Description);
                lstvAreas.Items.Add(nuevoItem);
            }
        }
        private void txtSearchArea_TextChanged(object sender, EventArgs e)
        {

            var areasFiltradas = this.areasList.Where(a => a.Description.ToLower().Contains(((System.Windows.Forms.TextBox)sender).Text.ToLower()));
            lstvAreas.Items.Clear();

            AdaptAreas(areasFiltradas);
            lstvAreas.Refresh(); 
            lblOutputArea.Text = lstvAreas.Items.Count.ToString();
        }
    }
}
