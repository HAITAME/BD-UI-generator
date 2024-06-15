namespace BD_UI
{
    partial class Add
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
            Addpanel = new Panel();
            SuspendLayout();
            // 
            // Addpanel
            // 
            Addpanel.Location = new Point(4, 0);
            Addpanel.Name = "Addpanel";
            Addpanel.Size = new Size(793, 451);
            Addpanel.TabIndex = 0;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Addpanel);
            Name = "Add";
            Text = "Add";
            ResumeLayout(false);
        }

        #endregion

        private Panel Addpanel;
    }
}