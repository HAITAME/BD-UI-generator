using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BD_UI
{
    public partial class EtatDB : Form
    {
        private string connectionString;
        private MySqlConnection connection;

        public EtatDB(MySqlConnection connection, string cnx_str)
        {
            InitializeComponent();
            connectionString = cnx_str;
            this.connection = connection;
            SetupListView(); // Appeler la méthode pour configurer les colonnes du ListView
            ShowInfo();
        }

        private void SetupListView()
        {
            listView1.View = View.Details; // Définir le mode de vue détaillée
            listView1.Columns.Add("Variable", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Value", 100, HorizontalAlignment.Left);
        }

        private void ShowInfo()
        {
            try
            {
                listView1.Items.Clear(); // Efface les éléments existants dans le ListView

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Ajouter les noms des variables de statut que vous souhaitez récupérer
                    string[] variableNames =
                    {
                        "Bytes_received",
                        "Bytes_sent",
                        "Threads_connected",
                        "Threads_running",
                        "Uptime",
                        "Questions",        // Total number of queries
                        "Slow_queries",     // Total number of slow queries
                        "Connections",      // Number of connection attempts
                        "Aborted_clients",  // Number of aborted connections
                        "Aborted_connects"  // Failed connection attempts
                    };

                    foreach (string variableName in variableNames)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = $"SHOW GLOBAL STATUS LIKE '{variableName}'";

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    long variableValue = Convert.ToInt64(reader["Value"]);
                                    ListViewItem item = new ListViewItem(variableName);
                                    item.SubItems.Add(variableValue.ToString());
                                    listView1.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving MySQL system variables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
