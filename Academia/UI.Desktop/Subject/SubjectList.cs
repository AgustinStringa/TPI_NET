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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.Desktop.Subject
{
    public partial class SubjectList : Form
    {
        private ApplicationCore.Model.Subject subject;
        UI.Desktop.CorrelativeType type;
        public SubjectList(ApplicationCore.Model.Subject subject, UI.Desktop.CorrelativeType type)
        {
            InitializeComponent();
            this.subject = subject;
            this.type = type;
            //dada la subject y el Parent||children -> encontrar posibles materias
            LoadSubjects(type);
        }

        private async void LoadSubjects(CorrelativeType type)

        {
            var service = new SubjectService();
            lstCorrelativeSubjects.Items.Clear();
            IEnumerable<ApplicationCore.Model.Subject> subjectList = new List<ApplicationCore.Model.Subject>();
            if (type == CorrelativeType.Children)
            {
                subjectList = await service.GetPossibleChildrenCorrelatives(subject);
            }
            else if (type == CorrelativeType.Parent)
            {
                subjectList = await service.GetPossibleParentCorrelatives(subject);

            }

            foreach (ApplicationCore.Model.Subject item in subjectList)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Description);
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Level.ToString());
                lstCorrelativeSubjects.Items.Add(nuevoItem);
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //encuentro la materia seleccionada.
            //dependiendo del tipo padre/hijo añado a una u otra coleccion
            // guardo
            try
            {
                if (lstCorrelativeSubjects.SelectedItems.Count > 0)
                {

                    ApplicationCore.Model.Subject selectedSubject = (ApplicationCore.Model.Subject)lstCorrelativeSubjects.SelectedItems[0].Tag;

                    if (this.type == CorrelativeType.Parent)
                    {
                        var newCorrelative = new ApplicationCore.Model.Correlative
                        {
                            CorrelativeId = subject.Id,
                            SubjectId = selectedSubject.Id,
                            To = "cursar",
                            Status = "regular"
                        };

                        var service = new CorrelativeService();
                        //hacer que el servicio me la devuelva creada y ahi add aal array
                        newCorrelative = await service.Create(newCorrelative);

                        this.subject.CorrelativesParents.Add(newCorrelative);
                    }
                    else if (this.type == CorrelativeType.Children)
                    {
                        var newCorrelative = new ApplicationCore.Model.Correlative
                        {
                            CorrelativeId = selectedSubject.Id,
                            SubjectId = subject.Id,
                            To = "cursar",
                            Status = "regular"
                        };
                        var service = new CorrelativeService();
                        //hacer que el servicio me la devuelva creada y ahi add aal array
                        newCorrelative = await service.Create(newCorrelative);
                        this.subject.CorrelativesChildren.Add(newCorrelative);
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

    }
}
