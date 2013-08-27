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

        private void parseDt(DataTable dt, DataGridView dgv)
        {
            while (dt.Columns.Count != 3)
                dt.Columns.Add();

            for (int row = 0; row < dt.Rows.Count; row++ )
            {
                string read = dt.Rows[row][0].ToString();
                string[] write = read.Split(';');
                dt.Rows[row][0] = write[0];
                dt.Rows[row][1] = write[1];
                dt.Rows[row][2] = write[2];
            }
            dgvFw.DataSource = dt;

            for (int row = 0; row < dgvFw.Rows.Count; row++)
                dgvFw.Rows[row].HeaderCell.Value = ((row + 1)%64).ToString();

            dgvFw.Columns[0].HeaderText = "funkce";
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
                string conStr = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + Path.GetDirectoryName(Path.GetFullPath(path)) + ";Extensions=csv,txt";
                OdbcConnection conn = new OdbcConnection(conStr);
                OdbcDataAdapter da = new OdbcDataAdapter("Select * from [" + Path.GetFileName(path) + "]", conn);

                DataTable dt = new DataTable(path);
                da.Fill(dt);

                parseDt(dt,dgvFw);
                
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

        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            try
            {
                if (gridIn.RowCount > 0)
                {
                    StreamWriter swOut = new StreamWriter(outputFile);

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(";");
                        }
                        swOut.Write(gridIn.Columns[i].HeaderText);
                    }
                    swOut.WriteLine();

                    for (int row = 0; row < gridIn.RowCount - 2; row++)
                    {
                        for (int column = 0; column < gridIn.ColumnCount; column++)
                        {
                            if (!string.IsNullOrWhiteSpace(gridIn.Rows[row].Cells[column].Value.ToString()))
                                swOut.Write(gridIn.Rows[row].Cells[column].Value.ToString());
                            if (column < (gridIn.ColumnCount - 1))
                                swOut.Write(";");
                        }
                        swOut.WriteLine();
                    }
                    swOut.Close();
                }
                else{
                    MessageBox.Show(this, "Prázdný soubor neuložím. Pro vytvoření nového souboru konfigurace stiskněte tlačítko nový.", "chyba při ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex){
                MessageBox.Show(this, "Vyskytla se chyba při ukládání, v případě že potíže přetrvávají kontaktujte Jiřího Kyzlinka na mailu jkyzlink@gmail.com nebo tel. č. 774 658 060" + ex.Message, "chyba při ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            saveFileDialog1.InitialDirectory = "Vyberte soubor pro uložení";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                writeCSV(dgvFw, saveFileDialog1.FileName);
            }
        }
    }
}
