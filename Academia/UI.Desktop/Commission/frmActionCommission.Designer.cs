﻿namespace UI.Desktop.Commission
{
    partial class frmActionCommission
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
            cbCurriculum = new ComboBox();
            lblIdCurriculumError = new Label();
            lblIdError = new Label();
            lblDescriptionError = new Label();
            btnActionCommission = new Button();
            txtId = new TextBox();
            txtCommissionDescription = new TextBox();
            lblYear = new Label();
            lblId = new Label();
            lblDescription = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cbCurriculum);
            panel1.Controls.Add(lblIdCurriculumError);
            panel1.Controls.Add(lblIdError);
            panel1.Controls.Add(lblDescriptionError);
            panel1.Controls.Add(btnActionCommission);
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(txtCommissionDescription);
            panel1.Controls.Add(lblYear);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(lblDescription);
            panel1.Location = new Point(24, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 298);
            panel1.TabIndex = 0;
            // 
            // cbCurriculum
            // 
            cbCurriculum.FormattingEnabled = true;
            cbCurriculum.Location = new Point(112, 157);
            cbCurriculum.Name = "cbCurriculum";
            cbCurriculum.Size = new Size(100, 23);
            cbCurriculum.TabIndex = 12;
            // 
            // lblIdCurriculumError
            // 
            lblIdCurriculumError.AutoSize = true;
            lblIdCurriculumError.ForeColor = Color.Red;
            lblIdCurriculumError.Location = new Point(112, 183);
            lblIdCurriculumError.Name = "lblIdCurriculumError";
            lblIdCurriculumError.Size = new Size(123, 15);
            lblIdCurriculumError.TabIndex = 11;
            lblIdCurriculumError.Text = "Ingrese un plan válido";
            // 
            // lblIdError
            // 
            lblIdError.AutoSize = true;
            lblIdError.ForeColor = Color.Red;
            lblIdError.Location = new Point(112, 124);
            lblIdError.Name = "lblIdError";
            lblIdError.Size = new Size(110, 15);
            lblIdError.TabIndex = 10;
            lblIdError.Text = "Ingrese un id válido";
            // 
            // lblDescriptionError
            // 
            lblDescriptionError.AutoSize = true;
            lblDescriptionError.ForeColor = Color.Red;
            lblDescriptionError.Location = new Point(112, 68);
            lblDescriptionError.Name = "lblDescriptionError";
            lblDescriptionError.Size = new Size(166, 15);
            lblDescriptionError.TabIndex = 9;
            lblDescriptionError.Text = "Ingrese una descripción válida";
            // 
            // btnActionCommission
            // 
            btnActionCommission.Location = new Point(281, 157);
            btnActionCommission.Name = "btnActionCommission";
            btnActionCommission.Size = new Size(128, 23);
            btnActionCommission.TabIndex = 8;
            btnActionCommission.Text = "Crear comisión";
            btnActionCommission.UseVisualStyleBackColor = true;
            btnActionCommission.Click += btnActionCommission_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(112, 98);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            // 
            // txtCommissionDescription
            // 
            txtCommissionDescription.Location = new Point(112, 42);
            txtCommissionDescription.Name = "txtCommissionDescription";
            txtCommissionDescription.Size = new Size(297, 23);
            txtCommissionDescription.TabIndex = 4;
            txtCommissionDescription.KeyDown += txtCommissionDescription_KeyDown;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(60, 160);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(46, 15);
            lblYear.TabIndex = 2;
            lblYear.Text = "Id plan:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(86, 98);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 1;
            lblId.Text = "Id:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(34, 45);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(72, 15);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Descripción:";
            // 
            // frmActionCommission
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 332);
            Controls.Add(panel1);
            Name = "frmActionCommission";
            Text = "Crear Comisión";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblId;
        private Label lblDescription;
        private Label lblYear;
        private TextBox txtId;
        private TextBox txtCommissionDescription;
        private Button btnActionCommission;
        private Label lblDescriptionError;
        private Label lblIdCurriculumError;
        private Label lblIdError;
        private ComboBox cbCurriculum;
    }
}