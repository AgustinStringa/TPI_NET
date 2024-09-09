namespace UI.Desktop
{
    partial class FrmActionUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            lblTipoUsuario = new Label();
            lblCurriculum = new Label();
            lblArea = new Label();
            cbCurriculums = new ComboBox();
            cbAreas = new ComboBox();
            rbtnUserStudent = new RadioButton();
            rbtnUserTeacher = new RadioButton();
            rbtnUserAdministrative = new RadioButton();
            lblLegajoError = new Label();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            lblAddressError = new Label();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhoneNumberError = new Label();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblFechaNacimientoError = new Label();
            lblApellidoError = new Label();
            lblNombreError = new Label();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmailError = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblClaveError = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            mtbPassword = new MaskedTextBox();
            lblUsernameError = new Label();
            lblCuitError = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            txtCuit = new TextBox();
            lblCuit = new Label();
            lblOutput = new Label();
            btnActionUser = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblLegajoError);
            panel1.Controls.Add(txtStudentId);
            panel1.Controls.Add(lblStudentId);
            panel1.Controls.Add(lblAddressError);
            panel1.Controls.Add(lblAddress);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(lblPhoneNumberError);
            panel1.Controls.Add(lblPhoneNumber);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Controls.Add(lblFechaNacimientoError);
            panel1.Controls.Add(lblApellidoError);
            panel1.Controls.Add(lblNombreError);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(lblEmailError);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(lblClaveError);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(mtbPassword);
            panel1.Controls.Add(lblUsernameError);
            panel1.Controls.Add(lblCuitError);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblBirthDate);
            panel1.Controls.Add(dtpBirthDate);
            panel1.Controls.Add(txtCuit);
            panel1.Controls.Add(lblCuit);
            panel1.Controls.Add(lblOutput);
            panel1.Controls.Add(btnActionUser);
            panel1.Location = new Point(103, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(915, 686);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTipoUsuario);
            panel2.Controls.Add(lblCurriculum);
            panel2.Controls.Add(lblArea);
            panel2.Controls.Add(cbCurriculums);
            panel2.Controls.Add(cbAreas);
            panel2.Controls.Add(rbtnUserStudent);
            panel2.Controls.Add(rbtnUserTeacher);
            panel2.Controls.Add(rbtnUserAdministrative);
            panel2.Location = new Point(330, 365);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 175);
            panel2.TabIndex = 30;
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Font = new Font("Segoe UI", 12F);
            lblTipoUsuario.Location = new Point(3, 19);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(112, 21);
            lblTipoUsuario.TabIndex = 31;
            lblTipoUsuario.Text = "Tipo Usuario: *";
            // 
            // lblCurriculum
            // 
            lblCurriculum.AutoSize = true;
            lblCurriculum.Location = new Point(8, 152);
            lblCurriculum.Name = "lblCurriculum";
            lblCurriculum.Size = new Size(96, 15);
            lblCurriculum.TabIndex = 14;
            lblCurriculum.Text = "Plan de estudios:";
            lblCurriculum.Visible = false;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Location = new Point(8, 123);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(75, 15);
            lblArea.TabIndex = 13;
            lblArea.Text = "Especialidad:";
            lblArea.Visible = false;
            // 
            // cbCurriculums
            // 
            cbCurriculums.FormattingEnabled = true;
            cbCurriculums.Location = new Point(113, 149);
            cbCurriculums.Name = "cbCurriculums";
            cbCurriculums.Size = new Size(170, 23);
            cbCurriculums.TabIndex = 12;
            cbCurriculums.Visible = false;
            // 
            // cbAreas
            // 
            cbAreas.FormattingEnabled = true;
            cbAreas.Location = new Point(113, 120);
            cbAreas.Name = "cbAreas";
            cbAreas.Size = new Size(170, 23);
            cbAreas.TabIndex = 12;
            cbAreas.Visible = false;
            cbAreas.SelectedIndexChanged += cbAreas_SelectedIndexChanged;
            // 
            // rbtnUserStudent
            // 
            rbtnUserStudent.AutoSize = true;
            rbtnUserStudent.Location = new Point(8, 94);
            rbtnUserStudent.Name = "rbtnUserStudent";
            rbtnUserStudent.Size = new Size(66, 19);
            rbtnUserStudent.TabIndex = 9;
            rbtnUserStudent.TabStop = true;
            rbtnUserStudent.Text = "Student";
            rbtnUserStudent.UseVisualStyleBackColor = true;
            rbtnUserStudent.CheckedChanged += rbtn_CheckedChanged;
            // 
            // rbtnUserTeacher
            // 
            rbtnUserTeacher.AutoSize = true;
            rbtnUserTeacher.Location = new Point(8, 73);
            rbtnUserTeacher.Name = "rbtnUserTeacher";
            rbtnUserTeacher.Size = new Size(65, 19);
            rbtnUserTeacher.TabIndex = 10;
            rbtnUserTeacher.TabStop = true;
            rbtnUserTeacher.Text = "Teacher";
            rbtnUserTeacher.UseVisualStyleBackColor = true;
            rbtnUserTeacher.CheckedChanged += rbtn_CheckedChanged;
            // 
            // rbtnUserAdministrative
            // 
            rbtnUserAdministrative.AutoSize = true;
            rbtnUserAdministrative.Location = new Point(8, 51);
            rbtnUserAdministrative.Name = "rbtnUserAdministrative";
            rbtnUserAdministrative.Size = new Size(102, 19);
            rbtnUserAdministrative.TabIndex = 11;
            rbtnUserAdministrative.TabStop = true;
            rbtnUserAdministrative.Text = "Administrative";
            rbtnUserAdministrative.UseVisualStyleBackColor = true;
            rbtnUserAdministrative.CheckedChanged += rbtn_CheckedChanged;
            // 
            // lblLegajoError
            // 
            lblLegajoError.AutoSize = true;
            lblLegajoError.Font = new Font("Segoe UI", 12F);
            lblLegajoError.ForeColor = Color.FromArgb(220, 38, 38);
            lblLegajoError.Location = new Point(330, 623);
            lblLegajoError.Name = "lblLegajoError";
            lblLegajoError.Size = new Size(159, 21);
            lblLegajoError.TabIndex = 29;
            lblLegajoError.Text = "Campo es obligatorio";
            lblLegajoError.Visible = false;
            // 
            // txtStudentId
            // 
            txtStudentId.Font = new Font("Segoe UI", 12F);
            txtStudentId.Location = new Point(330, 591);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(285, 29);
            txtStudentId.TabIndex = 9;
            txtStudentId.Visible = false;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI", 12F);
            lblStudentId.Location = new Point(330, 567);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(74, 21);
            lblStudentId.TabIndex = 28;
            lblStudentId.Text = "Legajo : *";
            lblStudentId.Visible = false;
            // 
            // lblAddressError
            // 
            lblAddressError.AutoSize = true;
            lblAddressError.Font = new Font("Segoe UI", 12F);
            lblAddressError.ForeColor = Color.FromArgb(220, 38, 38);
            lblAddressError.Location = new Point(330, 320);
            lblAddressError.Name = "lblAddressError";
            lblAddressError.Size = new Size(221, 42);
            lblAddressError.TabIndex = 26;
            lblAddressError.Text = "Campo obligatorio. \r\nIntroduce una dirección válida.";
            lblAddressError.Visible = false;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 12F);
            lblAddress.Location = new Point(324, 261);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(93, 21);
            lblAddress.TabIndex = 24;
            lblAddress.Text = "Dirección : *";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(324, 287);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(285, 29);
            txtAddress.TabIndex = 8;
            // 
            // lblPhoneNumberError
            // 
            lblPhoneNumberError.AutoSize = true;
            lblPhoneNumberError.Font = new Font("Segoe UI", 12F);
            lblPhoneNumberError.ForeColor = Color.FromArgb(220, 38, 38);
            lblPhoneNumberError.Location = new Point(330, 184);
            lblPhoneNumberError.Name = "lblPhoneNumberError";
            lblPhoneNumberError.Size = new Size(200, 42);
            lblPhoneNumberError.TabIndex = 23;
            lblPhoneNumberError.Text = "Campo obligatorio. \r\nIntroduce un telfono válido.";
            lblPhoneNumberError.Visible = false;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 12F);
            lblPhoneNumber.Location = new Point(324, 125);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(86, 21);
            lblPhoneNumber.TabIndex = 21;
            lblPhoneNumber.Text = "Telefono : *";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 12F);
            txtPhoneNumber.Location = new Point(324, 151);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(285, 29);
            txtPhoneNumber.TabIndex = 7;
            // 
            // lblFechaNacimientoError
            // 
            lblFechaNacimientoError.AutoSize = true;
            lblFechaNacimientoError.Font = new Font("Segoe UI", 12F);
            lblFechaNacimientoError.ForeColor = Color.FromArgb(220, 38, 38);
            lblFechaNacimientoError.Location = new Point(324, 72);
            lblFechaNacimientoError.Name = "lblFechaNacimientoError";
            lblFechaNacimientoError.Size = new Size(140, 21);
            lblFechaNacimientoError.TabIndex = 20;
            lblFechaNacimientoError.Text = "Campo obligatorio";
            lblFechaNacimientoError.Visible = false;
            // 
            // lblApellidoError
            // 
            lblApellidoError.AutoSize = true;
            lblApellidoError.Font = new Font("Segoe UI", 12F);
            lblApellidoError.ForeColor = Color.FromArgb(220, 38, 38);
            lblApellidoError.Location = new Point(13, 538);
            lblApellidoError.Name = "lblApellidoError";
            lblApellidoError.Size = new Size(199, 42);
            lblApellidoError.TabIndex = 19;
            lblApellidoError.Text = "Campo  obligatorio.\r\nIntroduce un apellido váldo";
            lblApellidoError.Visible = false;
            // 
            // lblNombreError
            // 
            lblNombreError.AutoSize = true;
            lblNombreError.Font = new Font("Segoe UI", 12F);
            lblNombreError.ForeColor = Color.FromArgb(220, 38, 38);
            lblNombreError.Location = new Point(13, 416);
            lblNombreError.Name = "lblNombreError";
            lblNombreError.Size = new Size(206, 42);
            lblNombreError.TabIndex = 18;
            lblNombreError.Text = "Campo obligatorio.\r\nIntroduce un nombre válido.";
            lblNombreError.Visible = false;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 12F);
            lblLastName.Location = new Point(13, 482);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(85, 21);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Apellido : *";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F);
            txtLastName.Location = new Point(13, 506);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(285, 29);
            txtLastName.TabIndex = 5;
            // 
            // lblEmailError
            // 
            lblEmailError.AutoSize = true;
            lblEmailError.Font = new Font("Segoe UI", 12F);
            lblEmailError.ForeColor = Color.FromArgb(220, 38, 38);
            lblEmailError.Location = new Point(14, 319);
            lblEmailError.Name = "lblEmailError";
            lblEmailError.Size = new Size(140, 21);
            lblEmailError.TabIndex = 17;
            lblEmailError.Text = "Campo obligatorio";
            lblEmailError.Visible = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(13, 360);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 21);
            lblName.TabIndex = 4;
            lblName.Text = "Nombre : *";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(13, 384);
            txtName.Name = "txtName";
            txtName.Size = new Size(285, 29);
            txtName.TabIndex = 4;
            // 
            // lblClaveError
            // 
            lblClaveError.AutoSize = true;
            lblClaveError.Font = new Font("Segoe UI", 12F);
            lblClaveError.ForeColor = Color.FromArgb(220, 38, 38);
            lblClaveError.Location = new Point(14, 184);
            lblClaveError.Name = "lblClaveError";
            lblClaveError.Size = new Size(143, 21);
            lblClaveError.TabIndex = 16;
            lblClaveError.Text = "Campo obligatorio.";
            lblClaveError.Visible = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(14, 263);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 21);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email : *";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(14, 287);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(285, 29);
            txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(14, 125);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 21);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Clave : *";
            // 
            // mtbPassword
            // 
            mtbPassword.Font = new Font("Segoe UI", 12F);
            mtbPassword.Location = new Point(14, 149);
            mtbPassword.Name = "mtbPassword";
            mtbPassword.PasswordChar = '*';
            mtbPassword.Size = new Size(285, 29);
            mtbPassword.TabIndex = 2;
            // 
            // lblUsernameError
            // 
            lblUsernameError.AutoSize = true;
            lblUsernameError.Font = new Font("Segoe UI", 12F);
            lblUsernameError.ForeColor = Color.FromArgb(220, 38, 38);
            lblUsernameError.Location = new Point(13, 72);
            lblUsernameError.Name = "lblUsernameError";
            lblUsernameError.Size = new Size(151, 42);
            lblUsernameError.TabIndex = 16;
            lblUsernameError.Text = "Campo obligatorio. \r\nMinimo 4 caracteres";
            lblUsernameError.Visible = false;
            // 
            // lblCuitError
            // 
            lblCuitError.AutoSize = true;
            lblCuitError.Font = new Font("Segoe UI", 12F);
            lblCuitError.ForeColor = Color.FromArgb(220, 38, 38);
            lblCuitError.Location = new Point(330, 623);
            lblCuitError.Name = "lblCuitError";
            lblCuitError.Size = new Size(188, 21);
            lblCuitError.TabIndex = 18;
            lblCuitError.Text = "Este campo es obligatorio";
            lblCuitError.Visible = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(14, 14);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username : *";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(14, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(285, 29);
            txtUsername.TabIndex = 1;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 12F);
            lblBirthDate.Location = new Point(324, 14);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(169, 21);
            lblBirthDate.TabIndex = 15;
            lblBirthDate.Text = "Fecha de Nacimiento: *";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Segoe UI", 12F);
            dtpBirthDate.Location = new Point(324, 40);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(285, 29);
            dtpBirthDate.TabIndex = 6;
            // 
            // txtCuit
            // 
            txtCuit.Font = new Font("Segoe UI", 12F);
            txtCuit.Location = new Point(330, 591);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(285, 29);
            txtCuit.TabIndex = 12;
            txtCuit.Visible = false;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI", 12F);
            lblCuit.Location = new Point(330, 567);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(56, 21);
            lblCuit.TabIndex = 13;
            lblCuit.Text = "Cuit : *";
            lblCuit.Visible = false;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(330, 646);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(69, 15);
            lblOutput.TabIndex = 5;
            lblOutput.Text = "output here";
            // 
            // btnActionUser
            // 
            btnActionUser.BackColor = SystemColors.ActiveCaption;
            btnActionUser.Font = new Font("Segoe UI", 12F);
            btnActionUser.Location = new Point(756, 614);
            btnActionUser.Name = "btnActionUser";
            btnActionUser.Size = new Size(141, 47);
            btnActionUser.TabIndex = 10;
            btnActionUser.Text = "Crear Usuario";
            btnActionUser.UseVisualStyleBackColor = false;
            btnActionUser.Click += btnActionUser_Click;
            // 
            // FrmActionUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1072, 732);
            Controls.Add(panel1);
            Name = "FrmActionUser";
            Text = "Crear Usuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtEmail;
        private Label lblEmail;
        private Button btnActionUser;
        private Label lblOutput;
        private RadioButton rbtnUserAdministrative;
        private RadioButton rbtnUserStudent;
        private RadioButton rbtnUserTeacher;
        private ComboBox cbCurriculums;
        private ComboBox cbAreas;
        private TextBox txtCuit;
        private Label lblCuit;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;
        private Label lblEmailError;
        private Label lblNombreError;
        private Label lblApellidoError;
        private Label lblCuitError;
        private Label lblClaveError;
        private Label lblPassword;
        private MaskedTextBox mtbPassword;
        private Label lblFechaNacimientoError;
        private Label lblUsernameError;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblAddressError;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPhoneNumberError;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblLegajoError;
        private TextBox txtStudentId;
        private Label lblStudentId;
        private Panel panel2;
        private Label lblCurriculum;
        private Label lblArea;
        private Label lblTipoUsuario;
    }
}