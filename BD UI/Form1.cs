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
    public partial class Editor : Form
    {
        private MySqlConnection connection;
        private string connectionString;
        private string tableName;
        private DataRow currentRow;
        private DataTable dataTable;
        private int currentIndex = -1;
        private System.Windows.Forms.Label lblIndex;
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

        private async Task LoadData(string tableName)
        {
            try
            {
                string query = $"SELECT * FROM `{tableName}`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Afficher la première ligne dans le panel
                currentIndex = 0;
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
            // Affichage de l'index actuel
            // lblIndex.Text = $"Index: {currentIndex}";

            if (dataTable != null && dataTable.Rows.Count > 0 && index >= 0 && index < dataTable.Rows.Count)
            {
                currentRow = dataTable.Rows[index];
                panelEditor.Controls.Clear();

                // Afficher chaque colonne dans le panel avec des contrôles de saisie pour l'édition
                int yPos = 10;
                foreach (DataColumn column in dataTable.Columns)
                {
                    Label label = new Label();
                    label.Text = $"{column.ColumnName}:";
                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(10, yPos);
                    panelEditor.Controls.Add(label);

                    // Ajouter un contrôle de saisie correspondant au type de données
                    Control inputControl = null;

                    if (column.DataType == typeof(int))
                    {
                        NumericUpDown numericUpDown = new NumericUpDown();
                        numericUpDown.Value = Convert.ToInt32(currentRow[column]);
                        numericUpDown.Location = new System.Drawing.Point(150, yPos);
                        numericUpDown.Width = 100;
                        inputControl = numericUpDown;
                    }
                    else if (column.DataType == typeof(string))
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = currentRow[column].ToString();
                        textBox.Location = new System.Drawing.Point(150, yPos);
                        textBox.Width = 200;
                        inputControl = textBox;
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        DateTimePicker dateTimePicker = new DateTimePicker();
                        dateTimePicker.Value = Convert.ToDateTime(currentRow[column]);
                        dateTimePicker.Location = new System.Drawing.Point(150, yPos);
                        dateTimePicker.Width = 150;
                        inputControl = dateTimePicker;
                    }
                    else if (column.DataType == typeof(bool))
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Checked = Convert.ToBoolean(currentRow[column]);
                        checkBox.Location = new System.Drawing.Point(150, yPos);
                        inputControl = checkBox;
                    }
                    else
                    {
                        // Gérer d'autres types de données selon vos besoins
                        TextBox textBox = new TextBox();
                        textBox.Text = currentRow[column].ToString();
                        textBox.Location = new System.Drawing.Point(150, yPos);
                        textBox.Width = 200;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentRow != null)
            {
                // Récupérer l'ID ou toute clé primaire nécessaire pour la suppression
                int idToDelete = Convert.ToInt32(currentRow["ID"]); // Exemple d'ID primaire

                // Exécuter la requête de suppression
                try
                {
                    string deleteQuery = $"DELETE FROM `{tableName}` WHERE ID = @idToDelete";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@idToDelete", idToDelete);
                    deleteCmd.ExecuteNonQueryAsync();
                    currentIndex--;
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
        }

        private async Task SaveChanges()
        {
            if (currentRow != null)
            {
                try
                {
                    // Construction de la requête UPDATE dynamique
                    StringBuilder updateQuery = new StringBuilder($"UPDATE `{tableName}` SET ");
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    int ID;
                    // Itérer sur les colonnes de la table
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Exclure la clé primaire (si connue) ou d'autres colonnes spécifiques si nécessaire
                        if (column.ColumnName != "id") // Exemple d'exclusion de la colonne ID
                        {
                            updateQuery.Append($"`{column.ColumnName}` = @{column.ColumnName}, ");

                            // Vérifier si le paramètre existe déjà dans la collection
                            if (!parameters.Any(p => p.ParameterName == $"@{column.ColumnName}"))
                            {
                                parameters.Add(new MySqlParameter($"@{column.ColumnName}", currentRow[column]));
                            }
                            else
                            {
                                // Remplacer le paramètre existant
                                parameters.First(p => p.ParameterName == $"@{column.ColumnName}").Value = currentRow[column];
                            }
                        }

                    }
                    updateQuery.Remove(updateQuery.Length - 2, 2);
                    updateQuery.Append($" WHERE id = @ID"); 

                    if (!parameters.Any(p => p.ParameterName == "@ID"))
                    {
                        parameters.Add(new MySqlParameter("@ID", currentRow["id"])); 
                    }
                    else
                    {
                        parameters.First(p => p.ParameterName == "@ID").Value = currentRow["id"];
                    }

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery.ToString(), connection))
                    {
                        updateCmd.Parameters.AddRange(parameters.ToArray());
                        await updateCmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show("Les modifications ont été enregistrées avec succès.", "Sauvegarde réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erreur MySQL : {ex.Message}", "Erreur MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée pour la sauvegarde.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges(); 
        }
    }

}
