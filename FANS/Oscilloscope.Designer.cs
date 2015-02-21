﻿namespace FANS
{
    partial class Oscilloscope
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oscilloscope));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FolderName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TimeLimit = new System.Windows.Forms.TextBox();
            this.RecordTime_Limit = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.filename_textbox = new System.Windows.Forms.TextBox();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.RawDataRecording = new System.Windows.Forms.CheckBox();
            this.RecordingInFile_Enabled = new System.Windows.Forms.CheckBox();
            this.Oscilloscope_zgc = new ZedGraph.ZedGraphControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PointsPerBlock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Acqusition_Rate = new System.Windows.Forms.TextBox();
            this.AcquisitionRateTrackBar1 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.VoltageScaleTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VoltageScale = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeScaleTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeScale = new System.Windows.Forms.TextBox();
            this.Channels_DAC = new System.Windows.Forms.Panel();
            this.channel_4_DAC_Enabled = new System.Windows.Forms.CheckBox();
            this.channel_2_DAC_Enabled = new System.Windows.Forms.CheckBox();
            this.channel_3_DAC_Enabled = new System.Windows.Forms.CheckBox();
            this.channel_1_DAC_Enabled = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.oscilloscope_toolstrip_rescale = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AcquisitionRateTrackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoltageScaleTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleTrackBar)).BeginInit();
            this.Channels_DAC.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Stop);
            this.panel2.Controls.Add(this.Start);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(596, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 121);
            this.panel2.TabIndex = 3;
            // 
            // Stop
            // 
            this.Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stop.BackgroundImage")));
            this.Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Stop.Location = new System.Drawing.Point(101, 3);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(86, 81);
            this.Stop.TabIndex = 4;
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Start
            // 
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Start.Location = new System.Drawing.Point(7, 3);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(80, 81);
            this.Start.TabIndex = 3;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.start_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(596, 300);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(194, 129);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.FolderName);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.TimeLimit);
            this.panel6.Controls.Add(this.RecordTime_Limit);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.filename_textbox);
            this.panel6.Controls.Add(this.OpenFolder);
            this.panel6.Controls.Add(this.RawDataRecording);
            this.panel6.Controls.Add(this.RecordingInFile_Enabled);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 129);
            this.panel6.TabIndex = 7;
            // 
            // FolderName
            // 
            this.FolderName.BackColor = System.Drawing.SystemColors.Control;
            this.FolderName.Location = new System.Drawing.Point(61, 50);
            this.FolderName.Multiline = true;
            this.FolderName.Name = "FolderName";
            this.FolderName.ReadOnly = true;
            this.FolderName.Size = new System.Drawing.Size(124, 42);
            this.FolderName.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "ms";
            // 
            // TimeLimit
            // 
            this.TimeLimit.Location = new System.Drawing.Point(88, 24);
            this.TimeLimit.Name = "TimeLimit";
            this.TimeLimit.Size = new System.Drawing.Size(74, 20);
            this.TimeLimit.TabIndex = 11;
            // 
            // RecordTime_Limit
            // 
            this.RecordTime_Limit.AutoSize = true;
            this.RecordTime_Limit.Location = new System.Drawing.Point(6, 26);
            this.RecordTime_Limit.Name = "RecordTime_Limit";
            this.RecordTime_Limit.Size = new System.Drawing.Size(73, 17);
            this.RecordTime_Limit.TabIndex = 10;
            this.RecordTime_Limit.Text = "Time Limit";
            this.RecordTime_Limit.UseVisualStyleBackColor = true;
            this.RecordTime_Limit.CheckedChanged += new System.EventHandler(this.RecordTime_Limit_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "FileName";
            // 
            // filename_textbox
            // 
            this.filename_textbox.Location = new System.Drawing.Point(60, 98);
            this.filename_textbox.Name = "filename_textbox";
            this.filename_textbox.Size = new System.Drawing.Size(124, 20);
            this.filename_textbox.TabIndex = 9;
            this.filename_textbox.Text = "Measurement.dat";
            // 
            // OpenFolder
            // 
            this.OpenFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenFolder.BackgroundImage")));
            this.OpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenFolder.Location = new System.Drawing.Point(4, 47);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(54, 45);
            this.OpenFolder.TabIndex = 2;
            this.OpenFolder.Text = "Open";
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.button3_Click);
            // 
            // RawDataRecording
            // 
            this.RawDataRecording.AutoSize = true;
            this.RawDataRecording.Location = new System.Drawing.Point(88, 3);
            this.RawDataRecording.Name = "RawDataRecording";
            this.RawDataRecording.Size = new System.Drawing.Size(74, 17);
            this.RawDataRecording.TabIndex = 1;
            this.RawDataRecording.Text = "Raw Data";
            this.RawDataRecording.UseVisualStyleBackColor = true;
            this.RawDataRecording.CheckedChanged += new System.EventHandler(this.RawDataRecording_CheckedChanged);
            // 
            // RecordingInFile_Enabled
            // 
            this.RecordingInFile_Enabled.AutoSize = true;
            this.RecordingInFile_Enabled.Location = new System.Drawing.Point(7, 3);
            this.RecordingInFile_Enabled.Name = "RecordingInFile_Enabled";
            this.RecordingInFile_Enabled.Size = new System.Drawing.Size(61, 17);
            this.RecordingInFile_Enabled.TabIndex = 0;
            this.RecordingInFile_Enabled.Text = "Record";
            this.RecordingInFile_Enabled.UseVisualStyleBackColor = true;
            this.RecordingInFile_Enabled.CheckedChanged += new System.EventHandler(this.RecordingInFile_Enabled_CheckedChanged);
            // 
            // Oscilloscope_zgc
            // 
            this.Oscilloscope_zgc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Oscilloscope_zgc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Oscilloscope_zgc.Location = new System.Drawing.Point(3, 3);
            this.Oscilloscope_zgc.Name = "Oscilloscope_zgc";
            this.tableLayoutPanel1.SetRowSpan(this.Oscilloscope_zgc, 6);
            this.Oscilloscope_zgc.ScrollGrace = 0D;
            this.Oscilloscope_zgc.ScrollMaxX = 0D;
            this.Oscilloscope_zgc.ScrollMaxY = 0D;
            this.Oscilloscope_zgc.ScrollMaxY2 = 0D;
            this.Oscilloscope_zgc.ScrollMinX = 0D;
            this.Oscilloscope_zgc.ScrollMinY = 0D;
            this.Oscilloscope_zgc.ScrollMinY2 = 0D;
            this.Oscilloscope_zgc.Size = new System.Drawing.Size(587, 553);
            this.Oscilloscope_zgc.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.PointsPerBlock);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.Acqusition_Rate);
            this.panel4.Controls.Add(this.AcquisitionRateTrackBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(596, 214);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 80);
            this.panel4.TabIndex = 5;
            // 
            // PointsPerBlock
            // 
            this.PointsPerBlock.Location = new System.Drawing.Point(96, 58);
            this.PointsPerBlock.Name = "PointsPerBlock";
            this.PointsPerBlock.Size = new System.Drawing.Size(67, 20);
            this.PointsPerBlock.TabIndex = 8;
            this.PointsPerBlock.Text = "100";
            this.PointsPerBlock.TextChanged += new System.EventHandler(this.PointsPerBlock_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Points per Block";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Acquisition Rate";
            // 
            // Acqusition_Rate
            // 
            this.Acqusition_Rate.Location = new System.Drawing.Point(96, 3);
            this.Acqusition_Rate.Name = "Acqusition_Rate";
            this.Acqusition_Rate.Size = new System.Drawing.Size(67, 20);
            this.Acqusition_Rate.TabIndex = 6;
            this.Acqusition_Rate.TextChanged += new System.EventHandler(this.Acqusition_Rate_TextChanged);
            // 
            // AcquisitionRateTrackBar1
            // 
            this.AcquisitionRateTrackBar1.Location = new System.Drawing.Point(4, 29);
            this.AcquisitionRateTrackBar1.Maximum = 100;
            this.AcquisitionRateTrackBar1.Name = "AcquisitionRateTrackBar1";
            this.AcquisitionRateTrackBar1.Size = new System.Drawing.Size(182, 45);
            this.AcquisitionRateTrackBar1.TabIndex = 6;
            this.AcquisitionRateTrackBar1.Value = 50;
            this.AcquisitionRateTrackBar1.Scroll += new System.EventHandler(this.AcuisitionRateTrackBar1_Scroll);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.VoltageScaleTrackBar);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.VoltageScale);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(596, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 64);
            this.panel3.TabIndex = 4;
            // 
            // VoltageScaleTrackBar
            // 
            this.VoltageScaleTrackBar.Location = new System.Drawing.Point(4, 29);
            this.VoltageScaleTrackBar.Maximum = 100;
            this.VoltageScaleTrackBar.Name = "VoltageScaleTrackBar";
            this.VoltageScaleTrackBar.Size = new System.Drawing.Size(182, 45);
            this.VoltageScaleTrackBar.TabIndex = 4;
            this.VoltageScaleTrackBar.Value = 50;
            this.VoltageScaleTrackBar.Scroll += new System.EventHandler(this.VoltageScaleTrackBar_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Voltage Scale";
            // 
            // VoltageScale
            // 
            this.VoltageScale.Location = new System.Drawing.Point(96, 3);
            this.VoltageScale.Name = "VoltageScale";
            this.VoltageScale.Size = new System.Drawing.Size(67, 20);
            this.VoltageScale.TabIndex = 4;
            this.VoltageScale.TextChanged += new System.EventHandler(this.VoltageScale_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TimeScaleTrackBar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TimeScale);
            this.panel1.Location = new System.Drawing.Point(596, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 56);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ms";
            // 
            // TimeScaleTrackBar
            // 
            this.TimeScaleTrackBar.Location = new System.Drawing.Point(3, 29);
            this.TimeScaleTrackBar.Maximum = 100;
            this.TimeScaleTrackBar.Name = "TimeScaleTrackBar";
            this.TimeScaleTrackBar.Size = new System.Drawing.Size(182, 45);
            this.TimeScaleTrackBar.TabIndex = 2;
            this.TimeScaleTrackBar.Value = 50;
            this.TimeScaleTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Scale";
            // 
            // TimeScale
            // 
            this.TimeScale.Location = new System.Drawing.Point(96, 3);
            this.TimeScale.Name = "TimeScale";
            this.TimeScale.Size = new System.Drawing.Size(66, 20);
            this.TimeScale.TabIndex = 0;
            this.TimeScale.TextChanged += new System.EventHandler(this.TimeScale_TextChanged);
            // 
            // Channels_DAC
            // 
            this.Channels_DAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Channels_DAC.Controls.Add(this.channel_4_DAC_Enabled);
            this.Channels_DAC.Controls.Add(this.channel_2_DAC_Enabled);
            this.Channels_DAC.Controls.Add(this.channel_3_DAC_Enabled);
            this.Channels_DAC.Controls.Add(this.channel_1_DAC_Enabled);
            this.Channels_DAC.Location = new System.Drawing.Point(596, 3);
            this.Channels_DAC.Name = "Channels_DAC";
            this.Channels_DAC.Size = new System.Drawing.Size(194, 71);
            this.Channels_DAC.TabIndex = 1;
            // 
            // channel_4_DAC_Enabled
            // 
            this.channel_4_DAC_Enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel_4_DAC_Enabled.AutoSize = true;
            this.channel_4_DAC_Enabled.Location = new System.Drawing.Point(110, 38);
            this.channel_4_DAC_Enabled.Name = "channel_4_DAC_Enabled";
            this.channel_4_DAC_Enabled.Size = new System.Drawing.Size(65, 23);
            this.channel_4_DAC_Enabled.TabIndex = 3;
            this.channel_4_DAC_Enabled.Text = "Channel 4";
            this.channel_4_DAC_Enabled.UseVisualStyleBackColor = true;
            this.channel_4_DAC_Enabled.CheckedChanged += new System.EventHandler(this.channel_4_DAC_Enabled_CheckedChanged);
            // 
            // channel_2_DAC_Enabled
            // 
            this.channel_2_DAC_Enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel_2_DAC_Enabled.AutoSize = true;
            this.channel_2_DAC_Enabled.Location = new System.Drawing.Point(110, 9);
            this.channel_2_DAC_Enabled.Name = "channel_2_DAC_Enabled";
            this.channel_2_DAC_Enabled.Size = new System.Drawing.Size(65, 23);
            this.channel_2_DAC_Enabled.TabIndex = 2;
            this.channel_2_DAC_Enabled.Text = "Channel 2";
            this.channel_2_DAC_Enabled.UseVisualStyleBackColor = true;
            this.channel_2_DAC_Enabled.CheckedChanged += new System.EventHandler(this.channel_2_DAC_Enabled_CheckedChanged);
            // 
            // channel_3_DAC_Enabled
            // 
            this.channel_3_DAC_Enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel_3_DAC_Enabled.AutoSize = true;
            this.channel_3_DAC_Enabled.Location = new System.Drawing.Point(14, 38);
            this.channel_3_DAC_Enabled.Name = "channel_3_DAC_Enabled";
            this.channel_3_DAC_Enabled.Size = new System.Drawing.Size(65, 23);
            this.channel_3_DAC_Enabled.TabIndex = 1;
            this.channel_3_DAC_Enabled.Text = "Channel 3";
            this.channel_3_DAC_Enabled.UseVisualStyleBackColor = true;
            this.channel_3_DAC_Enabled.CheckedChanged += new System.EventHandler(this.channel_3_DAC_Enabled_CheckedChanged);
            // 
            // channel_1_DAC_Enabled
            // 
            this.channel_1_DAC_Enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel_1_DAC_Enabled.AutoSize = true;
            this.channel_1_DAC_Enabled.Checked = true;
            this.channel_1_DAC_Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.channel_1_DAC_Enabled.Location = new System.Drawing.Point(14, 9);
            this.channel_1_DAC_Enabled.Name = "channel_1_DAC_Enabled";
            this.channel_1_DAC_Enabled.Size = new System.Drawing.Size(65, 23);
            this.channel_1_DAC_Enabled.TabIndex = 0;
            this.channel_1_DAC_Enabled.Text = "Channel 1";
            this.channel_1_DAC_Enabled.UseVisualStyleBackColor = true;
            this.channel_1_DAC_Enabled.CheckedChanged += new System.EventHandler(this.channel_1_DAC_Enabled_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.Channels_DAC, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Oscilloscope_zgc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.30957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.06925F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 559);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oscilloscope_toolstrip_rescale,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2MinSize = 22;
            this.splitContainer1.Size = new System.Drawing.Size(793, 585);
            this.splitContainer1.SplitterDistance = 559;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 3);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(442, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(185, 16);
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Oscilloscope";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Oscilloscope";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Oscilloscope_closed);
            this.Load += new System.EventHandler(this.Oscilloscope_Load);
            this.Resize += new System.EventHandler(this.OscilloscopeResize);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AcquisitionRateTrackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VoltageScaleTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleTrackBar)).EndInit();
            this.Channels_DAC.ResumeLayout(false);
            this.Channels_DAC.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private ZedGraph.ZedGraphControl Oscilloscope_zgc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Channels_DAC;
        private System.Windows.Forms.CheckBox channel_4_DAC_Enabled;
        private System.Windows.Forms.CheckBox channel_2_DAC_Enabled;
        private System.Windows.Forms.CheckBox channel_3_DAC_Enabled;
        private System.Windows.Forms.CheckBox channel_1_DAC_Enabled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TimeScaleTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TimeScale;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar VoltageScaleTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VoltageScale;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox PointsPerBlock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Acqusition_Rate;
        private System.Windows.Forms.TrackBar AcquisitionRateTrackBar1;
        private System.Windows.Forms.CheckBox RawDataRecording;
        private System.Windows.Forms.CheckBox RecordingInFile_Enabled;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox FolderName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TimeLimit;
        private System.Windows.Forms.CheckBox RecordTime_Limit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox filename_textbox;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton oscilloscope_toolstrip_rescale;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;



    }
}