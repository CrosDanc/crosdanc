using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class DB_EditoreForm : Form
	{
		SUBD_Access subd = new SUBD_Access();
		public DB_EditoreForm()
		{
			InitializeComponent();
		}

		private void DB_EditoreForm_Load(object sender, EventArgs e)
		{
			RefreshTables();
		}

		private void RefreshTables()
		{
			dataGridView1.DataSource = subd.GetAnyTable("Студенты");
			dataGridView2.DataSource = subd.GetAnyTable("Преподаватели");
			dataGridView3.DataSource = subd.GetAnyTable("Успеваемость");
			dataGridView4.DataSource = subd.GetAnyTable("Учебная группа");

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string tableName = tabControl1.SelectedTab.Text;
			string columnName = "";
			int id = 0;
			try
			{
				switch (tabControl1.SelectedIndex)
				{
					case 0:
						columnName = dataGridView1.Columns[0].HeaderText;
						id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
						break;
					case 1:
						columnName = dataGridView1.Columns[0].HeaderText;
						id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
						break;
					case 2:
						columnName = dataGridView1.Columns[0].HeaderText;
						id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
						break;
					case 3:
						columnName = dataGridView1.Columns[0].HeaderText;
						id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value.ToString());
						break;

				}
				subd.DeleteStringFromDb(tableName, columnName, id);
				RefreshTables();
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		private void button3_Click(object sender, EventArgs e)
		{
			string query = "";
			switch (tabControl1.SelectedTab.Text)
			{
				case "Студенты":
					 query = $"INSERT INTO [Студенты] ([Код], [Фамилия], [Группа], [Оценка], [Предмет])" +
						$" VALUES ({dataGridView1[0,dataGridView1.CurrentRow.Index].Value}, '{dataGridView1[1, dataGridView1.CurrentRow.Index].Value}', '{dataGridView1[2, dataGridView1.CurrentRow.Index].Value}', {dataGridView1[3, dataGridView1.CurrentRow.Index].Value}, '{dataGridView1[4, dataGridView1.CurrentRow.Index].Value}')";
					break;

				case "Преподаватели":
					query = $"INSERT INTO [Преподаватели] ([Код], [Фамилия], [Предмет])" +
					   $" VALUES ({dataGridView1[0, dataGridView1.CurrentRow.Index].Value}, '{dataGridView1[1, dataGridView1.CurrentRow.Index].Value}', '{dataGridView1[2, dataGridView1.CurrentRow.Index].Value}')";
					break;

				case "Успеваемость":
					query = $"INSERT INTO [Успеваемость] ([Код], [Фамилия], [Оценка], [Предмет])" +
					   $" VALUES ({dataGridView1[0, dataGridView1.CurrentRow.Index].Value}, '{dataGridView1[1, dataGridView1.CurrentRow.Index].Value}', '{dataGridView1[2, dataGridView1.CurrentRow.Index].Value}', {dataGridView1[3, dataGridView1.CurrentRow.Index].Value},)";
					break;

				case "Учебная группа":
					query = $"INSERT INTO [Учебная группа] ([Код], [Фамилия], [Группа])" +
					   $" VALUES ({dataGridView1[0, dataGridView1.CurrentRow.Index].Value}, '{dataGridView1[1, dataGridView1.CurrentRow.Index].Value}', '{dataGridView1[2, dataGridView1.CurrentRow.Index].Value}')";
					break;

			}

			subd.InsertStringFromDb(query);
		}
	}
}
