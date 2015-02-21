using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using FANS.interfaces;
using FANS.classes;
using System.Threading;
using System.IO;
using ZedGraph;
using System.Diagnostics;
namespace FANS
{  
    
    public partial class Main : Form
    {

        Oscilloscope Oscilloscope_Form;
        VoltagesControl VoltagesControl_Form;
        ChannelProperties ChannelProperties_Form;
        NoiseSpectra NoiseSpectra_Form;
        OutputControl OutputControl_Form;
        AutomatedApplyVoltage AutomatedApplyVoltage_Form;
        NoiseMeasurementAutomation NoiseMeasurementAutomation_Form;

        public Main()
        {
            InitializeComponent();
            Oscilloscope_Form = new Oscilloscope();
            Oscilloscope_Form.MdiParent = this;

            VoltagesControl_Form = new VoltagesControl();
            VoltagesControl_Form.MdiParent = this;

            ChannelProperties_Form = new ChannelProperties();
            ChannelProperties_Form.MdiParent = this;

            NoiseSpectra_Form = new NoiseSpectra();
            NoiseSpectra_Form.MdiParent = this;

            OutputControl_Form = new OutputControl();
            OutputControl_Form.MdiParent = this;

            AutomatedApplyVoltage_Form=new AutomatedApplyVoltage();
            AutomatedApplyVoltage_Form.MdiParent = this;

            NoiseMeasurementAutomation_Form = new NoiseMeasurementAutomation(NoiseSpectra_Form);
            NoiseMeasurementAutomation_Form.MdiParent = this;
        }



        private void oscilloscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(Oscilloscope_Form.Visible)
              Oscilloscope_Form.Visible = false;
            else
              Oscilloscope_Form.Visible = true;
        }

        private void Main_Window_Close(object sender, FormClosingEventArgs e)
        {
            foreach (Form child in this.MdiChildren)
                child.Close();
            Application.Exit();
        }

        private void connectToDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agilent_USB_DAQ.Instance.Open("USB0::0x0957::0x1718::TW52524501::INSTR");
            Agilent_USB_DAQ.Instance.WriteString("*CLS");
            Agilent_USB_DAQ.Instance.WriteString("*RST");
            Agilent_USB_DAQ.Instance.WriteString("*IDN?");
            MessageBox.Show(Agilent_USB_DAQ.Instance.ReadString());
            
        }

       

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ApplyingVoltage z = new ApplyingVoltage();
            //z.ApplyVoltage(2, 1, 1, 2);
            ApplyingVoltage a = new ApplyingVoltage(1, 1, 2, 0.001);
            a.ApplyVoltageInThread(0);
           
            //z.ApplyVoltage(-2, 1, 1, 2);
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasurementThread.Instance.StopThread();
        }
        private void voltageControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoltagesControl_Form.Visible = VoltagesControl_Form.Visible ^ true;
        }

        private void channelPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChannelProperties_Form.Visible = ChannelProperties_Form.Visible ^ true;
        }

        private void noiseSpectraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiseSpectra_Form.Visible = NoiseSpectra_Form.Visible ^ true;

        }

        private void outputControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputControl_Form.Visible = OutputControl_Form.Visible ^ true;
        }

        private void noiseMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiseSpectra_Form.Visible = NoiseSpectra_Form.Visible ^ true;
        }

        private void timeTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Oscilloscope_Form.Visible)
                Oscilloscope_Form.Visible = false;
            else
                Oscilloscope_Form.Visible = true;
        }

        private void voltageControlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VoltagesControl_Form.Visible = VoltagesControl_Form.Visible ^ true;
        }

        private void applyVoltageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutomatedApplyVoltage_Form.Visible = AutomatedApplyVoltage_Form.Visible ^ true;
        }

        private void noiseMeasurementAutomationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiseMeasurementAutomation_Form.Visible = NoiseMeasurementAutomation_Form.Visible ^ true;
        }

 

    }
}
