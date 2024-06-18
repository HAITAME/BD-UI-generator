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
    public partial class CreateTableForm : Form
    {
        private MySqlConnection connection;


        public CreateTableForm(MySqlConnection cnx)
        {
            InitializeComponent();
            connection = cnx;
            ;

            panelColonnes.FlowDirection = FlowDirection.TopDown;
            panelColonnes.AutoSize = true;
            panelColonnes.WrapContents = false;
            panelColonnes.Dock = DockStyle.Fill;
            panelColonnes.WrapContents = false;
            panelColonnes.AutoScroll = true;


        }
        private void Connect()
        {
            if (connection.State != ConnectionState.Open)
            {
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

        

        private void AddColumn_Click(object sender, EventArgs e)
        {
            AjouterChamp();
        }

        private void AjouterChamp()
        {
            TextBox nomChampTextBox = new TextBox();
            ComboBox typeChampComboBox = new ComboBox();
            typeChampComboBox.Items.AddRange(new string[] { "INT", "VARCHAR", "DATE", "FLOAT" });

            TextBox tailleChampTextBox = new TextBox();
            tailleChampTextBox.Visible = false;
            tailleChampTextBox.Width = 50;

            CheckBox allowNullCheckBox = new CheckBox();
            allowNullCheckBox.Text = "NULL autorisé";
            allowNullCheckBox.Visible = false;

            CheckBox zeroFillCheckBox = new CheckBox();
            zeroFillCheckBox.Text = "ZEROFILL";
            zeroFillCheckBox.Visible = false;

            CheckBox unsignedCheckBox = new CheckBox();
            unsignedCheckBox.Text = "UNSIGNED";
            unsignedCheckBox.Visible = false;

            CheckBox primaryKeyCheckBox = new CheckBox();
            primaryKeyCheckBox.Text = "PRIMARY KEY";
            primaryKeyCheckBox.Visible = false;

            CheckBox uniqueCheckBox = new CheckBox();
            uniqueCheckBox.Text = "UNIQUE";
            uniqueCheckBox.Visible = false;

            CheckBox fulltextCheckBox = new CheckBox();
            fulltextCheckBox.Text = "FULLTEXT";
            fulltextCheckBox.Visible = false;

            CheckBox spatialCheckBox = new CheckBox();
            spatialCheckBox.Text = "SPATIAL";
            spatialCheckBox.Visible = false;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Controls.Add(nomChampTextBox);
            flowPanel.Controls.Add(typeChampComboBox);
            flowPanel.Controls.Add(tailleChampTextBox);
            flowPanel.Controls.Add(allowNullCheckBox);
            flowPanel.Controls.Add(zeroFillCheckBox);
            flowPanel.Controls.Add(unsignedCheckBox);
            flowPanel.Controls.Add(primaryKeyCheckBox);
            flowPanel.Controls.Add(uniqueCheckBox);
            flowPanel.Controls.Add(fulltextCheckBox);
            flowPanel.Controls.Add(spatialCheckBox);

            typeChampComboBox.SelectedIndexChanged += (sender, e) =>
            {
                string selectedType = typeChampComboBox.SelectedItem?.ToString();
                tailleChampTextBox.Visible = selectedType == "VARCHAR";
                allowNullCheckBox.Visible = selectedType == "INT" || selectedType == "VARCHAR" || selectedType == "DATE" || selectedType == "FLOAT";
                zeroFillCheckBox.Visible = selectedType == "INT" || selectedType == "FLOAT";
                unsignedCheckBox.Visible = selectedType == "INT" || selectedType == "FLOAT";
                primaryKeyCheckBox.Visible = true;
                uniqueCheckBox.Visible = true;
                fulltextCheckBox.Visible = selectedType == "VARCHAR";
                spatialCheckBox.Visible = selectedType == "GEOMETRY"; 
            };

            this.panelColonnes.Controls.Add(flowPanel);
        }

        private void CreateTab_Click(object sender, EventArgs e)
        {
            string nomTable = NomTable.Text.Trim();

            if (string.IsNullOrEmpty(nomTable))
            {
                MessageBox.Show("Veuillez entrer un nom de table.");
                return;
            }

            // Vérifier s'il y a au moins une colonne ajoutée
            if (panelColonnes.Controls.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins une colonne à la table.");
                return;
            }

            string queryCreationTable = $"CREATE TABLE `{nomTable}` (";

            foreach (FlowLayoutPanel panel in panelColonnes.Controls)
            {
                TextBox nomChampTextBox = panel.Controls[0] as TextBox;
                ComboBox typeChampComboBox = panel.Controls[1] as ComboBox;
                TextBox tailleChampTextBox = panel.Controls.Count > 2 ? panel.Controls[2] as TextBox : null;
                CheckBox allowNullCheckBox = panel.Controls.Count > 3 ? panel.Controls[3] as CheckBox : null;
                CheckBox zeroFillCheckBox = panel.Controls.Count > 4 ? panel.Controls[4] as CheckBox : null;
                CheckBox unsignedCheckBox = panel.Controls.Count > 5 ? panel.Controls[5] as CheckBox : null;
                CheckBox primaryKeyCheckBox = panel.Controls.Count > 6 ? panel.Controls[6] as CheckBox : null;
                CheckBox uniqueCheckBox = panel.Controls.Count > 7 ? panel.Controls[7] as CheckBox : null;
                CheckBox fulltextCheckBox = panel.Controls.Count > 8 ? panel.Controls[8] as CheckBox : null;
                CheckBox spatialCheckBox = panel.Controls.Count > 9 ? panel.Controls[9] as CheckBox : null;

                string nomChamp = nomChampTextBox.Text.Trim();
                string typeChamp = typeChampComboBox.SelectedItem?.ToString();
                bool allowNull = allowNullCheckBox != null && allowNullCheckBox.Checked;
                bool zerofill = zeroFillCheckBox != null && zeroFillCheckBox.Checked;
                bool unsigned = unsignedCheckBox != null && unsignedCheckBox.Checked;
                bool primaryKey = primaryKeyCheckBox != null && primaryKeyCheckBox.Checked;
                bool unique = uniqueCheckBox != null && uniqueCheckBox.Checked;
                bool fulltext = fulltextCheckBox != null && fulltextCheckBox.Checked;
                bool spatial = spatialCheckBox != null && spatialCheckBox.Checked;

                if (string.IsNullOrEmpty(nomChamp) || string.IsNullOrEmpty(typeChamp))
                {
                    MessageBox.Show("Veuillez entrer des noms et types de colonnes valides.");
                    return;
                }

                string columnDefinition = $"`{nomChamp}` {typeChamp}";

                if (typeChamp == "VARCHAR" && tailleChampTextBox != null && !string.IsNullOrEmpty(tailleChampTextBox.Text.Trim()))
                {
                    columnDefinition += $"({tailleChampTextBox.Text.Trim()})";
                }

                if (typeChamp == "INT" || typeChamp == "FLOAT")
                {
                    if (zerofill)
                    {
                        columnDefinition += " ZEROFILL";
                    }

                    if (unsigned)
                    {
                        columnDefinition += " UNSIGNED";
                    }
                }

                if (primaryKey)
                {
                    columnDefinition += " PRIMARY KEY";
                }

                if (unique)
                {
                    columnDefinition += " UNIQUE";
                }

                if (fulltext)
                {
                    columnDefinition += " FULLTEXT";
                }

                if (spatial)
                {
                    columnDefinition += " SPATIAL";
                }

                if (!allowNull)
                {
                    columnDefinition += " NOT NULL";
                }

                queryCreationTable += $"{columnDefinition},";
            }

            queryCreationTable = queryCreationTable.TrimEnd(',') + ");";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(queryCreationTable, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Table créée avec succès.");
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
            finally
            {
                connection.Close();
            }
        }

    }
}
