﻿namespace BD_UI
{
    partial class Login
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
            RelatedTable = new Panel();
            logbutton = new Button();
            input_database = new TextBox();
            label1 = new Label();
            input_password = new TextBox();
            password_label = new Label();
            input_username = new TextBox();
            UserLabel = new Label();
            input_host = new TextBox();
            Host_label = new Label();
            RelatedTable.SuspendLayout();
            SuspendLayout();
            // 
            // RelatedTable
            // 
            RelatedTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            RelatedTable.BackColor = SystemColors.Control;
            RelatedTable.Controls.Add(logbutton);
            RelatedTable.Controls.Add(input_database);
            RelatedTable.Controls.Add(label1);
            RelatedTable.Controls.Add(input_password);
            RelatedTable.Controls.Add(password_label);
            RelatedTable.Controls.Add(input_username);
            RelatedTable.Controls.Add(UserLabel);
            RelatedTable.Controls.Add(input_host);
            RelatedTable.Controls.Add(Host_label);
            RelatedTable.Location = new Point(351, -1);
            RelatedTable.Name = "RelatedTable";
            RelatedTable.Size = new Size(471, 457);
            RelatedTable.TabIndex = 0;
            RelatedTable.Paint += panel1_Paint;
            // 
            // logbutton
            // 
            logbutton.Location = new Point(83, 384);
            logbutton.Name = "logbutton";
            logbutton.Size = new Size(188, 44);
            logbutton.TabIndex = 9;
            logbutton.Text = "Ouvrir";
            logbutton.UseVisualStyleBackColor = true;
            logbutton.Click += logbutton_Click;
            // 
            // input_database
            // 
            input_database.Location = new Point(62, 328);
            input_database.Name = "input_database";
            input_database.Size = new Size(225, 27);
            input_database.TabIndex = 8;
            input_database.Text = "bibliotheque";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 295);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 7;
            label1.Text = "Nom de la base de données";
            // 
            // input_password
            // 
            input_password.Location = new Point(62, 249);
            input_password.Name = "input_password";
            input_password.Size = new Size(225, 27);
            input_password.TabIndex = 5;
            input_password.TextChanged += input_password_TextChanged;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(62, 216);
            password_label.Name = "password_label";
            password_label.Size = new Size(98, 20);
            password_label.TabIndex = 4;
            password_label.Text = "Mot de passe";
            // 
            // input_username
            // 
            input_username.Location = new Point(62, 157);
            input_username.Name = "input_username";
            input_username.Size = new Size(225, 27);
            input_username.TabIndex = 3;
            input_username.Text = "root";
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Location = new Point(62, 124);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(76, 20);
            UserLabel.TabIndex = 2;
            UserLabel.Text = "Utilisateur";
            // 
            // input_host
            // 
            input_host.Location = new Point(62, 65);
            input_host.Name = "input_host";
            input_host.Size = new Size(225, 27);
            input_host.TabIndex = 1;
            input_host.Text = "localhost";
            // 
            // Host_label
            // 
            Host_label.AutoSize = true;
            Host_label.Location = new Point(62, 32);
            Host_label.Name = "Host_label";
            Host_label.Size = new Size(141, 20);
            Host_label.TabIndex = 0;
            Host_label.Text = "Nom ou IP de l'hôte";
            Host_label.Click += label1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(822, 456);
            Controls.Add(RelatedTable);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += login_Load;
            RelatedTable.ResumeLayout(false);
            RelatedTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Host_label;
        private TextBox input_password;
        private Label password_label;
        private TextBox input_username;
        private Label UserLabel;
        private TextBox input_host;
        private TextBox input_database;
        private Label label1;
        private Button logbutton;
        private Panel RelatedTable;
    }
}