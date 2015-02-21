namespace FANS
{
    partial class OutputControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.channel1enabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Freq_channel1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AC_Channel1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DC_Channel1 = new System.Windows.Forms.TextBox();
            this.channel8 = new System.Windows.Forms.RadioButton();
            this.channel7 = new System.Windows.Forms.RadioButton();
            this.channel6 = new System.Windows.Forms.RadioButton();
            this.channel5 = new System.Windows.Forms.RadioButton();
            this.channel4 = new System.Windows.Forms.RadioButton();
            this.channel3 = new System.Windows.Forms.RadioButton();
            this.channel2 = new System.Windows.Forms.RadioButton();
            this.channel1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.channel2enabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Freq_channel2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AC_Channel2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DC_Channel2 = new System.Windows.Forms.TextBox();
            this.channel16 = new System.Windows.Forms.RadioButton();
            this.channel15 = new System.Windows.Forms.RadioButton();
            this.channel14 = new System.Windows.Forms.RadioButton();
            this.channel13 = new System.Windows.Forms.RadioButton();
            this.channel12 = new System.Windows.Forms.RadioButton();
            this.channel11 = new System.Windows.Forms.RadioButton();
            this.channel10 = new System.Windows.Forms.RadioButton();
            this.channel9 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.channel1enabled);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Freq_channel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AC_Channel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DC_Channel1);
            this.groupBox1.Controls.Add(this.channel8);
            this.groupBox1.Controls.Add(this.channel7);
            this.groupBox1.Controls.Add(this.channel6);
            this.groupBox1.Controls.Add(this.channel5);
            this.groupBox1.Controls.Add(this.channel4);
            this.groupBox1.Controls.Add(this.channel3);
            this.groupBox1.Controls.Add(this.channel2);
            this.groupBox1.Controls.Add(this.channel1);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel 1 ";
            // 
            // channel1enabled
            // 
            this.channel1enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel1enabled.Checked = true;
            this.channel1enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.channel1enabled.Location = new System.Drawing.Point(6, 97);
            this.channel1enabled.Name = "channel1enabled";
            this.channel1enabled.Size = new System.Drawing.Size(196, 23);
            this.channel1enabled.TabIndex = 19;
            this.channel1enabled.Text = "Enabled";
            this.channel1enabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.channel1enabled.UseVisualStyleBackColor = true;
            this.channel1enabled.CheckedChanged += new System.EventHandler(this.channel1enabled_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Hz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Freq";
            // 
            // Freq_channel1
            // 
            this.Freq_channel1.Location = new System.Drawing.Point(130, 71);
            this.Freq_channel1.Name = "Freq_channel1";
            this.Freq_channel1.Size = new System.Drawing.Size(52, 20);
            this.Freq_channel1.TabIndex = 16;
            this.Freq_channel1.Text = "0";
            this.Freq_channel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Freq_channel1.TextChanged += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "AC";
            // 
            // AC_Channel1
            // 
            this.AC_Channel1.Location = new System.Drawing.Point(130, 45);
            this.AC_Channel1.Name = "AC_Channel1";
            this.AC_Channel1.Size = new System.Drawing.Size(52, 20);
            this.AC_Channel1.TabIndex = 13;
            this.AC_Channel1.Text = "0";
            this.AC_Channel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AC_Channel1.TextChanged += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "V";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "DC";
            // 
            // DC_Channel1
            // 
            this.DC_Channel1.Location = new System.Drawing.Point(130, 19);
            this.DC_Channel1.Name = "DC_Channel1";
            this.DC_Channel1.Size = new System.Drawing.Size(52, 20);
            this.DC_Channel1.TabIndex = 10;
            this.DC_Channel1.Text = "0";
            this.DC_Channel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DC_Channel1.TextChanged += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel8
            // 
            this.channel8.AutoSize = true;
            this.channel8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel8.Location = new System.Drawing.Point(75, 55);
            this.channel8.Name = "channel8";
            this.channel8.Size = new System.Drawing.Size(17, 30);
            this.channel8.TabIndex = 9;
            this.channel8.TabStop = true;
            this.channel8.Text = "8";
            this.channel8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel8.UseVisualStyleBackColor = true;
            this.channel8.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel7
            // 
            this.channel7.AutoSize = true;
            this.channel7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel7.Location = new System.Drawing.Point(52, 55);
            this.channel7.Name = "channel7";
            this.channel7.Size = new System.Drawing.Size(17, 30);
            this.channel7.TabIndex = 8;
            this.channel7.TabStop = true;
            this.channel7.Text = "7";
            this.channel7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel7.UseVisualStyleBackColor = true;
            this.channel7.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel6
            // 
            this.channel6.AutoSize = true;
            this.channel6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel6.Location = new System.Drawing.Point(29, 55);
            this.channel6.Name = "channel6";
            this.channel6.Size = new System.Drawing.Size(17, 30);
            this.channel6.TabIndex = 7;
            this.channel6.TabStop = true;
            this.channel6.Text = "6";
            this.channel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel6.UseVisualStyleBackColor = true;
            this.channel6.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel5
            // 
            this.channel5.AutoSize = true;
            this.channel5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel5.Location = new System.Drawing.Point(6, 55);
            this.channel5.Name = "channel5";
            this.channel5.Size = new System.Drawing.Size(17, 30);
            this.channel5.TabIndex = 6;
            this.channel5.TabStop = true;
            this.channel5.Text = "5";
            this.channel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel5.UseVisualStyleBackColor = true;
            this.channel5.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel4
            // 
            this.channel4.AutoSize = true;
            this.channel4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel4.Location = new System.Drawing.Point(75, 19);
            this.channel4.Name = "channel4";
            this.channel4.Size = new System.Drawing.Size(17, 30);
            this.channel4.TabIndex = 5;
            this.channel4.TabStop = true;
            this.channel4.Text = "4";
            this.channel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel4.UseVisualStyleBackColor = true;
            this.channel4.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel3
            // 
            this.channel3.AutoSize = true;
            this.channel3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel3.Location = new System.Drawing.Point(52, 19);
            this.channel3.Name = "channel3";
            this.channel3.Size = new System.Drawing.Size(17, 30);
            this.channel3.TabIndex = 4;
            this.channel3.TabStop = true;
            this.channel3.Text = "3";
            this.channel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel3.UseVisualStyleBackColor = true;
            this.channel3.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel2
            // 
            this.channel2.AutoSize = true;
            this.channel2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel2.Location = new System.Drawing.Point(29, 19);
            this.channel2.Name = "channel2";
            this.channel2.Size = new System.Drawing.Size(17, 30);
            this.channel2.TabIndex = 3;
            this.channel2.TabStop = true;
            this.channel2.Text = "2";
            this.channel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel2.UseVisualStyleBackColor = true;
            this.channel2.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel1
            // 
            this.channel1.AutoSize = true;
            this.channel1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel1.Location = new System.Drawing.Point(6, 19);
            this.channel1.Name = "channel1";
            this.channel1.Size = new System.Drawing.Size(17, 30);
            this.channel1.TabIndex = 0;
            this.channel1.TabStop = true;
            this.channel1.Text = "1";
            this.channel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel1.UseVisualStyleBackColor = true;
            this.channel1.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.channel2enabled);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Freq_channel2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.AC_Channel2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.DC_Channel2);
            this.groupBox2.Controls.Add(this.channel16);
            this.groupBox2.Controls.Add(this.channel15);
            this.groupBox2.Controls.Add(this.channel14);
            this.groupBox2.Controls.Add(this.channel13);
            this.groupBox2.Controls.Add(this.channel12);
            this.groupBox2.Controls.Add(this.channel11);
            this.groupBox2.Controls.Add(this.channel10);
            this.groupBox2.Controls.Add(this.channel9);
            this.groupBox2.Location = new System.Drawing.Point(5, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 126);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel 2";
            // 
            // channel2enabled
            // 
            this.channel2enabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.channel2enabled.Checked = true;
            this.channel2enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.channel2enabled.Location = new System.Drawing.Point(6, 97);
            this.channel2enabled.Name = "channel2enabled";
            this.channel2enabled.Size = new System.Drawing.Size(196, 23);
            this.channel2enabled.TabIndex = 19;
            this.channel2enabled.Text = "Enabled";
            this.channel2enabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.channel2enabled.UseVisualStyleBackColor = true;
            this.channel2enabled.CheckedChanged += new System.EventHandler(this.channel2enabled_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Hz";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Freq";
            // 
            // Freq_channel2
            // 
            this.Freq_channel2.Location = new System.Drawing.Point(130, 71);
            this.Freq_channel2.Name = "Freq_channel2";
            this.Freq_channel2.Size = new System.Drawing.Size(52, 20);
            this.Freq_channel2.TabIndex = 16;
            this.Freq_channel2.Text = "0";
            this.Freq_channel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Freq_channel2.TextChanged += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "V";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "AC";
            // 
            // AC_Channel2
            // 
            this.AC_Channel2.Location = new System.Drawing.Point(130, 45);
            this.AC_Channel2.Name = "AC_Channel2";
            this.AC_Channel2.Size = new System.Drawing.Size(52, 20);
            this.AC_Channel2.TabIndex = 13;
            this.AC_Channel2.Text = "0";
            this.AC_Channel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AC_Channel2.TextChanged += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "V";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "DC";
            // 
            // DC_Channel2
            // 
            this.DC_Channel2.Location = new System.Drawing.Point(130, 19);
            this.DC_Channel2.Name = "DC_Channel2";
            this.DC_Channel2.Size = new System.Drawing.Size(52, 20);
            this.DC_Channel2.TabIndex = 10;
            this.DC_Channel2.Text = "0";
            this.DC_Channel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DC_Channel2.TextChanged += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel16
            // 
            this.channel16.AutoSize = true;
            this.channel16.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel16.Location = new System.Drawing.Point(75, 55);
            this.channel16.Name = "channel16";
            this.channel16.Size = new System.Drawing.Size(23, 30);
            this.channel16.TabIndex = 9;
            this.channel16.TabStop = true;
            this.channel16.Text = "16";
            this.channel16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel16.UseVisualStyleBackColor = true;
            this.channel16.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel15
            // 
            this.channel15.AutoSize = true;
            this.channel15.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel15.Location = new System.Drawing.Point(52, 55);
            this.channel15.Name = "channel15";
            this.channel15.Size = new System.Drawing.Size(23, 30);
            this.channel15.TabIndex = 8;
            this.channel15.TabStop = true;
            this.channel15.Text = "15";
            this.channel15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel15.UseVisualStyleBackColor = true;
            this.channel15.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel14
            // 
            this.channel14.AutoSize = true;
            this.channel14.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel14.Location = new System.Drawing.Point(29, 55);
            this.channel14.Name = "channel14";
            this.channel14.Size = new System.Drawing.Size(23, 30);
            this.channel14.TabIndex = 7;
            this.channel14.TabStop = true;
            this.channel14.Text = "14";
            this.channel14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel14.UseVisualStyleBackColor = true;
            this.channel14.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel13
            // 
            this.channel13.AutoSize = true;
            this.channel13.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel13.Location = new System.Drawing.Point(6, 55);
            this.channel13.Name = "channel13";
            this.channel13.Size = new System.Drawing.Size(23, 30);
            this.channel13.TabIndex = 6;
            this.channel13.TabStop = true;
            this.channel13.Text = "13";
            this.channel13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel13.UseVisualStyleBackColor = true;
            this.channel13.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel12
            // 
            this.channel12.AutoSize = true;
            this.channel12.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel12.Location = new System.Drawing.Point(75, 19);
            this.channel12.Name = "channel12";
            this.channel12.Size = new System.Drawing.Size(23, 30);
            this.channel12.TabIndex = 5;
            this.channel12.TabStop = true;
            this.channel12.Text = "12";
            this.channel12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel12.UseVisualStyleBackColor = true;
            this.channel12.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel11
            // 
            this.channel11.AutoSize = true;
            this.channel11.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel11.Location = new System.Drawing.Point(52, 19);
            this.channel11.Name = "channel11";
            this.channel11.Size = new System.Drawing.Size(23, 30);
            this.channel11.TabIndex = 4;
            this.channel11.TabStop = true;
            this.channel11.Text = "11";
            this.channel11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel11.UseVisualStyleBackColor = true;
            this.channel11.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel10
            // 
            this.channel10.AutoSize = true;
            this.channel10.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel10.Location = new System.Drawing.Point(29, 19);
            this.channel10.Name = "channel10";
            this.channel10.Size = new System.Drawing.Size(23, 30);
            this.channel10.TabIndex = 3;
            this.channel10.TabStop = true;
            this.channel10.Text = "10";
            this.channel10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel10.UseVisualStyleBackColor = true;
            this.channel10.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // channel9
            // 
            this.channel9.AutoSize = true;
            this.channel9.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.channel9.Checked = true;
            this.channel9.Location = new System.Drawing.Point(10, 19);
            this.channel9.Name = "channel9";
            this.channel9.Size = new System.Drawing.Size(17, 30);
            this.channel9.TabIndex = 0;
            this.channel9.TabStop = true;
            this.channel9.Text = "9";
            this.channel9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.channel9.UseVisualStyleBackColor = true;
            this.channel9.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // OutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 271);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OutputControl";
            this.Text = "OutputControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.Load += new System.EventHandler(this.OutputControl_Load);
            this.VisibleChanged += new System.EventHandler(this.VisibleChanged1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton channel1;
        private System.Windows.Forms.RadioButton channel8;
        private System.Windows.Forms.RadioButton channel7;
        private System.Windows.Forms.RadioButton channel6;
        private System.Windows.Forms.RadioButton channel5;
        private System.Windows.Forms.RadioButton channel4;
        private System.Windows.Forms.RadioButton channel3;
        private System.Windows.Forms.RadioButton channel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Freq_channel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AC_Channel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DC_Channel1;
        private System.Windows.Forms.CheckBox channel1enabled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox channel2enabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Freq_channel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox AC_Channel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox DC_Channel2;
        private System.Windows.Forms.RadioButton channel16;
        private System.Windows.Forms.RadioButton channel15;
        private System.Windows.Forms.RadioButton channel14;
        private System.Windows.Forms.RadioButton channel13;
        private System.Windows.Forms.RadioButton channel12;
        private System.Windows.Forms.RadioButton channel11;
        private System.Windows.Forms.RadioButton channel10;
        private System.Windows.Forms.RadioButton channel9;
    }
}