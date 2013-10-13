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
    public partial class Form1 : Form
    {
        bool connecting = false;
        bool connected = false;

        public Form1()
        {
            InitializeComponent();
            bDisconnect.Enabled = false;
        }

        public void Start_Click(object sender, EventArgs e)
        {
            try
            {
                SP1.PortName = "COM" + Convert.ToString(Pref.Default.ComPort);
                SP1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Nepodařilo se otevřít com port, prosím zkontrolujte ostatní aplikace, jestli jej nevyužívají.\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SP1.Write("i");
            connecting = true;
            lb1SetText("připojeno");
            timer1.Interval = (int)Pref.Default.Tick;
            timer1.Start();
            Start.Enabled = false;
            bDisconnect.Enabled = true;
        }

        private void UpdateImg(ulong[] data)
        {
            Bitmap bmp = new Bitmap(576, 275);
            Graphics port = Graphics.FromImage(bmp);
            Font fnt = new Font("Arial", 9);

            for (int j = 0; j != 11; j++)
            {
                for (int i = 0; i != 32; i++)
                {
                    if (Convert.ToBoolean((data[j] >> (i * 2)) & 0x01))
                    {
                        port.FillRectangle(Brushes.Black, i * 18, j * 25, 18, 12);
                        port.DrawString(Convert.ToString((i * 2) + 1), fnt, Brushes.White, i * 18, j * 25 - 2);
                    }
                    else
                    {
                        port.FillRectangle(Brushes.White, i * 18, j * 25, 18, 12);
                        port.DrawString(Convert.ToString((i * 2) + 1), fnt, Brushes.Black, i * 18, j * 25 - 2);
                    }

                    if (Convert.ToBoolean((data[j] >> (i * 2 + 1)) & 0x01))
                    {
                        port.FillRectangle(Brushes.Black, i * 18, j * 25 + 12, 18, 12);
                        port.DrawString(Convert.ToString((i * 2) + 2), fnt, Brushes.White, i * 18, j * 25 + 10);
                    }
                    else
                    {
                        port.FillRectangle(Brushes.White, i * 18, j * 25 + 12, 18, 12);
                        port.DrawString(Convert.ToString((i * 2) + 2), fnt, Brushes.Black, i * 18, j * 25 + 10);
                    }
                }
                if (j != 0)
                    port.DrawLine(Pens.Black, 0, j * 25 - 1, 576, j * 25 - 1);
            }
            PbInput0.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (connected)
                SP1.Write("i");
            else
                bDisconnect.PerformClick();
            timer1.Interval = (int)Pref.Default.Tick;
        }

        private void SP1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {    
            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            if (connecting)
            {
                connecting = false;
                connected = true;
            }

            if (!connected)
            {
                try
                {
                    string str = sp.ReadExisting();
                    if (str.Contains("a"))
                    {
                        sp.DiscardInBuffer();
                        connected = true;
                    }
                }
                catch
                {
                    lb1SetText("nelze se připojit k procesoru");
                }
                sp.DiscardInBuffer();
            }
            else
            {
                try
                {
                    //sp.DiscardInBuffer();
                    if (sp.ReadChar() == 'a')
                    {
                        System.Threading.Thread.Sleep(2);
                        if (sp.BytesToRead > 176)
                        {
                            ulong[] inpData = new ulong[11];
                            for (int i = 0; i != 11; i++)
                            {
                                if (!ulong.TryParse(sp.ReadLine().Trim(), out inpData[i]))
                                {
                                    sp.ReadExisting();
                                    break;
                                }

                            }
                            sp.DiscardInBuffer();
                            UpdateImg(inpData);
                        }
                    }
                }
                catch(Exception ex)
                {
                    lb1SetText("catch exeption" + ex.Message);
                    timer1.Stop();
                    return;
                }
            }
        }
        
        private void lb1SetText(string text)
        {
            lb1.SynchronizedInvoke(() => lb1.Text = text);
        }

        private void startSetText(string text)
        {
            Start.SynchronizedInvoke(() => Start.Text = text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void bConf_Click(object sender, EventArgs e)
        {
            if (connected)
                Start.PerformClick();
            IOConfig IOconfig = new IOConfig();
            IOconfig.Show();
        }

        private void bDisconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            connecting = false;
            timer1.Stop();
            if (SP1 != null)
            {
                if (SP1.IsOpen)
                {
                    SP1.Close();
                }
                SP1.Dispose();
            }
            lb1.Text = "odpojeno";
            bDisconnect.Enabled = false;
            Start.Enabled = true;
        }
    }    
    public static class update
    {
        public static void SynchronizedInvoke(this ISynchronizeInvoke sync, Action action)
        {
            // If the invoke is not required, then invoke here and get out.
            if (!sync.InvokeRequired)
            {
                // Execute action.
                action();

                // Get out.
                return;
            }

            // Marshal to the required context.
            sync.Invoke(action, new object[] { });
        }
    }
}
