namespace FANS
{
    partial class AutomatedApplyVoltage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FastGateBack = new System.Windows.Forms.Button();
            this.GateBack = new System.Windows.Forms.Button();
            this.FastGateForward = new System.Windows.Forms.Button();
            this.GateForward = new System.Windows.Forms.Button();
            this.SwitchGateVoltage = new System.Windows.Forms.Button();
            this.StopGateVoltage = new System.Windows.Forms.Button();
            this.SetGateVoltage = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Tolerance2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GateActualVoltage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GateTargetVoltage = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FastBackSample = new System.Windows.Forms.Button();
            this.BackSample = new System.Windows.Forms.Button();
            this.FastForwardSample = new System.Windows.Forms.Button();
            this.ForwardSample = new System.Windows.Forms.Button();
            this.SwitchSampleVoltage = new System.Windows.Forms.Button();
            this.StopGoing1 = new System.Windows.Forms.Button();
            this.SetSampleVoltage = new System.Windows.Forms.Button();
            this.Tolerancelbl = new System.Windows.Forms.Label();
            this.Tolerance1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ActualSampleVoltage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TargetSampleVoltage = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RelayChannel2 = new System.Windows.Forms.ComboBox();
            this.MotorChannel2 = new System.Windows.Forms.ComboBox();
            this.FeedbackChannel2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RelayChannel1 = new System.Windows.Forms.ComboBox();
            this.MotorChannel1 = new System.Windows.Forms.ComboBox();
            this.FeedbackChannel1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(179, 279);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(171, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Voltages";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FastGateBack);
            this.groupBox4.Controls.Add(this.GateBack);
            this.groupBox4.Controls.Add(this.FastGateForward);
            this.groupBox4.Controls.Add(this.GateForward);
            this.groupBox4.Controls.Add(this.SwitchGateVoltage);
            this.groupBox4.Controls.Add(this.StopGateVoltage);
            this.groupBox4.Controls.Add(this.SetGateVoltage);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.Tolerance2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.GateActualVoltage);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.GateTargetVoltage);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 123);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GateVoltage";
            // 
            // FastGateBack
            // 
            this.FastGateBack.Location = new System.Drawing.Point(5, 93);
            this.FastGateBack.Name = "FastGateBack";
            this.FastGateBack.Size = new System.Drawing.Size(34, 23);
            this.FastGateBack.TabIndex = 12;
            this.FastGateBack.Text = "<<";
            this.FastGateBack.UseVisualStyleBackColor = true;
            this.FastGateBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GateFastBackwardMouseDown);
            this.FastGateBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GateFowardBackwardMouseUp);
            // 
            // GateBack
            // 
            this.GateBack.Location = new System.Drawing.Point(45, 93);
            this.GateBack.Name = "GateBack";
            this.GateBack.Size = new System.Drawing.Size(34, 23);
            this.GateBack.TabIndex = 11;
            this.GateBack.Text = "<";
            this.GateBack.UseVisualStyleBackColor = true;
            this.GateBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GateBackwardMouseDown);
            this.GateBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GateFowardBackwardMouseUp);
            // 
            // FastGateForward
            // 
            this.FastGateForward.Location = new System.Drawing.Point(125, 93);
            this.FastGateForward.Name = "FastGateForward";
            this.FastGateForward.Size = new System.Drawing.Size(34, 23);
            this.FastGateForward.TabIndex = 10;
            this.FastGateForward.Text = ">>";
            this.FastGateForward.UseVisualStyleBackColor = true;
            this.FastGateForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GateFastForwardMouseDown);
            this.FastGateForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GateFowardBackwardMouseUp);
            // 
            // GateForward
            // 
            this.GateForward.Location = new System.Drawing.Point(85, 93);
            this.GateForward.Name = "GateForward";
            this.GateForward.Size = new System.Drawing.Size(34, 23);
            this.GateForward.TabIndex = 9;
            this.GateForward.Text = ">";
            this.GateForward.UseVisualStyleBackColor = true;
            this.GateForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GateForwardMouseDown);
            this.GateForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GateFowardBackwardMouseUp);
            // 
            // SwitchGateVoltage
            // 
            this.SwitchGateVoltage.Location = new System.Drawing.Point(114, 65);
            this.SwitchGateVoltage.Name = "SwitchGateVoltage";
            this.SwitchGateVoltage.Size = new System.Drawing.Size(50, 23);
            this.SwitchGateVoltage.TabIndex = 8;
            this.SwitchGateVoltage.Text = "Switch";
            this.SwitchGateVoltage.UseVisualStyleBackColor = true;
            this.SwitchGateVoltage.Click += new System.EventHandler(this.SwitchGateVoltage_Click);
            // 
            // StopGateVoltage
            // 
            this.StopGateVoltage.Location = new System.Drawing.Point(115, 39);
            this.StopGateVoltage.Name = "StopGateVoltage";
            this.StopGateVoltage.Size = new System.Drawing.Size(50, 23);
            this.StopGateVoltage.TabIndex = 7;
            this.StopGateVoltage.Text = "Stop";
            this.StopGateVoltage.UseVisualStyleBackColor = true;
            this.StopGateVoltage.Click += new System.EventHandler(this.StopGoing1_Click);
            // 
            // SetGateVoltage
            // 
            this.SetGateVoltage.Location = new System.Drawing.Point(115, 12);
            this.SetGateVoltage.Name = "SetGateVoltage";
            this.SetGateVoltage.Size = new System.Drawing.Size(50, 23);
            this.SetGateVoltage.TabIndex = 6;
            this.SetGateVoltage.Text = "Go!";
            this.SetGateVoltage.UseVisualStyleBackColor = true;
            this.SetGateVoltage.Click += new System.EventHandler(this.SetGateVoltage_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tolerance";
            // 
            // Tolerance2
            // 
            this.Tolerance2.Location = new System.Drawing.Point(68, 67);
            this.Tolerance2.Name = "Tolerance2";
            this.Tolerance2.Size = new System.Drawing.Size(40, 20);
            this.Tolerance2.TabIndex = 4;
            this.Tolerance2.Text = "0.001";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Actual";
            // 
            // GateActualVoltage
            // 
            this.GateActualVoltage.Location = new System.Drawing.Point(50, 41);
            this.GateActualVoltage.Name = "GateActualVoltage";
            this.GateActualVoltage.Size = new System.Drawing.Size(58, 20);
            this.GateActualVoltage.TabIndex = 2;
            this.GateActualVoltage.Text = "0";
            this.GateActualVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Target";
            // 
            // GateTargetVoltage
            // 
            this.GateTargetVoltage.Location = new System.Drawing.Point(50, 14);
            this.GateTargetVoltage.Name = "GateTargetVoltage";
            this.GateTargetVoltage.Size = new System.Drawing.Size(58, 20);
            this.GateTargetVoltage.TabIndex = 0;
            this.GateTargetVoltage.Text = "0";
            this.GateTargetVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FastBackSample);
            this.groupBox3.Controls.Add(this.BackSample);
            this.groupBox3.Controls.Add(this.FastForwardSample);
            this.groupBox3.Controls.Add(this.ForwardSample);
            this.groupBox3.Controls.Add(this.SwitchSampleVoltage);
            this.groupBox3.Controls.Add(this.StopGoing1);
            this.groupBox3.Controls.Add(this.SetSampleVoltage);
            this.groupBox3.Controls.Add(this.Tolerancelbl);
            this.groupBox3.Controls.Add(this.Tolerance1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ActualSampleVoltage);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TargetSampleVoltage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(165, 123);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sample Voltage";
            // 
            // FastBackSample
            // 
            this.FastBackSample.Location = new System.Drawing.Point(5, 93);
            this.FastBackSample.Name = "FastBackSample";
            this.FastBackSample.Size = new System.Drawing.Size(34, 23);
            this.FastBackSample.TabIndex = 12;
            this.FastBackSample.Text = "<<";
            this.FastBackSample.UseVisualStyleBackColor = true;
            this.FastBackSample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SampleFastBackwardMouseDown);
            this.FastBackSample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ForwardBackwardSampleMouseUp);
            // 
            // BackSample
            // 
            this.BackSample.Location = new System.Drawing.Point(45, 93);
            this.BackSample.Name = "BackSample";
            this.BackSample.Size = new System.Drawing.Size(34, 23);
            this.BackSample.TabIndex = 11;
            this.BackSample.Text = "<";
            this.BackSample.UseVisualStyleBackColor = true;
            this.BackSample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SampleBackwardMouseDown);
            this.BackSample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ForwardBackwardSampleMouseUp);
            // 
            // FastForwardSample
            // 
            this.FastForwardSample.Location = new System.Drawing.Point(125, 93);
            this.FastForwardSample.Name = "FastForwardSample";
            this.FastForwardSample.Size = new System.Drawing.Size(34, 23);
            this.FastForwardSample.TabIndex = 10;
            this.FastForwardSample.Text = ">>";
            this.FastForwardSample.UseVisualStyleBackColor = true;
            this.FastForwardSample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SampleFastForwardMouseDown);
            this.FastForwardSample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ForwardBackwardSampleMouseUp);
            // 
            // ForwardSample
            // 
            this.ForwardSample.Location = new System.Drawing.Point(85, 93);
            this.ForwardSample.Name = "ForwardSample";
            this.ForwardSample.Size = new System.Drawing.Size(34, 23);
            this.ForwardSample.TabIndex = 9;
            this.ForwardSample.Text = ">";
            this.ForwardSample.UseVisualStyleBackColor = true;
            this.ForwardSample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ForwardMouseDown);
            this.ForwardSample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ForwardBackwardSampleMouseUp);
            // 
            // SwitchSampleVoltage
            // 
            this.SwitchSampleVoltage.Location = new System.Drawing.Point(114, 65);
            this.SwitchSampleVoltage.Name = "SwitchSampleVoltage";
            this.SwitchSampleVoltage.Size = new System.Drawing.Size(50, 23);
            this.SwitchSampleVoltage.TabIndex = 8;
            this.SwitchSampleVoltage.Text = "Switch";
            this.SwitchSampleVoltage.UseVisualStyleBackColor = true;
            this.SwitchSampleVoltage.Click += new System.EventHandler(this.SwitchSampleVoltage_Click);
            // 
            // StopGoing1
            // 
            this.StopGoing1.Location = new System.Drawing.Point(115, 39);
            this.StopGoing1.Name = "StopGoing1";
            this.StopGoing1.Size = new System.Drawing.Size(50, 23);
            this.StopGoing1.TabIndex = 7;
            this.StopGoing1.Text = "Stop";
            this.StopGoing1.UseVisualStyleBackColor = true;
            this.StopGoing1.Click += new System.EventHandler(this.StopGoing1_Click);
            // 
            // SetSampleVoltage
            // 
            this.SetSampleVoltage.Location = new System.Drawing.Point(115, 12);
            this.SetSampleVoltage.Name = "SetSampleVoltage";
            this.SetSampleVoltage.Size = new System.Drawing.Size(50, 23);
            this.SetSampleVoltage.TabIndex = 6;
            this.SetSampleVoltage.Text = "Go!";
            this.SetSampleVoltage.UseVisualStyleBackColor = true;
            this.SetSampleVoltage.Click += new System.EventHandler(this.SetSampleVoltage_Click);
            // 
            // Tolerancelbl
            // 
            this.Tolerancelbl.AutoSize = true;
            this.Tolerancelbl.Location = new System.Drawing.Point(7, 70);
            this.Tolerancelbl.Name = "Tolerancelbl";
            this.Tolerancelbl.Size = new System.Drawing.Size(55, 13);
            this.Tolerancelbl.TabIndex = 5;
            this.Tolerancelbl.Text = "Tolerance";
            // 
            // Tolerance1
            // 
            this.Tolerance1.Location = new System.Drawing.Point(68, 67);
            this.Tolerance1.Name = "Tolerance1";
            this.Tolerance1.Size = new System.Drawing.Size(40, 20);
            this.Tolerance1.TabIndex = 4;
            this.Tolerance1.Text = "0.001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Actual";
            // 
            // ActualSampleVoltage
            // 
            this.ActualSampleVoltage.Location = new System.Drawing.Point(50, 41);
            this.ActualSampleVoltage.Name = "ActualSampleVoltage";
            this.ActualSampleVoltage.Size = new System.Drawing.Size(58, 20);
            this.ActualSampleVoltage.TabIndex = 2;
            this.ActualSampleVoltage.Text = "0";
            this.ActualSampleVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Target";
            // 
            // TargetSampleVoltage
            // 
            this.TargetSampleVoltage.Location = new System.Drawing.Point(50, 14);
            this.TargetSampleVoltage.Name = "TargetSampleVoltage";
            this.TargetSampleVoltage.Size = new System.Drawing.Size(58, 20);
            this.TargetSampleVoltage.TabIndex = 0;
            this.TargetSampleVoltage.Text = "0";
            this.TargetSampleVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(171, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RelayChannel2);
            this.groupBox2.Controls.Add(this.MotorChannel2);
            this.groupBox2.Controls.Add(this.FeedbackChannel2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gate Voltage";
            // 
            // RelayChannel2
            // 
            this.RelayChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RelayChannel2.FormattingEnabled = true;
            this.RelayChannel2.Items.AddRange(new object[] {
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
            this.RelayChannel2.Location = new System.Drawing.Point(119, 61);
            this.RelayChannel2.Name = "RelayChannel2";
            this.RelayChannel2.Size = new System.Drawing.Size(40, 21);
            this.RelayChannel2.TabIndex = 5;
            // 
            // MotorChannel2
            // 
            this.MotorChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MotorChannel2.FormattingEnabled = true;
            this.MotorChannel2.Items.AddRange(new object[] {
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
            this.MotorChannel2.Location = new System.Drawing.Point(119, 37);
            this.MotorChannel2.Name = "MotorChannel2";
            this.MotorChannel2.Size = new System.Drawing.Size(40, 21);
            this.MotorChannel2.TabIndex = 4;
            // 
            // FeedbackChannel2
            // 
            this.FeedbackChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FeedbackChannel2.FormattingEnabled = true;
            this.FeedbackChannel2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.FeedbackChannel2.Location = new System.Drawing.Point(119, 13);
            this.FeedbackChannel2.Name = "FeedbackChannel2";
            this.FeedbackChannel2.Size = new System.Drawing.Size(40, 21);
            this.FeedbackChannel2.TabIndex = 3;
            this.FeedbackChannel2.SelectedIndexChanged += new System.EventHandler(this.FeedbackChannel2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Relay AO channel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Motor AO channel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Feedback channel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RelayChannel1);
            this.groupBox1.Controls.Add(this.MotorChannel1);
            this.groupBox1.Controls.Add(this.FeedbackChannel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample Voltage";
            // 
            // RelayChannel1
            // 
            this.RelayChannel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RelayChannel1.FormattingEnabled = true;
            this.RelayChannel1.Items.AddRange(new object[] {
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
            this.RelayChannel1.Location = new System.Drawing.Point(119, 61);
            this.RelayChannel1.Name = "RelayChannel1";
            this.RelayChannel1.Size = new System.Drawing.Size(40, 21);
            this.RelayChannel1.TabIndex = 5;
            // 
            // MotorChannel1
            // 
            this.MotorChannel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MotorChannel1.FormattingEnabled = true;
            this.MotorChannel1.Items.AddRange(new object[] {
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
            this.MotorChannel1.Location = new System.Drawing.Point(119, 37);
            this.MotorChannel1.Name = "MotorChannel1";
            this.MotorChannel1.Size = new System.Drawing.Size(40, 21);
            this.MotorChannel1.TabIndex = 4;
            // 
            // FeedbackChannel1
            // 
            this.FeedbackChannel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FeedbackChannel1.FormattingEnabled = true;
            this.FeedbackChannel1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.FeedbackChannel1.Location = new System.Drawing.Point(119, 13);
            this.FeedbackChannel1.Name = "FeedbackChannel1";
            this.FeedbackChannel1.Size = new System.Drawing.Size(40, 21);
            this.FeedbackChannel1.TabIndex = 3;
            this.FeedbackChannel1.SelectedIndexChanged += new System.EventHandler(this.FeedbackChannel1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Relay AO channel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motor AO channel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feedback channel";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerTickMeasureVoltage);
            // 
            // AutomatedApplyVoltage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 279);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AutomatedApplyVoltage";
            this.Text = "Apply Voltage To Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.VisibleChanged += new System.EventHandler(this.visibilityChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox FeedbackChannel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox RelayChannel2;
        private System.Windows.Forms.ComboBox MotorChannel2;
        private System.Windows.Forms.ComboBox FeedbackChannel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox RelayChannel1;
        private System.Windows.Forms.ComboBox MotorChannel1;
        private System.Windows.Forms.Label Tolerancelbl;
        private System.Windows.Forms.TextBox Tolerance1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ActualSampleVoltage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TargetSampleVoltage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button FastGateBack;
        private System.Windows.Forms.Button GateBack;
        private System.Windows.Forms.Button FastGateForward;
        private System.Windows.Forms.Button GateForward;
        private System.Windows.Forms.Button SwitchGateVoltage;
        private System.Windows.Forms.Button StopGateVoltage;
        private System.Windows.Forms.Button SetGateVoltage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tolerance2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox GateActualVoltage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox GateTargetVoltage;
        private System.Windows.Forms.Button FastBackSample;
        private System.Windows.Forms.Button BackSample;
        private System.Windows.Forms.Button FastForwardSample;
        private System.Windows.Forms.Button ForwardSample;
        private System.Windows.Forms.Button SwitchSampleVoltage;
        private System.Windows.Forms.Button StopGoing1;
        private System.Windows.Forms.Button SetSampleVoltage;
        private System.Windows.Forms.Timer timer1;
    }
}