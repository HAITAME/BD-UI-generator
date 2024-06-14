using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD_UI
{
    public partial class Playground : Form
    {
        private MySqlConnection connection;
        private string cnx_str;

        public Playground(MySqlConnection connection, string cnx_str)
        {
            InitializeComponent();
            this.connection = connection;
            this.cnx_str = cnx_str;
            LoadTables();
        }

        private async void LoadTables()
        {
            string query = "SHOW TABLES";
            list_tables.Items.Clear();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string tableName = reader.GetString(0);
                            list_tables.Items.Add(tableName);
                        }
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
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(cnx_str))
                {
                    string query = $"SELECT * FROM `{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    table_data.DataSource = dt;
                }
                DataTable relatedTables = GetRelatedTables(tableName);
                DisplayRelatedTables(relatedTables);
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

        private void playground_Load(object sender, EventArgs e)
        {

        }

        private void table_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private DataTable GetRelatedTables(string tableName)
        {
            DataTable schemaTable = new DataTable();
            string query = $@"
                SELECT DISTINCT
                    REFERENCED_TABLE_NAME AS 'Table liée'
                FROM
                    INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                WHERE
                    TABLE_NAME = '{tableName}'
                    AND REFERENCED_TABLE_NAME IS NOT NULL";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(schemaTable);
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

            return schemaTable;
        }
        private void DisplayRelatedTables(DataTable relatedTables)
        {
            RelatedTables.Controls.Clear();

            foreach (DataRow row in relatedTables.Rows)
            {
                string relatedTableName = row["Table liée"].ToString();

                // Créer un bouton pour afficher le nom de la table liée
                Button button = new Button();
                button.Text = relatedTableName;
                button.Click += (sender, e) =>
                {
                    // Action à effectuer lors du clic sur le bouton (par exemple, afficher les données de la table liée)
                    LoadRelatedTableData(relatedTableName);
                };

                // Ajouter le bouton au FlowLayoutPanel
                RelatedTables.Controls.Add(button);
            }
        }

        private void LoadRelatedTableData(string tableName)
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(cnx_str))
                {
                    string query = $"SELECT * FROM `{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    RelatedTableData.DataSource = dt; // Assurez-vous que dataGridViewRelatedTableData est lié uniquement à dt
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

        private void button1_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor(connection ,cnx_str);
            editor.ShowDialog();
        }
    }
}
