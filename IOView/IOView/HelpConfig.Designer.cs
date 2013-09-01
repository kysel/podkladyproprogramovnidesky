namespace IOView
{
    partial class HelpConfig
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
            this.bClose = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(127, 103);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "zavřít";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(304, 85);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "\nStavy výstupů se zapisují jako port + pin\nnapř pro výsup na portu 3 a pinu 40 se" +
    " zapíše 340.\n\nPozn. porty i piny se indexují od č. 1 přesně jako v IOView\n";
            // 
            // HelpConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 136);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HelpConfig";
            this.Text = "HelpConfig";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}