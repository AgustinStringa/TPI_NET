namespace UI.Desktop.Curriculum
{
    partial class frmActionCurriculum
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
            label7 = new Label();
            txtCurriculumYear = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtCurriculumResolution = new TextBox();
            label4 = new Label();
            label3 = new Label();
            cbAreas = new ComboBox();
            txtResolutionId = new TextBox();
            lblId = new Label();
            label1 = new Label();
            btnActionCurriculum = new Button();
            label2 = new Label();
            txtCurriculumDescription = new TextBox();
            label8 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtCurriculumYear);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtCurriculumResolution);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbAreas);
            panel1.Controls.Add(txtResolutionId);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnActionCurriculum);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCurriculumDescription);
            panel1.Location = new Point(27, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(595, 245);
            panel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(64, 131);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 12;
            label7.Text = "El año es obligatorio";
            // 
            // txtCurriculumYear
            // 
            txtCurriculumYear.Location = new Point(64, 105);
            txtCurriculumYear.Name = "txtCurriculumYear";
            txtCurriculumYear.Size = new Size(179, 23);
            txtCurriculumYear.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 37);
            label6.Name = "label6";
            label6.Size = new Size(136, 15);
            label6.TabIndex = 10;
            label6.Text = "El nombre es obligatorio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 108);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 10;
            label5.Text = "Año:";
            label5.Click += label5_Click;
            // 
            // txtCurriculumResolution
            // 
            txtCurriculumResolution.Location = new Point(391, 108);
            txtCurriculumResolution.Name = "txtCurriculumResolution";
            txtCurriculumResolution.Size = new Size(121, 23);
            txtCurriculumResolution.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(310, 108);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 8;
            label4.Text = "Resolucion:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 17);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Especialidad:";
            label3.Click += label3_Click;
            // 
            // cbAreas
            // 
            cbAreas.FormattingEnabled = true;
            cbAreas.Location = new Point(391, 14);
            cbAreas.Name = "cbAreas";
            cbAreas.Size = new Size(121, 23);
            cbAreas.TabIndex = 6;
            // 
            // txtResolutionId
            // 
            txtResolutionId.Enabled = false;
            txtResolutionId.Location = new Point(64, 189);
            txtResolutionId.Name = "txtResolutionId";
            txtResolutionId.Size = new Size(140, 23);
            txtResolutionId.TabIndex = 5;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(38, 192);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 4;
            lblId.Text = "Id:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // btnActionCurriculum
            // 
            btnActionCurriculum.Location = new Point(440, 209);
            btnActionCurriculum.Name = "btnActionCurriculum";
            btnActionCurriculum.Size = new Size(139, 24);
            btnActionCurriculum.TabIndex = 2;
            btnActionCurriculum.Text = "Crear Plan De Estudios";
            btnActionCurriculum.UseVisualStyleBackColor = true;
            btnActionCurriculum.Click += btnActionCurriculum_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(249, 14);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 3;
            label2.Text = "*";
            // 
            // txtCurriculumDescription
            // 
            txtCurriculumDescription.Location = new Point(63, 11);
            txtCurriculumDescription.Name = "txtCurriculumDescription";
            txtCurriculumDescription.Size = new Size(180, 23);
            txtCurriculumDescription.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(249, 105);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 13;
            label8.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(518, 14);
            label9.Name = "label9";
            label9.Size = new Size(12, 15);
            label9.TabIndex = 3;
            label9.Text = "*";
            // 
            // frmActionCurriculum
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 299);
            Controls.Add(panel1);
            Name = "frmActionCurriculum";
            Text = "frmActionCurriculum";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtResolutionId;
        private Label lblId;
        private Label label1;
        private Button btnActionCurriculum;
        private Label label2;
        private TextBox txtCurriculumDescription;
        private Label label3;
        private ComboBox cbAreas;
        private TextBox txtCurriculumYear;
        private Label label6;
        private Label label5;
        private TextBox txtCurriculumResolution;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}