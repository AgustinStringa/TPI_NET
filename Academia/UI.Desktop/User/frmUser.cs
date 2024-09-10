﻿using Domain.Services;
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

    public partial class FrmUser : Form
    {
        private IEnumerable<Domain.Model.User> users = [];
        private IEnumerable<Domain.Model.User> filteredUsers = [];
        private string textSearch = "";
        private List<UserType> userTypeFilters = [UserType.Student, UserType.Teacher, UserType.Administrative];
        public FrmUser()
        {
            InitializeComponent();
            chbAdministrative.Tag = UserType.Administrative;
            chbStudent.Tag = UserType.Student;
            chbTeacher.Tag = UserType.Teacher;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var service = new UserService();
            this.users = await service.GetAll();
            this.filteredUsers = this.users;
            AdaptUsersToListView(this.filteredUsers);
        }

        private void AdaptUsersToListView(IEnumerable<Domain.Model.User> users)
        {
            lstUsers.Items.Clear();
            foreach (Domain.Model.User user in users)
            {
                ListViewItem item = new ListViewItem(user.Name);
                item.Tag = user;
                item.SubItems.Add(user.Lastname);
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.StudentId != null ? user.StudentId : "-");
                item.SubItems.Add(user.Cuit != null ? user.Cuit : "-");
                lstUsers.Items.Add(item);
            }
            lstUsers.Refresh();
        }

        private void txtSearchUsers_TextChanged(object sender, EventArgs e)
        {
            var search = Data.Util.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower());
            if (search != this.textSearch)
            {
                this.textSearch = search;
                ApplyFilters();
            }
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UserType userType = (UserType)checkBox.Tag;
            chbAll.Checked = false;
            if (checkBox.Checked)
            {
                if (!this.userTypeFilters.Contains(userType))
                {
                    this.userTypeFilters.Add(userType);
                    ApplyFilters();
                }
            }
            else
            {
                if (this.userTypeFilters.Contains(userType))
                {
                    this.userTypeFilters.Remove(userType);
                    ApplyFilters();
                }
            }
        }
        private void ApplyFilters()
        {
            this.filteredUsers = this.users.Where(
                u => Data.Util.DeleteDiacritic(u.Name.ToLower()).Contains(this.textSearch)
                  || Data.Util.DeleteDiacritic(u.Lastname.ToLower()).Contains(this.textSearch)
                   || ((u.StudentId != null) && Data.Util.DeleteDiacritic(u.StudentId.ToLower()).Contains(this.textSearch))
                 || ((u.Cuit != null) && Data.Util.DeleteDiacritic(u.Cuit.ToLower()).Contains(this.textSearch))
                   );
            lstUsers.Items.Clear();
            this.filteredUsers = this.filteredUsers.Where(u => this.userTypeFilters.Contains(GetUserType(u.UserType)));
            AdaptUsersToListView(this.filteredUsers);
            lstUsers.Refresh();
        }

        private void tsbtnDeleteUser_Click(object sender, EventArgs e)
        {

            var selectedUser = (lstUsers.SelectedItems[0].Tag as Domain.Model.User);
            if (selectedUser != null)
            {
                // verificar que haya seleccionado un item
                var response = MessageBox.Show("You really want to delete the user? \n username: " +
                    selectedUser.Username + " \n firstName: " + selectedUser.Name + " \n last name: " + selectedUser.Lastname + "\n this will remove all data related to user like inscriptions", "delete user", MessageBoxButtons.OKCancel);
                if (response == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var userService = new UserService();
                        userService.Delete(selectedUser);
                        //ver como proceder con error en eliminacion
                        MessageBox.Show("User removed successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Select a user before remove");

                }
                //system.windows.forms.dialog.DialogResult
                // System.Windows.Forms.DialogResult.OK
                //System.Windows.Forms.DialogResult.Cancel
            }

        }

        private void tsbtnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedUser = (lstUsers.SelectedItems[0].Tag as Domain.Model.User);
                if (selectedUser != null)
                {
                    FrmActionUser App = new FrmActionUser(Mode.Edit, selectedUser);
                    App.ShowDialog();
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Select a user before edit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private UserType GetUserType(int val)
        {
            switch (val)
            {
                case 1:
                    return UserType.Administrative;
                    break;
                case 2:
                    return UserType.Teacher;
                    break;
                case 3:
                    return UserType.Student;
                    break;
                default:
                    return UserType.Administrative;
                    break;
            }

        }
        private void chbAll_Click(object sender, EventArgs e)
        {
            if (chbAll.Checked)
            {
                chbAdministrative.Checked = true;
                chbTeacher.Checked = true;
                chbStudent.Checked = true;
                this.userTypeFilters = [UserType.Student, UserType.Teacher, UserType.Administrative];
            }
        }
        private void tsbtnAddUser_Click(object sender, EventArgs e)
        {
            FrmActionUser AppCreateUser = new FrmActionUser(Mode.Create);
            AppCreateUser.ShowDialog();
        }
    }
}
