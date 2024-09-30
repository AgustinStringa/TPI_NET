using ApplicationCore.Model;
using ApplicationCore.Services;
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
using ClientService;

namespace UI.Desktop.User
{

	public partial class FrmUser : Form
	{
		private IEnumerable<UserDTO> users = [];
		private IEnumerable<UserDTO> filteredUsers = [];
		private string textSearch = "";
		private List<UserType> userTypeFilters = [UserType.Student, UserType.Teacher, UserType.Administrative];
		private ClientService.IUserService userService;
		private IServiceProvider serviceProvider;
		public FrmUser(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			chbAdministrative.Tag = UserType.Administrative;
			chbStudent.Tag = UserType.Student;
			chbTeacher.Tag = UserType.Teacher;
			this.serviceProvider = serviceProvider;
			this.userService = serviceProvider.GetRequiredService<ClientService.IUserService>();
			Utilities.StyleListViewHeader(lstUsers, Color.FromArgb(184, 218, 255));
			LoadUsers();
		}

		private async void LoadUsers()
		{
			try
			{
				this.users = await this.userService.GetAllAsync();
				this.filteredUsers = this.users;
				AdaptUsersToListView(this.filteredUsers);
			}
			catch (Exception)
			{
				MessageBox.Show("Error al obtener los usuarios", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void AdaptUsersToListView(IEnumerable<UserDTO> users)
		{
			lstUsers.Items.Clear();
			foreach (var user in users)
			{
				ListViewItem item = new ListViewItem(user.Name);
				item.Tag = user;
				item.SubItems.Add(user.Lastname);
				item.SubItems.Add(user.Username);

				if (user.Role == "Student")
				{
					item.SubItems.Add(user.StudentId);
					item.SubItems.Add("-");
				}
				else if (user.Role == "Teacher")
				{

					item.SubItems.Add(user.TeacherId);
					item.SubItems.Add(user.Cuit);
				}
				else if (user.Role == "Administrative")
				{

					item.SubItems.Add("-");
					item.SubItems.Add(user.Cuit);
				}
				else
				{
					item.SubItems.Add("Unknown");
					item.SubItems.Add("-");
				}
				lstUsers.Items.Add(item);
			}
			lstUsers.Refresh();
		}

		private void txtSearchUsers_TextChanged(object sender, EventArgs e)
		{
			var search = Utilities.DeleteDiacritic(((System.Windows.Forms.TextBox)sender).Text.ToLower());
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
			//this.filteredUsers = this.users.Where(
			//	u => Utilities.DeleteDiacritic(u.Name.ToLower()).Contains(this.textSearch)
			//	  || Utilities.DeleteDiacritic(u.Lastname.ToLower()).Contains(this.textSearch)
			//	   || ((u.StudentId != null) && Utilities.DeleteDiacritic(u.StudentId.ToLower()).Contains(this.textSearch))
			//	 || ((u.Cuit != null) && Utilities.DeleteDiacritic(u.Cuit.ToLower()).Contains(this.textSearch))
			//	   );
			this.filteredUsers = this.users.Where(
		u => Utilities.DeleteDiacritic(u.Name.ToLower()).Contains(this.textSearch)
		|| Utilities.DeleteDiacritic(u.Lastname.ToLower()).Contains(this.textSearch)
		);
			lstUsers.Items.Clear();
			//this.filteredUsers = this.filteredUsers.Where(u => this.userTypeFilters.Contains(GetUserType(u.UserType)));
			AdaptUsersToListView(this.filteredUsers);
			lstUsers.Refresh();
		}

		private async void tsbtnDeleteUser_Click(object sender, EventArgs e)
		{

			var selectedUser = (lstUsers.SelectedItems[0].Tag as UserDTO);
			if (selectedUser != null)
			{
				// verificar que haya seleccionado un item
				var response = MessageBox.Show("¿Estás seguro de eliminar este usuario? \n nombre de usuario: " +
					selectedUser.Username + " \n nombres: " + selectedUser.Name + " \n apellidos: " + selectedUser.Lastname + "\n esta acción eliminará todos los datos asociados al usuario, como inscripciones y no se puede deshacer", "Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (response == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						//var userService = new ApplicationCore.Services.UserService();
						await userService.DeleteAsync(selectedUser.Id);
						//ver como proceder con error en eliminacion
						MessageBox.Show("Usuario eliminado exitosamente", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					finally
					{
						LoadUsers();
					}
				}
			}
			else
			{
				MessageBox.Show("Selecciona un usuario antes de eliminar", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		}

		private async void tsbtnEditUser_Click(object sender, EventArgs e)
		{
			try
			{
				var selectedUserDTO = (lstUsers.SelectedItems[0].Tag as UserDTO);
				if (selectedUserDTO != null)
				{


					FrmActionUser App = new FrmActionUser(Mode.Edit, selectedUserDTO, this.serviceProvider);
					App.ShowDialog();
					//si se editó, DialogResult == OK -> LOADUSERS
					LoadUsers();

				}
				else
				{
					MessageBox.Show("Selecciona un usuario antes de editar ", "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			FrmActionUser AppCreateUser = new FrmActionUser(Mode.Create, this.serviceProvider);
			AppCreateUser.ShowDialog();
			LoadUsers();
		}
	}
}
