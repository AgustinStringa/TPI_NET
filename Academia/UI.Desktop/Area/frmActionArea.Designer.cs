namespace UI.Desktop.Area
{
    partial class FrmActionArea
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
            btnActionArea = new Button();
            label2 = new Label();
            panel1 = new Panel();
            txtId = new TextBox();
            lblId = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
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
            // txtAreaName
            // 
            txtAreaName.Location = new Point(63, 11);
            txtAreaName.Name = "txtAreaName";
            txtAreaName.Size = new Size(140, 23);
            txtAreaName.TabIndex = 1;
            txtAreaName.KeyDown += txtAreaName_KeyDown;
            // 
            // btnActionArea
            // 
            btnActionArea.Location = new Point(228, 125);
            btnActionArea.Name = "btnActionArea";
            btnActionArea.Size = new Size(126, 23);
            btnActionArea.TabIndex = 2;
            btnActionArea.Text = "Crear Especialidad";
            btnActionArea.UseVisualStyleBackColor = true;
            btnActionArea.Click += btnActionArea_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 14);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 3;
            label2.Text = "*";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnActionArea);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtAreaName);
            panel1.Location = new Point(26, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 165);
            panel1.TabIndex = 4;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(63, 57);
            txtId.Name = "txtId";
            txtId.Size = new Size(140, 23);
            txtId.TabIndex = 5;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(37, 60);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 4;
            lblId.Text = "Id:";
            // 
            // frmCreateArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 204);
            Controls.Add(panel1);
            Name = "frmCreateArea";
            Text = "Crear Especilidad";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtAreaName;
        private Button btnActionArea;
        private Label label2;
        private Panel panel1;
        private TextBox txtId;
        private Label lblId;
    }
}