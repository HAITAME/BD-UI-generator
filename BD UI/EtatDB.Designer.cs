﻿namespace BD_UI
{
    partial class EtatDB
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
            tabPageQueryStat = new TabPage();
            listViewQueryStat = new ListView();
            tabPageProcessus = new TabPage();
            listViewProcessus = new ListView();
            tabPageServeur = new TabPage();
            pictureBox1 = new PictureBox();
            listView1 = new ListView();
            tabControl1 = new TabControl();
            tabPageQueryStat.SuspendLayout();
            tabPageProcessus.SuspendLayout();
            tabPageServeur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageQueryStat
            // 
            tabPageQueryStat.Controls.Add(listViewQueryStat);
            tabPageQueryStat.Location = new Point(4, 29);
            tabPageQueryStat.Name = "tabPageQueryStat";
            tabPageQueryStat.Size = new Size(564, 313);
            tabPageQueryStat.TabIndex = 2;
            tabPageQueryStat.Text = "Statistiques sur les requêtes";
            tabPageQueryStat.UseVisualStyleBackColor = true;
            // 
            // listViewQueryStat
            // 
            listViewQueryStat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewQueryStat.Location = new Point(3, 3);
            listViewQueryStat.Name = "listViewQueryStat";
            listViewQueryStat.Size = new Size(561, 307);
            listViewQueryStat.TabIndex = 0;
            listViewQueryStat.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageProcessus
            // 
            tabPageProcessus.Controls.Add(listViewProcessus);
            tabPageProcessus.Location = new Point(4, 29);
            tabPageProcessus.Name = "tabPageProcessus";
            tabPageProcessus.Padding = new Padding(3);
            tabPageProcessus.Size = new Size(564, 313);
            tabPageProcessus.TabIndex = 1;
            tabPageProcessus.Text = "Processus";
            tabPageProcessus.UseVisualStyleBackColor = true;
            // 
            // listViewProcessus
            // 
            listViewProcessus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewProcessus.Location = new Point(6, 2);
            listViewProcessus.Name = "listViewProcessus";
            listViewProcessus.Size = new Size(555, 299);
            listViewProcessus.TabIndex = 0;
            listViewProcessus.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageServeur
            // 
            tabPageServeur.Controls.Add(listView1);
            tabPageServeur.Controls.Add(pictureBox1);
            tabPageServeur.Location = new Point(4, 29);
            tabPageServeur.Name = "tabPageServeur";
            tabPageServeur.Padding = new Padding(3);
            tabPageServeur.Size = new Size(564, 313);
            tabPageServeur.TabIndex = 0;
            tabPageServeur.Text = "Serveur";
            tabPageServeur.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.BD_etat_removebg_preview__1_;
            pictureBox1.Location = new Point(3, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 241);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.BackColor = SystemColors.HighlightText;
            listView1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.Location = new Point(244, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(317, 308);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageServeur);
            tabControl1.Controls.Add(tabPageProcessus);
            tabControl1.Controls.Add(tabPageQueryStat);
            tabControl1.Location = new Point(1, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(572, 346);
            tabControl1.TabIndex = 2;
            // 
            // EtatDB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 354);
            Controls.Add(tabControl1);
            Name = "EtatDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etat";
            tabPageQueryStat.ResumeLayout(false);
            tabPageProcessus.ResumeLayout(false);
            tabPageServeur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPageQueryStat;
        private ListView listViewQueryStat;
        private TabPage tabPageProcessus;
        private ListView listViewProcessus;
        private TabPage tabPageServeur;
        private ListView listView1;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
    }
}