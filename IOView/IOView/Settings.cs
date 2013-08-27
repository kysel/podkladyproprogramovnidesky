using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOView
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            MaximizeBox = false;
            nudTick.Value = Pref.Default.Tick;
            nudComPort.Value = Pref.Default.ComPort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pref.Default.ComPort = (uint)nudComPort.Value;
            Pref.Default.Tick = (uint)nudTick.Value;
            Pref.Default.Save();
            Close();
        }
        
        private void nudTick_ValueChanged(object sender, EventArgs e)
        {
            Pref.Default.Tick = (uint)nudTick.Value;
            Pref.Default.Save();
        }

        private void nudComPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d)
                button1.PerformClick();
        }

        private void nudTick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d)
                nudComPort.Focus();
        }
    }
}
