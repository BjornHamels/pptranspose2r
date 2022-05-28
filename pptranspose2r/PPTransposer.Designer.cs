namespace pptranspose2r
{
    partial class PPTransposer
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
            this.btLoadPPcsv = new System.Windows.Forms.Button();
            this.ofdCSVKeuze = new System.Windows.Forms.OpenFileDialog();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btLoadPPcsv
            // 
            this.btLoadPPcsv.Dock = System.Windows.Forms.DockStyle.Top;
            this.btLoadPPcsv.Location = new System.Drawing.Point(0, 0);
            this.btLoadPPcsv.Name = "btLoadPPcsv";
            this.btLoadPPcsv.Size = new System.Drawing.Size(876, 87);
            this.btLoadPPcsv.TabIndex = 0;
            this.btLoadPPcsv.Text = "Load PP .csv";
            this.btLoadPPcsv.UseVisualStyleBackColor = true;
            this.btLoadPPcsv.Click += new System.EventHandler(this.btLoadPPcsv_Click);
            // 
            // ofdCSVKeuze
            // 
            this.ofdCSVKeuze.DefaultExt = "csv";
            this.ofdCSVKeuze.FileName = "*.csv";
            this.ofdCSVKeuze.Filter = "PP csv bestanden|*.csv";
            this.ofdCSVKeuze.InitialDirectory = "./";
            this.ofdCSVKeuze.Title = "Kies PP csv bestand";
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 32;
            this.lbLog.Items.AddRange(new object[] {
            "Loading a PP .csv file will instantly save 2 more files.",
            "This is the log of all operations.",
            "---"});
            this.lbLog.Location = new System.Drawing.Point(0, 87);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(876, 512);
            this.lbLog.TabIndex = 1;
            // 
            // PPTransposer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 599);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btLoadPPcsv);
            this.Name = "PPTransposer";
            this.Text = "PPTransposer";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btLoadPPcsv;
        private OpenFileDialog ofdCSVKeuze;
        private ListBox lbLog;
    }
}