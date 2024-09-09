﻿namespace UI.Desktop
{
    partial class FrmMain
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
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            frmSalir = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            crearUsuarioToolStripMenuItem1 = new ToolStripMenuItem();
            usuariosToolStripMenuItem1 = new ToolStripMenuItem();
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            planesDeEstudioToolStripMenuItem = new ToolStripMenuItem();
            materiasToolStripMenuItem = new ToolStripMenuItem();
            comisionesToolStripMenuItem = new ToolStripMenuItem();
            crearUsuarioToolStripMenuItem = new ToolStripMenuItem();
            cursadoToolStripMenuItem = new ToolStripMenuItem();
            inscripcionACursadoToolStripMenuItem = new ToolStripMenuItem();
            cursadosActivosToolStripMenuItem = new ToolStripMenuItem();
            crearCursadoToolStripMenuItem = new ToolStripMenuItem();
            administrarCursadosToolStripMenuItem = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, usuariosToolStripMenuItem, especialidadesToolStripMenuItem, planesDeEstudioToolStripMenuItem, materiasToolStripMenuItem, comisionesToolStripMenuItem, crearUsuarioToolStripMenuItem, cursadoToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 24);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { frmSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(60, 20);
            mnuArchivo.Text = "&Archivo";
            // 
            // frmSalir
            // 
            frmSalir.Name = "frmSalir";
            frmSalir.Size = new Size(96, 22);
            frmSalir.Text = "Salir";
            frmSalir.Click += frmSalir_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem1, crearUsuarioToolStripMenuItem1 });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // crearUsuarioToolStripMenuItem1
            // 
            crearUsuarioToolStripMenuItem1.Name = "crearUsuarioToolStripMenuItem1";
            crearUsuarioToolStripMenuItem1.Size = new Size(145, 22);
            crearUsuarioToolStripMenuItem1.Text = "Crear Usuario";
            crearUsuarioToolStripMenuItem1.Click += crearUsuarioToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem1
            // 
            usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            usuariosToolStripMenuItem1.Size = new Size(145, 22);
            usuariosToolStripMenuItem1.Text = "Usuarios";
            usuariosToolStripMenuItem1.Click += usuariosToolStripMenuItem1_Click;
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(95, 20);
            especialidadesToolStripMenuItem.Text = "Especialidades";
            especialidadesToolStripMenuItem.Click += especialidadesToolStripMenuItem_Click;
            // 
            // planesDeEstudioToolStripMenuItem
            // 
            planesDeEstudioToolStripMenuItem.Name = "planesDeEstudioToolStripMenuItem";
            planesDeEstudioToolStripMenuItem.Size = new Size(111, 20);
            planesDeEstudioToolStripMenuItem.Text = "Planes de Estudio";
            planesDeEstudioToolStripMenuItem.Click += planesDeEstudioToolStripMenuItem_Click;
            // 
            // materiasToolStripMenuItem
            // 
            materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            materiasToolStripMenuItem.Size = new Size(64, 20);
            materiasToolStripMenuItem.Text = "Materias";
            materiasToolStripMenuItem.Click += materiasToolStripMenuItem_Click;
            // 
            // comisionesToolStripMenuItem
            // 
            comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            comisionesToolStripMenuItem.Size = new Size(81, 20);
            comisionesToolStripMenuItem.Text = "Comisiones";
            comisionesToolStripMenuItem.Click += comisionesToolStripMenuItem_Click;
            // 
            // crearUsuarioToolStripMenuItem
            // 
            crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            crearUsuarioToolStripMenuItem.Size = new Size(90, 20);
            crearUsuarioToolStripMenuItem.Text = "Crear Usuario";
            crearUsuarioToolStripMenuItem.Click += crearUsuarioToolStripMenuItem_Click;
            // 
            // cursadoToolStripMenuItem
            // 
            cursadoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inscripcionACursadoToolStripMenuItem, cursadosActivosToolStripMenuItem, crearCursadoToolStripMenuItem, administrarCursadosToolStripMenuItem });
            cursadoToolStripMenuItem.Name = "cursadoToolStripMenuItem";
            cursadoToolStripMenuItem.Size = new Size(63, 20);
            cursadoToolStripMenuItem.Text = "Cursado";
            // 
            // inscripcionACursadoToolStripMenuItem
            // 
            inscripcionACursadoToolStripMenuItem.Name = "inscripcionACursadoToolStripMenuItem";
            inscripcionACursadoToolStripMenuItem.Size = new Size(188, 22);
            inscripcionACursadoToolStripMenuItem.Text = "Inscripcion a Cursado";
            inscripcionACursadoToolStripMenuItem.Click += inscripcionACursadoToolStripMenuItem_Click;
            // 
            // cursadosActivosToolStripMenuItem
            // 
            cursadosActivosToolStripMenuItem.Name = "cursadosActivosToolStripMenuItem";
            cursadosActivosToolStripMenuItem.Size = new Size(188, 22);
            cursadosActivosToolStripMenuItem.Text = "Mis Cursados";
            cursadosActivosToolStripMenuItem.Click += cursadosActivosToolStripMenuItem_Click;
            // 
            // crearCursadoToolStripMenuItem
            // 
            crearCursadoToolStripMenuItem.Name = "crearCursadoToolStripMenuItem";
            crearCursadoToolStripMenuItem.Size = new Size(188, 22);
            crearCursadoToolStripMenuItem.Text = "Crear Cursado";
            // 
            // administrarCursadosToolStripMenuItem
            // 
            administrarCursadosToolStripMenuItem.Name = "administrarCursadosToolStripMenuItem";
            administrarCursadosToolStripMenuItem.Size = new Size(188, 22);
            administrarCursadosToolStripMenuItem.Text = "Administrar Cursados";
            administrarCursadosToolStripMenuItem.Click += administrarCursadosToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mnsPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Academia";
            WindowState = FormWindowState.Maximized;
            Shown += frmMain_Shown;
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem frmSalir;
        private ToolStripMenuItem especialidadesToolStripMenuItem;
        private ToolStripMenuItem planesDeEstudioToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem materiasToolStripMenuItem;
        private ToolStripMenuItem comisionesToolStripMenuItem;
        private ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private ToolStripMenuItem crearUsuarioToolStripMenuItem1;
        private ToolStripMenuItem cursadoToolStripMenuItem;
        private ToolStripMenuItem inscripcionACursadoToolStripMenuItem;
        private ToolStripMenuItem cursadosActivosToolStripMenuItem;
        private ToolStripMenuItem crearCursadoToolStripMenuItem;
        private ToolStripMenuItem administrarCursadosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem1;
    }
}