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
using FourierTransformProvider;
using System.Threading;

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
        public static PointPairList AddList(this PointPairList Obj, PointPairList ListToAdd)
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

        private PointPairList m_NoiseBoxNoise;

        private PointPairList m_HomemadeAmplifierNoise;
    
        private PointPairList m_StanfordAmplifierNoise;
    
       // private PointPairList m_CurrentAmplifierNoise;

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
            //if (File.Exists(Filename))
            //{
            //    return;
            //}
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

        public PointPairList NoiseBoxNoise
        {
            get { return m_NoiseBoxNoise; }
        }
        //public PointPairList CurrentAmplifierNoise
        //{
        //    get
        //    {
        //        return m_CurrentAmplifierNoise;
        //    }
        //}
        
        public bool NeedCalibration
        {
            get
            {
                if (m_DAQnoise == null || m_HomemadeAmplifierNoise == null || m_StanfordAmplifierNoise == null||m_NoiseBoxNoise==null)// || m_CurrentAmplifierNoise == null)
                    return true;
                if (m_DAQnoise.Count == 0 || m_HomemadeAmplifierNoise.Count == 0 || m_StanfordAmplifierNoise.Count == 0 ||m_NoiseBoxNoise.Count==0)//|| m_CurrentAmplifierNoise.Count == 0)
                    return true;
                return false;
        
            }
        }
        
        [NonSerialized]
        private AdvancedFourierTransform m_FFT;
        [NonSerialized]
        private Thread m_FFTprocessing;
        [NonSerialized]
        private TimeTracesAcquisition m_Aquisition;
        [NonSerialized]
        private Queue<PointPairList> m_QueueToGetProcessed;
        [NonSerialized]
        private AI_Channels m_Channels;
        [NonSerialized]
        private PointPairList m_ProcessedFFTs;
        [NonSerialized]
        private int m_AveragedSpectraCounter;


        private void MakeFFTOfQueue()
        {
            while ((m_QueueToGetProcessed.Count != 0) && MeasurementThread.MeasurementInProgress && (m_AveragedSpectraCounter <= AveragingForCalibration))
            {
                PointPairList result = m_FFT.AdvancedFFT(m_QueueToGetProcessed.Dequeue());//.makeFFT(QueueToGetProcessed.Dequeue());
                m_ProcessedFFTs.AddList(result);
                //AddPointPairListToFinal(result);
                m_AveragedSpectraCounter++;
                AllCustomEvents.Instance.OnNoiseMeasurementStatusChanged(this, new StatusEventArgs("Spectra Acquired " + m_AveragedSpectraCounter + "/" + AveragingForCalibration, 1, AveragingForCalibration, m_AveragedSpectraCounter));
                if (m_AveragedSpectraCounter % SpectraPerShow == 0)
                    AllCustomEvents.Instance.OnNoiseSpectraArrived(this, new NoiseEventArgs(m_ProcessedFFTs.Clone().Divide(m_AveragedSpectraCounter)));
            }
            if (m_AveragedSpectraCounter >= AveragingForCalibration)
            {
                var RawData = m_ProcessedFFTs.Divide(m_AveragedSpectraCounter);
                //PointPairList FinalData = DividePointPairList(RawData, ImportantConstants.K_Ampl_first_Channel * ImportantConstants.K_Ampl_first_Channel);
                AllCustomEvents.Instance.OnLastNoiseSpectraArrived(this, new FinalNoiseEventArgs(RawData, RawData, "last spectra"));
            }

        }
        private void FillFrequenciesInFinalFFT(int NumberOFPoints)
        {
            m_ProcessedFFTs.Clear();
            m_ProcessedFFTs = m_FFT.GetFrequencyList();
            

        }
        private void StartFFTThread()
        {
            this.m_FFTprocessing = new Thread(new ThreadStart(MakeFFTOfQueue));
            this.m_FFTprocessing.Priority = ThreadPriority.Highest;
            this.m_FFTprocessing.Start();
        }
        private void MakeNoiseMeasurements()
        {
            Agilent_DigitalOutput_LowLevel.Instance.AllToZero();

            
            if (!MeasurementThread.MeasurementInProgress) return;

            AllCustomEvents.Instance.OnMeasurementStatusChanged(this, new StatusEventArgs("Recording"));

            m_Channels.Read_AI_Channel_Status();
            int ACQ_Rate = m_Channels.ACQ_Rate;
            m_Channels.SetChannelsToAC();
            m_Channels.ACQ_Rate = 499712;//262144;
            m_Channels.SingleShotPointsPerBlock = 499712;//262144;
            
            m_QueueToGetProcessed.Clear();
            m_AveragedSpectraCounter = 0;
            FillFrequenciesInFinalFFT(m_Channels.SingleShotPointsPerBlock);
            for (int i = 0; (i < AveragingForCalibration) && (MeasurementThread.MeasurementInProgress); i++)
            {
                m_QueueToGetProcessed.Enqueue(m_Aquisition.MakeSingleShot(1));
                if (!m_FFTprocessing.IsAlive) this.StartFFTThread();
            }

            m_FFTprocessing.Join();
            m_Channels.ACQ_Rate = ACQ_Rate;

            
        }


        private const int AveragingForCalibration = 40000;
        private const int SpectraPerShow = 10;
        public void Calibrate(object caller=null, EventArgs e=null)
        {
            if (MeasurementThread.Instance.MeasurementRunning)
            {
                AllCustomEvents.Instance.MeasurementFinished += Calibrate;
                MeasurementThread.Instance.MeasurementRunning = false; return;
            }
            else
                AllCustomEvents.Instance.MeasurementFinished -= Calibrate;

            if(!NeedCalibration)
            {
                var result = MessageBox.Show("The calibrations are already done.\r\nAre You sure to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }

            m_Aquisition = new TimeTracesAcquisition();
            m_FFT = new AdvancedFourierTransform(DigitalAnalyzerSpectralRange.Discret499712Freq1_1600Step1Freq1647_249856Step61);
            m_QueueToGetProcessed = new Queue<PointPairList>();
            m_FFTprocessing = new Thread(new ThreadStart(MakeFFTOfQueue));
            m_FFTprocessing.Priority = ThreadPriority.Highest;
            m_Channels = AI_Channels.Instance;
            var VisualizationForm = new NoiseVisualizerForm();
            


            var caption = "Callibration";
            if (MessageBox.Show("Please shortcut the DAQ`s input and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            VisualizationForm.SubscribeForNoiseSpectra();
            VisualizationForm.SubscribeForStatusMessages();
            VisualizationForm.Show();

            m_ProcessedFFTs = new PointPairList();
            MakeNoiseMeasurements();
            m_DAQnoise = m_ProcessedFFTs;
           
            
            
            //m_DAQnoise = new PointPairList();
            //for (int i = 0; i < 100; i++)
            //{
            //    m_DAQnoise.Add(i, i * 2);
            //}

            if (MessageBox.Show("Please shortcut the NoiseBoxs`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");

            VisualizationForm.SubscribeForNoiseSpectra();
            VisualizationForm.SubscribeForStatusMessages();
            VisualizationForm.Show();
            m_ProcessedFFTs = new PointPairList();
            MakeNoiseMeasurements();
            m_NoiseBoxNoise = m_ProcessedFFTs;
            //m_NoiseBoxNoise = new PointPairList();
            //for (int i = 0; i < 100; i++)
            //{
            //    m_NoiseBoxNoise.Add(i, i * 2);
            //}

            if (MessageBox.Show("Please shortcut the HomemadeAmp`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            VisualizationForm.SubscribeForNoiseSpectra();
            VisualizationForm.SubscribeForStatusMessages();
            VisualizationForm.Show();
            m_ProcessedFFTs = new PointPairList();
            MakeNoiseMeasurements();
            m_HomemadeAmplifierNoise = m_ProcessedFFTs.Subtract(m_NoiseBoxNoise);
            //m_HomemadeAmplifierNoise = new PointPairList();
            //for (int i = 0; i < 100; i++)
            //{
            //    m_HomemadeAmplifierNoise.Add(i, i * 2);
            //}
           
            if (MessageBox.Show("Please shortcut the Stanford`s input, connect it`s out to DAQ in and press OK", caption, MessageBoxButtons.OK) != DialogResult.OK)
                throw new Exception("cannot continue calibration. Ok was not pressed");
            VisualizationForm.SubscribeForNoiseSpectra();
            VisualizationForm.SubscribeForStatusMessages();
            VisualizationForm.Show();
            m_ProcessedFFTs = new PointPairList();
            MakeNoiseMeasurements();
            m_StanfordAmplifierNoise = m_ProcessedFFTs.Subtract(m_NoiseBoxNoise);
            //m_StanfordAmplifierNoise = new PointPairList();
            //for (int i = 0; i < 100; i++)
            //{
            //    m_StanfordAmplifierNoise.Add(i, i * 2);
            //}
            VisualizationForm.Hide();
            VisualizationForm.Dispose();
            VisualizationForm = null;
            Serialize();
            MessageBox.Show("Calibration completed");

        }

        

        public PointPairList GetPureDeviceNoise(PointPairList MeasuredPSD, bool HomemadeAmplifierAsPreamp,double HomemadeAmpGain /*, bool CurrentAmpAsPreamp, double CurrentAmpGain*/,bool StanfordAmpAsSecondary, double StanfordAmpGain,int FilterGain,int PGAGain)
        {
            if (NeedCalibration)
            {
                var dialogRresult = MessageBox.Show("The calibrations was not done yet.\r\nDoYou want to calibrate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogRresult == DialogResult.Yes)
                    Calibrate(this,new EventArgs());
                else
                { throw new Exception("No calibration was done before"); }
            }

            PointPairList preampNoise = new PointPairList();
            PointPairList secondaryAmpNoise = new PointPairList();
            double preampCoef = 1;
            double secondaryAmpCoef = 1;
            if(!HomemadeAmplifierAsPreamp)
                throw new Exception("Both current and homemade amps are set as either user or not.");
            //if (!(HomemadeAmplifierAsPreamp ^ CurrentAmpAsPreamp))
            //{
            //    throw new Exception("Both current and homemade amps are set as either user or not.");
            //}
            if(!StanfordAmpAsSecondary)
            {
                throw new Exception("Not set secondary amplifier");
            }

            if (HomemadeAmplifierAsPreamp)
            {
                preampNoise = m_HomemadeAmplifierNoise;
                preampCoef = HomemadeAmpGain;
            }
            //if (CurrentAmpAsPreamp)
            //{
            //    preampNoise = m_CurrentAmplifierNoise;
            //    preampCoef = CurrentAmpGain;
            //}
            if(StanfordAmpAsSecondary)
            {
                secondaryAmpNoise = m_StanfordAmplifierNoise;
                secondaryAmpCoef = StanfordAmpGain;
            }

            var result = MeasuredPSD.Divide(PGAGain*PGAGain* FilterGain*FilterGain).Subtract(m_NoiseBoxNoise).Divide(secondaryAmpCoef * secondaryAmpCoef).Subtract(secondaryAmpNoise).Divide(preampCoef * preampCoef).Subtract(preampNoise);

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
