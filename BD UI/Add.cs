using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_UI
{
    public partial class Add : Form
    {
        private MySqlConnection connection;
        private string tableName;
        private DataTable dataTable;
        public int InsertResult { get; private set; }

        public Add(MySqlConnection connection, string tableName)
        {
            InitializeComponent();
            this.connection = connection;
            this.tableName = tableName;
            LoadTableSchema();
            CreateFormControls();
        }
        private void Connecte()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
                connection.Open();
            }
        }
        private void Disconnect()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void LoadTableSchema()
        {
            Connecte();
            string query = $"DESCRIBE {tableName}";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            Disconnect();
        }

        private void CreateFormControls()
        {
            int yPosition = 20;

            foreach (DataRow row in dataTable.Rows)
            {
                string columnName = row["Field"].ToString();
                string columnType = row["Type"].ToString();

                Label label = CreateLabel(columnName, yPosition);
                Control inputControl = CreateInputControl(columnType);

                label.AutoSize = true;
                this.Controls.Add(label);
                this.Controls.Add(inputControl);

                inputControl.Name = columnName;
                inputControl.Location = new Point(150, yPosition - 4);
                yPosition += 30;
            }

            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new Point(150, yPosition);
            submitButton.Click += new EventHandler(SubmitButton_Click);
            this.Controls.Add(submitButton);
        }

        private Label CreateLabel(string text, int yPos)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(20, yPos);
            return label;
        }

        private Control CreateInputControl(string columnType)
        {
            if (IsNumericType(columnType))
            {
                return CreateNumericUpDown();
            }
            else if (IsDateType(columnType))
            {
                return CreateDateTimePicker();
            }
            else if (IsBooleanType(columnType))
            {
                return CreateCheckBox();
            }
            else
            {
                return CreateTextBox();
            }
        }

        private bool IsNumericType(string columnType)
        {
            return columnType.StartsWith("int") || columnType.StartsWith("decimal");
        }

        private bool IsDateType(string columnType)
        {
            return columnType.StartsWith("date") || columnType.StartsWith("time") || columnType.StartsWith("timestamp");
        }

        private bool IsBooleanType(string columnType)
        {
            return columnType.Equals("bit(1)");
        }

        private NumericUpDown CreateNumericUpDown()
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Width = 100;
            return numericUpDown;
        }

        private DateTimePicker CreateDateTimePicker()
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Width = 150;
            return dateTimePicker;
        }

        private CheckBox CreateCheckBox()
        {
            CheckBox checkBox = new CheckBox();
            return checkBox;
        }

        private TextBox CreateTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Width = 200;
            return textBox;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Connecte();
                string insertQuery = $"INSERT INTO {tableName} (";
                string valuesQuery = "VALUES (";

                foreach (DataRow row in dataTable.Rows)
                {
                    string columnName = row["Field"].ToString();
                    Control inputControl = this.Controls.Find(columnName, true).FirstOrDefault() as Control;

                    if (inputControl != null)
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
                        Control inputControl = this.Controls.Find(columnName, true).FirstOrDefault() as Control;

                        if (inputControl != null)
                        {
                            if (inputControl is NumericUpDown numericUpDown)
                            {
                                command.Parameters.AddWithValue($"@{columnName}", numericUpDown.Value);
                            }
                            else if (inputControl is DateTimePicker dateTimePicker)
                            {
                                command.Parameters.AddWithValue($"@{columnName}", dateTimePicker.Value);
                            }
                            else if (inputControl is CheckBox checkBox)
                            {
                                command.Parameters.AddWithValue($"@{columnName}", checkBox.Checked);
                            }
                            else
                            {
                                command.Parameters.AddWithValue($"@{columnName}", inputControl.Text);
                            }
                        }
                    }

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data inserted successfully!");
                InsertResult = 1;
                Disconnect();
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
