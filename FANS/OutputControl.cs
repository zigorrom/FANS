using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using FANS.classes;
namespace FANS
{
    public partial class OutputControl : Form
    {
        public OutputControl()
        {
            InitializeComponent();
            
            
        }

        private void OutputControl_Load(object sender, EventArgs e)
        {

        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
            this.Visible = false;
        }

        private void channel1_CheckedChanged(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += channel1_CheckedChanged; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= channel1_CheckedChanged;
            
            setChannel1Parameters();
        }
        private void channel2_CheckedChanged(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += channel2_CheckedChanged; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= channel2_CheckedChanged;
            
            setChannel2Parameters();
        }
        private void setChannel1Parameters()
        {
            double DC = TryParse(DC_Channel1.Text);
            double AC = TryParse(AC_Channel1.Text);
            double Freq = TryParse(Freq_channel1.Text);
            if ((DC_Channel1.Text != "0") && (DC == 0)) return; if ((AC_Channel1.Text != "0") && (AC == 0)) return; if ((Freq_channel1.Text != "0") && (Freq == 0)) return;

            if ((AC == 0) || (Freq == 0))
            {
                AO_Channels.Instance.SetDC_Output_To_Certain_Channel(GetChannel1_OutputNumber(), DC);
            }
            else
            {
                if (DC == 0)
                {
                    AO_Channels.Instance.SetAC_Output_To_Certain_Channel(GetChannel1_OutputNumber(), AC, (int)Freq);
                }
                else
                {
                    AO_Channels.Instance.SetAC_Output_To_Certain_Channel(GetChannel1_OutputNumber(), AC, (int)Freq, DC);
                }
            }
        }
        public void setChannel2Parameters()
        {
            double DC = TryParse(DC_Channel2.Text);
            double AC = TryParse(AC_Channel2.Text);
            double Freq = TryParse(Freq_channel2.Text);
            if ((DC_Channel2.Text != "0") && (DC == 0)) return; if ((AC_Channel2.Text != "0") && (AC == 0)) return; if ((Freq_channel2.Text != "0") && (Freq == 0)) return;

            if ((AC == 0) || (Freq == 0))
            {
                AO_Channels.Instance.SetDC_Output_To_Certain_Channel(GetChannel2_OutputNumber(), DC);
            }
            else
            {
                if (DC == 0)
                {
                    AO_Channels.Instance.SetAC_Output_To_Certain_Channel(GetChannel2_OutputNumber(), AC, (int)Freq);
                }
                else
                {
                    AO_Channels.Instance.SetAC_Output_To_Certain_Channel(GetChannel2_OutputNumber(), AC, (int)Freq, DC);
                }
            }
        }
        private int GetChannel2_OutputNumber()
        {
            var buttons = groupBox2.Controls.OfType<RadioButton>()
                          .FirstOrDefault(n => n.Checked);
            int id = Convert.ToInt32(buttons.Name.Replace("channel", ""));
            return id;
        }
        private int GetChannel1_OutputNumber()
        {
            var buttons = groupBox1.Controls.OfType<RadioButton>()
                          .FirstOrDefault(n => n.Checked);
            int id = Convert.ToInt32(buttons.Name.Replace("channel", ""));
            return id;
        }
        private double TryParse(string text)
        {
            double result;
            try
            {
                result = Double.Parse(text, ImportantConstants.NumberFormat());

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
                return result;
            
        }

        private void channel1enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += channel1enabled_CheckedChanged; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= channel1enabled_CheckedChanged;

            AO_Channels.Instance.Channels[1].Enabled = channel1enabled.Checked;
            AO_Channels.Instance.ReloadChannelsToLatch();
            if (channel1enabled.Checked) setChannel1Parameters();
            var radios_ch1 = groupBox1.Controls.OfType<RadioButton>();
            var texts_ch1 = groupBox1.Controls.OfType<TextBox>();
            foreach (var d in radios_ch1)
            {
                d.Enabled = channel1enabled.Checked;
            }
            foreach (var d in texts_ch1)
            {
                d.Enabled = channel1enabled.Checked;
            }


        }

