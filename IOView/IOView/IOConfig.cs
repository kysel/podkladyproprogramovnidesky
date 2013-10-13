using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;

namespace IOView
{
    public partial class IOConfig : Form
    {
        
        public IOConfig()
        {
            InitializeComponent();
        }

        private void parseDts(DataTable dt, DataGridView dgvfw, DataGridView dgvPorty)
        {
            {
                string read = dt.Rows[0][0].ToString();
                string[] write = read.Split(';');
                for (int j = 0; j != 4; j++)
                {
                    clbPullUps.SetItemChecked(j, Convert.ToBoolean((Convert.ToInt16(write[0]) >> j) % 2));
                }
                for (int j = 0; j != 7; j++)
                {
                    clbLogLevel.SetItemChecked(j, Convert.ToBoolean((Convert.ToInt16(write[1]) >> j) % 2));
                }
            }
            dt.Rows.RemoveAt(0);

            DataTable dtFwP = new DataTable();
            dtFwP.Columns.Add();
            dtFwP.Columns.Add();
            for (int j = 0; j != 4; j++)
            {
                dtFwP.Rows.Add();
                string read = dt.Rows[0][0].ToString();
                string[] write = read.Split(';');
                dtFwP.Rows[j][0] = write[0];
                dtFwP.Rows[j][1] = write[1];
                dt.Rows.RemoveAt(0);
            }
            dgvPortFw.DataSource = dtFwP;
            for (int j = 0; j != 2; j++)
            {
                DataGridViewColumn cSize = dgvPortFw.Columns[j];
                cSize.Width = 65;
            }
            dgvPortFw.Columns[0].ReadOnly = true;
            dgvPortFw.Columns[0].HeaderText = "Z portu";
            dgvPortFw.Columns[1].HeaderText = "Na port";


            DataTable dtPorty = new DataTable();
            dtPorty = dt.Copy();

            while (dtPorty.Columns.Count != 2)
                dtPorty.Columns.Add();

            for (int row = 0; row != 32; row++)
            {
                string read = dtPorty.Rows[row][0].ToString();
                string[] write = read.Split(';');
                dtPorty.Rows[row][0] = write[0];
                dtPorty.Rows[row][1] = write[1];
            }

            for (int i = dtPorty.Rows.Count - 1; i != 31; i--)
                dtPorty.Rows.RemoveAt(i);

            dgvPorty.DataSource = dtPorty;

            for (int i = 0; i != dgvPorty.Columns.Count; i++)
                dgvPorty.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            dgvPorty.Columns[0].ReadOnly = true;
            dgvPorty.Columns[0].HeaderText = "funkce č.";
            dgvPorty.Columns[1].HeaderText = "vstupní port č.";

           {
                DataGridViewColumn cSize = dgvPorty.Columns[0];
                cSize.Width = 80;
                cSize = dgvPorty.Columns[1];
                cSize.Width = 80;
            }

            while (dt.Columns.Count != 3)
                dt.Columns.Add();

            for (int row = 32; row < dt.Rows.Count; row++)
            {
                string read = dt.Rows[row][0].ToString();
                string[] write = read.Split(';');
                dt.Rows[row][0] = write[0];
                dt.Rows[row][1] = write[1];
                dt.Rows[row][2] = write[2];
            }

            for (int i = 32; i != 0; i--)
                dt.Rows.RemoveAt(i - 1);

            dgvFw.DataSource = dt;

            dgvfw.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvfw.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvfw.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvFw.Columns[0].ReadOnly = true;
            dgvFw.Columns[1].ReadOnly = true;

            {
                DataGridViewColumn cSize = dgvfw.Columns[0];
                cSize.Width = 30;
                cSize = dgvfw.Columns[1];
                cSize.Width = 60;
                cSize = dgvfw.Columns[2];
                cSize.Width = 80;
            }

            dgvFw.Columns[0].HeaderText = "f-ce";
            dgvFw.Columns[1].HeaderText = "vstup č.";
            dgvFw.Columns[2].HeaderText = "bude na v.  č.";

        }

