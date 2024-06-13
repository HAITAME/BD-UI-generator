using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BD_UI
{
    public partial class Playground : Form
    {
        private MySqlConnection connection;
        private DataTable schemaTable;

        public Playground(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            LoadTables();
        }

        private void LoadTables()
        {
            string query = "SHOW TABLES";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            list_tables.Items.Clear();

            try
            {

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableName = reader.GetString(0);
                        list_tables.Items.Add(tableName);
                    }
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

        private void list_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_tables.SelectedItem != null)
            {
                string selectedTableName = list_tables.SelectedItem.ToString();
                LoadTableData(selectedTableName);
            }
            else
            {
                MessageBox.Show("Aucune table sélectionnée.", "Information");
            }
        }

        private void LoadTableData(string tableName)
        {
            // Valider et échapper correctement le nom de la table pour éviter l'injection SQL
            if (!Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ArgumentException("Nom de table invalide.");
            }

            try
            {
                string selectQuery = $"SELECT * FROM `{tableName}`";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectQuery, connection);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                table_data.DataSource = dataTable;
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


        /*
        private void LoadTableData(string tableName)
        {
            // Valider et échapper correctement le nom de la table pour éviter l'injection SQL
            if (!Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$"))
            {
                throw new ArgumentException("Nom de table invalide.");
            }

            // Récupérer les informations sur les colonnes de la table
            string schemaQuery = $"SHOW COLUMNS FROM `{tableName}`";
            MySqlCommand schemaCmd = new MySqlCommand(schemaQuery, connection);
            MySqlDataAdapter schemaAdapter = new MySqlDataAdapter(schemaCmd);
            DataTable schemaTable = new DataTable();

            try
            {
                // Remplir le DataTable avec les informations de colonnes
                schemaAdapter.Fill(schemaTable);

                // Configuration des colonnes du DataGridView à partir de schemaTable
                table_data.Columns.Clear();
                table_data.AutoGenerateColumns = false;

                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["Field"].ToString();
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                    {
                        Name = columnName,
                        HeaderText = columnName,
                        DataPropertyName = columnName
                    };
                    table_data.Columns.Add(column);
                }

                // Sélectionner toutes les données de la table
                DataTable schemaTable = new DataTable();

                string selectQuery = $"SELECT * FROM {tableName} ;";
                MySqlDataAdapter dataselectAdapter = new MySqlDataAdapter(selectQuery, connection);
                MySqlDataAdapter selectAdapter = new MySqlDataAdapter(dataselectAdapter);

                MessageBox.Show(selectQuery);
                using ()
                {
                    MessageBox.Show("Adapter created");
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);

                    // Configurer le DataGridView pour être en lecture seule
                    table_data.ReadOnly = true;

                    // Lier le DataSet ou sa première table au DataGridView
                    if (ds.Tables.Count > 0)
                    {
                        table_data.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Aucune donnée trouvée dans la table spécifiée.", "Information");
                    }
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
        */

        private void playground_Load(object sender, EventArgs e)
        {
            // Code à exécuter lors du chargement du formulaire
        }
    }
}
