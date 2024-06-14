using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD_UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Console.WriteLine("Login start");
        }

        private async void logbutton_Click(object sender, EventArgs e)
        {
            string username = input_username.Text;
            string password = input_password.Text;
            string host = input_host.Text;
            string databaseName = input_database.Text;
            Console.WriteLine("click");

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(databaseName))
            {
                string connectionString = $"Server={host};Database={databaseName};Uid={username};Pwd={password};SslMode=none;";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        /*
                        string query = "SHOW TABLES";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                            {
                                comboBoxTables.Items.Clear();  // Clear existing items

                                while (await reader.ReadAsync())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        string tableName = reader.GetString(0);
                                        comboBoxTables.Items.Add(tableName);
                                    }
                                }
                            }
                        }
                        */
                        
                        // Optionnel : Masquer le formulaire de connexion et afficher le formulaire principal
                        this.Hide();
                        Playground mainForm = new Playground(connection ,connectionString);
                        mainForm.ShowDialog();
                        this.Close();
                        
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erreur MySQL : {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir un nom d'utilisateur, un mot de passe, un hôte et un nom de base de données valides.");
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void login_Load(object sender, EventArgs e) { }

        private void input_password_TextChanged(object sender, EventArgs e) { }
    }
}
