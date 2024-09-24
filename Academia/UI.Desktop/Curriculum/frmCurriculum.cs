using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Area;
using UI.Desktop;

namespace UI.Desktop.Curriculum
{
    public partial class FrmCurriculum : Form
    {
        private IEnumerable<ApplicationCore.Model.Curriculum> curriculumList;
        public FrmCurriculum()
        {
            InitializeComponent();
            LoadCurriculums();
        }
        private void AdaptCurriculumsToListView(IEnumerable<ApplicationCore.Model.Curriculum> curriculumList)
        {
            foreach (ApplicationCore.Model.Curriculum item in curriculumList)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Id.ToString());
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Description);
                nuevoItem.SubItems.Add(item.Area.Description);
                nuevoItem.SubItems.Add(item.Year.ToString());
                nuevoItem.SubItems.Add(item.Resolution);
                lstvCurriculum.Items.Add(nuevoItem);
            }
        }
        private async void LoadCurriculums()
        {
            try
            {
                var service = new ApplicationCore.Services.CurriculumService();
                this.curriculumList = await service.GetAll();
                AdaptCurriculumsToListView(curriculumList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }
        private async void tsbtnAdd_Click(object sender, EventArgs e)
        {
            FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Create);
            frm.ShowDialog();
            var service = new ApplicationCore.Services.CurriculumService();
            lstvCurriculum.Items.Clear();
            AdaptCurriculumsToListView(await service.GetAll());
            lstvCurriculum.Refresh();
        }

        private async void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (lstvCurriculum.SelectedItems.Count > 0)
            {
                var selectedCurriculum = (ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
                var service = new ApplicationCore.Services.CurriculumService();
                FrmActionCurriculum frm = new FrmActionCurriculum(Mode.Edit, selectedCurriculum);
                frm.ShowDialog();
                lstvCurriculum.Items.Clear();
                AdaptCurriculumsToListView(await service.GetAll());
                lstvCurriculum.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de edit");
            }
        }

        private async void tsbtnRemove_Click(object sender, EventArgs e)
        {
            if (lstvCurriculum.SelectedItems.Count > 0)
            {
                ApplicationCore.Model.Curriculum selectedCurriulum = (ApplicationCore.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
                ApplicationCore.Services.CurriculumService service = new ApplicationCore.Services.CurriculumService();
                await service.Delete(selectedCurriulum.Id);
                lstvCurriculum.Items.Clear();
                AdaptCurriculumsToListView(await service.GetAll());
                lstvCurriculum.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de remover");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filteredCurriculums = this.curriculumList.Where(a => Utilities.DeleteDiacritic(a.Description.ToLower()).Contains(Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower())));
            lstvCurriculum.Items.Clear();
            AdaptCurriculumsToListView(filteredCurriculums);
            lstvCurriculum.Refresh();
        }
    }
}
