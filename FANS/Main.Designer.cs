namespace FANS
{
    partial class Main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseMeasurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltageControlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseMeasurementAutomationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyVoltageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.measurementToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.testToolStripMenuItem,
            this.test1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveEnvironmentToolStripMenuItem,
            this.restoreEnvironmentToolStripMenuItem,
            this.connectToDeviceToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // saveEnvironmentToolStripMenuItem
            // 
            this.saveEnvironmentToolStripMenuItem.Name = "saveEnvironmentToolStripMenuItem";
            this.saveEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveEnvironmentToolStripMenuItem.Text = "Save Environment";
            // 
            // restoreEnvironmentToolStripMenuItem
            // 
            this.restoreEnvironmentToolStripMenuItem.Name = "restoreEnvironmentToolStripMenuItem";
            this.restoreEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.restoreEnvironmentToolStripMenuItem.Text = "Restore Environment";
            // 
            // connectToDeviceToolStripMenuItem
            // 
            this.connectToDeviceToolStripMenuItem.Name = "connectToDeviceToolStripMenuItem";
            this.connectToDeviceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.connectToDeviceToolStripMenuItem.Text = "Connect to Device";
            this.connectToDeviceToolStripMenuItem.Click += new System.EventHandler(this.connectToDeviceToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // measurementToolStripMenuItem
            // 
            this.measurementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeTraceToolStripMenuItem,
            this.noiseMeasurementToolStripMenuItem,
            this.voltageControlToolStripMenuItem1,
            this.noiseMeasurementAutomationToolStripMenuItem});
            this.measurementToolStripMenuItem.Name = "measurementToolStripMenuItem";
            this.measurementToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.measurementToolStripMenuItem.Text = "Measurement";
            // 
            // timeTraceToolStripMenuItem
            // 
            this.timeTraceToolStripMenuItem.Name = "timeTraceToolStripMenuItem";
            this.timeTraceToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.timeTraceToolStripMenuItem.Text = "Time Trace";
            this.timeTraceToolStripMenuItem.Click += new System.EventHandler(this.timeTraceToolStripMenuItem_Click);
            // 
            // noiseMeasurementToolStripMenuItem
            // 
            this.noiseMeasurementToolStripMenuItem.Name = "noiseMeasurementToolStripMenuItem";
            this.noiseMeasurementToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.noiseMeasurementToolStripMenuItem.Text = "Noise Measurement";
            this.noiseMeasurementToolStripMenuItem.Click += new System.EventHandler(this.noiseMeasurementToolStripMenuItem_Click);
            // 
            // voltageControlToolStripMenuItem1
            // 
            this.voltageControlToolStripMenuItem1.Name = "voltageControlToolStripMenuItem1";
            this.voltageControlToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.voltageControlToolStripMenuItem1.Text = "Voltage Control";
            this.voltageControlToolStripMenuItem1.Click += new System.EventHandler(this.voltageControlToolStripMenuItem1_Click);
            // 
            // noiseMeasurementAutomationToolStripMenuItem
            // 
            this.noiseMeasurementAutomationToolStripMenuItem.Name = "noiseMeasurementAutomationToolStripMenuItem";
            this.noiseMeasurementAutomationToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.noiseMeasurementAutomationToolStripMenuItem.Text = "Noise Measurement Automation";
            this.noiseMeasurementAutomationToolStripMenuItem.Click += new System.EventHandler(this.noiseMeasurementAutomationToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelPropertiesToolStripMenuItem,
            this.outputControlToolStripMenuItem,
            this.applyVoltageToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // channelPropertiesToolStripMenuItem
            // 
            this.channelPropertiesToolStripMenuItem.Name = "channelPropertiesToolStripMenuItem";
            this.channelPropertiesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.channelPropertiesToolStripMenuItem.Text = "Channel Properties";
            this.channelPropertiesToolStripMenuItem.Click += new System.EventHandler(this.channelPropertiesToolStripMenuItem_Click);
            // 
            // outputControlToolStripMenuItem
            // 
            this.outputControlToolStripMenuItem.Name = "outputControlToolStripMenuItem";
            this.outputControlToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.outputControlToolStripMenuItem.Text = "Output Control";
            this.outputControlToolStripMenuItem.Click += new System.EventHandler(this.outputControlToolStripMenuItem_Click);
            // 
            // applyVoltageToolStripMenuItem
            // 
            this.applyVoltageToolStripMenuItem.Name = "applyVoltageToolStripMenuItem";
            this.applyVoltageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.applyVoltageToolStripMenuItem.Text = "Apply Voltage";
            this.applyVoltageToolStripMenuItem.Click += new System.EventHandler(this.applyVoltageToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.test1ToolStripMenuItem.Text = "test1";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(982, 698);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "FANS - designed by Sergii Pud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Window_Close);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseMeasurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyVoltageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voltageControlToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseMeasurementAutomationToolStripMenuItem;
    }
}

