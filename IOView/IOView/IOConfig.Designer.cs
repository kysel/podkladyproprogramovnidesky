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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgvPorty = new System.Windows.Forms.DataGridView();
            this.dgvFw = new System.Windows.Forms.DataGridView();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.konfiguraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nováToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitDoPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nahrátDoΜPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.připojeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zavřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.cCancelAsync = new System.Windows.Forms.Button();
            this.clbPullUps = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lOpenFile = new System.Windows.Forms.Label();
            this.clbLogLevel = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPortFw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFw)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortFw)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgvPorty
            // 
            this.dgvPorty.AllowUserToAddRows = false;
            this.dgvPorty.AllowUserToDeleteRows = false;
            this.dgvPorty.AllowUserToResizeColumns = false;
            this.dgvPorty.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.NullValue = null;
            this.dgvPorty.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPorty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorty.Location = new System.Drawing.Point(208, 27);
            this.dgvPorty.Name = "dgvPorty";
            this.dgvPorty.RowHeadersVisible = false;
            this.dgvPorty.Size = new System.Drawing.Size(180, 379);
            this.dgvPorty.TabIndex = 3;
            this.dgvPorty.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPorty_CellValueChanged);
            // 
            // dgvFw
            // 
            this.dgvFw.AllowUserToAddRows = false;
            this.dgvFw.AllowUserToDeleteRows = false;
            this.dgvFw.AllowUserToResizeColumns = false;
            this.dgvFw.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.NullValue = null;
            this.dgvFw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFw.Location = new System.Drawing.Point(12, 27);
            this.dgvFw.Name = "dgvFw";
            this.dgvFw.RowHeadersVisible = false;
            this.dgvFw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFw.Size = new System.Drawing.Size(190, 379);
            this.dgvFw.TabIndex = 4;
            this.dgvFw.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFw_CellValueChanged);
            // 
            // bwDownload
            // 
            this.bwDownload.WorkerReportsProgress = true;
            this.bwDownload.WorkerSupportsCancellation = true;
            this.bwDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDownload_DoWork);
            this.bwDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDownload_ProgressChanged);
            this.bwDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDownload_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfiguraceToolStripMenuItem,
            this.připojeníToolStripMenuItem,
            this.zavřítToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(355, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfiguraceToolStripMenuItem
            // 
            this.konfiguraceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nováToolStripMenuItem,
            this.otevřítToolStripMenuItem,
            this.uložitDoPCToolStripMenuItem,
            this.nahrátDoΜPToolStripMenuItem});
            this.konfiguraceToolStripMenuItem.Name = "konfiguraceToolStripMenuItem";
            this.konfiguraceToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.konfiguraceToolStripMenuItem.Text = "Konfigurace";
            // 
            // nováToolStripMenuItem
            // 
            this.nováToolStripMenuItem.Name = "nováToolStripMenuItem";
            this.nováToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nováToolStripMenuItem.Text = "Nový";
            this.nováToolStripMenuItem.Click += new System.EventHandler(this.bNew_Click);
            // 
            // otevřítToolStripMenuItem
            // 
            this.otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            this.otevřítToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.otevřítToolStripMenuItem.Text = "Otevřít";
            this.otevřítToolStripMenuItem.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // uložitDoPCToolStripMenuItem
            // 
            this.uložitDoPCToolStripMenuItem.Name = "uložitDoPCToolStripMenuItem";
            this.uložitDoPCToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.uložitDoPCToolStripMenuItem.Text = "Uložit do PC";
            this.uložitDoPCToolStripMenuItem.Click += new System.EventHandler(this.bSave_Click);
            // 
            // nahrátDoΜPToolStripMenuItem
            // 
            this.nahrátDoΜPToolStripMenuItem.Name = "nahrátDoΜPToolStripMenuItem";
            this.nahrátDoΜPToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nahrátDoΜPToolStripMenuItem.Text = "Nahrát do μProcesoru";
            this.nahrátDoΜPToolStripMenuItem.Click += new System.EventHandler(this.bSend_Click);
            // 
            // připojeníToolStripMenuItem
            // 
            this.připojeníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveníToolStripMenuItem});
            this.připojeníToolStripMenuItem.Name = "připojeníToolStripMenuItem";
            this.připojeníToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.připojeníToolStripMenuItem.Text = "Připojení";
            // 
            // nastaveníToolStripMenuItem
            // 
            this.nastaveníToolStripMenuItem.Name = "nastaveníToolStripMenuItem";
            this.nastaveníToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.nastaveníToolStripMenuItem.Text = "Nastavení";
            this.nastaveníToolStripMenuItem.Click += new System.EventHandler(this.nastaveníToolStripMenuItem_Click);
            // 
            // zavřítToolStripMenuItem
            // 
            this.zavřítToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oknoToolStripMenuItem,
            this.aplikaciToolStripMenuItem});
            this.zavřítToolStripMenuItem.Name = "zavřítToolStripMenuItem";
            this.zavřítToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.zavřítToolStripMenuItem.Text = "Zavřít";
            // 
            // oknoToolStripMenuItem
            // 
            this.oknoToolStripMenuItem.Name = "oknoToolStripMenuItem";
            this.oknoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.oknoToolStripMenuItem.Text = "Okno";
            this.oknoToolStripMenuItem.Click += new System.EventHandler(this.bExitWindow_Click);
            // 
            // aplikaciToolStripMenuItem
            // 
            this.aplikaciToolStripMenuItem.Name = "aplikaciToolStripMenuItem";
            this.aplikaciToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aplikaciToolStripMenuItem.Text = "Aplikaci";
            this.aplikaciToolStripMenuItem.Click += new System.EventHandler(this.bExitApp_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nápovědaToolStripMenuItem,
            this.oProgramuToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            this.nápovědaToolStripMenuItem.Click += new System.EventHandler(this.nápovědaToolStripMenuItem_Click);
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.oProgramuToolStripMenuItem.Text = "O programu";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(12, 412);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(397, 23);
            this.pbDownload.TabIndex = 11;
            // 
            // cCancelAsync
            // 
            this.cCancelAsync.Location = new System.Drawing.Point(415, 412);
            this.cCancelAsync.Name = "cCancelAsync";
            this.cCancelAsync.Size = new System.Drawing.Size(114, 23);
            this.cCancelAsync.TabIndex = 12;
            this.cCancelAsync.Text = "zastavit nahrávání";
            this.cCancelAsync.UseVisualStyleBackColor = true;
            this.cCancelAsync.Click += new System.EventHandler(this.cCancelAsync_Click);
            // 
            // clbPullUps
            // 
            this.clbPullUps.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clbPullUps.CheckOnClick = true;
            this.clbPullUps.FormattingEnabled = true;
            this.clbPullUps.Items.AddRange(new object[] {
            "Port 1",
            "Port 2",
            "Port 3",
            "Port 4"});
            this.clbPullUps.Location = new System.Drawing.Point(394, 201);
            this.clbPullUps.Name = "clbPullUps";
            this.clbPullUps.Size = new System.Drawing.Size(60, 64);
            this.clbPullUps.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "vstupy\r\nlog 1 je 5V ?";
            // 
            // lOpenFile
            // 
            this.lOpenFile.AutoSize = true;
            this.lOpenFile.Location = new System.Drawing.Point(291, 5);
            this.lOpenFile.Name = "lOpenFile";
            this.lOpenFile.Size = new System.Drawing.Size(52, 13);
            this.lOpenFile.TabIndex = 15;
            this.lOpenFile.Text = "               ";
            // 
            // clbLogLevel
            // 
            this.clbLogLevel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.clbLogLevel.CheckOnClick = true;
            this.clbLogLevel.FormattingEnabled = true;
            this.clbLogLevel.Items.AddRange(new object[] {
            "Port 1",
            "Port 2",
            "Port 3",
            "Port 4",
            "Port 5",
            "Port 6",
            "Port 7"});
            this.clbLogLevel.Location = new System.Drawing.Point(394, 297);
            this.clbLogLevel.Name = "clbLogLevel";
            this.clbLogLevel.Size = new System.Drawing.Size(60, 109);
            this.clbLogLevel.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 26);
            this.label2.TabIndex = 17;
            this.label2.Text = "výstupy\r\nlog 1 je 5V ?";
            // 
            // dgvPortFw
            // 
            this.dgvPortFw.AllowUserToAddRows = false;
            this.dgvPortFw.AllowUserToDeleteRows = false;
            this.dgvPortFw.AllowUserToResizeColumns = false;
            this.dgvPortFw.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.NullValue = null;
            this.dgvPortFw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPortFw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPortFw.Location = new System.Drawing.Point(394, 27);
            this.dgvPortFw.Name = "dgvPortFw";
            this.dgvPortFw.RowHeadersVisible = false;
            this.dgvPortFw.Size = new System.Drawing.Size(135, 115);
            this.dgvPortFw.TabIndex = 18;
            this.dgvPortFw.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPortFw_CellValueChanged);
            // 
            // IOConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 440);
            this.Controls.Add(this.dgvPortFw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbLogLevel);
            this.Controls.Add(this.lOpenFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbPullUps);
            this.Controls.Add(this.cCancelAsync);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.dgvFw);
            this.Controls.Add(this.dgvPorty);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IOConfig";
            this.Text = "Varhany IOConfig © 2013 Jiří Kyzlink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IOConfig_FormClosing);
            this.Load += new System.EventHandler(this.IOConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFw)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortFw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgvPorty;
        private System.Windows.Forms.DataGridView dgvFw;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konfiguraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nováToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitDoPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nahrátDoΜPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zavřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aplikaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem připojeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveníToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Button cCancelAsync;
        private System.Windows.Forms.CheckedListBox clbPullUps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lOpenFile;
        private System.Windows.Forms.CheckedListBox clbLogLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPortFw;

    }
}