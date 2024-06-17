namespace BD_UI
{
    partial class Editor
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
            panelEditor = new Panel();
            comboBoxTables = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelEditor
            // 
            panelEditor.BackColor = SystemColors.HighlightText;
            panelEditor.Location = new Point(278, -1);
            panelEditor.Name = "panelEditor";
            panelEditor.Size = new Size(523, 410);
            panelEditor.TabIndex = 0;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(57, 168);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(151, 28);
            comboBoxTables.TabIndex = 1;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 119);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 2;
            label1.Text = "Table";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrevious);
            panel1.Location = new Point(278, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(523, 450);
            panel1.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(414, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(277, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(140, 415);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 1;
            btnNext.Text = "Suivant";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(3, 415);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "Précédent";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(comboBoxTables);
            Controls.Add(panelEditor);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Editor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editeur";
            Load += Editor_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelEditor;
        private ComboBox comboBoxTables;
        private Label label1;
        private Panel panel1;
        private Button btnDelete;
        private Button btnSave;
        private Button btnNext;
        private Button btnPrevious;
    }
}