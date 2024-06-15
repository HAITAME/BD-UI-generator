using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_UI
{
    public partial class Add : Form
    {
        private MySqlConnection connection;
        private string tableName;
        private DataTable dataTable;
        public Add(MySqlConnection connection, string tableName)
        {
            InitializeComponent();
            InitializeComponent();
            this.connection = connection;
            this.tableName = tableName;
            LoadTableSchema();
        }

        private void LoadTableSchema()
        {
            string query = $"DESCRIBE {tableName}";
            dataTable = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                string columnName = row.Field<string>("Field");
                string columnType = row.Field<string>("Type");
                string columnKey = row.Field<string>("Key");
                string columnNull = row.Field<string>("Null");
                string columnDefault = row.Field<string>("Default");
                string columnExtra = row.Field<string>("Extra");

                Console.WriteLine($"{columnName} {columnType} {columnKey} {columnNull} {columnDefault} {columnExtra}");

            }
        }
    }
}
