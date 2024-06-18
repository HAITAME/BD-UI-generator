using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;




namespace BD_UI
{
    public partial class Playground : Form
    {
        private MySqlConnection connection;
        private string cnx_str;
        private string cnx_str2;
        string selectedTableName;
        string RelatedTable_Name;
        string database;

        public Playground(MySqlConnection connection, string cnx_str, string cnx_str2, string db)
        {
            InitializeComponent();
            this.connection = connection;
            this.cnx_str = cnx_str;
            this.database = db;
            this.add.Enabled = false;
            this.add.Visible = false;
            this.supprimerLaTable.Enabled = false;
            this.supprimerLaTable.Visible = false;
            MainTab.TabPages.Remove(Relation);
            MainTab.TabPages.Remove(Parcourir);
            MainTab.TabPages.Remove(Structure);


            LoadTables();
            this.cnx_str2 = cnx_str2;
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
                ClearRelatedTableData();

                selectedTableName = list_tables.SelectedItem.ToString();

                LoadTableData(selectedTableName);
                if (!MainTab.TabPages.Contains(Parcourir))
                {
                    MainTab.TabPages.Add(Parcourir);
                }
                LoadTableSchema(selectedTableName);
                if (!MainTab.TabPages.Contains(Structure))
                {
                    MainTab.TabPages.Add(Structure);
                }
                
                supprimerLaTable.Enabled = true;
                supprimerLaTable.Visible = true;

                LoadRelatedTable(selectedTableName);
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
                    if (!MainTab.TabPages.Contains(Parcourir))
                    {
                        MainTab.TabPages.Add(Parcourir);
                    }
                    if (!MainTab.TabPages.Contains(Structure))
                    {
                        MainTab.TabPages.Add(Structure);
                    }
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
        private void LoadRelatedTable(string tableName)
        {
            try
            {
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
                button.Width = 100;
                button.Height = 30;
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
            //List<string> primaryKeys = GetPrimaryKeys(connection, database, selectedTableName);

            Editor editor = new Editor(connection, cnx_str, database);
            editor.ShowDialog();
            if (editor.UpdateResult == 1 || editor.DeleteResult == 1)
            {
                Disconnect();
                LoadTableData(selectedTableName);
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            List<string> primaryKeys = GetPrimaryKeys(connection, database, selectedTableName);
            Add add = new Add(connection, selectedTableName, primaryKeys);
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
                //List<string> primaryKeys = GetPrimaryKeys(connection, database, selectedTableName);
                Editor editor = new Editor(connection, cnx_str, database, id, selectedTableName);
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
                int id = Convert.ToInt32(row.Cells["id"].Value);
                //List<string> primaryKeys = GetPrimaryKeys(connection, database, RelatedTable_Name);
                Editor editor = new Editor(connection, cnx_str, database, id, RelatedTable_Name);
                editor.ShowDialog();
                if (editor.UpdateResult == 1 || editor.DeleteResult == 1)
                {
                    LoadTableData(RelatedTable_Name);
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
        private void ClearRelatedTableData()
        {
            RelatedTables.Controls.Clear();
            RelatedTableData.DataSource = null;
        }
        private void ClearTabPages()
        {
            selectedTableName = null;
            RelatedTable_Name = null;
            table_data.DataSource = null;
            RelatedTableData.DataSource = null;
            ViewStructure.DataSource = null;
            supprimerLaTable.Enabled = false;
            supprimerLaTable.Visible = false;

            ClearRelatedTableData();
        }

        private void RafraichirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Rafraîchir");
            //HideTabPages()
            this.Refresh();
            ClearTabPages();

            LoadTables();

        }

        private async void changerDeBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Connecte();
                changerDeBaseDeDonnéesToolStripMenuItem.DropDownItems.Clear();
                string query = "SHOW DATABASES";

                //List<string> databaseNames = new List<string>();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            string dbName = reader.GetString(0);
                            //databaseNames.Add(dbName);
                            ToolStripMenuItem dbItem = new ToolStripMenuItem(dbName);
                            dbItem.Click += DbItem_Click;
                            changerDeBaseDeDonnéesToolStripMenuItem.DropDownItems.Add(dbItem);
                        }
                    }
                }




                /*
                if (databaseNames.Count > 0)
                {
                    //string databaseList = string.Join(Environment.NewLine, databaseNames);
                    //MessageBox.Show($"Bases de données disponibles :{Environment.NewLine}{databaseList}", "Bases de données");
                    foreach (string dbName in databaseNames)
                    {
                        ToolStripMenuItem dbItem = new ToolStripMenuItem(dbName);
                        changerDeBaseDeDonnéesToolStripMenuItem.DropDownItems.Add(dbItem);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune base de données disponible.", "Information");
                }
                */
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
        private void DbItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                string dbName = item.Text;
                string newConnectionString = cnx_str2 + $"Database={dbName};";
                cnx_str = newConnectionString;
                connection = new MySqlConnection(cnx_str);
                ClearTabPages();
                //this.Refresh();
                this.database = dbName;
                LoadTables();
            }
            else
            {
                MessageBox.Show("Erreur : Impossible de changer de base de données.", "Erreur");
            }
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel(table_data);
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                sfd.FileName = $"{selectedTableName}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(sfd.FileName)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                        }

                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        package.Save();
                    }

                    MessageBox.Show("Données exportées avec succès.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'exportation vers Excel : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV(table_data);
        }

        private void ExportToCSV(DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter.", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichiers CSV (*.csv)|*.csv";
            sfd.FileName = $"{selectedTableName}.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            sw.Write(dataGridView.Columns[i].HeaderText);
                            if (i < dataGridView.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    sw.Write(row.Cells[i].Value.ToString());
                                }
                                if (i < dataGridView.Columns.Count - 1)
                                {
                                    sw.Write(",");
                                }
                            }
                            sw.WriteLine();
                        }

                        MessageBox.Show("Les données ont été exportées avec succès.", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'exportation vers CSV : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void etatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EtatDB etat = new EtatDB(connection, cnx_str);
            etat.ShowDialog();

        }

        private void deconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();

        }

        private List<string> GetPrimaryKeys(MySqlConnection connection, string database, string table)
        {
            var primaryKeys = new List<string>();

            string query = $@"
                SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                WHERE TABLE_SCHEMA = '{database}'
                  AND TABLE_NAME = '{table}'
                  AND CONSTRAINT_NAME = 'PRIMARY'";
            Connecte();
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        primaryKeys.Add(reader["COLUMN_NAME"].ToString());
                    }
                }
            }
            Disconnect();

            return primaryKeys;
        }

        private void créerUneNouvelleTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTableForm createTableForm = new CreateTableForm(connection);
            createTableForm.ShowDialog();
            LoadTables();

        }

        private void DeleteTable(string tableName)
        {
            try
            {
                Connecte();

                string query = $"DROP TABLE IF EXISTS `{tableName}`";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"La table '{tableName}' a été supprimée avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void supprimerLaTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTableName != null)
            {
                string tableNameToDelete = selectedTableName;

                DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer la table '{tableNameToDelete}' ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteTable(tableNameToDelete);
                }
                ClearTabPages();

                LoadTables();
            }
            else
            {
                MessageBox.Show("Aucune table sélectionnée.", "Information");
            }

        }
    }
}

