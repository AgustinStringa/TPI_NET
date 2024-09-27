namespace UI.Desktop
{
    partial class FrmUserCourseInscription
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
			label1 = new Label();
			cmbSubject = new ComboBox();
			label3 = new Label();
			button2 = new Button();
			btnInscription = new Button();
			cmbCourse = new ComboBox();
			label2 = new Label();
			panel1 = new Panel();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(278, 110);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 0;
			label1.Text = "Materia";
			// 
			// cmbSubject
			// 
			cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbSubject.FormattingEnabled = true;
			cmbSubject.Location = new Point(191, 137);
			cmbSubject.Name = "cmbSubject";
			cmbSubject.Size = new Size(228, 23);
			cmbSubject.TabIndex = 1;
			cmbSubject.SelectedValueChanged += cmbSubjects_SelectedValueChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 15F);
			label3.Location = new Point(200, 44);
			label3.Name = "label3";
			label3.Size = new Size(280, 28);
			label3.TabIndex = 2;
			label3.Text = "INSCRIPCION A UNA MATERIA";
			// 
			// button2
			// 
			button2.Location = new Point(447, 136);
			button2.Name = "button2";
			button2.Size = new Size(129, 23);
			button2.TabIndex = 3;
			button2.Text = "Ver detalles";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button1_Click;
			// 
			// btnInscription
			// 
			btnInscription.Location = new Point(447, 259);
			btnInscription.Margin = new Padding(3, 2, 3, 2);
			btnInscription.Name = "btnInscription";
			btnInscription.Size = new Size(125, 38);
			btnInscription.TabIndex = 6;
			btnInscription.Text = "Inscribirse";
			btnInscription.UseVisualStyleBackColor = true;
			btnInscription.Click += btnInscription_Click;
			// 
			// cmbCourse
			// 
			cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbCourse.FormattingEnabled = true;
			cmbCourse.Location = new Point(191, 208);
			cmbCourse.Name = "cmbCourse";
			cmbCourse.Size = new Size(228, 23);
			cmbCourse.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(278, 183);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.TabIndex = 0;
			label2.Text = "Cursado";
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Location = new Point(130, 104);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(459, 141);
			panel1.TabIndex = 7;
			// 
			// frmInscripcionCursado
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(726, 344);
			Controls.Add(label2);
			Controls.Add(btnInscription);
			Controls.Add(cmbCourse);
			Controls.Add(button2);
			Controls.Add(label3);
			Controls.Add(cmbSubject);
			Controls.Add(label1);
			Controls.Add(panel1);
			Name = "frmInscripcionCursado";
			Text = "frmInscripcionMateria";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private ComboBox cmbSubject;
        private Label label3;
        private Button button2;
        private Button btnInscription;
        private ComboBox cmbCourse;
        private Label label2;
        private Panel panel1;
    }
}