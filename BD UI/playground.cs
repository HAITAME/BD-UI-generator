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
        string selectedTableName;
        string RelatedTable_Name;
        public Playground(MySqlConnection connection, string cnx_str)
        {
            InitializeComponent();
            this.connection = connection;
            this.cnx_str = cnx_str;
            this.add.Enabled = false;
            this.add.Visible = false;
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
            Connecte();
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
            finally
            {
                Disconnect();
            }
        }
        private void list_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_tables.SelectedItem != null)
            {
                //ClearRelatedTableData();
                selectedTableName = list_tables.SelectedItem.ToString();
                LoadTableData(selectedTableName);
                LoadTableSchema(selectedTableName);
                this.add.Enabled = true;
                this.add.Visible = true;

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
                Connecte();
                using (MySqlConnection cnx = new MySqlConnection(cnx_str))
                {
                    string query = $"SELECT * FROM `{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    table_data.DataSource = dt;
                }
                DataTable relatedTables = GetRelatedTables(tableName);
                if (relatedTables.Rows.Count > 0)
                {
                    DisplayRelatedTables(relatedTables);
                    if (!MainTab.TabPages.Contains(Relation))
                    {
                        MainTab.TabPages.Add(Relation);
                    }
                }
                else
                {   
                    MainTab.SelectedTab = Parcourir;
                    MainTab.TabPages.Remove(Relation);
                    ClearRelatedTableData();
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
                Connecte();
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
            finally
            {
                Disconnect();
            }

            return schemaTable;
        }
        private void DisplayRelatedTables(DataTable relatedTables)
        {
            RelatedTables.Controls.Clear();

            foreach (DataRow row in relatedTables.Rows)
            {
                string relatedTableName = row["Table liée"].ToString();

                Button button = new Button();
                button.Text = relatedTableName;
                RelatedTable_Name = relatedTableName;
                button.Click += (sender, e) =>
                {
                    LoadRelatedTableData(relatedTableName);
                };

                RelatedTables.Controls.Add(button);
            }
        }
        private void LoadRelatedTableData(string tableName)
        {
            try
            {
                Connecte();
                using (MySqlConnection cnx = new MySqlConnection(cnx_str))
                {
                    string query = $"SELECT * FROM `{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    RelatedTableData.DataSource = dt;
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
        private void button1_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor(connection, cnx_str);
            editor.ShowDialog();
            if (editor.UpdateResult == 1 || editor.DeleteResult == 1)
            {
                Disconnect();
                LoadTableData(selectedTableName);
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            Add add = new Add(connection, selectedTableName);
            add.ShowDialog();
            int r = add.InsertResult;
            if (r == 1)
            {
                LoadTableData(selectedTableName);
            }
        }
        private void LoadTableSchema(string tableName)
        {
            try
            {
                Connecte();
                using (MySqlConnection cnx = new MySqlConnection(cnx_str))
                {
                    string query = $"DESCRIBE`{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ViewStructure.DataSource = dt;
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
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void RelatedTables_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RelatedTables_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void table_data_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //var i = table_data.Rows[e.RowIndex].Selected = true;
            try
            {
                Connecte();
                DataGridViewRow row = table_data.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                //MessageBox.Show(id.ToString());
                Editor editor = new Editor(connection, cnx_str, id, selectedTableName);
                editor.ShowDialog();
                //MessageBox.Show(id.ToString());
                if (editor.UpdateResult == 1 || editor.DeleteResult == 1)
                {
                    LoadTableData(selectedTableName);
                }
            }
            catch
            {
                MessageBox.Show("Selectionner une ligne valide");
            }
            finally
            {
                Disconnect();
            }



        }
        private void RelatedTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Connecte();
                DataGridViewRow row = RelatedTableData.Rows[e.RowIndex];
                int id =Convert.ToInt32(row.Cells["id"].Value);
                Editor editor = new Editor(connection, cnx_str ,id , RelatedTable_Name);
                editor.ShowDialog();
                if (editor.UpdateResult == 1 || editor.DeleteResult == 1)
                {
                    LoadTableData(RelatedTable_Name);
                }
            }catch
            {
                MessageBox.Show("Selectionner une ligne valide");
            }
            finally {
                Disconnect();
            }
        }        
        private void ClearRelatedTableData()
        {
            RelatedTables.Controls.Clear();
            RelatedTableData.DataSource = null;
        }
        
    }
}
