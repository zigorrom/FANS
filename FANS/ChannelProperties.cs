using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FANS.classes;
namespace FANS
{
   
    public partial class ChannelProperties : Form
    {
        AI_Channel_Parameters _AI_Parameters;
        public ChannelProperties()
        {
            InitializeComponent();

            Frequency_ComboBox.SelectedValueChanged -= SomeValuerChanged;
            Filter_Gain.SelectedValueChanged -= SomeValuerChanged;
            PGA_Gain.SelectedValueChanged -= SomeValuerChanged;
            CurrentAmpGains.SelectedValueChanged -= SomeValuerChanged;
            SecondAmpGains.SelectedValueChanged -= SomeValuerChanged;

            Frequency_ComboBox.SelectedIndex = 9;
            Filter_Gain.SelectedIndex = 0;
            PGA_Gain.SelectedIndex=0;
            CurrentAmpGains.SelectedIndex = 0;
            SecondAmpGains.SelectedIndex = 0;

            Frequency_ComboBox.SelectedValueChanged += SomeValuerChanged;
            Filter_Gain.SelectedValueChanged += SomeValuerChanged;
            PGA_Gain.SelectedValueChanged += SomeValuerChanged;
            CurrentAmpGains.SelectedValueChanged += SomeValuerChanged;
            SecondAmpGains.SelectedValueChanged += SomeValuerChanged;


            AllCustomEvents.Instance.AI_Channel_DigitalParameterChange_Started += WritingStarted;
            AllCustomEvents.Instance.AI_Channel_DigitalParameterChange_Finished += WritingFinished;
            _AI_Parameters = new AI_Channel_Parameters();
        }
        
        private int _numberOfSelectedChannel()
        {
            var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            string name = checkedButton.Name;
            name = name.Replace("Ch_", "");
            return Convert.ToInt32(name);
        }
        private void Ch_RadioButtonClick(object sender, EventArgs e)
        {
            _SetFormValuesFromLatch(AI_Channels.Instance.ChannelArray[_numberOfSelectedChannel() - 1].ChannelProperties);

        }
        private void _SetFormValuesFromLatch(AI_Channel_Latch ChannelLatch)
        {
            if (Frequency_ComboBox.Items.Contains(ChannelLatch.Filter_Frequency.ToString() + " kHz"))
                Frequency_ComboBox.SelectedIndex = Frequency_ComboBox.Items.IndexOf(ChannelLatch.Filter_Frequency.ToString() + " kHz");
            if(Filter_Gain.Items.Contains(ChannelLatch.Filter_Gain.ToString()))
                Filter_Gain.SelectedIndex=Filter_Gain.Items.IndexOf(ChannelLatch.Filter_Gain.ToString());
            if (PGA_Gain.Items.Contains(ChannelLatch.PGA_Gain.ToString()))
                PGA_Gain.SelectedIndex = PGA_Gain.Items.IndexOf(ChannelLatch.PGA_Gain.ToString());
            HomeMadeAmplifier_CheckBox.Checked = ChannelLatch.HomemadeAmplifier;
        }
        private void writeDataToChannel()
        {
            int frequency = Convert.ToInt32(Frequency_ComboBox.Text.Replace("kHz", ""));
            int FilterGain = Convert.ToInt32(Filter_Gain.Text);
            int PGAGain = Convert.ToInt32(PGA_Gain.Text);
            long currentAmpGain = (long)Double.Parse(CurrentAmpGains.Text);
            long secondAmpGain = (long)Double.Parse(SecondAmpGains.Text);
            _AI_Parameters.ChangeChannelParams(frequency, FilterGain, PGAGain, _numberOfSelectedChannel(), HomeMadeAmplifier_CheckBox.Checked, currentAmpGain,secondAmpGain);
            

        }
        private void WritingStarted(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Writing";
        }
        private void WritingFinished(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }
        private void SomeValuerChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Waiting";
            writeDataToChannel();
        }
        private void HomemadeAmpCheckedChanged(object sender, EventArgs e)
        {
            if (HomeMadeAmplifier_CheckBox.Checked)
                CurrentAmpGains.Enabled = false;
            else CurrentAmpGains.Enabled = true;
            SomeValuerChanged(sender, e);
        }

        private void ChannelProperties_Load(object sender, EventArgs e)
        {
            foreach (RadioButton a in groupBox1.Controls.OfType<RadioButton>())
            {
                a.Checked = true;
                writeDataToChannel();
            }
        }

        
    }
}
