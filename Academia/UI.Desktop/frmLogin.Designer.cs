namespace UI.Desktop
{
    partial class frmLogin
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
            txtUsuario = new TextBox();
            txtContra = new TextBox();
            btnIngresar = new Button();
            lnkOlvido = new LinkLabel();
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
            // txtUsuario
            // 
            txtUsuario.Location = new Point(151, 107);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(162, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtContra
            // 
            txtContra.Location = new Point(151, 146);
            txtContra.Name = "txtContra";
            txtContra.PasswordChar = '*';
            txtContra.Size = new Size(162, 23);
            txtContra.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(163, 218);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lnkOlvido
            // 
            lnkOlvido.AutoSize = true;
            lnkOlvido.Location = new Point(274, 309);
            lnkOlvido.Name = "lnkOlvido";
            lnkOlvido.Size = new Size(128, 15);
            lnkOlvido.TabIndex = 6;
            lnkOlvido.TabStop = true;
            lnkOlvido.Text = "¿Olvidó su contraseña?";
            lnkOlvido.LinkClicked += lnkOlvido_LinkClicked;
            // 
            // frmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 349);
            Controls.Add(lnkOlvido);
            Controls.Add(btnIngresar);
            Controls.Add(txtContra);
            Controls.Add(txtUsuario);
            Controls.Add(lblContra);
            Controls.Add(lblUsuario);
            Controls.Add(lblBienvenido);
            Name = "frmLogin";
            Text = "Login";
            Load += this.frmLogin_Load;
            Shown += this.frmLogin_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenido;
        private Label lblUsuario;
        private Label lblContra;
        private TextBox txtUsuario;
        private TextBox txtContra;
        private Button btnIngresar;
        private LinkLabel lnkOlvido;
    }
}
