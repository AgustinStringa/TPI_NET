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
            label2 = new Label();
            cmbCourse = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            lblmat = new Label();
            lblcur = new Label();
            btnInscription = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 181);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Materia:";
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(95, 219);
            cmbSubject.Margin = new Padding(3, 4, 3, 4);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(260, 28);
            cmbSubject.TabIndex = 1;
            cmbSubject.SelectedValueChanged += cmbSubjects_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 296);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 0;
            label2.Text = "Cursado:";
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(95, 320);
            cmbCourse.Margin = new Padding(3, 4, 3, 4);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(260, 28);
            cmbCourse.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(95, 89);
            label3.Name = "label3";
            label3.Size = new Size(295, 35);
            label3.TabIndex = 2;
            label3.Text = "Inscripción a una materia";
            // 
            // button1
            // 
            button1.Location = new Point(382, 320);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Ver detalles";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(382, 219);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 3;
            button2.Text = "Ver detalles";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click;
            // 
            // lblmat
            // 
            lblmat.AutoSize = true;
            lblmat.Location = new Point(544, 228);
            lblmat.Name = "lblmat";
            lblmat.Size = new Size(50, 20);
            lblmat.TabIndex = 4;
            lblmat.Text = "label4";
            // 
            // lblcur
            // 
            lblcur.AutoSize = true;
            lblcur.Location = new Point(554, 336);
            lblcur.Name = "lblcur";
            lblcur.Size = new Size(50, 20);
            lblcur.TabIndex = 5;
            lblcur.Text = "label5";
            // 
            // btnInscription
            // 
            btnInscription.Location = new Point(382, 419);
            btnInscription.Name = "btnInscription";
            btnInscription.Size = new Size(94, 29);
            btnInscription.TabIndex = 6;
            btnInscription.Text = "Inscribirse";
            btnInscription.UseVisualStyleBackColor = true;
            btnInscription.Click += btnInscription_Click;
            // 
            // frmInscripcionCursado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnInscription);
            Controls.Add(lblcur);
            Controls.Add(lblmat);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(cmbCourse);
            Controls.Add(cmbSubject);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmInscripcionCursado";
            Text = "frmInscripcionMateria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbSubject;
        private Label label2;
        private ComboBox cmbCourse;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label lblmat;
        private Label lblcur;
        private Button btnInscription;
    }
}