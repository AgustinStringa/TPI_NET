using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore;
using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService;
using ClientService.Administrative;
using ClientService.Area;
using ClientService.Student;
using ClientService.Teacher;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Desktop
{
	public partial class FrmActionUser : Form
	{
		private Mode Mode;
		private ClientService.IUserService userService;
		private IStudentService studentService;
		private IAreaService areaService;
		private ITeacherService teacherService;
		private IAdministrativeService administrativeService;
		private UserDTO userDTO;

		public FrmActionUser(Mode mode, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Create)
			{
				this.Text = "Crear Usuario";
				this.Mode = mode;
				this.userService = serviceProvider.GetRequiredService<ClientService.IUserService>();
				this.studentService = serviceProvider.GetRequiredService<IStudentService>();
				this.teacherService = serviceProvider.GetRequiredService<ITeacherService>();
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				this.administrativeService = serviceProvider.GetRequiredService<IAdministrativeService>();
				InitializeComponent();
				btnActionUser.Text = "Crear Usuario";
				dtpBirthDate.Value = DateTime.Now;
				btnChangePassword.Visible = false;
				LoadAreas();
			}
			else
			{
				this.Dispose();
			}
		}
		public FrmActionUser(Mode mode, UserDTO userDTO, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Edit)
			{
				InitializeComponent();
				this.Text = "Editar Usuario";
				this.Mode = mode;
				this.userDTO = userDTO;
				this.studentService = serviceProvider.GetRequiredService<IStudentService>();
				this.teacherService = serviceProvider.GetRequiredService<ITeacherService>();
				this.administrativeService = serviceProvider.GetRequiredService<IAdministrativeService>();
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				btnActionUser.Text = "Guardar Usuario";
				this.mtbPassword.Enabled = false;
				btnChangePassword.Visible = true;
				FillFields(userDTO);
			}
			else
			{
				this.Dispose();
			}
		}

		private async void LoadAreas()
		{
			if (this.Mode == Mode.Create)
			{
				Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAll());
			}
		}
		private async void btnActionUser_Click(object sender, EventArgs e)
		{
			try
			{
				bool correctForm = false;
				//USERNAME
				string username = txtUsername.Text.Trim();
				bool validUsername = Validations.IsValidUsername(username);
				if (!validUsername)
				{
					Utilities.SetErrorStyle(lblUsername, txtUsername);
					lblUsernameError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle(lblUsername, txtUsername);
					lblUsernameError.Visible = false;
				}


				//NAME
				string name = txtName.Text.Trim();
				bool validName = Validations.IsValidName(name);
				if (!validName)
				{
					Utilities.SetErrorStyle(lblName, txtName);
					lblNombreError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle(lblName, txtName);
					lblNombreError.Visible = false;
				}

				//LASTANAME
				string lastname = txtLastName.Text.Trim();
				bool validLastname = Validations.IsValidLastname(lastname);
				if (!validLastname)
				{
					Utilities.SetErrorStyle(lblLastName, txtLastName);
					lblApellidoError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle(lblLastName, txtLastName);
					lblApellidoError.Visible = false;
				}

				//PASSWORD
				string password;
				bool validPassword;
				if (mtbPassword.Enabled)
				{
					password = mtbPassword.Text.Trim();
					validPassword = Validations.IsValidPassword(password);
					if (!validPassword)
					{
						Utilities.SetErrorStyle(label: lblPassword, mtb: mtbPassword);
						lblClaveError.Visible = true;
					}
					else
					{
						Utilities.SetDefaultStyle(label: lblPassword, mtb: mtbPassword);
						lblClaveError.Visible = false;
					}
				}
				else
				{
					password = null;
					validPassword = true;
				}


				//EMAIL

				string email = txtEmail.Text.Trim();
				bool validEmail = Validations.IsValidEmail(email);
				if (!validEmail)
				{
					Utilities.SetErrorStyle(lblEmail, txtEmail);
					lblEmailError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle(lblEmail, txtEmail);
					lblEmailError.Visible = false;
				}

				//ADDRESS

				string address = txtAddress.Text.Trim();
				bool validAddress = Validations.IsValidAddress(address);
				if (!validAddress)
				{
					Utilities.SetErrorStyle (lblAddress, txtAddress);
					lblAddressError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle(lblAddress, txtAddress);
					lblAddressError.Visible = false;
				}

				//PHONE NUMBER

				string phoneNumber = txtPhoneNumber.Text.Trim();
				bool validPhoneNumber = Validations.IsValidPhoneNumber(phoneNumber);
				if (!validPhoneNumber)
				{
					Utilities.SetErrorStyle(lblPhoneNumber, txtPhoneNumber);
					lblPhoneNumberError.Visible = true;
				}
				else
				{
					Utilities.SetDefaultStyle (lblPhoneNumber, txtPhoneNumber);
					lblPhoneNumberError.Visible = false;
				}

				//DATEBIRTH

				DateTime birthDate = dtpBirthDate.Value;
				bool validBirthDate = Validations.IsValidBirthDate(birthDate);
				if (!validBirthDate)
				{
					Utilities.SetErrorStyle(lblBirthDate);
					dtpBirthDate.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblBirthDateError.Visible = true;

				}
				else
				{
					Utilities.SetDefaultStyle(lblBirthDate);
					dtpBirthDate.ForeColor = SystemColors.WindowText;
					lblBirthDateError.Visible = false;
				}


				//CUIT
				bool validCuit;
				string cuit = txtCuit.Text.Trim();
				if (txtCuit.Visible == true)
				{
					validCuit = Validations.IsValidCuit(cuit);
					if (!validCuit)
					{
						Utilities.SetErrorStyle (lblCuit,txtCuit);
						lblCuitError.Visible = true;
					}
					else
					{
						Utilities.SetDefaultStyle(lblCuit,txtCuit);
						lblCuitError.Visible = false;
						cuit = cuit.Replace("-", "");
					}
				}
				else
				{
					validCuit = false;
				}
				bool validStudentId;

				string studentId = null;
				if (txtStudentId.Visible == true)
				{
					//LEGAJO ESTUDIANTE
					studentId = txtStudentId.Text.Trim();
					studentId = studentId.Replace(".", "");
					validStudentId = Validations.IsValidStudentId(studentId);

					if (!validStudentId)
					{
						Utilities.SetErrorStyle(lblStudentId,txtStudentId);
						lblLegajoError.Visible = true;
					}
					else
					{
						Utilities.SetDefaultStyle (lblStudentId,txtStudentId);
						lblStudentId.Visible = false;
					}
				}
				else
				{
					validStudentId = false;
				}


				string role;
				ApplicationCore.Model.Curriculum curriculum = null;

				if (rbtnUserAdministrative.Checked || (userDTO!= null && userDTO.Role == "Administrative"))
				{
					role = "Administrative";
				}
				else if (rbtnUserTeacher.Checked || (userDTO != null && userDTO.Role == "Teacher"))
				{
					role = "Teacher";
				}
				else
				{
					role = "Student";
				}


				if (role == "Administrative")
				{
					correctForm = validUsername && validName && validLastname
					&& validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
					&& validCuit;
				}
				else if (role == "Teacher")
				{
					correctForm = validUsername && validName && validLastname
					&& validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
					&& validCuit;
				}
				else if (role == "Student")
				{
					bool validCurriculum = false;

					curriculum = (ApplicationCore.Model.Curriculum)cbCurriculums.SelectedItem;
					if (curriculum == null)
					{
						return;
					}
					else
					{
						validCurriculum = true;
					}


					correctForm = validUsername && validName && validLastname && validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
					&& validCurriculum && validStudentId;
				}
				else
				{
					return;
				}

				if (this.Mode == Mode.Create)
				{

					if (!rbtnUserAdministrative.Checked
					&& !rbtnUserStudent.Checked
					&& !rbtnUserTeacher.Checked)
					{
						MessageBox.Show("Seleccione el tipo de usuario (Alumno, Docente, Administrativo)", "Tipo de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					if (correctForm)
					{
						var newUserDTO = new UserDTO
						{
							Role = role,
							Address = address,
							BirthDate = birthDate,
							Cuit = cuit,
							Email = email,
							Lastname = lastname,
							Name = name,
							Password = password,
							PhoneNumber = phoneNumber,
							StudentId = studentId,
							Username = username,
						};
						await CreateUser(newUserDTO);

					}
				}
				else if (this.Mode == Mode.Edit)
				{
					UserDTO userDTOToUpdate;
					if (userDTO.Role == "Administrative")
					{
						correctForm = correctForm && validCuit;
					}
					else if (userDTO.Role == "Teacher")
					{
						correctForm = correctForm && validCuit;
					}
					else
					{
						correctForm = correctForm && validStudentId;
					}

					if (correctForm)
					{
						userDTOToUpdate = new UserDTO
						{
							Address = address,
							BirthDate = birthDate,
							Cuit = cuit,
							Email = email,
							Id = userDTO.Id,
							Lastname = lastname,
							Name = name,
							PhoneNumber = phoneNumber,
							StudentId = studentId,
							Username = username,
							Password = password != null ? password : null,
						};
						await UpdateUser(userDTOToUpdate);
					}
					else
					{
						return;
					}
				}

				#region SEND EMAIL
				//SEND EMAIL
				//try {

				//    var emailAddress = new MimeKit.MailboxAddress("", email);
				//    bool isValid = true;
				//    using (var client = new SmtpClient())
				//    {
				//        client.Connect("smtp.gmail.com", 587, false);

				//        // Si el servidor SMTP requiere autenticación
				//        client.Authenticate("stringaagustin1@gmail.com", "svwh duri ritq riiz");

				//        var valid = client.Verify(email);
				//        lblOutput.Text = valid.ApplicationCore;
				//        lblOutput.Text = "asdasdasdas";
				//        client.Disconnect(true);

				//        if (valid != null)
				//        {
				//            isValid = true;
				//        }
				//        else { 
				//         isValid = false;   
				//        }

				//    }

				//    if (!isValid)
				//    {
				//        txtEmail.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
				//        lblEmailError.Visible = true;
				//        lblEmailError.Text = "Introduce un correo válido" + txtEmail.Text;

				//    }
				//    else
				//    {
				//        lblEmailError.Visible = false;
				//        txtEmail.ForeColor = SystemColors.WindowText;



				//        //var message = new MimeMessage();


				//        //                message.From.Add(new MailboxAddress("Joey Tribbiani", "stringaagustin1@gmail.com"));
				//        //                message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "agustinstringa24@hotmail.com"));
				//        //                message.Subject = "How you doin'?";

				//        //                message.Body = new TextPart("plain")
				//        //                {
				//        //                    Text = @"Hey Chandler,

				//        //I just wanted to let you know that Monica and I were going to go play some paintball, you in?

				//        //-- Joey"
				//        //                };

				//        //                using (var client = new SmtpClient())
				//        //                {
				//        //                    client.Connect("smtp.gmail.com", 587, false);

				//        //                    //// Note: only needed if the SMTP server requires authentication
				//        //                    client.Authenticate("stringaagustin1@gmail.com", "svwh duri ritq riiz");

				//        //                    client.Send(message);
				//        //                    client.Disconnect(true);
				//        //                }

				//    }



				//}
				//catch (SmtpCommandException ex){
				//    lblOutput.Text = ex.Message;
				//    throw ex;
				//}
				#endregion

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void rbtn_CheckedChanged(object sender, EventArgs e)
		{
			bool student = rbtnUserStudent.Checked;
			bool teacher = rbtnUserTeacher.Checked;
			bool administrative = rbtnUserAdministrative.Checked;

			txtStudentId.Visible = student;
			lblStudentId.Visible = student;
			cbAreas.Enabled = student;
			if (cbAreas.DataSource is null)
			{
				Utilities.LoadAreas(cbAreas);
			}
			cbAreas.SelectedIndex = 0;
			cbAreas.Visible = student;
			lblArea.Visible = student;
			cbCurriculums.Enabled = student;
			cbCurriculums.Visible = student;
			lblCurriculum.Visible = student;

			txtCuit.Visible = teacher || administrative;
			lblCuit.Visible = teacher || administrative;

		}

		private async void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbCurriculums.Enabled = true;
			cbCurriculums.ResetText();
			var curriculumService = new CurriculumService();
			cbCurriculums.DataSource = await curriculumService.GetByAreaId(((ApplicationCore.Model.Area)cbAreas.SelectedItem).Id);
			cbCurriculums.ValueMember = "Id";
			cbCurriculums.DisplayMember = "Description";

		}

		private void ResetForm()
		{
			txtUsername.ResetText();
			mtbPassword.ResetText();
			txtEmail.ResetText();
			txtName.ResetText();
			txtLastName.ResetText();
			txtPhoneNumber.ResetText();
			txtAddress.ResetText();
			txtStudentId.ResetText();
			txtCuit.ResetText();
			dtpBirthDate.ResetText();
		}

		private async void FillFields(UserDTO userDTO)
		{
			txtUsername.Text = userDTO.Username;
			mtbPassword.Text = ""; // VER HASH
			txtEmail.Text = userDTO.Email;
			txtName.Text = userDTO.Name;
			txtLastName.Text = userDTO.Lastname;
			dtpBirthDate.Value = userDTO.BirthDate;
			txtPhoneNumber.Text = userDTO.PhoneNumber;
			txtAddress.Text = userDTO.Address;
			panel2.Visible = false;
			switch (userDTO.Role)
			{
				case "Administrative":
					var administrative = await administrativeService.GetById(userDTO.Id);
					txtStudentId.Visible = false;
					lblStudentId.Visible = false;
					lblTeacherId.Visible = false;
					lblTeacherIdValue.Visible = false;
					txtCuit.Visible = true;
					lblCuit.Visible = true;
					txtCuit.Text = administrative.Cuit;
					break;
				case "Teacher":
					var teacher = await teacherService.GetById(userDTO.Id);
					txtStudentId.Visible = true;
					lblStudentId.Visible = true;
					txtCuit.Visible = true;
					lblCuit.Visible = true;
					txtCuit.Text = teacher.Cuit;
					txtStudentId.Visible = false;
					lblTeacherId.Visible = true;
					lblTeacherIdValue.Visible = true;
					lblTeacherIdValue.Text = teacher.TeacherId.ToString();
					break;
				case "Student":
					var student = await studentService.GetById(userDTO.Id);
					txtStudentId.Visible = true;
					lblStudentId.Visible = true;
					lblTeacherId.Visible = false;
					lblTeacherIdValue.Visible = false;
					txtCuit.Visible = false;
					lblCuit.Visible = false;
					txtStudentId.Text = student.StudentId;
					Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAll(), student.Curriculum.AreaId);
					break;
				default:
					break;
			}
		}


		private async Task CreateUser(UserDTO newUserDTO)
		{
			try
			{
				switch (newUserDTO.Role)
				{
					case "Administrative":
						var newAdministrative = new ApplicationCore.Model.Administrative
						{
							Address = newUserDTO.Address,
							BirthDate = newUserDTO.BirthDate,
							Cuit = newUserDTO.Cuit,
							Email = newUserDTO.Email,
							Lastname = newUserDTO.Lastname,
							Name = newUserDTO.Name,
							Password = newUserDTO.Password,
							PhoneNumber = newUserDTO.PhoneNumber,
							Username = newUserDTO.Username,
						};
						await administrativeService.Create(newAdministrative);

						break;
					case "Student":
						int curriculumId = 0;
						var curriculum = (ApplicationCore.Model.Curriculum)cbCurriculums.SelectedItem;
						if (curriculum != null)
						{
							curriculumId = curriculum.Id;
						}

						var newStudent = new ApplicationCore.Model.Student
						{
							Address = newUserDTO.Address,
							BirthDate = newUserDTO.BirthDate,
							Username = newUserDTO.Username,
							PhoneNumber = newUserDTO.PhoneNumber,
							Email = newUserDTO.Email,
							Lastname = newUserDTO.Lastname,
							Name = newUserDTO.Name,
							Password = newUserDTO.Password,
							StudentId = newUserDTO.StudentId,
							CurriculumId = curriculumId,
						};
						await studentService.Create(newStudent);
						break;
					case "Teacher":
						var newTeacher = new ApplicationCore.Model.Teacher
						{
							Address = newUserDTO.Address,
							BirthDate = newUserDTO.BirthDate,
							Cuit = newUserDTO.Cuit,
							Email = newUserDTO.Email,
							Lastname = newUserDTO.Lastname,
							Name = newUserDTO.Name,
							Password = newUserDTO.Password,
							PhoneNumber = newUserDTO.PhoneNumber,
							Username = newUserDTO.Username,
						};
						await teacherService.Create(newTeacher);
						break;
					default:
						break;

				}
				MessageBox.Show("Usuario creado exitosamente", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Error al crear el usuario");
			}
		}
		private async Task UpdateUser(UserDTO userToUpdateDTO)
		{
			try
			{
				switch (this.userDTO.Role)
				{
					case "Administrative":
						var administrativeToUpdate =
							new Administrative
							{
								Address = userToUpdateDTO.Address,
								BirthDate = userToUpdateDTO.BirthDate,
								Cuit = userToUpdateDTO.Cuit,
								Email = userToUpdateDTO.Email,
								Lastname = userToUpdateDTO.Lastname,
								Name = userToUpdateDTO.Name,
								Password = userToUpdateDTO.Password,
								PhoneNumber = userToUpdateDTO.PhoneNumber,
								Username = userToUpdateDTO.Username,
								Id = userToUpdateDTO.Id,
							};
						await administrativeService.Update(administrativeToUpdate);
						break;
					case "Student":
						var studentToUpdate = new Student
						{
							Address = userToUpdateDTO.Address,
							BirthDate = userToUpdateDTO.BirthDate,
							Username = userToUpdateDTO.Username,
							PhoneNumber = userToUpdateDTO.PhoneNumber,
							Email = userToUpdateDTO.Email,
							Lastname = userToUpdateDTO.Lastname,
							Name = userToUpdateDTO.Name,
							Password = userToUpdateDTO.Password,
							StudentId = userToUpdateDTO.StudentId,
							CurriculumId = null,
							Id = userToUpdateDTO.Id,
							Curriculum = null,
							StudentCourses = [],
						};
						await studentService.Update(studentToUpdate);
						break;
					case "Teacher":
						var teacherToUpdate = new Teacher
						{
							Address = userToUpdateDTO.Address,
							BirthDate = userToUpdateDTO.BirthDate,
							Cuit = userToUpdateDTO.Cuit,
							Email = userToUpdateDTO.Email,
							Lastname = userToUpdateDTO.Lastname,
							Name = userToUpdateDTO.Name,
							Password = userToUpdateDTO.Password,
							PhoneNumber = userToUpdateDTO.PhoneNumber,
							Username = userToUpdateDTO.Username,
							Id = userToUpdateDTO.Id,
						};
						await teacherService.Update(teacherToUpdate);
						break;
					default:
						break;
				}
				MessageBox.Show("Usuario actualizado exitosamente", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Error al guardar el usuario", "Editar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			this.mtbPassword.Enabled = !this.mtbPassword.Enabled;
		}
	}
}
