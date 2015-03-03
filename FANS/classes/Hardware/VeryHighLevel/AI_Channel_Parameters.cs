using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class ChannelParamsToSet
    {
        
        public ChannelParamsToSet(int Freq, int FiltGain, int Pgagain, int channel_Number, bool homemade_Amplifier, long currentAmpGain, long secondAmpGain )
        {
            this.freq = Freq;
            this.filt_gain = FiltGain;
            this.pga_gain = Pgagain;
            this.channelNumber = channel_Number;
            this.homemadeAmplifier = homemade_Amplifier;
            this.currentAmpGain = currentAmpGain;
            this.secondAmpGain = secondAmpGain;
        }
        public int freq;
        public int filt_gain;
        public int pga_gain;
        public bool homemadeAmplifier;
        public int channelNumber;
        public long currentAmpGain;
        public long secondAmpGain;
        
    }
    class AI_Channel_Parameters
    {
        private List<ChannelParamsToSet> _Queue;
        public AI_Channel_Parameters()
        {
            _Queue = new List<ChannelParamsToSet>();
        }

        private void _AddToQueue(ChannelParamsToSet Channel_Params)
        {
            int j = -1; 
            for (int i = 0; i < _Queue.Count; i++)
            {
                if (Channel_Params.channelNumber == _Queue[i].channelNumber)
                { j = i; break; }
            }
            if (j != -1)
                _Queue.RemoveAt(j);
            _Queue.Add(Channel_Params);
        }
        public void ChangeChannelParams(int freq, int filter_Gain, int PGA_gain, int channelNumber, bool homemadeAmp, long currentAmpGain, long secondAmpGain)
        {
            this._Queue.Add(new ChannelParamsToSet(freq, filter_Gain, PGA_gain, channelNumber, homemadeAmp,currentAmpGain,secondAmpGain));
            _ChangeChannelParamsInThread(this, null);
        }
        private void _ChangeChannelParamsInThread(object sender, EventArgs e)
        {
            if (MeasurementThread.Instance.MeasurementRunning)
            {
                AllCustomEvents.Instance.MeasurementFinished += _ChangeChannelParamsInThread;

            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= _ChangeChannelParamsInThread;
                AllCustomEvents.Instance.OnAI_Channel_DigitalParameterChange_Started(this,null);
                MeasurementThread.Instance.StartThread(_releaseQueue);
            }
        }
        private void _releaseQueue()
        {
            for(int i=0;i<_Queue.Count;i++)
                _setChannelParams(_Queue[i]);
            _Queue.Clear();
            AllCustomEvents.Instance.OnAI_Channel_DigitalParameterChange_Finished(this, null);
        }
        private void _setChannelParams(ChannelParamsToSet par)
        {
            AI_Channels.Instance.ChannelArray[par.channelNumber - 1].ChannelProperties.Filter_Frequency = par.freq;
            AI_Channels.Instance.ChannelArray[par.channelNumber - 1].ChannelProperties.Filter_Gain = par.filt_gain;
            AI_Channels.Instance.ChannelArray[par.channelNumber - 1].ChannelProperties.PGA_Gain = par.pga_gain;
            AI_Channels.Instance.ChannelArray[par.channelNumber - 1].ChannelProperties.HomemadeAmplifier = par.homemadeAmplifier;
            AI_Channels.Instance.ChannelArray[par.channelNumber - 1].ChannelProperties.SaveValuesToLatch();
            if (par.channelNumber == 1)
            {
                ImportantConstants.K_Ampl_first_Channel = par.filt_gain * par.pga_gain;
                ImportantConstants.PGAGain = par.pga_gain;
                ImportantConstants.FilterGain = par.filt_gain;
                if (par.homemadeAmplifier)
                {
                    ImportantConstants.HomemadeAmplifierAsPreamp = true;
                    ImportantConstants.HomemadeAmplifierGain = 178;
                    ImportantConstants.K_Ampl_first_Channel *= 178;
                }
                else
                {
                    ImportantConstants.K_Ampl_first_Channel *= par.currentAmpGain;
                }
                ImportantConstants.K_Ampl_first_Channel *= par.secondAmpGain;
                ImportantConstants.StanfordAsSecondAmp = true;
                ImportantConstants.StanfordAmpGain = par.secondAmpGain;
            }

        }

    }
}
