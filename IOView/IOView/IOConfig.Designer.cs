namespace IOView
{
    partial class IOConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFw = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bOpen = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFw
            // 
            this.dgvFw.AllowUserToResizeColumns = false;
            this.dgvFw.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.NullValue = null;
            this.dgvFw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFw.Location = new System.Drawing.Point(12, 12);
            this.dgvFw.Name = "dgvFw";
            this.dgvFw.Size = new System.Drawing.Size(433, 379);
            this.dgvFw.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(103, 417);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 23);
            this.bOpen.TabIndex = 1;
            this.bOpen.Text = "otevřít";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(184, 417);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "uložit";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // IOConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 474);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.dgvFw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IOConfig";
            this.Text = "Varhany IOConfig © 2013 Jiří Kyzlink";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFw;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}