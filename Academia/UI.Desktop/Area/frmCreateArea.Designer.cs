namespace UI.Desktop.Area
{
    partial class frmCreateArea
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
            txtAreaName = new TextBox();
            btnCreateArea = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 45);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txtAreaName
            // 
            txtAreaName.Location = new Point(99, 42);
            txtAreaName.Name = "txtAreaName";
            txtAreaName.Size = new Size(140, 23);
            txtAreaName.TabIndex = 1;
            // 
            // btnCreateArea
            // 
            btnCreateArea.Location = new Point(251, 148);
            btnCreateArea.Name = "btnCreateArea";
            btnCreateArea.Size = new Size(126, 23);
            btnCreateArea.TabIndex = 2;
            btnCreateArea.Text = "Crear Especialidad";
            btnCreateArea.UseVisualStyleBackColor = true;
            btnCreateArea.Click += btnCreateArea_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 45);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 3;
            label2.Text = "*";
            // 
            // frmCreateArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 204);
            Controls.Add(label2);
            Controls.Add(btnCreateArea);
            Controls.Add(txtAreaName);
            Controls.Add(label1);
            Name = "frmCreateArea";
            Text = "Crear Especilidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAreaName;
        private Button btnCreateArea;
        private Label label2;
    }
}