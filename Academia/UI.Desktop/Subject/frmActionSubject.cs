using ApplicationCore.Model;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Curriculum;

namespace UI.Desktop.Subject
{

    public partial class FrmActionSubject : Form
    {

        #region Fields
        private ApplicationCore.Model.Subject subject;
        private IEnumerable<ApplicationCore.Model.Curriculum> curriculums;
        private Mode Mode;
        #endregion

        #region Constructors
        public FrmActionSubject(Mode mode, ApplicationCore.Model.Subject subj)
        {
            InitializeComponent();
            if (mode == Mode.Edit)
            {
                subject = subj;
                btnAccept.Text = "Guardar Materia";
                Utilities.LoadCurriculums(curriculums, cbCurriculums, subject.IdCurriculum);
                txtDescription.Text = subject.Description;
                txtTotalHours.Text = subject.TotalHours.ToString();
                txtWeeklyHours.Text = subject.WeeklyHours.ToString();
                numLevel.Value = subject.Level;
                LoadCorrelatives();
            }
        }
        public FrmActionSubject(Mode mode)
        {
            InitializeComponent();
            if (mode == Mode.Create)
            {
                this.Mode = mode;
                btnAccept.Text = "Crear Materia";
                Utilities.LoadCurriculums(curriculums, cbCurriculums);
            }
        }
        #endregion

        #region Methods
        private void LoadCorrelatives()
        {
            lstCorrelativesChildren.Items.Clear();
            lstCorrelativesParent.Items.Clear();
            foreach (ApplicationCore.Model.Correlative item in subject.CorrelativesChildren)
            {
                lstCorrelativesChildren.Items.Add(new ListBoxItem { DisplayText = item.CorrelativeSubject.Description, Tag = item });
            }
            foreach (ApplicationCore.Model.Correlative item in subject.CorrelativesParents)
            {
                lstCorrelativesParent.Items.Add(new ListBoxItem { DisplayText = item.Subject.Description, Tag = item });
            }
        }
        #endregion

        #region Events
        private async void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string description = txtDescription.Text.Trim();
                int totalHours = int.Parse(txtTotalHours.Text.Trim());
                int weeklyHours = int.Parse(txtWeeklyHours.Text.Trim());
                int level = (int)numLevel.Value;
                ApplicationCore.Model.Curriculum curriculum = (ApplicationCore.Model.Curriculum)cbCurriculums.SelectedItem;
                var service = new SubjectService();
                switch (Mode)
                {
                    case Mode.Edit:
                        subject.Description = description;
                        subject.TotalHours = totalHours;
                        subject.WeeklyHours = weeklyHours;
                        subject.Level = level;
                        subject.IdCurriculum = curriculum.Id;
                        service.Update(subject);
                        MessageBox.Show("Materia Actualizada correctamente");
                        this.Dispose();
                        break;
                    case Mode.Create:
                        var newSubject = new ApplicationCore.Model.Subject
                        {
                            Description = description,
                            TotalHours = totalHours,
                            WeeklyHours = weeklyHours,
                            Level = level,
                            IdCurriculum = curriculum.Id,
                        };
                        service.Create(newSubject);
                        MessageBox.Show("Materia creada correctamente");
                        this.Dispose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw;

            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddCorrelativeParent_Click(object sender, EventArgs e)
        {
            SubjectList frm = new SubjectList(subject, CorrelativeType.Parent);
            frm.ShowDialog();
            LoadCorrelatives();
        }

        private void btnAddCorrelativeChildren_Click(object sender, EventArgs e)
        {
            SubjectList frm = new SubjectList(subject, CorrelativeType.Children);
            frm.ShowDialog();
            LoadCorrelatives();
        }

        private void btnRemoveCorrelativeParent_Click(object sender, EventArgs e)
        {
            if (lstCorrelativesParent.SelectedItems.Count > 0)
            {
                ApplicationCore.Model.Correlative correlativeToDelete = ((ListBoxItem)lstCorrelativesParent.SelectedItems[0]).Tag;
                var service = new CorrelativeService();
                service.Delete(correlativeToDelete);
                subject.CorrelativesParents.Remove(correlativeToDelete);
            }
            LoadCorrelatives();

        }

        private void btnRemoveCorrelativeChildren_Click(object sender, EventArgs e)
        {
            if (lstCorrelativesChildren.SelectedItems.Count > 0)
            {
                ApplicationCore.Model.Correlative correlativeToDelete = ((ListBoxItem)lstCorrelativesChildren.SelectedItems[0]).Tag;
                var service = new CorrelativeService();
                service.Delete(correlativeToDelete);
                subject.CorrelativesChildren.Remove(correlativeToDelete);
            }
            LoadCorrelatives();
        }
        #endregion
    }
}
