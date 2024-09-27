using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
	public partial class FrmInputGrade : Form
	{
		public int _currentGrade;
		public FrmInputGrade(int currentGrade)
		{
			InitializeComponent();
			_currentGrade = currentGrade;
			txtGrade.Text = _currentGrade.ToString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				_currentGrade = int.Parse(txtGrade.Text);
				if (_currentGrade < 0 || _currentGrade > 10)
				{
					lblGradeError.Visible = true;
					lblGradeError.Text = "Ingresa una nota valida";
				}
				else
				{
					lblGradeError.Visible = false;
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception)
			{
				lblGradeError.Visible = true;
				lblGradeError.Text = "Ingresa una nota valida";
			}

		}
	}
}
