namespace BD_UI
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
            LoginPanel = new Panel();
            checkBox1 = new CheckBox();
            logbutton = new Button();
            input_database = new TextBox();
            label1 = new Label();
            input_password = new TextBox();
            password_label = new Label();
            input_username = new TextBox();
            UserLabel = new Label();
            input_host = new TextBox();
            Host_label = new Label();
            pictureBox1 = new PictureBox();
            LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoginPanel
            // 
            LoginPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoginPanel.BackColor = SystemColors.Control;
            LoginPanel.Controls.Add(checkBox1);
            LoginPanel.Controls.Add(logbutton);
            LoginPanel.Controls.Add(input_database);
            LoginPanel.Controls.Add(label1);
            LoginPanel.Controls.Add(input_password);
            LoginPanel.Controls.Add(password_label);
            LoginPanel.Controls.Add(input_username);
            LoginPanel.Controls.Add(UserLabel);
            LoginPanel.Controls.Add(input_host);
            LoginPanel.Controls.Add(Host_label);
            LoginPanel.Location = new Point(351, -1);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(471, 457);
            LoginPanel.TabIndex = 0;
            LoginPanel.Paint += panel1_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(303, 247);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 24);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Afficher";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
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
            input_database.Location = new Point(62, 330);
            input_database.Name = "input_database";
            input_database.Size = new Size(225, 27);
            input_database.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 291);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 7;
            label1.Text = "Nom de la base de données";
            // 
            // input_password
            // 
            input_password.Location = new Point(62, 245);
            input_password.Name = "input_password";
            input_password.Size = new Size(225, 27);
            input_password.TabIndex = 5;
            input_password.TextChanged += input_password_TextChanged;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(62, 206);
            password_label.Name = "password_label";
            password_label.Size = new Size(98, 20);
            password_label.TabIndex = 4;
            password_label.Text = "Mot de passe";
            // 
            // input_username
            // 
            input_username.Location = new Point(62, 160);
            input_username.Name = "input_username";
            input_username.Size = new Size(225, 27);
            input_username.TabIndex = 3;
            input_username.Text = "root";
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Location = new Point(62, 121);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(76, 20);
            UserLabel.TabIndex = 2;
            UserLabel.Text = "Utilisateur";
            // 
            // input_host
            // 
            input_host.Location = new Point(62, 75);
            input_host.Name = "input_host";
            input_host.Size = new Size(225, 27);
            input_host.TabIndex = 1;
            input_host.Text = "localhost";
            // 
            // Host_label
            // 
            Host_label.AutoSize = true;
            Host_label.Location = new Point(62, 36);
            Host_label.Name = "Host_label";
            Host_label.Size = new Size(141, 20);
            Host_label.TabIndex = 0;
            Host_label.Text = "Nom ou IP de l'hôte";
            Host_label.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(312, 413);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(822, 456);
            Controls.Add(pictureBox1);
            Controls.Add(LoginPanel);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += login_Load;
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label Host_label;
        private TextBox input_password;
        private Label password_label;
        private TextBox input_username;
        private Label UserLabel;
        private TextBox input_host;
        private TextBox input_database;
        private Label label1;
        private Button logbutton;
        private Panel LoginPanel;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
    }
}