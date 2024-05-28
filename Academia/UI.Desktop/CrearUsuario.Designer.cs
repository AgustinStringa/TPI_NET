namespace UI.Desktop
{
    partial class CrearUsuario
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
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblClave = new Label();
            mtbClave = new MaskedTextBox();
            panel1 = new Panel();
            gpbUserType = new GroupBox();
            cbCurriculums = new ComboBox();
            rbtnUserAdministrative = new RadioButton();
            rbtnUserStudent = new RadioButton();
            rbtnUserTeacher = new RadioButton();
            lblOutput = new Label();
            btnCrearUsuario = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            panel1.SuspendLayout();
            gpbUserType.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(14, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(285, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(14, 14);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(66, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username :";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(333, 10);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(42, 15);
            lblClave.TabIndex = 2;
            lblClave.Text = "Clave :";
            // 
            // mtbClave
            // 
            mtbClave.Location = new Point(333, 40);
            mtbClave.Name = "mtbClave";
            mtbClave.PasswordChar = '*';
            mtbClave.Size = new Size(285, 23);
            mtbClave.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(gpbUserType);
            panel1.Controls.Add(lblOutput);
            panel1.Controls.Add(btnCrearUsuario);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtApellido);
            panel1.Controls.Add(lblApellido);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(mtbClave);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblClave);
            panel1.Location = new Point(64, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(631, 454);
            panel1.TabIndex = 4;
            // 
            // gpbUserType
            // 
            gpbUserType.Controls.Add(cbCurriculums);
            gpbUserType.Controls.Add(rbtnUserAdministrative);
            gpbUserType.Controls.Add(rbtnUserStudent);
            gpbUserType.Controls.Add(rbtnUserTeacher);
            gpbUserType.Location = new Point(14, 261);
            gpbUserType.Name = "gpbUserType";
            gpbUserType.Size = new Size(200, 126);
            gpbUserType.TabIndex = 11;
            gpbUserType.TabStop = false;
            gpbUserType.Text = "groupBox1";
            // 
            // cbCurriculums
            // 
            cbCurriculums.FormattingEnabled = true;
            cbCurriculums.Location = new Point(109, 21);
            cbCurriculums.Name = "cbCurriculums";
            cbCurriculums.Size = new Size(85, 23);
            cbCurriculums.TabIndex = 12;
            // 
            // rbtnUserAdministrative
            // 
            rbtnUserAdministrative.AutoSize = true;
            rbtnUserAdministrative.Location = new Point(6, 72);
            rbtnUserAdministrative.Name = "rbtnUserAdministrative";
            rbtnUserAdministrative.Size = new Size(102, 19);
            rbtnUserAdministrative.TabIndex = 11;
            rbtnUserAdministrative.TabStop = true;
            rbtnUserAdministrative.Text = "Administrative";
            rbtnUserAdministrative.UseVisualStyleBackColor = true;
            // 
            // rbtnUserStudent
            // 
            rbtnUserStudent.AutoSize = true;
            rbtnUserStudent.Location = new Point(6, 22);
            rbtnUserStudent.Name = "rbtnUserStudent";
            rbtnUserStudent.Size = new Size(66, 19);
            rbtnUserStudent.TabIndex = 9;
            rbtnUserStudent.TabStop = true;
            rbtnUserStudent.Text = "Student";
            rbtnUserStudent.UseVisualStyleBackColor = true;
            rbtnUserStudent.CheckedChanged += rbtnUserStudent_CheckedChanged;
            // 
            // rbtnUserTeacher
            // 
            rbtnUserTeacher.AutoSize = true;
            rbtnUserTeacher.Location = new Point(6, 47);
            rbtnUserTeacher.Name = "rbtnUserTeacher";
            rbtnUserTeacher.Size = new Size(65, 19);
            rbtnUserTeacher.TabIndex = 10;
            rbtnUserTeacher.TabStop = true;
            rbtnUserTeacher.Text = "Teacher";
            rbtnUserTeacher.UseVisualStyleBackColor = true;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(277, 287);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(69, 15);
            lblOutput.TabIndex = 5;
            lblOutput.Text = "output here";
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Location = new Point(523, 223);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(95, 23);
            btnCrearUsuario.TabIndex = 6;
            btnCrearUsuario.Text = "Crear Usuario";
            btnCrearUsuario.UseVisualStyleBackColor = true;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(14, 183);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(285, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email :";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(333, 119);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(285, 23);
            txtApellido.TabIndex = 4;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(333, 101);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(57, 15);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido :";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 119);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(285, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(14, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre :";
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(784, 561);
            Controls.Add(panel1);
            Name = "CrearUsuario";
            Text = "Crear Usuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gpbUserType.ResumeLayout(false);
            gpbUserType.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblClave;
        private MaskedTextBox mtbClave;
        private Panel panel1;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtEmail;
        private Label lblEmail;
        private Button btnCrearUsuario;
        private Label lblOutput;
        private GroupBox gpbUserType;
        private RadioButton rbtnUserAdministrative;
        private RadioButton rbtnUserStudent;
        private RadioButton rbtnUserTeacher;
        private ComboBox cbCurriculums;
    }
}