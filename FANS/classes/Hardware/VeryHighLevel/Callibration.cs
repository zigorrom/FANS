using DigitalAnalyzerNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ZedGraph;
using System.Runtime.Serialization.Formatters.Binary;

namespace FANS.classes
{
    public static class Extentions
    {
        public static PointPairList Subtract(this PointPairList From, PointPairList NoiseToSubtract)
        {
            if (From.Count != NoiseToSubtract.Count)
                throw new ArgumentException("List Lengths are not equal");
            var enum1 = From.GetEnumerator();
            var enum2 = NoiseToSubtract.GetEnumerator();
            while(enum1.MoveNext()&&enum2.MoveNext())
            {
                enum1.Current.Y -= enum2.Current.Y;
            }
            return From;
        }
        public static PointPairList Add(this PointPairList Obj, PointPairList ListToAdd)
        {
            if (Obj.Count != ListToAdd.Count)
                throw new ArgumentException("List Lengths are not equal");
            var enum1 = Obj.GetEnumerator();
            var enum2 = ListToAdd.GetEnumerator();
            while (enum1.MoveNext() && enum2.MoveNext())
            {
                enum1.Current.Y += enum2.Current.Y;
            }
            return Obj;

        }

        public static PointPairList Divide(this PointPairList val, double divider)
        {
            foreach (var p in val)
            {
                p.Y /= divider;
            }
            return val;
        }
    }

    [Serializable]
    public class Callibration
    {
    
        private DigitalAnalyzerSpectralRange m_digitalAnalyzerSpectralRange;
    
        private PointPairList m_DAQnoise;
    
        private PointPairList m_HomemadeAmplifierNoise;
    
        private PointPairList m_StanfordAmplifierNoise;
    
        private PointPairList m_CurrentAmplifierNoise;

        private static volatile Callibration m_instance;
        private static object syncRoot = new object();

        private const string FileNameFormat = "{0}\\CalibrationDataRange{1}.cal";
        //private bool m_needCalibration;
        
        private Callibration()
        {
           //m_needCalibration = true;
            
        }
        ~Callibration()
        {
            Serialize();
        }
        
        public static Callibration GetInstance(DigitalAnalyzerSpectralRange digitalAnalyzerSpectralRange)
        {
            
                if(m_instance == null)
                {
                    lock(syncRoot)
                    {
                        if (m_instance == null)
                            DeserializeOrNew(digitalAnalyzerSpectralRange);
                    }
                }
                return m_instance;
            
        }

