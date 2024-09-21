namespace UI.Desktop.Curriculum
{
    partial class FrmActionCurriculum
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
            label8 = new Label();
            lblCurriculumYearError = new Label();
            txtCurriculumYear = new TextBox();
            lblCurriculumDescriptionError = new Label();
            label5 = new Label();
            txtCurriculumResolution = new TextBox();
            label4 = new Label();
            label3 = new Label();
            cbAreas = new ComboBox();
            txtCurriculumId = new TextBox();
            lblCurriculumId = new Label();
            label1 = new Label();
            btnActionCurriculum = new Button();
            label9 = new Label();
            label2 = new Label();
            txtCurriculumDescription = new TextBox();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblCurriculumYearError);
            panel1.Controls.Add(txtCurriculumYear);
            panel1.Controls.Add(lblCurriculumDescriptionError);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtCurriculumResolution);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbAreas);
            panel1.Controls.Add(txtCurriculumId);
            panel1.Controls.Add(lblCurriculumId);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnActionCurriculum);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCurriculumDescription);
            panel1.Location = new Point(28, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(692, 308);
            panel1.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(280, 108);
            label8.Name = "label8";
            label8.Size = new Size(17, 21);
            label8.TabIndex = 13;
            label8.Text = "*";
            // 
            // lblCurriculumYearError
            // 
            lblCurriculumYearError.AutoSize = true;
            lblCurriculumYearError.Font = new Font("Segoe UI", 12F);
            lblCurriculumYearError.ForeColor = Color.FromArgb(192, 0, 0);
            lblCurriculumYearError.Location = new Point(95, 137);
            lblCurriculumYearError.Name = "lblCurriculumYearError";
            lblCurriculumYearError.Size = new Size(151, 21);
            lblCurriculumYearError.TabIndex = 12;
            lblCurriculumYearError.Text = "El año es obligatorio";
            lblCurriculumYearError.Visible = false;
            // 
            // txtCurriculumYear
            // 
            txtCurriculumYear.Font = new Font("Segoe UI", 12F);
            txtCurriculumYear.Location = new Point(95, 105);
            txtCurriculumYear.Name = "txtCurriculumYear";
            txtCurriculumYear.Size = new Size(179, 29);
            txtCurriculumYear.TabIndex = 2;
            // 
            // lblCurriculumDescriptionError
            // 
            lblCurriculumDescriptionError.AutoSize = true;
            lblCurriculumDescriptionError.Font = new Font("Segoe UI", 12F);
            lblCurriculumDescriptionError.ForeColor = Color.FromArgb(192, 0, 0);
            lblCurriculumDescriptionError.Location = new Point(94, 43);
            lblCurriculumDescriptionError.Name = "lblCurriculumDescriptionError";
            lblCurriculumDescriptionError.Size = new Size(180, 21);
            lblCurriculumDescriptionError.TabIndex = 10;
            lblCurriculumDescriptionError.Text = "El nombre es obligatorio";
            lblCurriculumDescriptionError.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(17, 108);
            label5.Name = "label5";
            label5.Size = new Size(41, 21);
            label5.TabIndex = 0;
            label5.Text = "Año:";
            // 
            // txtCurriculumResolution
            // 
            txtCurriculumResolution.Font = new Font("Segoe UI", 12F);
            txtCurriculumResolution.Location = new Point(464, 105);
            txtCurriculumResolution.Name = "txtCurriculumResolution";
            txtCurriculumResolution.Size = new Size(181, 29);
            txtCurriculumResolution.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(369, 105);
            label4.Name = "label4";
            label4.Size = new Size(89, 21);
            label4.TabIndex = 0;
            label4.Text = "Resolucion:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(360, 14);
            label3.Name = "label3";
            label3.Size = new Size(98, 21);
            label3.TabIndex = 0;
            label3.Text = "Especialidad:";
            // 
            // cbAreas
            // 
            cbAreas.Font = new Font("Segoe UI", 12F);
            cbAreas.FormattingEnabled = true;
            cbAreas.Location = new Point(464, 11);
            cbAreas.Name = "cbAreas";
            cbAreas.Size = new Size(181, 29);
            cbAreas.TabIndex = 3;
            // 
            // txtCurriculumId
            // 
            txtCurriculumId.Enabled = false;
            txtCurriculumId.Font = new Font("Segoe UI", 12F);
            txtCurriculumId.Location = new Point(94, 230);
            txtCurriculumId.Name = "txtCurriculumId";
            txtCurriculumId.Size = new Size(140, 29);
            txtCurriculumId.TabIndex = 5;
            // 
            // lblCurriculumId
            // 
            lblCurriculumId.AutoSize = true;
            lblCurriculumId.Font = new Font("Segoe UI", 12F);
            lblCurriculumId.Location = new Point(17, 233);
            lblCurriculumId.Name = "lblCurriculumId";
            lblCurriculumId.Size = new Size(26, 21);
            lblCurriculumId.TabIndex = 0;
            lblCurriculumId.Text = "Id:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // btnActionCurriculum
            // 
            btnActionCurriculum.BackColor = SystemColors.ActiveCaption;
            btnActionCurriculum.Font = new Font("Segoe UI", 12F);
            btnActionCurriculum.Location = new Point(516, 230);
            btnActionCurriculum.Name = "btnActionCurriculum";
            btnActionCurriculum.Size = new Size(147, 60);
            btnActionCurriculum.TabIndex = 5;
            btnActionCurriculum.Text = "Crear Plan De Estudios";
            btnActionCurriculum.UseVisualStyleBackColor = false;
            btnActionCurriculum.Click += btnActionCurriculum_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(656, 14);
            label9.Name = "label9";
            label9.Size = new Size(17, 21);
            label9.TabIndex = 3;
            label9.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(280, 14);
            label2.Name = "label2";
            label2.Size = new Size(17, 21);
            label2.TabIndex = 3;
            label2.Text = "*";
            // 
            // txtCurriculumDescription
            // 
            txtCurriculumDescription.Font = new Font("Segoe UI", 12F);
            txtCurriculumDescription.Location = new Point(94, 11);
            txtCurriculumDescription.Name = "txtCurriculumDescription";
            txtCurriculumDescription.Size = new Size(180, 29);
            txtCurriculumDescription.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F);
            lblTitle.Location = new Point(31, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 28);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "label6";
            // 
            // frmActionCurriculum
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 387);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Name = "frmActionCurriculum";
            Text = "frmActionCurriculum";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtCurriculumId;
        private Label lblCurriculumId;
        private Label label1;
        private Button btnActionCurriculum;
        private Label label2;
        private TextBox txtCurriculumDescription;
        private Label label3;
        private ComboBox cbAreas;
        private TextBox txtCurriculumYear;
        private Label lblCurriculumDescriptionError;
        private Label label5;
        private TextBox txtCurriculumResolution;
        private Label label4;
        private Label lblCurriculumYearError;
        private Label label8;
        private Label label9;
        private Label lblTitle;
    }
}