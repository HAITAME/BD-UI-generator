namespace BD_UI
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
            listView1 = new ListView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.HighlightText;
            listView1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.Location = new Point(249, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(317, 308);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BD_etat_removebg_preview__1_;
            pictureBox1.Location = new Point(8, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 227);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // EtatDB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 332);
            Controls.Add(listView1);
            Controls.Add(pictureBox1);
            Name = "EtatDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etat";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private PictureBox pictureBox1;
    }
}