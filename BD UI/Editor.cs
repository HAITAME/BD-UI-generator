using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_UI
{
    public partial class Editor : Form
    {
        private MySqlConnection connection;
        private string connectionString;
        private string tableName;
        private DataRow currentRow;
        private DataTable dataTable;
        private List<string> primaryKeys;
        private int currentIndex = -1;

        public int DeleteResult { get; private set; }
        public int UpdateResult { get; private set; }

        public Editor(MySqlConnection connection, string connectionString, List<string> keys, int dataId = -1, string dataTableName = "")
        {
            InitializeComponent();
            this.connection = connection;
            this.connectionString = connectionString;
            this.primaryKeys = keys;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            this.FormClosing += new FormClosingEventHandler(Editor_Close);

            if (dataId != -1)
            {
                LoadOneRowData(dataTableName, dataId);
                comboBoxTables.Text = dataTableName;
                this.tableName = dataTableName;
            }
            else
            {
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }

            LoadTables();
        }

        private void Connect()
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

        private async void LoadTables()
        {
            comboBoxTables.Items.Clear();
            try
            {
                Connect();
                DataTable schemaTable = connection.GetSchema("Tables");
                foreach (DataRow row in schemaTable.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    comboBoxTables.Items.Add(tableName);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
            }
            finally
            {
                Disconnect();
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem != null)
            {
                tableName = comboBoxTables.SelectedItem.ToString();
                LoadData(tableName);
            }
        }

        private async Task LoadData(string tableName, int index = 0)
        {
            try
            {
                Connect();
                string query = $"SELECT * FROM `{tableName}`";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        dataTable = new DataTable();
                        await adapter.FillAsync(dataTable);
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    DisplayEmptyTableMessage(tableName);
                    return;
                }

                currentIndex = index;
                DisplayRow(currentIndex);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
            }
            finally
            {
                Disconnect();
            }
        }

        private void DisplayEmptyTableMessage(string tableName)
        {
            panelEditor.Controls.Clear();

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                RowStyles = { new RowStyle(SizeType.Percent, 50F), new RowStyle(SizeType.Percent, 50F) }
            };

            Label lblMessage = new Label
            {
                Text = $"La table '{tableName}' est vide.",
                AutoSize = true,
                Anchor = AnchorStyles.None
            };

            Button btnAjouter = new Button
            {
                Text = "Ajouter des données",
                Anchor = AnchorStyles.None,
                Size = new Size(200, 30),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            btnAjouter.Click += (sender, e) =>
            {
                Add add = new Add(connection, tableName, primaryKeys);
                add.ShowDialog();
                if (add.InsertResult == 1)
                {
                    LoadData(tableName);
                }
            };

            tableLayoutPanel.Controls.Add(lblMessage, 0, 0);
            tableLayoutPanel.Controls.Add(btnAjouter, 0, 1);

            panelEditor.Controls.Add(tableLayoutPanel);

            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
        }

        private void DisplayRow(int index)
        {
            if (dataTable != null && dataTable.Rows.Count > 0 && index >= 0 && index < dataTable.Rows.Count)
            {
                currentRow = dataTable.Rows[index];
                panelEditor.Controls.Clear();

                int yPos = 10;
                foreach (DataColumn column in dataTable.Columns)
                {
                    Label label = new Label
                    {
                        Text = $"{column.ColumnName}:",
                        AutoSize = true,
                        Location = new Point(10, yPos)
                    };

                    Control inputControl = CreateInputControl(column, yPos);
                    panelEditor.Controls.Add(label);
                    panelEditor.Controls.Add(inputControl);
                    yPos += 30;
                }
            }
        }

        private Control CreateInputControl(DataColumn column, int yPos)
        {
            Control inputControl = null;
            if (primaryKeys.Contains(column.ColumnName))
            {
                inputControl = new Label
                {
                    Text = currentRow[column].ToString(),
                    Location = new Point(150, yPos),
                    Width = 100,
                    Name = column.ColumnName
                };
            }
            else if (column.DataType == typeof(int))
            {
                inputControl = new NumericUpDown
                {
                    Value = Convert.ToInt32(currentRow[column]),
                    Location = new Point(150, yPos),
                    Width = 100,
                    Name = column.ColumnName
                };
            }
            else if (column.DataType == typeof(string))
            {
                inputControl = new TextBox
                {
                    Text = currentRow[column].ToString(),
                    Location = new Point(150, yPos),
                    Width = 200,
                    Name = column.ColumnName
                };
            }
            else if (column.DataType == typeof(DateTime))
            {
                inputControl = new DateTimePicker
                {
                    Value = Convert.ToDateTime(currentRow[column]),
                    Location = new Point(150, yPos),
                    Width = 150,
                    Name = column.ColumnName
                };
            }
            else if (column.DataType == typeof(bool))
            {
                inputControl = new CheckBox
                {
                    Checked = Convert.ToBoolean(currentRow[column]),
                    Location = new Point(150, yPos),
                    Name = column.ColumnName
                };
            }
            else
            {
                inputControl = new TextBox
                {
                    Text = currentRow[column].ToString(),
                    Location = new Point(150, yPos),
                    Width = 200,
                    Name = column.ColumnName
                };
            }

            return inputControl;
        }

        private async Task LoadOneRowData(string tableName, int id)
        {
            try
            {
                Connect();
                dataTable = new DataTable();
                string query = $"SELECT * FROM `{tableName}` WHERE id = {id}";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        await adapter.FillAsync(dataTable);
                    }
                }
                DisplayOneRow(dataTable);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
            }
            finally
            {
                Disconnect();
            }
        }

        private void DisplayOneRow(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                currentRow = dataTable.Rows[0];
                panelEditor.Controls.Clear();

                int yPos = 10;
                foreach (DataColumn column in dataTable.Columns)
                {
                    Label label = new Label
                    {
                        Text = $"{column.ColumnName}:",
                        AutoSize = true,
                        Location = new Point(10, yPos)
                    };

                    Control inputControl = CreateInputControl(column, yPos);
                    panelEditor.Controls.Add(label);
                    panelEditor.Controls.Add(inputControl);
                    yPos += 30;
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayRow(currentIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < dataTable.Rows.Count - 1)
            {
                currentIndex++;
                DisplayRow(currentIndex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement ?", "Confirmation de suppression", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Connect();
                    string query = $"DELETE FROM `{tableName}` WHERE id = {currentRow["id"]}";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        DeleteResult = await cmd.ExecuteNonQueryAsync();
                    }

                    if (DeleteResult == 1)
                    {
                        MessageBox.Show("L'enregistrement a été supprimé avec succès.", "Succès");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("La suppression a échoué.", "Erreur");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
                }
                finally
                {
                    Disconnect();
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append($"UPDATE `{tableName}` SET ");

                List<string> setClauses = new List<string>();

                foreach (Control control in panelEditor.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        string columnName = textBox.Name;
                        string value = textBox.Text;
                        setClauses.Add($"{columnName} = '{value}'");
                    }
                    else if (control is NumericUpDown numericUpDown)
                    {
                        string columnName = numericUpDown.Name;
                        string value = numericUpDown.Value.ToString();
                        setClauses.Add($"{columnName} = {value}");
                    }
                    else if (control is DateTimePicker dateTimePicker)
                    {
                        string columnName = dateTimePicker.Name;
                        string value = dateTimePicker.Value.ToString("yyyy-MM-dd");
                        setClauses.Add($"{columnName} = '{value}'");
                    }
                    else if (control is CheckBox checkBox)
                    {
                        string columnName = checkBox.Name;
                        string value = checkBox.Checked ? "1" : "0";
                        setClauses.Add($"{columnName} = {value}");
                    }
                }

                queryBuilder.Append(string.Join(", ", setClauses));
                queryBuilder.Append($" WHERE id = {currentRow["id"]}");

                string query = queryBuilder.ToString();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    UpdateResult = await cmd.ExecuteNonQueryAsync();
                }

                if (UpdateResult == 1)
                {
                    MessageBox.Show("L'enregistrement a été mis à jour avec succès.", "Succès");
                    LoadData(tableName);
                }
                else
                {
                    MessageBox.Show("La mise à jour a échoué.", "Erreur");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
            }
            finally
            {
                Disconnect();
            }
        }
        private void Editor_Load(object sender, EventArgs e)
        {
            Connect();
            //MessageBox.Show("Chargement de l'éditeur");
        }

        private void Editor_Close(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}
