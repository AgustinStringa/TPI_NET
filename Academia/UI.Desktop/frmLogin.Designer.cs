namespace UI.Desktop
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lblBienvenido = new Label();
			lblUsuario = new Label();
			lblContra = new Label();
			txtUsername = new TextBox();
			txtPassword = new TextBox();
			btnSubmit = new Button();
			lnkForgetPassword = new LinkLabel();
			SuspendLayout();
			// 
			// lblBienvenido
			// 
			lblBienvenido.AutoSize = true;
			lblBienvenido.Location = new Point(141, 38);
			lblBienvenido.Name = "lblBienvenido";
			lblBienvenido.Size = new Size(131, 30);
			lblBienvenido.TabIndex = 0;
			lblBienvenido.Text = "Bienvenido a Academia\r\nIngrese sus datos";
			lblBienvenido.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblUsuario
			// 
			lblUsuario.AutoSize = true;
			lblUsuario.Location = new Point(98, 110);
			lblUsuario.Name = "lblUsuario";
			lblUsuario.Size = new Size(47, 15);
			lblUsuario.TabIndex = 1;
			lblUsuario.Text = "Usuario";
			// 
			// lblContra
			// 
			lblContra.AutoSize = true;
			lblContra.Location = new Point(78, 149);
			lblContra.Name = "lblContra";
			lblContra.Size = new Size(67, 15);
			lblContra.TabIndex = 2;
			lblContra.Text = "Contraseña";
			// 
			// txtUsername
			// 
			txtUsername.Location = new Point(151, 107);
			txtUsername.Name = "txtUsername";
			txtUsername.Size = new Size(162, 23);
			txtUsername.TabIndex = 3;
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(151, 146);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.Size = new Size(162, 23);
			txtPassword.TabIndex = 4;
			// 
			// btnSubmit
			// 
			btnSubmit.Location = new Point(163, 218);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(75, 23);
			btnSubmit.TabIndex = 5;
			btnSubmit.Text = "Ingresar";
			btnSubmit.UseVisualStyleBackColor = true;
			btnSubmit.Click += btnIngresar_Click;
			// 
			// lnkForgetPassword
			// 
			lnkForgetPassword.AutoSize = true;
			lnkForgetPassword.Location = new Point(274, 309);
			lnkForgetPassword.Name = "lnkForgetPassword";
			lnkForgetPassword.Size = new Size(128, 15);
			lnkForgetPassword.TabIndex = 6;
			lnkForgetPassword.TabStop = true;
			lnkForgetPassword.Text = "¿Olvidó su contraseña?";
			lnkForgetPassword.LinkClicked += lnkOlvido_LinkClicked;
			// 
			// FrmLogin
			// 
			AcceptButton = btnSubmit;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(414, 349);
			Controls.Add(lnkForgetPassword);
			Controls.Add(btnSubmit);
			Controls.Add(txtPassword);
			Controls.Add(txtUsername);
			Controls.Add(lblContra);
			Controls.Add(lblUsuario);
			Controls.Add(lblBienvenido);
			Name = "FrmLogin";
			Text = "Login";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblBienvenido;
        private Label lblUsuario;
        private Label lblContra;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSubmit;
        private LinkLabel lnkForgetPassword;
    }
}
