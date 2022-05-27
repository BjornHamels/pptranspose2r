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
            var result = ofdCSVKeuze.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(ofdCSVKeuze.FileName);
                string inputFile = ofdCSVKeuze.FileName;
                string participantID = "participantID";
                string outputFile = path + $"\\{participantID}_pptranspose2r.csv";
                lbInputFile.Text = inputFile;
                lbOutputFile.Text = outputFile;
            }
        }
    }
}
