namespace UI.Desktop.Commission
{
    partial class FrmActionCommission
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
			numLevel = new NumericUpDown();
			cbCurriculum = new ComboBox();
			lblLevelError = new Label();
			lblIdCurriculumError = new Label();
			lblDescriptionError = new Label();
			btnActionCommission = new Button();
			txtCommissionDescription = new TextBox();
			label1 = new Label();
			lblYear = new Label();
			lblDescription = new Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numLevel).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(numLevel);
			panel1.Controls.Add(cbCurriculum);
			panel1.Controls.Add(lblLevelError);
			panel1.Controls.Add(lblIdCurriculumError);
			panel1.Controls.Add(lblDescriptionError);
			panel1.Controls.Add(btnActionCommission);
			panel1.Controls.Add(txtCommissionDescription);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(lblYear);
			panel1.Controls.Add(lblDescription);
			panel1.Location = new Point(24, 22);
			panel1.Name = "panel1";
			panel1.Size = new Size(465, 298);
			panel1.TabIndex = 0;
			// 
			// numLevel
			// 
			numLevel.Location = new Point(135, 179);
			numLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numLevel.Name = "numLevel";
			numLevel.ReadOnly = true;
			numLevel.Size = new Size(120, 23);
			numLevel.TabIndex = 13;
			numLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// cbCurriculum
			// 
			cbCurriculum.DropDownStyle = ComboBoxStyle.DropDownList;
			cbCurriculum.FormattingEnabled = true;
			cbCurriculum.Location = new Point(135, 107);
			cbCurriculum.Name = "cbCurriculum";
			cbCurriculum.Size = new Size(125, 23);
			cbCurriculum.TabIndex = 12;
			// 
			// lblLevelError
			// 
			lblLevelError.AutoSize = true;
			lblLevelError.ForeColor = Color.Red;
			lblLevelError.Location = new Point(135, 218);
			lblLevelError.Name = "lblLevelError";
			lblLevelError.Size = new Size(125, 15);
			lblLevelError.TabIndex = 11;
			lblLevelError.Text = "Ingrese un nivel válido";
			lblLevelError.Visible = false;
			// 
			// lblIdCurriculumError
			// 
			lblIdCurriculumError.AutoSize = true;
			lblIdCurriculumError.ForeColor = Color.Red;
			lblIdCurriculumError.Location = new Point(135, 133);
			lblIdCurriculumError.Name = "lblIdCurriculumError";
			lblIdCurriculumError.Size = new Size(123, 15);
			lblIdCurriculumError.TabIndex = 11;
			lblIdCurriculumError.Text = "Ingrese un plan válido";
			lblIdCurriculumError.Visible = false;
			// 
			// lblDescriptionError
			// 
			lblDescriptionError.AutoSize = true;
			lblDescriptionError.ForeColor = Color.Red;
			lblDescriptionError.Location = new Point(135, 68);
			lblDescriptionError.Name = "lblDescriptionError";
			lblDescriptionError.Size = new Size(142, 15);
			lblDescriptionError.TabIndex = 9;
			lblDescriptionError.Text = "Ingrese un nombre válido";
			lblDescriptionError.Visible = false;
			// 
			// btnActionCommission
			// 
			btnActionCommission.Location = new Point(323, 249);
			btnActionCommission.Name = "btnActionCommission";
			btnActionCommission.Size = new Size(128, 35);
			btnActionCommission.TabIndex = 8;
			btnActionCommission.Text = "Crear comisión";
			btnActionCommission.UseVisualStyleBackColor = true;
			btnActionCommission.Click += btnActionCommission_Click;
			// 
			// txtCommissionDescription
			// 
			txtCommissionDescription.Location = new Point(135, 42);
			txtCommissionDescription.Name = "txtCommissionDescription";
			txtCommissionDescription.Size = new Size(297, 23);
			txtCommissionDescription.TabIndex = 4;
			txtCommissionDescription.KeyDown += txtCommissionDescription_KeyDown;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(34, 187);
			label1.Name = "label1";
			label1.Size = new Size(37, 15);
			label1.TabIndex = 2;
			label1.Text = "Nivel:";
			// 
			// lblYear
			// 
			lblYear.AutoSize = true;
			lblYear.Location = new Point(34, 107);
			lblYear.Name = "lblYear";
			lblYear.Size = new Size(91, 15);
			lblYear.TabIndex = 2;
			lblYear.Text = "Plan de Estudio:";
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
			((System.ComponentModel.ISupportInitialize)numLevel).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
        private Label lblDescription;
        private Label lblYear;
        private TextBox txtCommissionDescription;
        private Button btnActionCommission;
        private Label lblDescriptionError;
        private Label lblIdCurriculumError;
        private ComboBox cbCurriculum;
		private NumericUpDown numLevel;
		private Label lblLevelError;
		private Label label1;
	}
}