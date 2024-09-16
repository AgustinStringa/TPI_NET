namespace UI.Desktop
{
    partial class frmInscripcionCursado
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
            label1.Location = new Point(318, 146);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Materia";
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(218, 183);
            cmbSubject.Margin = new Padding(3, 4, 3, 4);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(260, 28);
            cmbSubject.TabIndex = 1;
            cmbSubject.SelectedValueChanged += cmbSubjects_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(228, 59);
            label3.Name = "label3";
            label3.Size = new Size(354, 35);
            label3.TabIndex = 2;
            label3.Text = "INSCRIPCION A UNA MATERIA";
            // 
            // button2
            // 
            button2.Location = new Point(511, 181);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(147, 31);
            button2.TabIndex = 3;
            button2.Text = "Ver detalles";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click;
            // 
            // btnInscription
            // 
            btnInscription.Location = new Point(511, 345);
            btnInscription.Name = "btnInscription";
            btnInscription.Size = new Size(143, 50);
            btnInscription.TabIndex = 6;
            btnInscription.Text = "Inscribirse";
            btnInscription.UseVisualStyleBackColor = true;
            btnInscription.Click += btnInscription_Click;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(218, 278);
            cmbCourse.Margin = new Padding(3, 4, 3, 4);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(260, 28);
            cmbCourse.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 244);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Cursado";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(149, 139);
            panel1.Name = "panel1";
            panel1.Size = new Size(524, 187);
            panel1.TabIndex = 7;
            // 
            // frmInscripcionCursado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 458);
            Controls.Add(label2);
            Controls.Add(btnInscription);
            Controls.Add(cmbCourse);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(cmbSubject);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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