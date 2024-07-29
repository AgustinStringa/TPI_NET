using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailValidation;
using Entities;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.UI.Xaml;

namespace UI.Desktop
{
    public partial class frmCrearUsuario : Form
    {
        private Entities.Area[] areas;

        public frmCrearUsuario()
        {
            InitializeComponent();
            LoadAreas();
            //var stackPanel = new StackPanel
            //{
            //    Orientation = Orientation.Vertical,
            //    Margin = new Thickness(20)
            //};

            //// Crear RadioButtons
            //var radioButton1 = new RadioButton
            //{
            //    Content = "Opción 1",
            //    Margin = new Thickness(0, 0, 0, 10)
            //};

            //var radioButton2 = new RadioButton
            //{
            //    Content = "Opción 2",
            //    Margin = new Thickness(0, 0, 0, 10)
            //};

            //var radioButton3 = new RadioButton
            //{
            //    Content = "Opción 3",
            //    Margin = new Thickness(0, 0, 0, 10)
            //};

            //// Manejar eventos Checked
            //radioButton1.Checked += RadioButton_Checked;
            //radioButton2.Checked += RadioButton_Checked;
            //radioButton3.Checked += RadioButton_Checked;

            //// Añadir los RadioButtons al StackPanel
            //stackPanel.Children.Add(radioButton1);
            //stackPanel.Children.Add(radioButton2);
            //stackPanel.Children.Add(radioButton3);
            //this.Controls.Add();

        }

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            var edad = Business.Validations.GetEdad(dtpBirthDate.Value);
            lblOutput.Text = edad.ToString();
            try
            {
                if (!rbtnUserAdministrative.Checked
                    && !rbtnUserStudent.Checked
                    && !rbtnUserTeacher.Checked)
                {
                    MessageBox.Show("Seleccione el tipo de usuario (Alumno, Docente, Administrativo)");
                    return;
                }

                //USERNAME
                string username = txtUsername.Text.Trim();
                bool validUsername = Business.Validations.IsValidUsername(username);
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
                bool validName = Business.Validations.IsValidName(name);
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
                bool validLastname = Business.Validations.IsValidLastname(lastname);
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
                bool validPassword = Business.Validations.IsValidPassword(password);
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
                bool validEmail = Business.Validations.IsValidEmail(email);
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
                bool validAddress = Business.Validations.IsValidAddress(address);
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
                bool validPhoneNumber = Business.Validations.IsValidPhoneNumber(phoneNumber);
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
                bool validBirthDate = Business.Validations.IsValidBirthDate(birthDate);
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
                //        lblOutput.Text = valid.Domain;
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




                if (rbtnUserAdministrative.Checked)
                {
                    //CUIT

                    string cuit = txtCuit.Text.Trim();
                    bool validCuit = Business.Validations.IsValidCuit(cuit);
                    if (!validCuit)
                    {
                        txtCuit.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                        lblCuitError.Visible = true;
                        return;
                    }
                    else
                    {
                        txtCuit.ForeColor = SystemColors.WindowText;
                        lblCuitError.Visible = false;
                    }

                    //si no hay campos vacios/erroneos
                    bool correctForm = validUsername && validName && validLastname
                        && validEmail && validPassword && validAddress && validPhoneNumber && validBirthDate
                       && validCuit;


                    if (correctForm)
                    {
                        Entities.Administrative newAdministrative = new Entities.Administrative(

                            username: username,
                            password: password,
                            email: email,
                            name: name,
                            lastname: lastname,
                            address: address,
                            phonenumber: phoneNumber,
                            birthdate: birthDate,
                            cuit: cuit

                        );
                        await Business.Administrative.Create(newAdministrative);

                        MessageBox.Show("USUARIO ADMINISTRATIVO CREADO");
                        //REINICIAR FORM


                    }
                }

                else if (rbtnUserStudent.Checked)
                {
                    //LEGAJO
                    string legajo = txtCuit.Text.Trim();
                    //if (!Business.Validations.IsValidCuit(cuit))
                    //{
                    //    txtCuitLegajo.ForeColor = System.Drawing.Color.FromArgb(1, 220, 38, 38);
                    //    lblCuitLegajo.Visible = true;
                    //}
                    //else
                    //{
                    //    txtCuitLegajo.ForeColor = SystemColors.WindowText;
                    //    lblCuitLegajo.Visible = false;
                    //}

                }

                else if (rbtnUserTeacher.Checked) { }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            //var nuevoestudiante = new Entities.Student("stri24", "mypass", "correo@correo",
            //    "agusitn", "stringa", "san martin1763", "346715212", DateTime.Now, "51338");

            //lblOutput.Text = rbtnUserTeacher.Checked.ToString();


        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUserStudent.Checked)
            {
                cbAreas.Enabled = true;
                if (cbAreas.DataSource is null)
                {
                    LoadAreas();
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
            else if (rbtnUserAdministrative.Checked)
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
            else if (rbtnUserTeacher.Checked)
            {
                lblCurriculum.Visible = false;
                lblArea.Visible = false;
                cbAreas.Visible = false;
                cbCurriculums.Visible = false;
                txtLegajo.Visible = true;
                lblLegajo.Visible = true;
                txtCuit.Visible = false;
                lblCuit.Visible = false;
            }
        }

        private async void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCurriculums.Enabled = true;
            cbCurriculums.ResetText();
            cbCurriculums.DataSource = await Business.Area.GetCurriculums((Entities.Area)cbAreas.SelectedItem);
        }

        

        private async void LoadAreas()
        {

            List<Entities.Area> areasList = await Business.Area.FindAll();
            cbAreas.DataSource = areasList;
            cbAreas.ValueMember = "IdArea";
            cbAreas.DisplayMember = "Description";
            if (cbAreas.ItemHeight > 0)
            {
                cbAreas.SelectedIndex = 0;
                cbCurriculums.DataSource = await Business.Area.GetCurriculums((Entities.Area)cbAreas.Items[0]);
                cbCurriculums.ValueMember = "Id";
                cbCurriculums.DisplayMember = "Description";

            }
        }

        private void ResetForm() { 
            txtUsername.ResetText();
            mtbClave.ResetText();
            txtEmail.ResetText();
            txtNombre.ResetText();
            txtApellido.ResetText();
            txtPhoneNumber.ResetText();
            txtAddress.ResetText();
            txtLegajo.ResetText();
            txtCuit.ResetText();
        }

    }
}
