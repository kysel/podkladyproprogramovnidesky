namespace IOView
{
    partial class Settings
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTick = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudComPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComPort)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "použit a zavřít";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "perioda obnovování";
            // 
            // nudTick
            // 
            this.nudTick.Location = new System.Drawing.Point(121, 12);
            this.nudTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTick.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTick.Name = "nudTick";
            this.nudTick.Size = new System.Drawing.Size(56, 20);
            this.nudTick.TabIndex = 2;
            this.nudTick.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTick.ValueChanged += new System.EventHandler(this.nudTick_ValueChanged);
            this.nudTick.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudTick_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "číslo COM portu";
            // 
            // nudComPort
            // 
            this.nudComPort.Location = new System.Drawing.Point(121, 38);
            this.nudComPort.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudComPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudComPort.Name = "nudComPort";
            this.nudComPort.Size = new System.Drawing.Size(56, 20);
            this.nudComPort.TabIndex = 5;
            this.nudComPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudComPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudComPort_KeyPress);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 94);
            this.Controls.Add(this.nudComPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavení";
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudComPort;
    }
}