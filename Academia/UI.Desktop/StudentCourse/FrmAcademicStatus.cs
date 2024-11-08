using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore.Model;
using ApplicationCore.Services;
using ClientService.Curriculum;
using ClientService.StudentCourse;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Desktop
{
	public partial class FrmAcademicStatus : Form
	{
		private IStudentCourseService studentCourseService;
		private IEnumerable<AcademicStatusItem> academicStatus;
		private Student student;

		private int totatSubjects;
		private int passedSubjects;
		private int failedSubjects;
		private double passedSubjectPerc;
		private double failedSubjectPerc;
		private double average;

		private string selectedPath = "";

		public FrmAcademicStatus(ApplicationCore.Model.Student student, IServiceProvider serviceProvider)
		{
			this.studentCourseService = serviceProvider.GetRequiredService<IStudentCourseService>();
			this.student = student;
			InitializeComponent();
			lstAcademicStatus.Enabled = false;
			lblName.Text = $"{student.Name} {student.Lastname} ({student.StudentId}) a las  {DateTime.Now.ToString()}";
			LoadAcademicStatus();
		}

		public async void LoadAcademicStatus()
		{
			try
			{
				this.academicStatus = await studentCourseService.GetAcademicStatus(this.student.Id);
				lstAcademicStatus.Items.Clear();
				foreach (AcademicStatusItem item in this.academicStatus)
				{
					var nuevo = new ListViewItem(item.SubjectDescription);
					nuevo.SubItems.Add(item.Condition);
					nuevo.SubItems.Add(item.Grade.ToString());
					nuevo.SubItems.Add(item.CalendarYear);
					nuevo.SubItems.Add(item.SubjectLevel.ToString());
					lstAcademicStatus.Items.Add(nuevo);
				}
				lstAcademicStatus.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				GetStatistics();
			}
		}

		public void GetStatistics()
		{
			this.totatSubjects = academicStatus.Count();
			if (this.totatSubjects > 0)
			{
				this.passedSubjects = academicStatus.Count(item => item.Grade >= 6);
				this.failedSubjects = academicStatus.Count(item => item.Grade < 6);

				this.passedSubjectPerc = passedSubjects * 100 / totatSubjects;
				this.failedSubjectPerc = failedSubjects * 100 / totatSubjects;
				this.average = Math.Round(((double)academicStatus.Sum(i => i.Grade)) / totatSubjects, 2);
				lblCountPassedSubjects.Text = $"Materias Aprobadas: {passedSubjects.ToString()} ({passedSubjectPerc.ToString()} porciento)";
				lblCountFailedSubjects.Text = $"Materias Reprobadas: {failedSubjects.ToString()} ({failedSubjectPerc.ToString()} porciento)";
			}
			else
			{
				this.passedSubjects = this.failedSubjects = 0;
				this.average = 0;
			}
			lblCountPassedSubjects.Text = $"Materias Aprobadas: {passedSubjects.ToString()} (0% porciento)";
			lblCountFailedSubjects.Text = $"Materias Reprobadas: {failedSubjects.ToString()} (0% porciento)";
			lblAverage.Text = $"Promedio: {this.average.ToString()}";
		}

		private async void btnGenerateReport_Click(object sender, EventArgs e)
		{
			if (this.selectedPath == "")
			{
				MessageBox.Show("Selecciona un directorio destino para el reporte (archivo .pdf)", "Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			try
			{
				var report = await this.studentCourseService.GetReport(this.student.Id);
				await File.WriteAllBytesAsync($"{this.selectedPath}\\demo_user_id_{this.student.Id.ToString()}.pdf", report);
				MessageBox.Show($"Reporte Generado. Revisa el directorio:{$"{this.selectedPath}"}", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				MessageBox.Show("Error al generar el reporte", "Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnSelectPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.ShowDialog(this);
			this.selectedPath = this.folderBrowserDialog1.SelectedPath;
			this.txtSelectedPath.Text = this.selectedPath;
		}
	}
}
