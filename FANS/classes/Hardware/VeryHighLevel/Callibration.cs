using DigitalAnalyzerNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace FANS.classes
{
    public class Callibration
    {
        private DigitalAnalyzerSpectralRange m_digitalAnalyzerSpectralRange;
        private PointPairList m_DAQnoise;
        private PointPairList m_HomemadeAmplifierNoise;
        private PointPairList m_StanfordAmplifierNoise;
        private PointPairList m_CurrentAmplifierNoise;

        public Callibration(DigitalAnalyzerSpectralRange digitalAnalyzerSpectralRange)
        {
            m_digitalAnalyzerSpectralRange = digitalAnalyzerSpectralRange;
        }

        public PointPairList DAQnoise 
        {
            get
            {
                return m_DAQnoise;
            }
        }

        public PointPairList HomemadeAmplifierNoise
        {
            get
            {
                return m_HomemadeAmplifierNoise;
            }
        }

        public PointPairList StanfordAmplifierNoise
        {
            get {
                return m_StanfordAmplifierNoise;
                }
        }

        public PointPairList CurrentAmplifierNoise
        {
            get
            {
                return m_CurrentAmplifierNoise;
            }
        }
        
        public PointPairList GetPureDeviceNoise(PointPairList MeasuredPSD, bool HomemadeAmplifierAsPreamp,double HomemadeAmpGain, bool CurrentAmpAsPreamp, double CurrentAmpGain,  )
    }
}
