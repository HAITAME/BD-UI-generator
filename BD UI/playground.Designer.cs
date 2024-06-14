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
            RelatedTables = new FlowLayoutPanel();
            Menu = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            buttonEdit = new Button();
            label2 = new Label();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)table_data).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // list_tables
            // 
            list_tables.FormattingEnabled = true;
            list_tables.Location = new Point(10, 38);
            list_tables.Name = "list_tables";
            list_tables.Size = new Size(152, 444);
            list_tables.TabIndex = 4;
            list_tables.SelectedIndexChanged += list_tables_SelectedIndexChanged;
            // 
            // table_data
            // 
            table_data.AllowUserToAddRows = false;
            table_data.AllowUserToDeleteRows = false;
            table_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_data.Location = new Point(6, 43);
            table_data.Name = "table_data";
            table_data.RowHeadersWidth = 51;
            table_data.Size = new Size(505, 227);
            table_data.TabIndex = 5;
            // 
            // RelatedTableData
            // 
            RelatedTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RelatedTableData.Location = new Point(6, 47);
            RelatedTableData.Name = "RelatedTableData";
            RelatedTableData.RowHeadersWidth = 51;
            RelatedTableData.Size = new Size(702, 159);
            RelatedTableData.TabIndex = 6;
            // 
            // RelatedTables
            // 
            RelatedTables.Location = new Point(171, 276);
            RelatedTables.Name = "RelatedTables";
            RelatedTables.Size = new Size(716, 44);
            RelatedTables.TabIndex = 8;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 5);
            label1.Name = "label1";
            label1.Size = new Size(61, 31);
            label1.TabIndex = 10;
            label1.Text = "Liste";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(Menu);
            panel1.Controls.Add(list_tables);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 492);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(table_data);
            panel2.Location = new Point(169, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 280);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonEdit);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(709, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(178, 280);
            panel3.TabIndex = 13;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(40, 241);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(94, 29);
            buttonEdit.TabIndex = 13;
            buttonEdit.Text = "Edit";
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
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(RelatedTableData);
            panel4.Location = new Point(169, 279);
            panel4.Name = "panel4";
            panel4.Size = new Size(719, 214);
            panel4.TabIndex = 14;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 494);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(RelatedTables);
            Controls.Add(panel4);
            Name = "Playground";
            Text = "Playground";
            Load += playground_Load;
            ((System.ComponentModel.ISupportInitialize)table_data).EndInit();
            ((System.ComponentModel.ISupportInitialize)RelatedTableData).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ListBox list_tables;
        private DataGridView table_data;
        private DataGridView RelatedTableData;
        private FlowLayoutPanel RelatedTables;
        private Label Menu;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private Button buttonEdit;
    }
}
