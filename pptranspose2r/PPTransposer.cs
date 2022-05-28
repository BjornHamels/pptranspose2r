using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pptranspose2r
{
    public partial class PPTransposer : Form
    {
        public PPTransposer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is where the magic happens!
        /// </summary>
        private void btLoadPPcsv_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ofdCSVKeuze.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(ofdCSVKeuze.FileName);
                    string inputFile = ofdCSVKeuze.FileName;

                    PPcsvReader reader = new(inputFile);

                    string rDataOut = path + $"\\{reader.ParticipantID}_pptranspose2r.csv";
                    string avgDataOut = path + $"\\{reader.ParticipantID}_pptranspose2r_avgrecord.csv";

                    reader.SaveRecordsTo(rDataOut);

                    lbLog.Items.Add("---- Success ----");
                    lbLog.Items.Add($"Details: n={reader.NumRecords}, first={reader.FirstDate}, last={reader.LastDate}");
                    lbLog.Items.Add($"Read: {inputFile}");
                    lbLog.Items.Add($"Saved: {rDataOut}");
                    lbLog.Items.Add($"Saved: {avgDataOut}");
                    lbLog.Items.Add($"Average record: {reader.AverageRecord}");
                }
            }
            catch (Exception ex)
            {
                lbLog.Items.Add("---- ERROR ----");
                lbLog.Items.Add(ex.Message);
                lbLog.Items.Add(ex.StackTrace);
                MessageBox.Show("Something went wrong while transposing :(. We're both sad this hapened!\n\nTech talk: " +
                                ex.Message + "\n\nTech details: \n" + ex.StackTrace);
            }
        }
    }
}