        private void channel2enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += channel2enabled_CheckedChanged; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= channel2enabled_CheckedChanged;
            
            AO_Channels.Instance.Channels[0].Enabled = channel2enabled.Checked;
            AO_Channels.Instance.ReloadChannelsToLatch();
            if (channel2enabled.Checked) setChannel2Parameters();
            var radios_ch2 = groupBox2.Controls.OfType<RadioButton>();
            var texts_ch2 = groupBox2.Controls.OfType<TextBox>();
            foreach (var d in radios_ch2)
            {
                d.Enabled = channel2enabled.Checked;
            }
            foreach (var d in texts_ch2)
            {
                d.Enabled = channel2enabled.Checked;
            }
        }

        private void OutputChangedFromOutside(object sender, VoltageAdjustment_EventArgs e)
        {
            if (e.channelNumber <= 8)
            {
                SetTextChannel1ThreadSafe(DC_Channel1, e.DC.ToString("G3"));
                SetTextChannel1ThreadSafe(AC_Channel1, e.AC.ToString("G3"));
                SetTextChannel1ThreadSafe(Freq_channel1, e.FREQ.ToString("G3"));
            }
            if (e.channelNumber > 8)
            {
                SetTextChannel2ThreadSafe(DC_Channel2, e.DC.ToString("G3"));
                SetTextChannel2ThreadSafe(AC_Channel2, e.AC.ToString("G3"));
                SetTextChannel2ThreadSafe(Freq_channel2, e.FREQ.ToString("G3"));
            }
            CheckRadioButtonThreadSafe(e.channelNumber);
        }

        delegate void SetTextCallback(TextBox a, string text);
        private void SetTextChannel1ThreadSafe(TextBox a, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (a.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextChannel1ThreadSafe);
                this.BeginInvoke(d, new object[] { a, text });
            }
            else
            {
                a.TextChanged -= channel1_CheckedChanged;
                a.Text = text;
                a.TextChanged += channel1_CheckedChanged;
            }
        }
        private void SetTextChannel2ThreadSafe(TextBox a, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (a.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextChannel2ThreadSafe);
                this.BeginInvoke(d, new object[] { a, text });
            }
            else
            {
                a.TextChanged -= channel2_CheckedChanged;
                a.Text = text;
                a.TextChanged += channel2_CheckedChanged;
            }
        }
        private void CheckRadioButtonThreadSafe(int number)
        {
            RadioButton button = new RadioButton();
            if (number > 8)
            {
                button = groupBox2.Controls.OfType<RadioButton>()
                             .FirstOrDefault(n => n.Name == "channel" + number);
                button.Click -= channel2_CheckedChanged;
                CheckRadioButtonThreadSafe(button);
                button.Click += channel2_CheckedChanged;

            }
            if (number <= 8)
            {
                button = groupBox1.Controls.OfType<RadioButton>()
                          .FirstOrDefault(n => n.Name == "channel" + number);
                button.Click -= channel1_CheckedChanged;
                CheckRadioButtonThreadSafe(button);
                button.Click += channel1_CheckedChanged;
            }
            
        }
        public static void CheckRadioButtonThreadSafe(RadioButton Button)
        {
            if (Button.InvokeRequired)
            {
                Action<RadioButton> deleg = new Action<RadioButton>(CheckRadioButtonThreadSafe);
                Button.Invoke(deleg, new object[] { Button });

            }
            else
            {
                Button.Checked = true;
            }
        }

        private void VisibleChanged1(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                AllCustomEvents.Instance.OutputStatusChanged += OutputChangedFromOutside;
            }
            else
                AllCustomEvents.Instance.OutputStatusChanged -= OutputChangedFromOutside;
        }
    }
}
