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
using System.Linq.Expressions;

namespace UI.Desktop.Subject
{
    public partial class FrmSubject : Form
    {
        private IEnumerable<Domain.Model.Subject> subjects;
        private List<Domain.Model.Curriculum> curriculums = new List<Domain.Model.Curriculum>();
        private string textSearch = "";

        public FrmSubject()
        {
            InitializeComponent();
            LoadSubjects();
        }
        #region events
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            FrmActionSubject frm = new FrmActionSubject(Mode.Create);
            frm.ShowDialog();
            LoadSubjects();
        }
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Domain.Model.Subject selectedSubject = (Domain.Model.Subject)listView1.SelectedItems[0].Tag;
                FrmActionSubject frm = new FrmActionSubject(Mode.Edit, selectedSubject);
                frm.ShowDialog();
                LoadSubjects();
            }

            else
            {
                MessageBox.Show("Seleccione una asignatura antes de editar", "Editar Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void tsbtnDelete_Click(object sender, EventArgs e)
        {
            //encontrar elemento seleccionado

           
                if (listView1.SelectedItems.Count > 0)
                {
                    try {
                        Domain.Model.Subject selectedSubject = (Domain.Model.Subject)listView1.SelectedItems[0].Tag;
                        if (MessageBox.Show("¿Desea Eliminar la asignatura ' " + selectedSubject.Description + " '  ?", "Eliminar asignatura", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            var service = new SubjectService();
                            await service.Delete(selectedSubject.Id);
                            LoadSubjects();
                        }
                        else
                        {
                            MessageBox.Show("Asginatura NO eliminada");
                        }
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

                    MessageBox.Show("Seleccione una asignatura antes de eliminar", "Eliminar asignatura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }
           
        
        private void txtSearchSubject_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void cbCurriculum_SelectedValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            this.txtSearchSubject.Text = "";
            this.cbCurriculum.SelectedIndex = 0;
            AdaptSubjectsToListView(this.subjects);
            listView1.Refresh();
        }
        #endregion

        #region Methods
        private async void LoadSubjects()
        {
            var service = new SubjectService();
            subjects = await service.GetAll();
            AdaptSubjectsToListView(subjects);
            LoadCurriculumFilter();
        }
        private void LoadCurriculumFilter()
        {
            this.curriculums.Clear();
            this.curriculums.Add(new Domain.Model.Curriculum { Description = "Todos los planes" });
            this.curriculums.AddRange(this.subjects.Select(s => s.Curriculum).Distinct().ToList());
            cbCurriculum.DataSource = null;
            cbCurriculum.DataSource = curriculums;
            cbCurriculum.Refresh();
            cbCurriculum.ValueMember = "Id";
            cbCurriculum.DisplayMember = "Description";
        }
        private void AdaptSubjectsToListView(IEnumerable<Domain.Model.Subject> subjectList)
        {
            listView1.Items.Clear();
            foreach (Domain.Model.Subject item in subjectList)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Description);
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Curriculum.Description);
                nuevoItem.SubItems.Add(item.Level.ToString());
                nuevoItem.SubItems.Add(item.WeeklyHours.ToString());
                nuevoItem.SubItems.Add(item.TotalHours.ToString());
                listView1.Items.Add(nuevoItem);
            }
        }
        private void ApplyFilters()
        {
            if (this.subjects == null || this.subjects.Count() <= 0)
            {
                return;
            }
            var filteredSubjects = this.subjects;
            this.textSearch = txtSearchSubject.Text;
            filteredSubjects = filteredSubjects.Where(s => Data.Util.DeleteDiacritic(s.Description.ToLower()).Contains(Data.Util.DeleteDiacritic(this.textSearch.ToLower())));
            if (cbCurriculum.SelectedItem != null && cbCurriculum.SelectedIndex != 0)
            {
                filteredSubjects = filteredSubjects.Where(s => s.IdCurriculum == ((Domain.Model.Curriculum)cbCurriculum.SelectedItem).Id);
            }
            listView1.Items.Clear();
            AdaptSubjectsToListView(filteredSubjects);
            listView1.Refresh();
        }
        #endregion
    }
}
