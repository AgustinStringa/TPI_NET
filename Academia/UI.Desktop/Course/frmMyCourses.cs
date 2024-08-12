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
    public partial class frmMyCourses : Form
    {
        private IEnumerable<Domain.Model.UserCourse> MyCourses;
        public frmMyCourses(Domain.Model.User user)
        {
            InitializeComponent();
            MyCourses = user.UserCourses.Where(c => c.Status == "inscripto");
            AdaptCoursesToListView(MyCourses);
        }
        private void AdaptCoursesToListView(IEnumerable<Domain.Model.UserCourse> courses)
        {
            foreach (var item in MyCourses)
            {
                ListViewItem nuevoItem = new ListViewItem("COMISION");
                nuevoItem.Tag = item;
                nuevoItem.SubItems.Add(item.Course.Subject.Description);
                nuevoItem.SubItems.Add(item.Course.CalendarYear);
                nuevoItem.SubItems.Add(item.Course.Subject.Level.ToString());
                lstvMyCourses.Items.Add(nuevoItem);
            }
        }
    }
}
