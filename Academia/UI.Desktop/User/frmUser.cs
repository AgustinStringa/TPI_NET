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

namespace UI.Desktop.User
{

    public partial class frmUser : Form
    {
        private IEnumerable<Domain.Model.User> users;
        public frmUser()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var service = new UserService();
            this.users = await service.GetAll();
            AdaptUsersToListView(this.users);
        }

        private void AdaptUsersToListView(IEnumerable<Domain.Model.User> users)
        {
            foreach (Domain.Model.User user in users)
            {
                ListViewItem item = new ListViewItem(user.Name);
                item.Tag = user;
                item.SubItems.Add(user.Lastname);
                item.SubItems.Add(user.StudentId);
                item.SubItems.Add(user.Cuit);
                listView1.Items.Add(item);
            }
        }
    }
}
