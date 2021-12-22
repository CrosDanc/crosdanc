using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class SUBD_Access
	{
		public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Общее.mdb";
		private OleDbConnection connection = new OleDbConnection(connectionString);

		public DataTable GetAnyTable(string tableName)
		{
			string query = $"SELECT * FROM [{tableName}]";
			OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
			DataTable dataTable = new DataTable();
			adapter.Fill(dataTable);
			return dataTable;

		}

		public void DeleteStringFromDb(string tableName, string columnName, int id)
		{
			connection.Open();
			string query = $"DELETE FROM [{tableName}] WHERE {columnName} = {id}";
			OleDbCommand command = new OleDbCommand(query, connection);
			command.ExecuteNonQuery();
			connection.Close();
		}

		public void InsertStringFromDb(string query)
		{
			connection.Open();
			OleDbCommand command = new OleDbCommand(query, connection);
			command.ExecuteNonQuery();
			connection.Close();
		}

	}



}
