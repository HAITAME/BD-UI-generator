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
            table_data = new DataGridView();
            RelatedTableData = new DataGridView();
            comboBoxTables = new ComboBox();
            RelatedTables = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)table_data).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).BeginInit();
            SuspendLayout();
            // 
            // list_tables
            // 
            list_tables.FormattingEnabled = true;
            list_tables.Location = new Point(12, 24);
            list_tables.Name = "list_tables";
            list_tables.Size = new Size(152, 444);
            list_tables.TabIndex = 4;
            list_tables.SelectedIndexChanged += list_tables_SelectedIndexChanged;
            // 
            // table_data
            // 
            table_data.ColumnHeadersHeight = 29;
            table_data.Location = new Point(170, 24);
            table_data.Name = "table_data";
            table_data.RowHeadersWidth = 51;
            table_data.Size = new Size(509, 227);
            table_data.TabIndex = 5;
            // 
            // RelatedTableData
            // 
            RelatedTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RelatedTableData.Location = new Point(170, 309);
            RelatedTableData.Name = "RelatedTableData";
            RelatedTableData.RowHeadersWidth = 51;
            RelatedTableData.Size = new Size(509, 159);
            RelatedTableData.TabIndex = 6;
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(712, 41);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(151, 28);
            comboBoxTables.TabIndex = 7;
            // 
            // RelatedTables
            // 
            RelatedTables.Location = new Point(171, 261);
            RelatedTables.Name = "RelatedTables";
            RelatedTables.Size = new Size(508, 42);
            RelatedTables.TabIndex = 8;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 494);
            Controls.Add(RelatedTables);
            Controls.Add(comboBoxTables);
            Controls.Add(RelatedTableData);
            Controls.Add(table_data);
            Controls.Add(list_tables);
            Name = "Playground";
            Text = "Playground";
            Load += playground_Load;
            ((System.ComponentModel.ISupportInitialize)table_data).EndInit();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ListBox list_tables;
        private DataGridView table_data;
        private DataGridView RelatedTableData;
        private ComboBox comboBoxTables;
        private FlowLayoutPanel RelatedTables;
    }
}
