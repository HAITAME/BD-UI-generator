using System.Windows.Forms;

namespace BD_UI
{
    partial class Playground
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            list_tables = new ListBox();
            RelatedTableData = new DataGridView();
            RelatedTables = new FlowLayoutPanel();
            Menu = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            add = new Button();
            buttonEdit = new Button();
            label2 = new Label();
            panel5 = new Panel();
            tabControl2 = new TabControl();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            table_data = new DataGridView();
            MainTab = new TabControl();
            Parcourir = new TabPage();
            Structure = new TabPage();
            ViewStructure = new DataGridView();
            Relation = new TabPage();
            SqlPlayGround = new TabPage();
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            Executer = new Button();
            Effacer = new Button();
            InputQuery = new RichTextBox();
            historique = new TabPage();
            HistoriqueListView = new ListView();
            RafraichirToolStripMenuItem = new ToolStripMenuItem();
            changerDeBaseDeDonnéesToolStripMenuItem = new ToolStripMenuItem();
            exporterLesDonnéesToolStripMenuItem = new ToolStripMenuItem();
            excelToolStripMenuItem = new ToolStripMenuItem();
            cSVToolStripMenuItem = new ToolStripMenuItem();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            etatToolStripMenuItem = new ToolStripMenuItem();
            créerUneNouvelleTableToolStripMenuItem = new ToolStripMenuItem();
            supprimerLaTable = new ToolStripMenuItem();
            deconnecterToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)table_data).BeginInit();
            MainTab.SuspendLayout();
            Parcourir.SuspendLayout();
            Structure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewStructure).BeginInit();
            Relation.SuspendLayout();
            SqlPlayGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            historique.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // list_tables
            // 
            list_tables.FormattingEnabled = true;
            list_tables.Location = new Point(10, 41);
            list_tables.Name = "list_tables";
            list_tables.Size = new Size(152, 364);
            list_tables.TabIndex = 4;
            list_tables.SelectedIndexChanged += list_tables_SelectedIndexChanged;
            // 
            // RelatedTableData
            // 
            RelatedTableData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RelatedTableData.BackgroundColor = SystemColors.Control;
            RelatedTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RelatedTableData.Location = new Point(12, 62);
            RelatedTableData.Name = "RelatedTableData";
            RelatedTableData.RowHeadersWidth = 51;
            RelatedTableData.Size = new Size(784, 439);
            RelatedTableData.TabIndex = 6;
            RelatedTableData.CellContentClick += RelatedTableData_CellContentClick;
            // 
            // RelatedTables
            // 
            RelatedTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RelatedTables.Location = new Point(12, 8);
            RelatedTables.Name = "RelatedTables";
            RelatedTables.Size = new Size(784, 54);
            RelatedTables.TabIndex = 8;
            RelatedTables.Paint += RelatedTables_Paint_1;
            // 
            // Menu
            // 
            Menu.AutoSize = true;
            Menu.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Menu.Location = new Point(12, 7);
            Menu.Name = "Menu";
            Menu.Size = new Size(73, 31);
            Menu.TabIndex = 9;
            Menu.Text = "Menu";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(Menu);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(list_tables);
            panel1.Location = new Point(1, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 540);
            panel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.Controls.Add(add);
            panel3.Controls.Add(buttonEdit);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 406);
            panel3.Name = "panel3";
            panel3.Size = new Size(159, 131);
            panel3.TabIndex = 13;
            // 
            // add
            // 
            add.Location = new Point(31, 47);
            add.Name = "add";
            add.Size = new Size(94, 29);
            add.TabIndex = 14;
            add.Text = "Ajouter";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(31, 95);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(94, 29);
            buttonEdit.TabIndex = 13;
            buttonEdit.Text = "Editer";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 31);
            label2.TabIndex = 11;
            label2.Text = "Editeur";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaption;
            panel5.Controls.Add(tabControl2);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(-146, -94);
            panel5.Name = "panel5";
            panel5.Size = new Size(534, 280);
            panel5.TabIndex = 13;
            // 
            // tabControl2
            // 
            tabControl2.Location = new Point(159, 9);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(250, 125);
            tabControl2.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(2, 5);
            label3.Name = "label3";
            label3.Size = new Size(61, 31);
            label3.TabIndex = 10;
            label3.Text = "Liste";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(505, 227);
            dataGridView1.TabIndex = 5;
            // 
            // table_data
            // 
            table_data.AllowUserToAddRows = false;
            table_data.AllowUserToDeleteRows = false;
            table_data.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table_data.BackgroundColor = SystemColors.Control;
            table_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_data.Location = new Point(6, 8);
            table_data.Name = "table_data";
            table_data.RowHeadersWidth = 51;
            table_data.Size = new Size(792, 490);
            table_data.TabIndex = 5;
            table_data.CellContentClick += table_data_CellContentClick_1;
            // 
            // MainTab
            // 
            MainTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainTab.Controls.Add(Parcourir);
            MainTab.Controls.Add(Structure);
            MainTab.Controls.Add(Relation);
            MainTab.Controls.Add(SqlPlayGround);
            MainTab.Controls.Add(historique);
            MainTab.Location = new Point(171, 31);
            MainTab.Name = "MainTab";
            MainTab.SelectedIndex = 0;
            MainTab.Size = new Size(812, 540);
            MainTab.TabIndex = 15;
            // 
            // Parcourir
            // 
            Parcourir.Controls.Add(table_data);
            Parcourir.Location = new Point(4, 29);
            Parcourir.Name = "Parcourir";
            Parcourir.Padding = new Padding(3);
            Parcourir.Size = new Size(804, 507);
            Parcourir.TabIndex = 0;
            Parcourir.Text = "Parcourir";
            Parcourir.UseVisualStyleBackColor = true;
            // 
            // Structure
            // 
            Structure.Controls.Add(ViewStructure);
            Structure.Location = new Point(4, 29);
            Structure.Name = "Structure";
            Structure.Padding = new Padding(3);
            Structure.Size = new Size(804, 507);
            Structure.TabIndex = 1;
            Structure.Text = "Structure";
            Structure.UseVisualStyleBackColor = true;
            // 
            // ViewStructure
            // 
            ViewStructure.AllowUserToAddRows = false;
            ViewStructure.AllowUserToDeleteRows = false;
            ViewStructure.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ViewStructure.BackgroundColor = SystemColors.Control;
            ViewStructure.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewStructure.Location = new Point(3, 8);
            ViewStructure.Name = "ViewStructure";
            ViewStructure.RowHeadersWidth = 51;
            ViewStructure.Size = new Size(790, 496);
            ViewStructure.TabIndex = 6;
            // 
            // Relation
            // 
            Relation.Controls.Add(RelatedTableData);
            Relation.Controls.Add(RelatedTables);
            Relation.Location = new Point(4, 29);
            Relation.Name = "Relation";
            Relation.Padding = new Padding(3);
            Relation.Size = new Size(804, 507);
            Relation.TabIndex = 2;
            Relation.Text = "Relation";
            Relation.UseVisualStyleBackColor = true;
            // 
            // SqlPlayGround
            // 
            SqlPlayGround.Controls.Add(splitContainer1);
            SqlPlayGround.Location = new Point(4, 29);
            SqlPlayGround.Name = "SqlPlayGround";
            SqlPlayGround.Padding = new Padding(3);
            SqlPlayGround.Size = new Size(804, 507);
            SqlPlayGround.TabIndex = 3;
            SqlPlayGround.Text = "Exécution des Requêtes SQL";
            SqlPlayGround.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(InputQuery);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.DimGray;
            splitContainer1.Size = new Size(798, 501);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(Executer);
            panel2.Controls.Add(Effacer);
            panel2.Location = new Point(12, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(781, 34);
            panel2.TabIndex = 4;
            // 
            // Executer
            // 
            Executer.Location = new Point(3, 3);
            Executer.Name = "Executer";
            Executer.Size = new Size(94, 29);
            Executer.TabIndex = 2;
            Executer.Text = "Exécuter";
            Executer.UseVisualStyleBackColor = true;
            Executer.Click += Executer_Click;
            // 
            // Effacer
            // 
            Effacer.Location = new Point(103, 3);
            Effacer.Name = "Effacer";
            Effacer.Size = new Size(94, 29);
            Effacer.TabIndex = 3;
            Effacer.Text = "Effacer";
            Effacer.UseVisualStyleBackColor = true;
            Effacer.Click += Effacer_Click;
            // 
            // InputQuery
            // 
            InputQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputQuery.Location = new Point(12, 41);
            InputQuery.Name = "InputQuery";
            InputQuery.Size = new Size(781, 211);
            InputQuery.TabIndex = 1;
            InputQuery.Text = "";
            // 
            // historique
            // 
            historique.Controls.Add(HistoriqueListView);
            historique.Location = new Point(4, 29);
            historique.Name = "historique";
            historique.Size = new Size(804, 507);
            historique.TabIndex = 4;
            historique.Text = "Historique des requêtes";
            historique.UseVisualStyleBackColor = true;
            // 
            // HistoriqueListView
            // 
            HistoriqueListView.Location = new Point(10, 12);
            HistoriqueListView.Name = "HistoriqueListView";
            HistoriqueListView.Size = new Size(791, 486);
            HistoriqueListView.TabIndex = 0;
            HistoriqueListView.UseCompatibleStateImageBehavior = false;
            HistoriqueListView.View = View.List;
            HistoriqueListView.SelectedIndexChanged += HistoriqueListView_SelectedIndexChanged;
            // 
            // RafraichirToolStripMenuItem
            // 
            RafraichirToolStripMenuItem.Name = "RafraichirToolStripMenuItem";
            RafraichirToolStripMenuItem.Size = new Size(86, 24);
            RafraichirToolStripMenuItem.Text = "Rafraîchir";
            RafraichirToolStripMenuItem.Click += RafraichirToolStripMenuItem_Click;
            // 
            // changerDeBaseDeDonnéesToolStripMenuItem
            // 
            changerDeBaseDeDonnéesToolStripMenuItem.Name = "changerDeBaseDeDonnéesToolStripMenuItem";
            changerDeBaseDeDonnéesToolStripMenuItem.Size = new Size(215, 24);
            changerDeBaseDeDonnéesToolStripMenuItem.Text = "Changer de base de données";
            changerDeBaseDeDonnéesToolStripMenuItem.Click += changerDeBaseDeDonnéesToolStripMenuItem_Click;
            // 
            // exporterLesDonnéesToolStripMenuItem
            // 
            exporterLesDonnéesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { excelToolStripMenuItem, cSVToolStripMenuItem, pDFToolStripMenuItem });
            exporterLesDonnéesToolStripMenuItem.Name = "exporterLesDonnéesToolStripMenuItem";
            exporterLesDonnéesToolStripMenuItem.Size = new Size(161, 24);
            exporterLesDonnéesToolStripMenuItem.Text = "Exporter les données";
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            excelToolStripMenuItem.Size = new Size(126, 26);
            excelToolStripMenuItem.Text = "Excel";
            excelToolStripMenuItem.Click += excelToolStripMenuItem_Click;
            // 
            // cSVToolStripMenuItem
            // 
            cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            cSVToolStripMenuItem.Size = new Size(126, 26);
            cSVToolStripMenuItem.Text = "CSV";
            cSVToolStripMenuItem.Click += cSVToolStripMenuItem_Click;
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            pDFToolStripMenuItem.Size = new Size(126, 26);
            pDFToolStripMenuItem.Text = "PDF";
            pDFToolStripMenuItem.Click += pDFToolStripMenuItem_Click;
            // 
            // etatToolStripMenuItem
            // 
            etatToolStripMenuItem.Name = "etatToolStripMenuItem";
            etatToolStripMenuItem.Size = new Size(49, 24);
            etatToolStripMenuItem.Text = "État";
            etatToolStripMenuItem.Click += etatToolStripMenuItem_Click;
            // 
            // créerUneNouvelleTableToolStripMenuItem
            // 
            créerUneNouvelleTableToolStripMenuItem.Name = "créerUneNouvelleTableToolStripMenuItem";
            créerUneNouvelleTableToolStripMenuItem.Size = new Size(184, 24);
            créerUneNouvelleTableToolStripMenuItem.Text = "Créer une nouvelle table";
            créerUneNouvelleTableToolStripMenuItem.Click += créerUneNouvelleTableToolStripMenuItem_Click;
            // 
            // supprimerLaTable
            // 
            supprimerLaTable.Name = "supprimerLaTable";
            supprimerLaTable.Size = new Size(144, 24);
            supprimerLaTable.Text = "supprimer la table";
            supprimerLaTable.Click += supprimerLaTableToolStripMenuItem_Click;
            // 
            // deconnecterToolStripMenuItem
            // 
            deconnecterToolStripMenuItem.Name = "deconnecterToolStripMenuItem";
            deconnecterToolStripMenuItem.Size = new Size(107, 24);
            deconnecterToolStripMenuItem.Text = "Deconnecter";
            deconnecterToolStripMenuItem.Click += deconnecterToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { RafraichirToolStripMenuItem, changerDeBaseDeDonnéesToolStripMenuItem, exporterLesDonnéesToolStripMenuItem, etatToolStripMenuItem, créerUneNouvelleTableToolStripMenuItem, supprimerLaTable, deconnecterToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(954, 28);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 574);
            Controls.Add(MainTab);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Playground";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Playground";
            Load += playground_Load;
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)table_data).EndInit();
            MainTab.ResumeLayout(false);
            Parcourir.ResumeLayout(false);
            Structure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ViewStructure).EndInit();
            Relation.ResumeLayout(false);
            SqlPlayGround.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            historique.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox list_tables;
        private DataGridView RelatedTableData;
        private FlowLayoutPanel RelatedTables;
        private Label Menu;
        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private Button buttonEdit;
        private Button add;
        private Panel panel5;
        private TabControl tabControl2;
       
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridView table_data;
        private TabControl MainTab;
        private TabPage Parcourir;
        private TabPage Structure;
        private DataGridView ViewStructure;
        private TabPage Relation;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private ToolStripMenuItem RafraichirToolStripMenuItem;
        private ToolStripMenuItem changerDeBaseDeDonnéesToolStripMenuItem;
        private ToolStripMenuItem exporterLesDonnéesToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
        private ToolStripMenuItem cSVToolStripMenuItem;
        private ToolStripMenuItem etatToolStripMenuItem;
        private ToolStripMenuItem créerUneNouvelleTableToolStripMenuItem;
        private ToolStripMenuItem supprimerLaTable;
        private ToolStripMenuItem deconnecterToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private TabPage SqlPlayGround;
        private SplitContainer splitContainer1;
        private RichTextBox InputQuery;
        private Button Effacer;
        private Button Executer;
        private Panel panel2;
        private TabPage historique;
        private ListView HistoriqueListView;
    }
}