        private static void DeserializeOrNew(DigitalAnalyzerSpectralRange digitalAnalyzerSpectralRange)
        {
            var CurrentDir = Directory.GetCurrentDirectory();
            var Filename = String.Format(FileNameFormat,CurrentDir,digitalAnalyzerSpectralRange.ToString());
            if (!File.Exists(Filename))
            {
                m_instance = new Callibration();
                m_instance.m_digitalAnalyzerSpectralRange = digitalAnalyzerSpectralRange;
                return;
            }
            var binaryFormatter = new BinaryFormatter();
            //XmlSerializer xmlFormat = new XmlSerializer(typeof(Callibration));
            using(Stream f = new FileStream(Filename,FileMode.Open,FileAccess.Read,FileShare.None))
            {
                m_instance = (Callibration)binaryFormatter.Deserialize(f);
            //    m_instance = (Callibration)xmlFormat.Deserialize(f);
            }
        }
        private void Serialize()
        {
            var CurrentDir = Directory.GetCurrentDirectory();
            var Filename = String.Format(FileNameFormat, CurrentDir, m_digitalAnalyzerSpectralRange.ToString());
            if (File.Exists(Filename))
            {
                return;
            }
            var binaryFormatter = new BinaryFormatter();
            //XmlSerializer xmlFormat = new XmlSerializer(typeof(Callibration));
            using (Stream f = new FileStream(Filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //xmlFormat.Serialize(f,this);
                binaryFormatter.Serialize(f, this);
            }
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
        
        public bool NeedCalibration
        {
            get
            {
                if (m_DAQnoise == null || m_HomemadeAmplifierNoise == null || m_StanfordAmplifierNoise == null || m_CurrentAmplifierNoise == null)
                    return true;
                if (m_DAQnoise.Count == 0 || m_HomemadeAmplifierNoise.Count == 0 || m_StanfordAmplifierNoise.Count == 0 || m_CurrentAmplifierNoise.Count == 0)
                    return true;
                return false;
        
            }
        }

        public void Calibrate()
        {
            if(!NeedCalibration)
            {
                var result = MessageBox.Show("The calibrations are already done.\r\nAre You sure to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            


            var caption = "Callibration";
            if (MessageBox.Show("Please shortcut the DAQ`s input and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            m_DAQnoise = new PointPairList();
            for (int i = 0; i < 100; i++)
            {
                m_DAQnoise.Add(i, i * 2);
            }
            if (MessageBox.Show("Please shortcut the HomemadeAmp`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            m_HomemadeAmplifierNoise = new PointPairList();
            for (int i = 0; i < 100; i++)
            {
                m_HomemadeAmplifierNoise.Add(i, i * 2);
            }
            if (MessageBox.Show("Please shortcut the CurrentAmp`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            m_CurrentAmplifierNoise = new PointPairList();
            for (int i = 0; i < 100; i++)
            {
                m_CurrentAmplifierNoise.Add(i, i * 2);
            }
            if (MessageBox.Show("Please shortcut the Stanford`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            m_StanfordAmplifierNoise = new PointPairList();
            for (int i = 0; i < 100; i++)
            {
                m_StanfordAmplifierNoise.Add(i, i * 2);
            }

        }

        public PointPairList GetPureDeviceNoise(PointPairList MeasuredPSD, bool HomemadeAmplifierAsPreamp,double HomemadeAmpGain, bool CurrentAmpAsPreamp, double CurrentAmpGain,bool StanfordAmpAsSecondary, double StanfordAmpGain)
        {
            if (NeedCalibration)
            {
                var dialogRresult = MessageBox.Show("The calibrations was not done yet.\r\nDoYou want to calibrate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogRresult == DialogResult.Yes)
                    Calibrate();
                else
                { throw new Exception("No calibration was done before"); }
            }

            PointPairList preampNoise = new PointPairList();
            PointPairList secondaryAmpNoise = new PointPairList();
            double preampCoef = 1;
            double secondaryAmpCoef = 1;
            
            if (!(HomemadeAmplifierAsPreamp ^ CurrentAmpAsPreamp))
            {
                throw new Exception("Both current and homemade amps are set as either user or not.");
            }
            if(!StanfordAmpAsSecondary)
            {
                throw new Exception("Not set secondary amplifier");
            }

            if (HomemadeAmplifierAsPreamp)
            {
                preampNoise = m_HomemadeAmplifierNoise;
                preampCoef = HomemadeAmpGain;
            }
            if (CurrentAmpAsPreamp)
            {
                preampNoise = m_CurrentAmplifierNoise;
                preampCoef = CurrentAmpGain;
            }
            if(StanfordAmpAsSecondary)
            {
                secondaryAmpNoise = m_StanfordAmplifierNoise;
                secondaryAmpCoef = StanfordAmpGain;
            }

            var result = MeasuredPSD.Subtract(m_DAQnoise).Divide(secondaryAmpCoef * secondaryAmpCoef).Subtract(secondaryAmpNoise).Divide(preampCoef * preampCoef).Subtract(preampNoise);

            return result;
            //throw new NotImplementedException();
        }

        //private PointPairList SubtractDAQNoise(PointPairList noiseList)
        //{
        //    return noiseList.Subtract(m_DAQnoise);
        //}
        //private PointPairList SubtractAmpNoise(PointPairList noiseList, PointPairList AmpNoise, double AmpCoef)
        //{
        //    return noiseList.Divide(AmpCoef * AmpCoef).Subtract(AmpNoise);
        //}
    }
}
