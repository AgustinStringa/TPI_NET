namespace UI.Desktop.User
{
    partial class FrmUser
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
            lstUsers = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            label1 = new Label();
            txtSearchUsers = new TextBox();
            panel1 = new Panel();
            chbAll = new CheckBox();
            chbTeacher = new CheckBox();
            chbStudent = new CheckBox();
            chbAdministrative = new CheckBox();
            toolStrip1 = new ToolStrip();
            tsbtnEditUser = new ToolStripButton();
            tsbtnDeleteUser = new ToolStripButton();
            tsbtnAddUser = new ToolStripButton();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lstUsers
            // 
            lstUsers.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lstUsers.FullRowSelect = true;
            lstUsers.Location = new Point(244, 164);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(972, 227);
            lstUsers.TabIndex = 0;
            lstUsers.UseCompatibleStateImageBehavior = false;
            lstUsers.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nombre";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Apellido";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Nombre de Usuario";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Legajo";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Cuit";
            columnHeader5.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(35, 72);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 1;
            label1.Text = "Usuarios";
            // 
            // txtSearchUsers
            // 
            txtSearchUsers.Font = new Font("Segoe UI", 12F);
            txtSearchUsers.Location = new Point(35, 110);
            txtSearchUsers.Name = "txtSearchUsers";
            txtSearchUsers.PlaceholderText = "Search...";
            txtSearchUsers.Size = new Size(257, 29);
            txtSearchUsers.TabIndex = 2;
            txtSearchUsers.TextChanged += txtSearchUsers_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(chbAll);
            panel1.Controls.Add(chbTeacher);
            panel1.Controls.Add(chbStudent);
            panel1.Controls.Add(chbAdministrative);
            panel1.Location = new Point(32, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(165, 156);
            panel1.TabIndex = 3;
            // 
            // chbAll
            // 
            chbAll.AutoSize = true;
            chbAll.Checked = true;
            chbAll.CheckState = CheckState.Checked;
            chbAll.Font = new Font("Segoe UI", 12F);
            chbAll.Location = new Point(4, 96);
            chbAll.Name = "chbAll";
            chbAll.Size = new Size(69, 25);
            chbAll.TabIndex = 3;
            chbAll.Tag = "2";
            chbAll.Text = "Todos";
            chbAll.UseVisualStyleBackColor = true;
            chbAll.Click += chbAll_Click;
            // 
            // chbTeacher
            // 
            chbTeacher.AutoSize = true;
            chbTeacher.Checked = true;
            chbTeacher.CheckState = CheckState.Checked;
            chbTeacher.Font = new Font("Segoe UI", 12F);
            chbTeacher.Location = new Point(3, 65);
            chbTeacher.Name = "chbTeacher";
            chbTeacher.Size = new Size(103, 25);
            chbTeacher.TabIndex = 2;
            chbTeacher.Tag = "2";
            chbTeacher.Text = "Profesores";
            chbTeacher.UseVisualStyleBackColor = true;
            chbTeacher.CheckedChanged += checkBoxFilter_CheckedChanged;
            // 
            // chbStudent
            // 
            chbStudent.AutoSize = true;
            chbStudent.Checked = true;
            chbStudent.CheckState = CheckState.Checked;
            chbStudent.Font = new Font("Segoe UI", 12F);
            chbStudent.Location = new Point(3, 34);
            chbStudent.Name = "chbStudent";
            chbStudent.Size = new Size(108, 25);
            chbStudent.TabIndex = 1;
            chbStudent.Tag = "3";
            chbStudent.Text = "Estudiantes";
            chbStudent.UseVisualStyleBackColor = true;
            chbStudent.CheckedChanged += checkBoxFilter_CheckedChanged;
            // 
            // chbAdministrative
            // 
            chbAdministrative.AutoSize = true;
            chbAdministrative.Checked = true;
            chbAdministrative.CheckState = CheckState.Checked;
            chbAdministrative.Font = new Font("Segoe UI", 12F);
            chbAdministrative.Location = new Point(3, 3);
            chbAdministrative.Name = "chbAdministrative";
            chbAdministrative.Size = new Size(138, 25);
            chbAdministrative.TabIndex = 0;
            chbAdministrative.Tag = "1";
            chbAdministrative.Text = "Administrativos";
            chbAdministrative.UseVisualStyleBackColor = true;
            chbAdministrative.CheckedChanged += checkBoxFilter_CheckedChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbtnAddUser, tsbtnEditUser, tsbtnDeleteUser });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1220, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnEditUser
            // 
            tsbtnEditUser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEditUser.Image = Properties.Resources.Edit;
            tsbtnEditUser.ImageTransparentColor = Color.Magenta;
            tsbtnEditUser.Name = "tsbtnEditUser";
            tsbtnEditUser.Size = new Size(23, 22);
            tsbtnEditUser.Text = "Edit User";
            tsbtnEditUser.Click += tsbtnEditUser_Click;
            // 
            // tsbtnDeleteUser
            // 
            tsbtnDeleteUser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnDeleteUser.Image = Properties.Resources.Delete;
            tsbtnDeleteUser.ImageTransparentColor = Color.Magenta;
            tsbtnDeleteUser.Name = "tsbtnDeleteUser";
            tsbtnDeleteUser.Size = new Size(23, 22);
            tsbtnDeleteUser.Text = "Delete User";
            tsbtnDeleteUser.Click += tsbtnDeleteUser_Click;
            // 
            // tsbtnAddUser
            // 
            tsbtnAddUser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnAddUser.Image = Properties.Resources.Add;
            tsbtnAddUser.ImageTransparentColor = Color.Magenta;
            tsbtnAddUser.Name = "tsbtnAddUser";
            tsbtnAddUser.Size = new Size(23, 22);
            tsbtnAddUser.Text = "toolStripButton1";
            tsbtnAddUser.Click += tsbtnAddUser_Click;
            // 
            // FrmUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 450);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Controls.Add(txtSearchUsers);
            Controls.Add(label1);
            Controls.Add(lstUsers);
            Name = "FrmUser";
            Text = "       ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lstUsers;
        private Label label1;
        private TextBox txtSearchUsers;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Panel panel1;
        private CheckBox chbTeacher;
        private CheckBox chbStudent;
        private CheckBox chbAdministrative;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbtnEditUser;
        private ToolStripButton tsbtnDeleteUser;
        private CheckBox chbAll;
        private ToolStripButton tsbtnAddUser;
    }
}