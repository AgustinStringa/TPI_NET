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
        private Domain.Model.User user;
        private IEnumerable<Domain.Model.Course> courses;
        private List<Domain.Model.Subject> subjects = new List<Domain.Model.Subject>();
        public frmInscripcionCursado(Domain.Model.User user)
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
                if (course.Subject != null && !this.subjects.Contains(course.Subject))
                {
                    this.subjects.Add(course.Subject);
                }
            }

            if (this.subjects.Count == 0)
            {
                MessageBox.Show("No hay materias disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                return;
            }

            cmbSubject.Items.Clear();
            cmbSubject.DataSource = this.subjects;
            cmbSubject.ValueMember = "Id";
            cmbSubject.DisplayMember = "Description";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info de la materia. \n Horas semanales: 123 \n horas totales: 64 \n", "Ingeniería y Calidad de Software", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void cmbSubjects_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (cmbSubject.SelectedItem == null)
            {
                return;
            }
            int subjectId = ((Domain.Model.Subject)(cmbSubject.SelectedItem)).Id;
            var filteredCourses = this.courses.Where(c => c.Subject.Id == subjectId);
            cmbCourse.DataSource = filteredCourses.ToList();
            cmbCourse.ValueMember = "Id";
            cmbCourse.DisplayMember = "ToStringProperty";
        }

        private async void btnInscription_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCourse.SelectedItem == null || cmbSubject.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userCourse = new Domain.Model.UserCourse()
                {
                    UserId = this.user.Id,
                    CourseId = ((Domain.Model.Course)cmbCourse.SelectedItem).Id,
                    Status = "inscripto"
                };

                var userCourseService = new Domain.Services.UserCourseService();
                await userCourseService.Add(userCourse);

                MessageBox.Show("Inscripción realizada con éxito", "Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
