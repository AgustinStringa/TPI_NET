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

namespace UI.Desktop
{
    public partial class frmCrearUsuario : Form
    {

        public frmCrearUsuario()
        {
            InitializeComponent();
            Utilities.LoadAreas(cbAreas);
        }

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                bool correctForm = false;
                int usertype = 0;
                string studentId = null;
                string cuit = null;
                ApplicationCore.Model.Curriculum curriculum = null;
                if (!rbtnUserAdministrative.Checked
                    && !rbtnUserStudent.Checked
                    && !rbtnUserTeacher.Checked)
                {
                    MessageBox.Show("Seleccione el tipo de usuario (Alumno, Docente, Administrativo)");
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
                string name = txtNombre.Text.Trim();
                bool validName = Validations.IsValidName(name);
                if (!validName)
                {
                    txtNombre.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                    lblNombreError.Visible = true;
                }
                else
                {
                    txtNombre.ForeColor = SystemColors.WindowText;
                    lblNombreError.Visible = false;
                }

                //LASTANAME
                string lastname = txtApellido.Text.Trim();
                bool validLastname = Validations.IsValidLastname(lastname);
                if (!validLastname)
                {
                    txtApellido.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                    lblApellidoError.Visible = true;
                }
                else
                {
                    txtApellido.ForeColor = SystemColors.WindowText;
                    lblApellidoError.Visible = false;
                }

                //PASSWORD
                string password = mtbClave.Text.Trim();
                bool validPassword = Validations.IsValidPassword(password);
                if (!validPassword)
                {
                    mtbClave.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                    lblClaveError.Visible = true;
                }
                else
                {
                    mtbClave.ForeColor = SystemColors.WindowText;
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
                    lblBirthDate.Visible = true;

                }
                else
                {
                    dtpBirthDate.ForeColor = SystemColors.WindowText;
                    lblBirthDate.Visible = false;
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



                if (usertype == 1 || usertype == 2)
                {
                    //CUIT

                    cuit = txtCuit.Text.Trim();
                    bool validCuit = Validations.IsValidCuit(cuit);
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



                    correctForm = validUsername && validName && validLastname
                        && validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
                       && validCuit;
                }

                else if (usertype == 3)
                {
                    //LEGAJO
                    studentId = txtLegajo.Text.Trim();
                    studentId = studentId.Replace(".", "");
                    bool validStudentId = Validations.IsValidStudentId(studentId);

                    if (!validStudentId)
                    {
                        txtLegajo.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                        lblLegajoError.Visible = true;
                    }
                    else
                    {
                        txtLegajo.ForeColor = SystemColors.WindowText;
                        lblLegajo.Visible = false;
                    }

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
                    IUserService service = new ApplicationCore.Services.UserService();

                    var newUser = new ApplicationCore.Model.User
                    {
                        Username = username,
                        Password = Utilities.EncodePassword(password),
                        Email = email,
                        Name = name,
                        Lastname = lastname,
                        Address = address,
                        PhoneNumber = phoneNumber,
                        BirthDate = birthDate,
                        Cuit = cuit,
                        UserType = usertype,
                        StudentId = studentId,
                    };
                    if (curriculum != null)
                    {
                        newUser.CurriculumId = curriculum.Id;
                    }
                    service.Add(newUser);
                    MessageBox.Show("Usuario creado");
                    ResetForm();
                }
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

                txtLegajo.Visible = true;
                lblLegajo.Visible = true;
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
                txtLegajo.Visible = false;
                lblLegajo.Visible = false;
            }
        }

        private async void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCurriculums.Enabled = true;
            cbCurriculums.ResetText();
            cbCurriculums.DataSource = ((ApplicationCore.Model.Area)cbAreas.SelectedItem).Curriculums;
            cbCurriculums.ValueMember = "Id";
            cbCurriculums.DisplayMember = "Description";

        }

        private void ResetForm()
        {
            txtUsername.ResetText();
            mtbClave.ResetText();
            txtEmail.ResetText();
            txtNombre.ResetText();
            txtApellido.ResetText();
            txtPhoneNumber.ResetText();
            txtAddress.ResetText();
            txtLegajo.ResetText();
            txtCuit.ResetText();
            dtpBirthDate.ResetText();
        }

    }
}
