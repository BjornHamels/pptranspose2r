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
            this.lbInputFile = new System.Windows.Forms.Label();
            this.lbOutputFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btLoadPPcsv
            // 
            this.btLoadPPcsv.Location = new System.Drawing.Point(12, 42);
            this.btLoadPPcsv.Name = "btLoadPPcsv";
            this.btLoadPPcsv.Size = new System.Drawing.Size(303, 87);
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
            // lbInputFile
            // 
            this.lbInputFile.AutoSize = true;
            this.lbInputFile.Location = new System.Drawing.Point(338, 42);
            this.lbInputFile.Name = "lbInputFile";
            this.lbInputFile.Size = new System.Drawing.Size(113, 32);
            this.lbInputFile.TabIndex = 1;
            this.lbInputFile.Text = "Open file";
            // 
            // lbOutputFile
            // 
            this.lbOutputFile.AutoSize = true;
            this.lbOutputFile.Location = new System.Drawing.Point(338, 97);
            this.lbOutputFile.Name = "lbOutputFile";
            this.lbOutputFile.Size = new System.Drawing.Size(551, 32);
            this.lbOutputFile.TabIndex = 2;
            this.lbOutputFile.Text = "Loading the file instantly saves the processed data";
            // 
            // PPTransposer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 192);
            this.Controls.Add(this.lbOutputFile);
            this.Controls.Add(this.lbInputFile);
            this.Controls.Add(this.btLoadPPcsv);
            this.Name = "PPTransposer";
            this.Text = "PPTransposer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btLoadPPcsv;
        private OpenFileDialog ofdCSVKeuze;
        private Label lbInputFile;
        private Label lbOutputFile;
    }
}