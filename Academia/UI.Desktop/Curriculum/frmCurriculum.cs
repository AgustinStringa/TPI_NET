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


namespace UI.Desktop.Curriculum
{
    public partial class frmCurriculum : Form
    {
        private IEnumerable<Domain.Model.Curriculum> curriculumList;
        public frmCurriculum()
        {
            InitializeComponent();
            LoadCurriculums();
        }
        private void AdaptCurriculumsToListView(IEnumerable<Domain.Model.Curriculum> curriculumList)
        {
            foreach (Domain.Model.Curriculum item in curriculumList)
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
                var service = new Domain.Services.CurriculumService();
                this.curriculumList = service.GetAll();
                AdaptCurriculumsToListView(curriculumList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionCurriculum frm = new frmActionCurriculum(Mode.Create);
            frm.ShowDialog();
            var service = new Domain.Services.CurriculumService();
            lstvCurriculum.Items.Clear();
            AdaptCurriculumsToListView(service.GetAll());
            lstvCurriculum.Refresh();
        }

        private async void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (lstvCurriculum.SelectedItems.Count > 0)
            {
                var selectedCurriculum = (Domain.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
                var service = new Domain.Services.CurriculumService();
                frmActionCurriculum frm = new frmActionCurriculum(Mode.Edit, selectedCurriculum);
                frm.ShowDialog();
                lstvCurriculum.Items.Clear();
                AdaptCurriculumsToListView(service.GetAll());
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
                Domain.Model.Curriculum selectedCurriulum = (Domain.Model.Curriculum)lstvCurriculum.SelectedItems[0].Tag;
                Domain.Services.CurriculumService service = new Domain.Services.CurriculumService();
                service.Delete(selectedCurriulum.Id);
                lstvCurriculum.Items.Clear();
                AdaptCurriculumsToListView(service.GetAll());
                lstvCurriculum.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione 1 area antes de remover");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filteredCurriculums = this.curriculumList.Where(a => a.Description.ToLower().Contains(((System.Windows.Forms.TextBox)sender).Text.ToLower()));
            lstvCurriculum.Items.Clear();
            AdaptCurriculumsToListView(filteredCurriculums);
            lstvCurriculum.Refresh();
        }
    }
}
