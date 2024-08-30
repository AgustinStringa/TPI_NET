namespace UI.Desktop.Subject
{
    partial class frmActionSubject
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
            txtDescription = new TextBox();
            label1 = new Label();
            txtWeeklyHours = new TextBox();
            label2 = new Label();
            cbCurriculums = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            txtLevel = new TextBox();
            label5 = new Label();
            txtTotalHours = new TextBox();
            lstCorrelativesParent = new ListBox();
            label6 = new Label();
            label7 = new Label();
            lstCorrelativesChildren = new ListBox();
            btnAddCorrelativeParent = new Button();
            btnRemoveCorrelativeParent = new Button();
            btnRemoveCorrelativeChildren = new Button();
            btnAddCorrelativeChildren = new Button();
            label8 = new Label();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(117, 114);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(194, 23);
            txtDescription.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 88);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre Materia";
            // 
            // txtWeeklyHours
            // 
            txtWeeklyHours.Location = new Point(117, 181);
            txtWeeklyHours.Margin = new Padding(3, 2, 3, 2);
            txtWeeklyHours.Name = "txtWeeklyHours";
            txtWeeklyHours.Size = new Size(194, 23);
            txtWeeklyHours.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 154);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Horas semanales";
            // 
            // cbCurriculums
            // 
            cbCurriculums.FormattingEnabled = true;
            cbCurriculums.Location = new Point(374, 114);
            cbCurriculums.Margin = new Padding(3, 2, 3, 2);
            cbCurriculums.Name = "cbCurriculums";
            cbCurriculums.Size = new Size(194, 23);
            cbCurriculums.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(374, 88);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 5;
            label3.Text = "Plan de Estudio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(374, 154);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 7;
            label4.Text = "Nivel";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(618, 379);
            btnAccept.Margin = new Padding(3, 2, 3, 2);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(139, 22);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Registrar Materia";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(172, 379);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(139, 22);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar Operacion";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(374, 181);
            txtLevel.Margin = new Padding(3, 2, 3, 2);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(194, 23);
            txtLevel.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(117, 221);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 11;
            label5.Text = "Horas totales";
            // 
            // txtTotalHours
            // 
            txtTotalHours.Location = new Point(117, 248);
            txtTotalHours.Margin = new Padding(3, 2, 3, 2);
            txtTotalHours.Name = "txtTotalHours";
            txtTotalHours.Size = new Size(194, 23);
            txtTotalHours.TabIndex = 10;
            // 
            // lstCorrelativesParent
            // 
            lstCorrelativesParent.FormattingEnabled = true;
            lstCorrelativesParent.ItemHeight = 15;
            lstCorrelativesParent.Location = new Point(637, 110);
            lstCorrelativesParent.Name = "lstCorrelativesParent";
            lstCorrelativesParent.Size = new Size(380, 94);
            lstCorrelativesParent.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(637, 92);
            label6.Name = "label6";
            label6.Size = new Size(102, 15);
            label6.TabIndex = 13;
            label6.Text = "Correlativas Padre";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(637, 214);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 15;
            label7.Text = "Correlativas Hija";
            // 
            // lstCorrelativesChildren
            // 
            lstCorrelativesChildren.FormattingEnabled = true;
            lstCorrelativesChildren.ItemHeight = 15;
            lstCorrelativesChildren.Location = new Point(637, 232);
            lstCorrelativesChildren.Name = "lstCorrelativesChildren";
            lstCorrelativesChildren.Size = new Size(380, 94);
            lstCorrelativesChildren.TabIndex = 14;
            // 
            // btnAddCorrelativeParent
            // 
            btnAddCorrelativeParent.Image = Properties.Resources.Add;
            btnAddCorrelativeParent.Location = new Point(1047, 110);
            btnAddCorrelativeParent.Name = "btnAddCorrelativeParent";
            btnAddCorrelativeParent.Size = new Size(75, 26);
            btnAddCorrelativeParent.TabIndex = 16;
            btnAddCorrelativeParent.UseVisualStyleBackColor = true;
            btnAddCorrelativeParent.Click += button1_Click;
            // 
            // btnRemoveCorrelativeParent
            // 
            btnRemoveCorrelativeParent.Image = Properties.Resources.Delete;
            btnRemoveCorrelativeParent.Location = new Point(1047, 142);
            btnRemoveCorrelativeParent.Name = "btnRemoveCorrelativeParent";
            btnRemoveCorrelativeParent.Size = new Size(75, 27);
            btnRemoveCorrelativeParent.TabIndex = 17;
            btnRemoveCorrelativeParent.UseVisualStyleBackColor = true;
            btnRemoveCorrelativeParent.Click += btnRemoveCorrelativeParent_Click;
            // 
            // btnRemoveCorrelativeChildren
            // 
            btnRemoveCorrelativeChildren.Image = Properties.Resources.Delete;
            btnRemoveCorrelativeChildren.Location = new Point(1047, 264);
            btnRemoveCorrelativeChildren.Name = "btnRemoveCorrelativeChildren";
            btnRemoveCorrelativeChildren.Size = new Size(75, 27);
            btnRemoveCorrelativeChildren.TabIndex = 19;
            btnRemoveCorrelativeChildren.UseVisualStyleBackColor = true;
            btnRemoveCorrelativeChildren.Click += btnRemoveCorrelativeChildren_Click;
            // 
            // btnAddCorrelativeChildren
            // 
            btnAddCorrelativeChildren.Image = Properties.Resources.Add;
            btnAddCorrelativeChildren.Location = new Point(1047, 232);
            btnAddCorrelativeChildren.Name = "btnAddCorrelativeChildren";
            btnAddCorrelativeChildren.Size = new Size(75, 26);
            btnAddCorrelativeChildren.TabIndex = 18;
            btnAddCorrelativeChildren.UseVisualStyleBackColor = true;
            btnAddCorrelativeChildren.Click += button4_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(431, 280);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 20;
            label8.Text = "label8";
            // 
            // frmActionSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 431);
            Controls.Add(label8);
            Controls.Add(btnRemoveCorrelativeChildren);
            Controls.Add(btnAddCorrelativeChildren);
            Controls.Add(btnRemoveCorrelativeParent);
            Controls.Add(btnAddCorrelativeParent);
            Controls.Add(label7);
            Controls.Add(lstCorrelativesChildren);
            Controls.Add(label6);
            Controls.Add(lstCorrelativesParent);
            Controls.Add(label5);
            Controls.Add(txtTotalHours);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbCurriculums);
            Controls.Add(label2);
            Controls.Add(txtLevel);
            Controls.Add(txtWeeklyHours);
            Controls.Add(label1);
            Controls.Add(txtDescription);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmActionSubject";
            Text = "frmActionArea";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescription;
        private Label label1;
        private TextBox txtWeeklyHours;
        private Label label2;
        private ComboBox cbCurriculums;
        private Label label3;
        private Label label4;
        private Button btnAccept;
        private Button btnCancel;
        private TextBox txtLevel;
        private Label label5;
        private TextBox txtTotalHours;
        private ListBox lstCorrelativesParent;
        private Label label6;
        private Label label7;
        private ListBox lstCorrelativesChildren;
        private Button btnAddCorrelativeParent;
        private Button btnRemoveCorrelativeParent;
        private Button btnRemoveCorrelativeChildren;
        private Button btnAddCorrelativeChildren;
        private Label label8;
    }
}