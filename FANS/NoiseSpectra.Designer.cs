namespace FANS
{
    partial class NoiseSpectra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoiseSpectra));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FolderName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.filename_textbox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SpectraPerShow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberOfSpectra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.oscilloscope_toolstrip_rescale = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(683, 517);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.76471F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.23529F));
            this.tableLayoutPanel1.Controls.Add(this.zedGraphControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.45238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.54762F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 461);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.tableLayoutPanel1.SetRowSpan(this.zedGraphControl1, 5);
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(484, 455);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.Stop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(493, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 101);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FolderName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.filename_textbox);
            this.panel2.Controls.Add(this.OpenFolder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(493, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 81);
            this.panel2.TabIndex = 8;
            // 
            // FolderName
            // 
            this.FolderName.BackColor = System.Drawing.SystemColors.Control;
            this.FolderName.Location = new System.Drawing.Point(59, 3);
            this.FolderName.Multiline = true;
            this.FolderName.Name = "FolderName";
            this.FolderName.ReadOnly = true;
            this.FolderName.Size = new System.Drawing.Size(124, 42);
            this.FolderName.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "FileName";
            // 
            // filename_textbox
            // 
            this.filename_textbox.Location = new System.Drawing.Point(59, 51);
            this.filename_textbox.Name = "filename_textbox";
            this.filename_textbox.Size = new System.Drawing.Size(124, 20);
            this.filename_textbox.TabIndex = 14;
            this.filename_textbox.Text = "Measurement.dat";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(493, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 93);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.SpectraPerShow);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.NumberOfSpectra);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(493, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 67);
            this.panel4.TabIndex = 10;
            // 
            // SpectraPerShow
            // 
            this.SpectraPerShow.Location = new System.Drawing.Point(121, 35);
            this.SpectraPerShow.Name = "SpectraPerShow";
            this.SpectraPerShow.Size = new System.Drawing.Size(57, 20);
            this.SpectraPerShow.TabIndex = 3;
            this.SpectraPerShow.Text = "5";
            this.SpectraPerShow.TextChanged += new System.EventHandler(this.NumberOfSpectra_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Update Every ";
            // 
            // NumberOfSpectra
            // 
            this.NumberOfSpectra.Location = new System.Drawing.Point(121, 10);
            this.NumberOfSpectra.Name = "NumberOfSpectra";
            this.NumberOfSpectra.Size = new System.Drawing.Size(57, 20);
            this.NumberOfSpectra.TabIndex = 1;
            this.NumberOfSpectra.Text = "100";
            this.NumberOfSpectra.TextChanged += new System.EventHandler(this.NumberOfSpectra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Spectra";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.oscilloscope_toolstrip_rescale});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(485, 22);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 21);
            // 
            // Start
            // 
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Start.Location = new System.Drawing.Point(6, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 85);
            this.Start.TabIndex = 5;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stop.BackgroundImage")));
            this.Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Stop.Location = new System.Drawing.Point(92, 12);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(86, 85);
            this.Stop.TabIndex = 6;
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenFolder.BackgroundImage")));
            this.OpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenFolder.Location = new System.Drawing.Point(3, 3);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(54, 45);
            this.OpenFolder.TabIndex = 13;
            this.OpenFolder.Text = "Open";
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::FANS.Properties.Resources.clear;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Clear Graph";
            this.toolStripButton2.ToolTipText = "Clear Graph";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // oscilloscope_toolstrip_rescale
            // 
            this.oscilloscope_toolstrip_rescale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.oscilloscope_toolstrip_rescale.Image = global::FANS.Properties.Resources.refresh;
            this.oscilloscope_toolstrip_rescale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.oscilloscope_toolstrip_rescale.Name = "oscilloscope_toolstrip_rescale";
            this.oscilloscope_toolstrip_rescale.Size = new System.Drawing.Size(23, 22);
            this.oscilloscope_toolstrip_rescale.Tag = "Rescale";
            this.oscilloscope_toolstrip_rescale.Text = "toolStripButton1";
            this.oscilloscope_toolstrip_rescale.ToolTipText = "Rescale";
            this.oscilloscope_toolstrip_rescale.Click += new System.EventHandler(this.oscilloscope_toolstrip_rescale_Click);
            // 
            // NoiseSpectra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 517);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NoiseSpectra";
            this.Text = "NoiseSpectra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoiseSpectraClosing);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FolderName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox filename_textbox;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox SpectraPerShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumberOfSpectra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton oscilloscope_toolstrip_rescale;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}