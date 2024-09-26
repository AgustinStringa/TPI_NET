namespace UI.Desktop.Course
{
	partial class FrmTeachersList
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
			btnAddTeacher = new Button();
			listView1 = new ListView();
			columnHeader1 = new ColumnHeader();
			SuspendLayout();
			// 
			// btnAddTeacher
			// 
			btnAddTeacher.Font = new Font("Segoe UI", 12F);
			btnAddTeacher.Location = new Point(208, 349);
			btnAddTeacher.Name = "btnAddTeacher";
			btnAddTeacher.Size = new Size(143, 41);
			btnAddTeacher.TabIndex = 1;
			btnAddTeacher.Text = "Agregar";
			btnAddTeacher.UseVisualStyleBackColor = true;
			btnAddTeacher.Click += btnAddTeacher_Click;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			listView1.Location = new Point(44, 26);
			listView1.Name = "listView1";
			listView1.Size = new Size(307, 300);
			listView1.TabIndex = 2;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Docente";
			columnHeader1.Width = 200;
			// 
			// FrmTeachersList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(401, 402);
			Controls.Add(listView1);
			Controls.Add(btnAddTeacher);
			Name = "FrmTeachersList";
			Text = "TeachersList";
			ResumeLayout(false);
		}

		#endregion
		private Button btnAddTeacher;
		private ListView listView1;
		private ColumnHeader columnHeader1;
	}
}