namespace FANS
{
    partial class ChannelProperties
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
            this.Frequency_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ch_4 = new System.Windows.Forms.RadioButton();
            this.Ch_3 = new System.Windows.Forms.RadioButton();
            this.Ch_2 = new System.Windows.Forms.RadioButton();
            this.Ch_1 = new System.Windows.Forms.RadioButton();
            this.Filter_Gain = new System.Windows.Forms.ComboBox();
            this.PGA_Gain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HomeMadeAmplifier_CheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Frequency_ComboBox
            // 
            this.Frequency_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Frequency_ComboBox.FormattingEnabled = true;
            this.Frequency_ComboBox.Items.AddRange(new object[] {
            "10 kHz",
            "20 kHz",
            "30 kHz",
            "40 kHz",
            "50 kHz",
            "60 kHz",
            "70 kHz",
            "80 kHz",
            "90 kHz",
            "100 kHz",
            "110 kHz",
            "120 kHz",
            "130 kHz",
            "140 kHz",
            "150 kHz"});
            this.Frequency_ComboBox.Location = new System.Drawing.Point(69, 61);
            this.Frequency_ComboBox.Name = "Frequency_ComboBox";
            this.Frequency_ComboBox.Size = new System.Drawing.Size(77, 21);
            this.Frequency_ComboBox.TabIndex = 0;
            this.Frequency_ComboBox.SelectedValueChanged += new System.EventHandler(this.SomeValuerChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter Gain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Tag = "Programmable Gain Amplifier Gain";
            this.label3.Text = "PGA Gain:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ch_4);
            this.groupBox1.Controls.Add(this.Ch_3);
            this.groupBox1.Controls.Add(this.Ch_2);
            this.groupBox1.Controls.Add(this.Ch_1);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // Ch_4
            // 
            this.Ch_4.AutoSize = true;
            this.Ch_4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_4.Location = new System.Drawing.Point(98, 11);
            this.Ch_4.Name = "Ch_4";
            this.Ch_4.Size = new System.Drawing.Size(33, 30);
            this.Ch_4.TabIndex = 3;
            this.Ch_4.TabStop = true;
            this.Ch_4.Text = "Ch 4";
            this.Ch_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_4.UseVisualStyleBackColor = true;
            this.Ch_4.Click += new System.EventHandler(this.Ch_RadioButtonClick);
            // 
            // Ch_3
            // 
            this.Ch_3.AutoSize = true;
            this.Ch_3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_3.Location = new System.Drawing.Point(67, 11);
            this.Ch_3.Name = "Ch_3";
            this.Ch_3.Size = new System.Drawing.Size(33, 30);
            this.Ch_3.TabIndex = 2;
            this.Ch_3.TabStop = true;
            this.Ch_3.Text = "Ch 3";
            this.Ch_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_3.UseVisualStyleBackColor = true;
            this.Ch_3.Click += new System.EventHandler(this.Ch_RadioButtonClick);
            // 
            // Ch_2
            // 
            this.Ch_2.AutoSize = true;
            this.Ch_2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_2.Location = new System.Drawing.Point(36, 11);
            this.Ch_2.Name = "Ch_2";
            this.Ch_2.Size = new System.Drawing.Size(33, 30);
            this.Ch_2.TabIndex = 1;
            this.Ch_2.TabStop = true;
            this.Ch_2.Text = "Ch 2";
            this.Ch_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_2.UseVisualStyleBackColor = true;
            this.Ch_2.Click += new System.EventHandler(this.Ch_RadioButtonClick);
            // 
            // Ch_1
            // 
            this.Ch_1.AutoSize = true;
            this.Ch_1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_1.Location = new System.Drawing.Point(6, 11);
            this.Ch_1.Name = "Ch_1";
            this.Ch_1.Size = new System.Drawing.Size(33, 30);
            this.Ch_1.TabIndex = 0;
            this.Ch_1.TabStop = true;
            this.Ch_1.Text = "Ch 1";
            this.Ch_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Ch_1.UseVisualStyleBackColor = true;
            this.Ch_1.Click += new System.EventHandler(this.Ch_RadioButtonClick);
            // 
            // Filter_Gain
            // 
            this.Filter_Gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Filter_Gain.FormattingEnabled = true;
            this.Filter_Gain.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.Filter_Gain.Location = new System.Drawing.Point(69, 86);
            this.Filter_Gain.Name = "Filter_Gain";
            this.Filter_Gain.Size = new System.Drawing.Size(77, 21);
            this.Filter_Gain.TabIndex = 5;
            this.Filter_Gain.SelectedValueChanged += new System.EventHandler(this.SomeValuerChanged);
            // 
            // PGA_Gain
            // 
            this.PGA_Gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PGA_Gain.FormattingEnabled = true;
            this.PGA_Gain.Items.AddRange(new object[] {
            "1",
            "10",
            "100"});
            this.PGA_Gain.Location = new System.Drawing.Point(69, 109);
            this.PGA_Gain.Name = "PGA_Gain";
            this.PGA_Gain.Size = new System.Drawing.Size(77, 21);
            this.PGA_Gain.TabIndex = 6;
            this.PGA_Gain.SelectedValueChanged += new System.EventHandler(this.SomeValuerChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Tag = "Programmable Gain Amplifier Gain";
            this.label4.Text = "Homemade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Tag = "Programmable Gain Amplifier Gain";
            this.label5.Text = "Amplifier";
            // 
            // HomeMadeAmplifier_CheckBox
            // 
            this.HomeMadeAmplifier_CheckBox.AutoSize = true;
            this.HomeMadeAmplifier_CheckBox.Location = new System.Drawing.Point(101, 140);
            this.HomeMadeAmplifier_CheckBox.Name = "HomeMadeAmplifier_CheckBox";
            this.HomeMadeAmplifier_CheckBox.Size = new System.Drawing.Size(15, 14);
            this.HomeMadeAmplifier_CheckBox.TabIndex = 9;
            this.HomeMadeAmplifier_CheckBox.UseVisualStyleBackColor = true;
            this.HomeMadeAmplifier_CheckBox.CheckedChanged += new System.EventHandler(this.SomeValuerChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 170);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(163, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "ready";
            // 
            // ChannelProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 192);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.HomeMadeAmplifier_CheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PGA_Gain);
            this.Controls.Add(this.Filter_Gain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Frequency_ComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChannelProperties";
            this.Text = "ChannelProperties";
            this.Load += new System.EventHandler(this.ChannelProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Frequency_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Ch_4;
        private System.Windows.Forms.RadioButton Ch_3;
        private System.Windows.Forms.RadioButton Ch_2;
        private System.Windows.Forms.RadioButton Ch_1;
        private System.Windows.Forms.ComboBox Filter_Gain;
        private System.Windows.Forms.ComboBox PGA_Gain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox HomeMadeAmplifier_CheckBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}