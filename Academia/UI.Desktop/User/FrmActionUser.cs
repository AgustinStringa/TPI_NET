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
		private ApplicationCore.Model.Student User;
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
				this.Mode = mode;
				this.userService = serviceProvider.GetRequiredService<ClientService.IUserService>();
				this.studentService = serviceProvider.GetRequiredService<IStudentService>();
				this.teacherService = serviceProvider.GetRequiredService<ITeacherService>();
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				this.administrativeService = serviceProvider.GetRequiredService<IAdministrativeService>();
				InitializeComponent();
				btnActionUser.Text = "Crear Usuario";
				dtpBirthDate.Value = DateTime.Now;
				LoadAreas();
			}
		}
		public FrmActionUser(Mode mode, UserDTO userDTO, IServiceProvider serviceProvider)
		{
			if (mode == Mode.Edit)
			{
				InitializeComponent();
				this.Mode = mode;
				this.userDTO = userDTO;
				this.studentService = serviceProvider.GetRequiredService<IStudentService>();
				this.teacherService = serviceProvider.GetRequiredService<ITeacherService>();
				this.administrativeService = serviceProvider.GetRequiredService<IAdministrativeService>();
				this.areaService = serviceProvider.GetRequiredService<IAreaService>();
				btnActionUser.Text = "Guardar Usuario";
				FillFields(userDTO);
			}
		}

		private async void LoadAreas()
		{
			if (this.Mode == Mode.Create)
			{
				Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAllAsync());
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
					txtUsername.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblUsernameError.Visible = true;
				}
				else
				{
					txtUsername.ForeColor = SystemColors.WindowText;
					lblUsernameError.Visible = false;
				}


				//NAME
				string name = txtName.Text.Trim();
				bool validName = Validations.IsValidName(name);
				if (!validName)
				{
					txtName.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblNombreError.Visible = true;
				}
				else
				{
					txtName.ForeColor = SystemColors.WindowText;
					lblNombreError.Visible = false;
				}

				//LASTANAME
				string lastname = txtLastName.Text.Trim();
				bool validLastname = Validations.IsValidLastname(lastname);
				if (!validLastname)
				{
					txtLastName.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblApellidoError.Visible = true;
				}
				else
				{
					txtLastName.ForeColor = SystemColors.WindowText;
					lblApellidoError.Visible = false;
				}

				//PASSWORD
				string password = mtbPassword.Text.Trim();
				bool validPassword = Validations.IsValidPassword(password);
				if (!validPassword)
				{
					mtbPassword.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblClaveError.Visible = true;
				}
				else
				{
					mtbPassword.ForeColor = SystemColors.WindowText;
					lblClaveError.Visible = false;
				}


				//EMAIL

				string email = txtEmail.Text.Trim();
				bool validEmail = Validations.IsValidEmail(email);
				if (!validEmail)
				{
					txtEmail.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblEmailError.Visible = true;
				}
				else
				{
					txtEmail.ForeColor = SystemColors.WindowText;
					lblEmailError.Visible = false;
				}

				//ADDRESS

				string address = txtAddress.Text.Trim();
				bool validAddress = Validations.IsValidAddress(address);
				if (!validAddress)
				{
					txtAddress.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblAddressError.Visible = true;
				}
				else
				{
					txtAddress.ForeColor = SystemColors.WindowText;
					lblAddressError.Visible = false;
				}

				//PHONE NUMBER

				string phoneNumber = txtPhoneNumber.Text.Trim();
				bool validPhoneNumber = Validations.IsValidPhoneNumber(phoneNumber);
				if (!validPhoneNumber)
				{
					txtPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblPhoneNumberError.Visible = true;
				}
				else
				{
					txtPhoneNumber.ForeColor = SystemColors.WindowText;
					lblPhoneNumberError.Visible = false;
				}

				//DATEBIRTH

				DateTime birthDate = dtpBirthDate.Value;
				bool validBirthDate = Validations.IsValidBirthDate(birthDate);
				if (!validBirthDate)
				{
					dtpBirthDate.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
					lblBirthDateError.Visible = true;

				}
				else
				{
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
						txtCuit.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
						lblCuitError.Visible = true;
					}
					else
					{
						txtCuit.ForeColor = SystemColors.WindowText;
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
					//LEGAJO
					studentId = txtStudentId.Text.Trim();
					studentId = studentId.Replace(".", "");
					validStudentId = Validations.IsValidStudentId(studentId);

					if (!validStudentId)
					{
						txtStudentId.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
						lblLegajoError.Visible = true;
					}
					else
					{
						txtStudentId.ForeColor = SystemColors.WindowText;
						lblStudentId.Visible = false;
					}
				}
				else
				{
					validStudentId = false;
				}


				if (this.Mode == Mode.Create)
				{
					int usertype = 0;

					ApplicationCore.Model.Curriculum curriculum = null;
					if (!rbtnUserAdministrative.Checked
					&& !rbtnUserStudent.Checked
					&& !rbtnUserTeacher.Checked)
					{
						MessageBox.Show("Seleccione el tipo de usuario (Alumno, Docente, Administrativo)", "Tipo de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					else
					{
						if (rbtnUserAdministrative.Checked)
						{

							usertype = 1;
						}
						else if (rbtnUserTeacher.Checked)
						{
							usertype = 2;

						}
						else if (rbtnUserStudent.Checked)
						{
							usertype = 3;

						}

					}
					if (usertype == 1 || usertype == 2)
					{
						correctForm = validUsername && validName && validLastname
						&& validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
						&& validCuit;
					}
					else if (usertype == 3)
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

					if (correctForm)
					{
						switch (usertype)
						{
							case 1:
								var newAdministrative = new ApplicationCore.Model.Administrative
								{
									Username = username,
									Password = password,
									Email = email,
									Name = name,
									Lastname = lastname,
									Address = address,
									PhoneNumber = phoneNumber,
									BirthDate = birthDate,
									Cuit = cuit
								};

								await this.administrativeService.CreateAsync(newAdministrative);
								break;
							case 2:
								var newTeacher = new ApplicationCore.Model.Teacher
								{
									Username = username,
									Password = password,
									Email = email,
									Name = name,
									Lastname = lastname,
									Address = address,
									PhoneNumber = phoneNumber,
									BirthDate = birthDate,
									Cuit = cuit
								};

								await this.teacherService.CreateAsync(newTeacher);
								break;

							case 3:
								var newStudent = new ApplicationCore.Model.Student
								{
									Username = username,
									Password = password,
									Email = email,
									Name = name,
									Lastname = lastname,
									Address = address,
									PhoneNumber = phoneNumber,
									BirthDate = birthDate,
									StudentId = studentId,
								};

								if (curriculum != null)
								{
									newStudent.CurriculumId = curriculum.Id;
								}
								await this.studentService.CreateAsync(newStudent);
								break;


						}

						MessageBox.Show("Usuario creado exitosamente", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DialogResult = DialogResult.OK;
						this.Close();
					}
				}
				else if (this.Mode == Mode.Edit)
				{
					//var usertype = User.UserType;

					correctForm = validUsername && validName && validLastname
					   && validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
					   ;

					User.Username = username;
					User.Password = Utilities.EncodePassword(password);
					User.Email = email;
					User.Name = name;
					User.Lastname = lastname;
					User.BirthDate = birthDate;
					User.PhoneNumber = phoneNumber;

					User.Address = address;

					//if (usertype == 1 || usertype == 2)
					//{
					//    correctForm = correctForm && validCuit;
					//    //User.Cuit = cuit;
					//}
					//else if (usertype == 3)
					//{
					//    correctForm = correctForm && validStudentId;
					//    //User.StudentId = studentId;
					//}

					if (correctForm)
					{
						try
						{
							var userService = new ApplicationCore.Services.UserService();
							userService.Update(User);
							MessageBox.Show("Usuario actualizado exitosamente", "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
							DialogResult = DialogResult.OK;
							this.Close();
						}
						catch (Exception)
						{
							throw;
						}

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
				throw ex;
			}
		}

		private void rbtn_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnUserStudent.Checked)
			{
				cbAreas.Enabled = true;
				if (cbAreas.DataSource is null)
				{
					Utilities.LoadAreas(cbAreas);
				}

				cbAreas.SelectedIndex = 0;
				cbAreas.Visible = true;
				lblArea.Visible = true;
				cbCurriculums.Enabled = true;
				cbCurriculums.Visible = true;
				lblCurriculum.Visible = true;

				txtStudentId.Visible = true;
				lblStudentId.Visible = true;
				txtCuit.Visible = false;
				lblCuit.Visible = false;
			}
			else if (rbtnUserAdministrative.Checked || rbtnUserTeacher.Checked)
			{

				lblCurriculum.Visible = false;
				lblArea.Visible = false;
				cbAreas.Visible = false;
				cbCurriculums.Visible = false;
				cbAreas.Enabled = false;
				cbCurriculums.Enabled = false;
				cbAreas.ResetText();
				cbCurriculums.ResetText();
				txtCuit.Visible = true;
				txtCuit.Enabled = true;
				lblCuit.Visible = true;
				txtStudentId.Visible = false;
				lblStudentId.Visible = false;
			}
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
					txtStudentId.Text = teacher.TeacherId.ToString();
					break;
				case "Student":
					var student = await studentService.GetById(userDTO.Id);
					txtStudentId.Visible = true;
					lblStudentId.Visible = true;
					txtCuit.Visible = false;
					lblCuit.Visible = false;
					txtStudentId.Text = student.StudentId;
					Utilities.AdaptAreasToCb(cbAreas, await areaService.GetAllAsync(), student.Curriculum.AreaId);
					break;
				default:
					break;
			}
		}

	}
}
