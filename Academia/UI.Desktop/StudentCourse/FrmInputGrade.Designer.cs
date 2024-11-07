namespace UI.Desktop
{
	partial class FrmInputGrade
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
			txtGrade = new TextBox();
			label1 = new Label();
			lblGradeError = new Label();
			btnSave = new Button();
			SuspendLayout();
			// 
			// txtGrade
			// 
			txtGrade.Location = new Point(36, 88);
			txtGrade.Name = "txtGrade";
			txtGrade.Size = new Size(175, 23);
			txtGrade.TabIndex = 0;
			txtGrade.KeyDown += txtGrade_KeyDown;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(36, 57);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.TabIndex = 1;
			label1.Text = "Nota:";
			// 
			// lblGradeError
			// 
			lblGradeError.AutoSize = true;
			lblGradeError.ForeColor = Color.Red;
			lblGradeError.Location = new Point(36, 132);
			lblGradeError.Name = "lblGradeError";
			lblGradeError.Size = new Size(36, 15);
			lblGradeError.TabIndex = 1;
			lblGradeError.Text = "Nota:";
			lblGradeError.Visible = false;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(136, 164);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 2;
			btnSave.Text = "Guardar Nota";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// FrmInputGrade
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(274, 259);
			Controls.Add(btnSave);
			Controls.Add(lblGradeError);
			Controls.Add(label1);
			Controls.Add(txtGrade);
			Name = "FrmInputGrade";
			Text = "Ingresar Nota";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtGrade;
		private Label label1;
		private Label lblGradeError;
		private Button btnSave;
	}
}