using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop;
using UI.Desktop.Area;

namespace UI.Desktop.Area
{


    public partial class FrmArea : Form
    {
        #region Fields
        private IEnumerable<Domain.Model.Area> areasList;
        #endregion
        public FrmArea()
        {
            InitializeComponent();
            LoadAreas();
        }

        #region Methods
        private async void LoadAreas()
        {
            try
            {
                var service = new Domain.Services.AreaService();
                this.areasList = await service.GetAll();
                AdaptAreasToListView(areasList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        #endregion


        #region Events 
        private async void tsbtnAdd_Click(object sender, EventArgs e)
        {
            FrmActionArea frm = new FrmActionArea(Mode.Create);
            frm.ShowDialog();
            var service = new Domain.Services.AreaService();
            lstvAreas.Items.Clear();
            AdaptAreasToListView(await service.GetAll());
            lstvAreas.Refresh();
        }
        private async void tsbtnEdit_Click(object sender, EventArgs e)
        {

            if (lstvAreas.SelectedItems.Count > 0)
            {
                Domain.Model.Area selectedArea = (Domain.Model.Area)lstvAreas.SelectedItems[0].Tag;
                var service = new Domain.Services.AreaService();
                FrmActionArea frm = new FrmActionArea(Mode.Edit, selectedArea);
                frm.ShowDialog();
                lstvAreas.Items.Clear();
                AdaptAreasToListView(await service.GetAll());
                lstvAreas.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de edit");
            }
        }
        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {

            if (lstvAreas.SelectedItems.Count > 0)
            {
                try
                {
                    Domain.Model.Area selectedArea = (Domain.Model.Area)lstvAreas.SelectedItems[0].Tag;
                    var service = new Domain.Services.AreaService();
                    await service.Delete(selectedArea.Id);
                    lstvAreas.Items.Clear();
                    AdaptAreasToListView(await service.GetAll());
                    lstvAreas.Refresh();
                    MessageBox.Show("Especialidad " + selectedArea.Description + "eliminada correctamente.", "Eliminar especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    var inner = ex.InnerException as Microsoft.Data.SqlClient.SqlException;
                    if (inner.ErrorCode == -2146232060)
                    {
                        MessageBox.Show("No puedes eliminar una especialidad con Datos asociados. \n Elimina todos los planes de estudios que referencien a esta especialidad antes de eliminar.", "No se ha podido eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de remover");
            }
        }
        private void AdaptAreasToListView(IEnumerable<Domain.Model.Area> areas)
        {
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
            AdaptAreasToListView(areasFiltradas);
            lstvAreas.Refresh();
        }

        #endregion
    }
}
