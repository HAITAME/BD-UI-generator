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
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            table_data = new DataGridView();
            Liste = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ViewStructure = new DataGridView();
            tabPage5 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            tabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)table_data).BeginInit();
            Liste.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ViewStructure).BeginInit();
            tabPage5.SuspendLayout();
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
            RelatedTableData.Size = new Size(784, 470);
            RelatedTableData.TabIndex = 6;
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
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 575);
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
            panel3.Size = new Size(159, 166);
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
            buttonEdit.Location = new Point(31, 96);
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
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Location = new Point(159, 9);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(250, 125);
            tabControl2.TabIndex = 11;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(242, 92);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(242, 92);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
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
            table_data.Size = new Size(792, 521);
            table_data.TabIndex = 5;
            table_data.CellContentClick += table_data_CellContentClick_1;
            // 
            // Liste
            // 
            Liste.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Liste.Controls.Add(tabPage1);
            Liste.Controls.Add(tabPage2);
            Liste.Controls.Add(tabPage5);
            Liste.Location = new Point(171, 4);
            Liste.Name = "Liste";
            Liste.SelectedIndex = 0;
            Liste.Size = new Size(812, 571);
            Liste.SizeMode = TabSizeMode.FillToRight;
            Liste.TabIndex = 15;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(table_data);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(804, 538);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Parcourir";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ViewStructure);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(804, 538);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Structure";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ViewStructure
            // 
            ViewStructure.AllowUserToAddRows = false;
            ViewStructure.AllowUserToDeleteRows = false;
            ViewStructure.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ViewStructure.BackgroundColor = SystemColors.Control;
            ViewStructure.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewStructure.Location = new Point(8, 8);
            ViewStructure.Name = "ViewStructure";
            ViewStructure.RowHeadersWidth = 51;
            ViewStructure.Size = new Size(790, 527);
            ViewStructure.TabIndex = 6;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(RelatedTableData);
            tabPage5.Controls.Add(RelatedTables);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(804, 538);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Relation";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 574);
            Controls.Add(Liste);
            Controls.Add(panel1);
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
            tabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)table_data).EndInit();
            Liste.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ViewStructure).EndInit();
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
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
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridView table_data;
        private TabControl Liste;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView ViewStructure;
        private TabPage tabPage5;
    }
}
