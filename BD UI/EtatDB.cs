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
            SetupListView();
            SetupListViewProcessus();
            SetupListViewQueryStat();
            ShowInfo();
            ShowProcesses();
            ShowQueryStats();
        }

        private void SetupListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Variable", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Value", 100, HorizontalAlignment.Left);
        }

        private void ShowInfo()
        {
            try
            {
                listView1.Items.Clear(); 
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string[] variableNames =
                    {
                        "Bytes_received",
                        "Bytes_sent",
                        "Threads_connected",
                        "Threads_running",
                        "Uptime",
                        "Questions",        
                        "Slow_queries",     
                        "Connections",      
                        "Aborted_clients",  
                        "Aborted_connects"  
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

        private void SetupListViewProcessus()
        {
            listViewProcessus.View = View.Details; 
            listViewProcessus.Columns.Add("Id", 50, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("User", 100, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("Host", 150, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("DB", 100, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("Command", 100, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("Time", 50, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("State", 100, HorizontalAlignment.Left);
            listViewProcessus.Columns.Add("Info", 300, HorizontalAlignment.Left);
        }

        private void SetupListViewQueryStat()
        {
            listViewQueryStat.View = View.Details; 
            listViewQueryStat.Columns.Add("Statistic", 200, HorizontalAlignment.Left);
            listViewQueryStat.Columns.Add("Value", 100, HorizontalAlignment.Left);
        }

        private void ShowProcesses()
        {
            try
            {
                listViewProcessus.Items.Clear();

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SHOW PROCESSLIST";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["Id"].ToString());
                                item.SubItems.Add(reader["User"].ToString());
                                item.SubItems.Add(reader["Host"].ToString());
                                item.SubItems.Add(reader["db"].ToString());
                                item.SubItems.Add(reader["Command"].ToString());
                                item.SubItems.Add(reader["Time"].ToString());
                                item.SubItems.Add(reader["State"].ToString());
                                item.SubItems.Add(reader["Info"].ToString());
                                listViewProcessus.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving MySQL processes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowQueryStats()
        {
            try
            {
                listViewQueryStat.Items.Clear();

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string[] statNames =
                    {
                        "Questions",
                        "Com_select",
                        "Com_insert",
                        "Com_update",
                        "Com_delete"
                    };

                    foreach (string statName in statNames)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = $"SHOW GLOBAL STATUS LIKE '{statName}'";

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string statValue = reader["Value"].ToString();
                                    ListViewItem item = new ListViewItem(statName);
                                    item.SubItems.Add(statValue);
                                    item.UseItemStyleForSubItems = false;
                                    //item.Font = new Font(item.Font, FontStyle.Bold); 
                                    listViewQueryStat.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving MySQL query statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
