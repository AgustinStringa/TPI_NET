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
	public partial class FrmTeachersList : Form
	{
		private IEnumerable<ApplicationCore.Model.User> teacherList;
		private FrmActionCourse Parent;

		public FrmTeachersList(IEnumerable<ApplicationCore.Model.User> teacherList, FrmActionCourse parent)
		{
			InitializeComponent();
			this.teacherList = teacherList;
			this.Parent = parent;
			FillTeachers();
		}

		private void FillTeachers()
		{
			foreach (var item in teacherList)
			{
				ListViewItem newItem = new ListViewItem(item.Name + " " + item.Lastname);
				newItem.Tag = item;
				listView1.Items.Add(newItem);
			}
		}

		private void btnAddTeacher_Click(object sender, EventArgs e)
		{

			if (listView1.SelectedItems.Count > 0)
			{

				ApplicationCore.Model.User selectedTeacher = (ApplicationCore.Model.User)listView1.SelectedItems[0].Tag;
				if (selectedTeacher != null)
				{
					this.Parent.newTeacher = selectedTeacher;
					this.Dispose();
				}
			}

		}
	}
}
