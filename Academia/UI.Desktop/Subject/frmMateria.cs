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
using Domain.Model;
using Domain.Services;

namespace UI.Desktop.Subject
{
    public partial class frmMateria : Form
    {
        private IEnumerable<Domain.Model.Subject> subjects;
        private List<Domain.Model.Curriculum> curriculums = new List<Domain.Model.Curriculum>();
        public frmMateria()
        {
            InitializeComponent();
            LoadSubjects();
        }
        private async void LoadSubjects()
        {
            var service = new SubjectService();
            subjects = await service.GetAll();
            AdaptSubjectsToListView(subjects);
            CreateRbtnFilters();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionSubject frm = new frmActionSubject(Mode.Create);
            frm.ShowDialog();
            LoadSubjects();
        }

        private void AdaptSubjectsToListView(IEnumerable<Domain.Model.Subject> subjectList)
        {
            listView1.Items.Clear();
            this.curriculums.Clear();
            foreach (Domain.Model.Subject item in subjectList)
            {
                if (!this.curriculums.Contains(item.Curriculum))
                {
                    this.curriculums.Add(item.Curriculum);
                }
                ListViewItem nuevoItem = new ListViewItem(item.Description);
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Curriculum.Description);
                nuevoItem.SubItems.Add(item.Level.ToString());
                nuevoItem.SubItems.Add(item.WeeklyHours.ToString());
                nuevoItem.SubItems.Add(item.TotalHours.ToString());
                listView1.Items.Add(nuevoItem);
            }
        }
        private void CreateRbtnFilters()
        {
            foreach (System.Windows.Forms.Control element in panel1.Controls)
            {
                try
                {
                    panel1.Controls.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            int i = 0;
            foreach (var curriculum in this.curriculums)
            {

                var newControl = new System.Windows.Forms.RadioButton();
                newControl.Tag = curriculum;
                newControl.Text = curriculum.Description;
                newControl.Location = new Point(10, 20 + (i * 30));
                newControl.AutoSize = true;
                newControl.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                panel1.Controls.Add(newControl);
                i++;
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rbtn = (System.Windows.Forms.RadioButton)sender;

            if (rbtn.Checked)
            {
                var filteredSubjects = this.subjects.Where(s => s.Curriculum.Id == (((Domain.Model.Curriculum)rbtn.Tag).Id));
                AdaptSubjectsToListView(filteredSubjects);
                listView1.Refresh();
            }
        }
        private void ResetFilters()
        {
            AdaptSubjectsToListView(this.subjects);
            listView1.Refresh();
            foreach (System.Windows.Forms.Control element in panel1.Controls)
            {
                try
                {
                    if (element.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        ((System.Windows.Forms.RadioButton)element).Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            ResetFilters();
            foreach (System.Windows.Forms.Control element in panel1.Controls)
            {
                try
                {
                    if (element.GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        ((System.Windows.Forms.RadioButton)element).Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void tsbtnDelete_Click(object sender, EventArgs e)
        {
            //encontrar elemento seleccionado
            if (listView1.SelectedItems.Count > 0)
            {
                Domain.Model.Subject selectedSubject = (Domain.Model.Subject)listView1.SelectedItems[0].Tag;
                if (MessageBox.Show("¿Desea Eliminar la asignatura ' " + selectedSubject.Description + " '  ?", "Eliminar asignatura", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var service = new SubjectService();
                    service.Delete(selectedSubject.Id);
                    listView1.Items.Clear();
                    this.subjects = await service.GetAll();
                    AdaptSubjectsToListView(this.subjects);
                    listView1.Refresh();
                    CreateRbtnFilters();
                    ResetFilters();

                    MessageBox.Show("Asginatura eliminada");
                }
                else
                {
                    MessageBox.Show("Asginatura NO eliminada");
                }
            }
        }

        private void txtSearchSubject_TextChanged(object sender, EventArgs e)
        {
            var filteredSubjects = this.subjects.Where(a => Data.Util.DeleteDiacritic(a.Description.ToLower()).Contains(Data.Util.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower())));
            listView1.Items.Clear();
            AdaptSubjectsToListView(filteredSubjects);
            listView1.Refresh();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Domain.Model.Subject selectedSubject = (Domain.Model.Subject)listView1.SelectedItems[0].Tag;
                frmActionSubject frm = new frmActionSubject(Mode.Edit, selectedSubject);
                frm.ShowDialog();
                LoadSubjects();
            }
        }
    }
}
