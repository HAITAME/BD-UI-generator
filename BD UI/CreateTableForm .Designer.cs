namespace BD_UI
{
    partial class CreateTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            NomTable = new TextBox();
            CreateTab = new Button();
            AddColumn = new Button();
            panelColonnes = new FlowLayoutPanel();
            MainPanel = new Panel();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 56);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Nom de la table :";
            // 
            // NomTable
            // 
            NomTable.Location = new Point(231, 54);
            NomTable.Name = "NomTable";
            NomTable.Size = new Size(224, 27);
            NomTable.TabIndex = 1;
            // 
            // CreateTab
            // 
            CreateTab.Location = new Point(508, 52);
            CreateTab.Name = "CreateTab";
            CreateTab.Size = new Size(94, 29);
            CreateTab.TabIndex = 2;
            CreateTab.Text = "Créer ";
            CreateTab.UseVisualStyleBackColor = true;
            CreateTab.Click += CreateTab_Click;
            // 
            // AddColumn
            // 
            AddColumn.Location = new Point(70, 117);
            AddColumn.Name = "AddColumn";
            AddColumn.Size = new Size(159, 29);
            AddColumn.TabIndex = 3;
            AddColumn.Text = "Ajouter une colonne";
            AddColumn.UseVisualStyleBackColor = true;
            AddColumn.Click += AddColumn_Click;
            // 
            // panelColonnes
            // 
            panelColonnes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelColonnes.AutoSize = true;
            panelColonnes.FlowDirection = FlowDirection.TopDown;
            panelColonnes.Location = new Point(44, 17);
            panelColonnes.Name = "panelColonnes";
            panelColonnes.Size = new Size(659, 230);
            panelColonnes.TabIndex = 4;
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainPanel.Controls.Add(panelColonnes);
            MainPanel.Location = new Point(26, 163);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(790, 264);
            MainPanel.TabIndex = 5;
            // 
            // CreateTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 450);
            Controls.Add(MainPanel);
            Controls.Add(AddColumn);
            Controls.Add(CreateTab);
            Controls.Add(NomTable);
            Controls.Add(label1);
            Name = "CreateTableForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CreateTableForm";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NomTable;
        private Button CreateTab;
        private Button AddColumn;
        private FlowLayoutPanel panelColonnes;
        private Panel MainPanel;
    }
}