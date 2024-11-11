using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService.Course;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Course
{
    public partial class FrmCourse : Form
    {
        private IEnumerable<ApplicationCore.Model.Course> courses = [];
        private IServiceProvider serviceProvider;
        private ICourseService courseService;
        public FrmCourse(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            StylizeList();
            this.serviceProvider = serviceProvider;
            this.courseService = serviceProvider.GetRequiredService<ICourseService>();
            LoadCourses();
        }

        private void StylizeList()
        {
            Utilities.StyleListViewHeader(lstvCourses, Color.FromArgb(184, 218, 255));
        }

        private async void LoadCourses()
        {
            try
            {
                lstvCourses.Enabled = false;
                this.courses = await courseService.GetAll();
                AdaptCoursesToListView(this.courses);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los cursados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstvCourses.Enabled = true;
            }
        }

        private void AdaptCoursesToListView(IEnumerable<ApplicationCore.Model.Course> coursesList)
        {
            lstvCourses.Items.Clear();
            foreach (ApplicationCore.Model.Course item in coursesList)
            {
                ListViewItem nuevoItem = new ListViewItem(item.Subject.Curriculum.Description);
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Subject.Description);
                nuevoItem.SubItems.Add(item.Commission.Description);
                nuevoItem.SubItems.Add(item.CalendarYear);
                nuevoItem.SubItems.Add(item.Capacity.ToString());
                lstvCourses.Items.Add(nuevoItem);
            }
            lstvCourses.Refresh();
        }

        private void lstvAreas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var orderFilter = lstvCourses.Columns[e.Column].Tag.ToString();

            IEnumerable<ApplicationCore.Model.Course> orderedCourses = new List<ApplicationCore.Model.Course>();
            if (orderFilter == "Subject.Description")
            {
                orderedCourses = this.courses.ToList().OrderBy(c => c.Subject.Description);
            }
            else if (orderFilter == "Capacity")
            {
                orderedCourses = this.courses.ToList().OrderBy(c => c.Capacity);
            }
            else if (orderFilter == "CalendarYear")
            {
                orderedCourses = this.courses.ToList().OrderBy(c => c.CalendarYear);
            }
            AdaptCoursesToListView(orderedCourses);
        }

        private void tsbtnAddCourse_Click(object sender, EventArgs e)
        {
            FrmActionCourse frm = new FrmActionCourse(Mode.Create, this.serviceProvider);
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadCourses();
            }
        }

        private void tsbtnEditCourse_Click(object sender, EventArgs e)
        {
            if (lstvCourses.SelectedItems.Count > 0)
            {
                try
                {
                    ApplicationCore.Model.Course selectedCourse = (ApplicationCore.Model.Course)lstvCourses.SelectedItems[0].Tag;
                    FrmActionCourse frm = new FrmActionCourse(Mode.Edit, selectedCourse, this.serviceProvider);
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        LoadCourses();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Seleccione un cursado antes de editar", "Editar Cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void tsbtnRemoveCourse_Click(object sender, EventArgs e)
        {
            if (lstvCourses.SelectedItems.Count > 0)
            {
                try
                {
                    if (Utilities.ConfirmDelete("este cursado") != DialogResult.OK) return;
                    ApplicationCore.Model.Course selectedCourse = (ApplicationCore.Model.Course)lstvCourses.SelectedItems[0].Tag;
                    await courseService.Delete(selectedCourse.Id);
                    MessageBox.Show("Cursado eliminado correctamente", "Eliminar Cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCourses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eliminar cursado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cursado antes de eliminar", "Eliminar Cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearchCourses_TextChanged(object sender, EventArgs e)
        {
            if (this.courses != null && this.courses.Count() > 0)
            {
                var search = Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower());

                var coursesFiltered = this.courses.Where(a =>
                    Utilities.DeleteDiacritic(a.Subject.Description.ToLower()).Contains(search)
                );

                AdaptCoursesToListView(coursesFiltered);
            }
        }
    }
}
