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
        public frmInscripcionCursado(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadCourses();
        }
        private async void LoadCourses() {
            var courseService = new CourseService();
            var cursos = await courseService.GetAvailableCourses(user);
            cmbCourse.Items.Clear();
            cmbCourse.DataSource = cursos;
            cmbCourse.ValueMember = "Id";
            cmbCourse.DisplayMember = "IdSubject";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info de la materia. \n Horas semanales: 123 \n horas totales: 64 \n", "Ingeniería y Calidad de Software", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
