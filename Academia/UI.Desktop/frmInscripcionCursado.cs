using Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;
namespace UI.Desktop
{
    public partial class frmInscripcionCursado : Form
    {
        private User user;
        private IEnumerable<Domain.Model.Course> courses;
        private List<Domain.Model.Subject> subjects = new List<Domain.Model.Subject>();
        public frmInscripcionCursado(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadCourses();
        }
        private async void LoadCourses()
        {
            var courseService = new CourseService();
            this.courses = await courseService.GetAvailableCourses(user);
            foreach (var course in this.courses)
            {

                if (!this.subjects.Contains(course.Subject))
                {
                    this.subjects.Add(course.Subject);
                }
            }
            cmbSubjects.Items.Clear();
            cmbSubjects.DataSource = this.subjects;
            cmbSubjects.ValueMember = "Id";
            cmbSubjects.DisplayMember = "Description";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info de la materia. \n Horas semanales: 123 \n horas totales: 64 \n", "Ingeniería y Calidad de Software", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void cmbSubjects_SelectedValueChanged(object sender, EventArgs e)
        {
            int subjectId = ((Domain.Model.Subject)(cmbSubjects.SelectedItem)).Id;
            var filteredCourses = this.courses.Where(c => c.Subject.Id == subjectId);
            cmbCourse.DataSource = filteredCourses.ToList();
            cmbCourse.ValueMember = "Id";
            cmbCourse.DisplayMember = "ToStringProperty";
        }
    }
}
