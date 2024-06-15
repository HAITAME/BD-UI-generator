using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_UI
{
    public partial class Add : Form
    {
        private MySqlConnection connection;
        private string tableName;
        private DataTable dataTable;
        public int InsertResult { get; private set; } // Property to store the result of the insert operation

        public Add(MySqlConnection connection, string tableName)
        {
            InitializeComponent();
            this.connection = connection;
            this.tableName = tableName;
            LoadTableSchema();
            CreateFormControls();
        }

        private void LoadTableSchema()
        {
            string query = $"DESCRIBE {tableName}";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
        }

        private void CreateFormControls()
        {
            int yPosition = 20;

            foreach (DataRow row in dataTable.Rows)
            {
                string columnName = row["Field"].ToString();
                string columnType = row["Type"].ToString();

                // Create Label
                Label label = new Label();
                label.Text = columnName;
                label.Location = new Point(20, yPosition);
                label.AutoSize = true;
                this.Controls.Add(label);

                // Create TextBox
                TextBox textBox = new TextBox();
                textBox.Name = columnName;
                textBox.Location = new Point(150, yPosition - 4);
                textBox.Width = 200;

                // Adjust TextBox properties based on columnType if needed

                this.Controls.Add(textBox);

                yPosition += 30;
            }

            // Create Submit Button
            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new Point(150, yPosition);
            submitButton.Click += new EventHandler(SubmitButton_Click);
            this.Controls.Add(submitButton);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = $"INSERT INTO {tableName} (";
                string valuesQuery = "VALUES (";

                foreach (DataRow row in dataTable.Rows)
                {
                    string columnName = row["Field"].ToString();
                    TextBox textBox = this.Controls.Find(columnName, true).FirstOrDefault() as TextBox;

                    if (textBox != null)
                    {
                        insertQuery += $"{columnName},";
                        valuesQuery += $"@{columnName},";
                    }
                }

                insertQuery = insertQuery.TrimEnd(',') + ") ";
                valuesQuery = valuesQuery.TrimEnd(',') + ")";

                using (MySqlCommand command = new MySqlCommand(insertQuery + valuesQuery, connection))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string columnName = row["Field"].ToString();
                        TextBox textBox = this.Controls.Find(columnName, true).FirstOrDefault() as TextBox;

                        if (textBox != null)
                        {
                            command.Parameters.AddWithValue($"@{columnName}", textBox.Text);
                        }
                    }

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data inserted successfully!");
                InsertResult = 1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                InsertResult = 0; 
            }
            finally
            {
                this.Close();
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