        private void loadCSV(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show(this, "File does not exist:\r\n" + path, "No File", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                Pref.Default.csvPath = path;
                Pref.Default.Save();

                if (path.Length > 50)
                    lOpenFile.Text = "otevřen: " + path.Remove(3) + " ... " + path.Substring(path.Length - 30);
                else
                    lOpenFile.Text = "otevřen: " + path;

                string conStr = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + Path.GetDirectoryName(Path.GetFullPath(path)) + ";Extensions=csv,txt";
                OdbcConnection conn = new OdbcConnection(conStr);
                OdbcDataAdapter da = new OdbcDataAdapter("Select * from [" + Path.GetFileName(path) + "]", conn);

                DataTable dt = new DataTable(path);
                da.Fill(dt);

                parseDts(dt, dgvFw, dgvPorty);
                
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There was an error loading the CSV file:\r\n" + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void saveCSV(string outputFile)
        {
            try
            {
                if (dgvFw.RowCount > 0 && dgvPorty.RowCount > 0)
                {
                    StreamWriter swOut = new StreamWriter(outputFile);

                    swOut.WriteLine("0;0;");

                    int pullups = 0;
                    for (int j = 0; j != 4; j++)
                    {
                        pullups += (Convert.ToInt16(clbPullUps.GetItemChecked(j)) * Convert.ToInt16(Math.Pow(2, j)));
                    }
                    swOut.Write(pullups + ";");

                    int logLev = 0;
                    for (int j = 0; j != 7; j++)
                    {
                        logLev += (Convert.ToInt16(clbLogLevel.GetItemChecked(j)) * Convert.ToInt16(Math.Pow(2, j)));
                    }
                    swOut.WriteLine(logLev + ";");

                    for (int row = 0; row != 4; row++)
                    {
                        for (int column = 0; column < dgvPortFw.ColumnCount; column++)
                        {
                            if (!string.IsNullOrWhiteSpace(dgvPortFw.Rows[row].Cells[column].Value.ToString()))
                                swOut.Write(dgvPortFw.Rows[row].Cells[column].Value.ToString());
                            swOut.Write(";");
                        }
                        swOut.WriteLine();
                    }

                    for (int row = 0; row < dgvPorty.RowCount; row++)
                    {
                        for (int column = 0; column < dgvPorty.ColumnCount; column++)
                        {
                            if (!string.IsNullOrWhiteSpace(dgvPorty.Rows[row].Cells[column].Value.ToString()))
                                swOut.Write(dgvPorty.Rows[row].Cells[column].Value.ToString());
                            swOut.Write(";");
                        }
                        swOut.WriteLine();
                    }


                    for (int row = 0; row < dgvFw.RowCount; row++)
                    {
                        for (int column = 0; column < dgvFw.ColumnCount; column++)
                        {
                            if (!string.IsNullOrWhiteSpace(dgvFw.Rows[row].Cells[column].Value.ToString()))
                                swOut.Write(dgvFw.Rows[row].Cells[column].Value.ToString());
                            if (column < (dgvFw.ColumnCount - 1))
                                swOut.Write(";");
                        }
                        swOut.WriteLine();
                    }
                    swOut.Close();
                    Pref.Default.csvPath = outputFile;
                    Pref.Default.Save();
                }
                else{
                    MessageBox.Show(this, "Prázdný soubor neuložím. Pro vytvoření nového souboru konfigurace stiskněte tlačítko nový.", "chyba při ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex){
                MessageBox.Show(this, "Vyskytla se chyba při ukládání, v případě že potíže přetrvávají kontaktujte Jiřího Kyzlinka na mailu jkyzlink@gmail.com\r\n nebo tel. č. 774 658 060 \r\n" + ex.Message, "chyba při ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void createCSV(string path)
        {
            try
            {
                StreamWriter swOut = new StreamWriter(path);
                swOut.WriteLine("0;0;");
                swOut.WriteLine("0;0;");

                for (int j = 1; j != 5; j++)
                    swOut.WriteLine(j.ToString() + ";0;");

                for (int i = 1; i != 33; i++)
                    swOut.WriteLine(i.ToString() + ";" + (((i - 1) % 4) + 1).ToString() + ";");

                for (int i = 0; i != 2048; i++)
                    swOut.WriteLine(((i / 64) + 1).ToString() + ";" + ((i % 64) + 1).ToString() + ";0");

                swOut.Close();

                loadCSV(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Vyskytla se chyba při ukládání, v případě že potíže přetrvávají kontaktujte Jiřího Kyzlinka na mailu jkyzlink@gmail.com nebo tel. č. 774 658 060" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void bOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Soubory konfigurace (.csv)|*.csv";
            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK)
            {
                loadCSV(openFileDialog1.FileName);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Soubory konfigurace (.csv)|*.csv";
            saveFileDialog1.InitialDirectory = "Vyberte soubor pro uložení.";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                saveCSV(saveFileDialog1.FileName);
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Soubory konfigurace (.csv)|*.csv";
            saveFileDialog1.InitialDirectory = "Vyberte soubor pro uložení, nebo vytvořte nový.";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                createCSV(saveFileDialog1.FileName);
            }
        }

        private void dgvFw_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    Int32 check = Convert.ToInt32(this.dgvFw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (764<check || check<0)
                    {
                        MessageBox.Show(this, "Chyba zápisu dat, zapsali jste neplatné číslo (rozsah od 0 do 764).", "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.dgvFw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Chyba zápisu dat, pravděpodobně jste zapsali neplatné číslo (rozsah od 0 do 764).\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgvPorty_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    Int32 check = Convert.ToInt32(this.dgvPorty.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (4 < check || check < 1)
                    {
                        MessageBox.Show(this, "Chyba zápisu dat, zapsali jste neplatné číslo (rozsah od 1 do 4).", "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.dgvPorty.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Chyba zápisu dat, pravděpodobně jste zapsali neplatné číslo (rozsah od 1 do 4).\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgvPortFw_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    Int32 check = Convert.ToInt32(this.dgvPortFw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (7 < check || check < 0)
                    {
                        MessageBox.Show(this, "Chyba zápisu dat, zapsali jste neplatné číslo (rozsah od 0 do 7).", "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.dgvPortFw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Chyba zápisu dat, pravděpodobně jste zapsali neplatné číslo (rozsah od 0 do 764).\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void bExitWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (bwDownload.IsBusy)
                MessageBox.Show(this, "Právě probíhá nahrávání konfiguračního souboru.", "IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (dgvFw.RowCount > 0 && dgvPorty.RowCount > 0)
                {
                    saveCSV(Pref.Default.csvPath);
                    pbDownload.Maximum = 2084;
                    bwDownload.RunWorkerAsync(Pref.Default.csvPath);
                }
                else
                    MessageBox.Show(this, "Není načtený konfigurační soubor, pro vytvoření nového stiskněte tlačítko \"nový\".", "IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bwDownload_DoWork(Object sender, DoWorkEventArgs e)
        {
            string path = e.Argument.ToString();
            System.IO.Ports.SerialPort SP1 = new System.IO.Ports.SerialPort("COM" + Pref.Default.ComPort.ToString(), 115200);
            StreamReader sIn = new StreamReader(path);  
            try
            {                               
                sIn.ReadLine();

                SP1.Open();
                SP1.Write("d");
                SP1.DiscardInBuffer();
                    //establish comm
                while (SP1.BytesToRead==0 || SP1.ReadByte() != 'a')
                {
                    SP1.Write("d");
                    SP1.Write("c");
                    System.Threading.Thread.Sleep(100);

                    if (bwDownload.CancellationPending)
                    {
                        SP1.WriteLine("s");
                        sIn.Close();
                        while (SP1.BytesToWrite != 0) { }
                        SP1.Close();
                        e.Cancel = true;
                    }
                }
                SP1.DiscardInBuffer();
                SP1.DiscardOutBuffer();
                    //connection established 
                {
                    SP1.WriteLine("0");
                    string read = sIn.ReadLine();
                    string[] write = read.Split(';');
                    SP1.WriteLine(write[0]);
                    bwDownload.ReportProgress(0);
                    while (SP1.ReadByte() != 'a') { }

                    SP1.WriteLine(write[1]);
                    bwDownload.ReportProgress(0);
                    while (SP1.ReadByte() != 'a') { }
                }

                for (int j = 0; j != 36; j++)
                {
                    string read = sIn.ReadLine();
                    string[] write = read.Split(';');
                    SP1.WriteLine(write[1]);
                    bwDownload.ReportProgress(j);
                    while (SP1.ReadByte() != 'a') { }

                    if (bwDownload.CancellationPending)
                    {                 
                        SP1.WriteLine("s");
                        sIn.Close();
                        while (SP1.BytesToWrite != 0) { }
                        SP1.Close();
                        e.Cancel = true;
                    }
                }
                
                SP1.Write("e");
                while (SP1.ReadByte() != 'a') { }

                for (int j = 35; j != 2083; j++)
                {
                    string read = sIn.ReadLine();
                    string[] write = read.Split(';');
                    int num = write[2] == "0" ? 65535 : Convert.ToInt32(write[2].Remove(0, 1)) * 64 + Convert.ToInt32(write[2].Remove(1));
                    SP1.WriteLine((Convert.ToInt32(write[2]) + 1).ToString());
                    bwDownload.ReportProgress(j);
                    while (SP1.ReadByte() != 'a') { }
                    if (bwDownload.CancellationPending)
                    {
                        SP1.WriteLine("s");
                        sIn.Close();
                        while (SP1.BytesToWrite != 0) { }
                        SP1.Close();
                        e.Cancel = true;
                    }
                }
                SP1.Write("e");
                SP1.Close();
                sIn.Close();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("COM"))
                    MessageBox.Show(this, "Nepodařilo se otevřít com port, prosím zkontrolujte ostatní aplikace, jestli jej nevyužívají.\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "Nepodařilo se uložit data do mikroprocesoru, prosím zkontrolujte, že máte načten konfigurační soubor.\r\n" + ex.Message, "Varhany IOConfig", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (SP1 != null)
                {
                    if (SP1.IsOpen)
                    {
                        SP1.Close();
                    }
                    SP1.Dispose();
                }
                if (sIn != null)
                {
                    sIn.Close();
                    sIn.Dispose();
                }
            }
        }

        private void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDownload.Value = e.ProgressPercentage;
        }

        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
        }

        private void cCancelAsync_Click(object sender, EventArgs e)
        {
            if (bwDownload.IsBusy)
                bwDownload.CancelAsync();
        }

        private void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbDownload.Value = 0;
        }

        private void IOConfig_Load(object sender, EventArgs e)
        {

        }

        private void IOConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void nápovědaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpConfig HlpCfg = new HelpConfig();
            HlpCfg.Show();
        }        

    }
}