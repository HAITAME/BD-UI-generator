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
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)table_data).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
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
            table_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_data.Location = new Point(196, 24);
            table_data.Name = "table_data";
            table_data.RowHeadersWidth = 51;
            table_data.Size = new Size(428, 159);
            table_data.TabIndex = 5;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(196, 247);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(428, 159);
            dataGridView.TabIndex = 6;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 494);
            Controls.Add(dataGridView);
            Controls.Add(table_data);
            Controls.Add(list_tables);
            Name = "Playground";
            Text = "Playground";
            Load += playground_Load;
            ((System.ComponentModel.ISupportInitialize)table_data).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ListBox list_tables;
        private DataGridView table_data;
        private DataGridView dataGridView;
    }
}
