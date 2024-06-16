﻿using System;
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
        public int DeleteResult { get; private set; }
        public int UpdateResult { get; private set; }
        public Editor(MySqlConnection connection, string connectionString, int data_id = -1, string data_tableName = "")
        {
            InitializeComponent();
            this.connection = connection;
            this.connectionString = connectionString;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            this.FormClosing += new FormClosingEventHandler(Editor_Close);
            if (data_id != -1)
            {
                LoadOneRowData(data_tableName, data_id);
                comboBoxTables.Text = data_tableName;
                this.tableName = data_tableName;
            }
            else
            {
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            LoadTables();

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

        private async void LoadTables()
        {
            comboBoxTables.Items.Clear();
            try
            {
                Connecte();
                DataTable schemaTable = connection.GetSchema("Tables");
                foreach (DataRow row in schemaTable.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    comboBoxTables.Items.Add(tableName);
                }
                connection.Close();
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
                btnPrevious.Visible = true;
                btnNext.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = true;
            }
        }

        private async Task LoadData(string tableName, int index = 0)
        {
            try
            {
                Connecte();
                string query = $"SELECT * FROM `{tableName}`";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    // Nettoyer le panelEditor s'il contient des contrôles
                    panelEditor.Controls.Clear();

                    // Créer un TableLayoutPanel pour organiser les contrôles
                    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                    tableLayoutPanel.Dock = DockStyle.Fill;
                    tableLayoutPanel.RowCount = 2;
                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

                    Label lblMessage = new Label();
                    lblMessage.Text = $"La table '{tableName}' est vide.";
                    lblMessage.AutoSize = true;
                    lblMessage.Anchor = AnchorStyles.None; 
                    tableLayoutPanel.Controls.Add(lblMessage, 0, 0);

                    Button btnAjouter = new Button();
                    btnAjouter.Text = "Ajouter des données";
                    btnAjouter.Anchor = AnchorStyles.None;
                    btnAjouter.Size = new Size(200, 30); 
                    btnAjouter.Font = new Font("Arial", 9, FontStyle.Bold);
                    btnAjouter.Click += (sender, e) =>
                    {
                        MessageBox.Show(tableName);
                        Add add = new Add(connection, tableName);
                        add.ShowDialog();
                        int r = add.InsertResult;
                        if (r == 1)
                        {
                            LoadData(tableName);

                           
                        }
                    };
                    tableLayoutPanel.Controls.Add(btnAjouter, 0, 1);

                    panelEditor.Controls.Add(tableLayoutPanel);

                    return;
                }
                currentIndex = index;
                DisplayRow(currentIndex);
                connection.Close();
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

        private async Task LoadOneRowData(string tableName, int id)
        {
            try
            {
                Connecte();
                if (dataTable != null)
                {
                    dataTable.Clear();
                }

                string query = $"SELECT * FROM `{tableName}` WHERE id = {id}";
                dataTable = new DataTable();
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
                        dateTimePicker.Name = column.ColumnName;
                        inputControl = dateTimePicker;
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
            if (currentRow != null)
            {
                int idToDelete = Convert.ToInt32(currentRow["id"]);
                try
                {
                    Connecte();

                    string deleteQuery = $"DELETE FROM `{tableName}` WHERE id = @idToDelete";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@idToDelete", idToDelete);
                    await deleteCmd.ExecuteNonQueryAsync(); // Await the async operation

                    MessageBox.Show("L'enregistrement a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeleteResult = 1;
                    currentIndex--;
                    LoadData(tableName, currentIndex);
                    connection.Close();


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
                finally
                {
                    Disconnect();
                }
            }
        }

        private async Task SaveChanges()
        {
            if (currentRow != null)
            {
                try
                {

                    Connecte();

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
                finally
                {
                    Disconnect();
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
        private void Editor_Close(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Fermeture de l'éditeur");
            dataTable.Clear();
            Disconnect();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Connecte();
            //MessageBox.Show("Chargement de l'éditeur");
        }
    }
}
