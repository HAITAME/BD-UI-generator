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
        private int currentIndex = -1;
        private System.Windows.Forms.Label lblIndex;
        public int DeleteResult { get; private set; }
        public int UpdateResult { get; private set; }

        public Editor(MySqlConnection connection, string connectionString)
        {
            InitializeComponent();
            this.connection = connection;
            this.connectionString = connectionString;
            LoadTables();
        }

        private async void LoadTables()
        {
            comboBoxTables.Items.Clear();
            try
            {
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
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem != null)
            {
                tableName = comboBoxTables.SelectedItem.ToString();
                LoadData(tableName);
            }
        }

        private async Task LoadData(string tableName , int index =0)
        {
            try
            {
                string query = $"SELECT * FROM `{tableName}`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                dataTable = new DataTable();
                await Task.Run(() => adapter.Fill(dataTable)); // Use Task.Run to avoid blocking the UI thread
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
                    Label label = new Label();
                    label.Text = $"{column.ColumnName}:";
                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(10, yPos);
                    panelEditor.Controls.Add(label);

                    Control inputControl = null;
                    if (column.ColumnName.ToLower() == "id")
                    {
                        Label idLabel = new Label();
                        idLabel.Text = currentRow[column].ToString();
                        idLabel.Location = new System.Drawing.Point(150, yPos);
                        idLabel.Width = 100;
                        idLabel.Name = column.ColumnName;
                        inputControl = idLabel;
                    }
                    else if (column.DataType == typeof(int))
                    {
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Value = Convert.ToInt32(currentRow[column]);
                        numericUpDown.Location = new System.Drawing.Point(150, yPos);
                        numericUpDown.Width = 100;
                        numericUpDown.Name = column.ColumnName;
                        inputControl = numericUpDown;
                    }
                    else if (column.DataType == typeof(string))
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = currentRow[column].ToString();
                        textBox.Location = new System.Drawing.Point(150, yPos);
                        textBox.Width = 200;
                        textBox.Name = column.ColumnName;
                        inputControl = textBox;
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTimePicker dateTimePicker = new DateTimePicker();
                        dateTimePicker.Value = Convert.ToDateTime(currentRow[column]);
                        dateTimePicker.Location = new System.Drawing.Point(150, yPos);
                        dateTimePicker.Width = 150;
                        inputControl = dateTimePicker;
                        inputControl.Name = column.ColumnName;
                    }
                    else if (column.DataType == typeof(bool))
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Checked = Convert.ToBoolean(currentRow[column]);
                        checkBox.Location = new System.Drawing.Point(150, yPos);
                        checkBox.Name = column.ColumnName;
                        inputControl = checkBox;
                    }
                    else
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = currentRow[column].ToString();
                        textBox.Location = new System.Drawing.Point(150, yPos);
                        textBox.Width = 200;
                        textBox.Name = column.ColumnName;
                        inputControl = textBox;
                    }

                    panelEditor.Controls.Add(inputControl);
                    yPos += 30;
                }
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
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
            if (currentRow != null)
            {
                int idToDelete = Convert.ToInt32(currentRow["id"]);
                try
                {
                    string deleteQuery = $"DELETE FROM `{tableName}` WHERE id = @idToDelete";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@idToDelete", idToDelete);
                    await deleteCmd.ExecuteNonQueryAsync(); // Await the async operation

                    MessageBox.Show("L'enregistrement a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeleteResult = 1;
                    currentIndex--;
                    LoadData(tableName, currentIndex);
                    

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL");
                    DeleteResult = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur");
                    DeleteResult = 0;
                }
            }
        }

        private async Task SaveChanges()
        {
            if (currentRow != null)
            {
                try
                {
                    foreach (Control control in panelEditor.Controls)
                    {
                        string columnName = control.Name;
                        if (control is TextBox textBox)
                        {
                            currentRow[columnName] = textBox.Text;
                        }
                        else if (control is NumericUpDown numericUpDown)
                        {
                            currentRow[columnName] = (int)numericUpDown.Value;
                        }
                        else if (control is DateTimePicker dateTimePicker)
                        {
                            currentRow[columnName] = dateTimePicker.Value;
                        }
                        else if (control is CheckBox checkBox)
                        {
                            currentRow[columnName] = checkBox.Checked;
                        }
                    }

                    StringBuilder updateQuery = new StringBuilder($"UPDATE `{tableName}` SET ");
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (column.ColumnName.ToLower() != "id")
                        {
                            updateQuery.Append($"`{column.ColumnName}` = @{column.ColumnName}, ");
                            MySqlParameter existingParameter = parameters.FirstOrDefault(p => p.ParameterName == $"@{column.ColumnName}");
                            if (existingParameter != null)
                            {
                                existingParameter.Value = currentRow[column];
                            }
                            else
                            {
                                parameters.Add(new MySqlParameter($"@{column.ColumnName}", currentRow[column]));
                            }
                        }
                    }

                    if (updateQuery.Length > 0)
                    {
                        updateQuery.Remove(updateQuery.Length - 2, 2);
                    }

                    updateQuery.Append($" WHERE `id` = @ID");
                    parameters.Add(new MySqlParameter("@ID", currentRow["id"]));

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery.ToString(), connection))
                    {
                        updateCmd.Parameters.AddRange(parameters.ToArray());
                        await updateCmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Les modifications ont été enregistrées avec succès.", "Sauvegarde réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateResult = 1;
                    DisplayRow(currentIndex); // Update display without reloading entire table
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateResult = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateResult = 0;
                }
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée pour la sauvegarde.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveChanges();
        }
    }
}
