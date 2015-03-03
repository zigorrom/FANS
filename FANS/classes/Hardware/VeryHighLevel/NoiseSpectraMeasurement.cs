using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Threading;
using FourierTransformProvider;
using FANS.classes;
using DigitalAnalyzerNamespace;

namespace FANS.classes
{
    class NoiseSpectraMeasurement
    {
        private VoltageMeasurement _VoltageMeasurement;
        private TimeTracesAcquisition _TimeTracesAcquisition;
        private AI_Channels _Channels;
        private DataStringConverter _DataConverter;
        //private FFT_4Thread _FFT;
        private AdvancedFourierTransform _FFT;
        private Thread _FFT_Processing;
        private PointPairList FinalFFT;
        private Callibration m_NoiseSetupCalibration;
        private int AveragedSpectraCounter;
        private Queue<PointPairList> QueueToGetProcessed;
        public int Averaging;
        public int SpectraPerShow;
        public NoiseSpectraMeasurement()
        {
            _VoltageMeasurement = new VoltageMeasurement();
            _TimeTracesAcquisition = new TimeTracesAcquisition();
            _FFT = new AdvancedFourierTransform(DigitalAnalyzerNamespace.DigitalAnalyzerSpectralRange.Discret499712Freq1_1600Step1Freq1647_249856Step61);//new FFT_4Thread(18);
            m_NoiseSetupCalibration = Callibration.GetInstance(DigitalAnalyzerSpectralRange.Discret499712Freq1_1600Step1Freq1647_249856Step61);
            if (m_NoiseSetupCalibration.NeedCalibration)
                m_NoiseSetupCalibration.Calibrate();
            //m_NoiseSetupCalibration = new Callibration(DigitalAnalyzerNamespace.DigitalAnalyzerSpectralRange.Discret499712Freq1_1600Step1Freq1647_249856Step61);
            Averaging = 100;
            SpectraPerShow = 10;
            _Channels = AI_Channels.Instance;
            _DataConverter = new DataStringConverter();
            QueueToGetProcessed = new Queue<PointPairList>();
            FinalFFT = new PointPairList();
            this._FFT_Processing = new Thread(new ThreadStart(MakeFFTOfQueue));
            this._FFT_Processing.Priority = ThreadPriority.Highest;
        }
        public void MakeNoiseMeasurement(object AsyncDataAcquisition)
        {
            if (m_NoiseSetupCalibration.NeedCalibration)
                throw new Exception("Need calibration");

            Agilent_DigitalOutput_LowLevel.Instance.AllToZero();

            _VoltageMeasurement.PerformVoltagePresiseMeasurement();
            if (!MeasurementThread.MeasurementInProgress) return;

            AllCustomEvents.Instance.OnMeasurementStatusChanged(this,new StatusEventArgs("Recording"));
            
            _Channels.Read_AI_Channel_Status();
            int ACQ_Rate = _Channels.ACQ_Rate;
            _Channels.SetChannelsToAC();
            _Channels.ACQ_Rate = 499712;//262144;
            _Channels.SingleShotPointsPerBlock = 499712;//262144;
            PointPairList DataPack = new PointPairList();
            QueueToGetProcessed.Clear();
            AveragedSpectraCounter = 0;
            FillFrequenciesInFinalFFT(_Channels.SingleShotPointsPerBlock);
            for (int i = 0; (i < Averaging)&&(MeasurementThread.MeasurementInProgress); i++)
            {
                QueueToGetProcessed.Enqueue(_TimeTracesAcquisition.MakeSingleShot(1));
                if (!_FFT_Processing.IsAlive) this.StartFFTThread();
            }
            if (_FFT_Processing.IsAlive)
                AllCustomEvents.Instance.LastNoiseSpectraArrived += RestartPreciseVoltageMeasurementInThread; 
                
            else
            {
                if (MeasurementThread.MeasurementInProgress)
                    _VoltageMeasurement.PerformVoltagePresiseMeasurement();
            }
            _Channels.ACQ_Rate = ACQ_Rate;

            if (AsyncDataAcquisition is bool)
            {
                var AsyncAcquisition = (bool)AsyncDataAcquisition;
                if (!AsyncAcquisition)
                    _FFT_Processing.Join();
            }
        }

        private void StartFFTThread()
        {
            this._FFT_Processing = new Thread(new ThreadStart(MakeFFTOfQueue));
            this._FFT_Processing.Priority = ThreadPriority.Highest;
            this._FFT_Processing.Start();
        }
        private void FillFrequenciesInFinalFFT(int NumberOFPoints)
        {
            FinalFFT.Clear();
            FinalFFT = _FFT.GetFrequencyList();
            //double ACQ_rate = _Channels.ACQ_Rate;
            //double NumberOfPoints_d = NumberOFPoints;
            //for (int i = 0; i < NumberOFPoints / 2; i++)
            //{
            //    FinalFFT.Add((i*(ACQ_rate/NumberOfPoints_d)),0);
            //}
            
          }
        private void MakeFFTOfQueue()
        {
            while ((QueueToGetProcessed.Count != 0) && MeasurementThread.MeasurementInProgress&&(AveragedSpectraCounter<=Averaging))
            {
                PointPairList result = _FFT.AdvancedFFT(QueueToGetProcessed.Dequeue());//.makeFFT(QueueToGetProcessed.Dequeue());
                AddPointPairListToFinal(result);
                AveragedSpectraCounter++;
                AllCustomEvents.Instance.OnNoiseMeasurementStatusChanged(this, new StatusEventArgs("Spectra Acquired " + AveragedSpectraCounter + "/" + Averaging, 1, Averaging, AveragedSpectraCounter));
                if(AveragedSpectraCounter % SpectraPerShow==0)
                    AllCustomEvents.Instance.OnNoiseSpectraArrived(this, new NoiseEventArgs(DividePointPairList(FinalFFT,AveragedSpectraCounter)));
            }
            if(AveragedSpectraCounter>=Averaging)
            {
                PointPairList RawData=DividePointPairList(FinalFFT, AveragedSpectraCounter);
                //ImportantConstants
                PointPairList FinalData = DividePointPairList(RawData, ImportantConstants.K_Ampl_first_Channel * ImportantConstants.K_Ampl_first_Channel);
                AllCustomEvents.Instance.OnLastNoiseSpectraArrived(this, new FinalNoiseEventArgs(RawData,FinalData,"last spectra"));
            }

        }
        private void AddPointPairListToFinal(PointPairList data)
        {
            for (int i = 0; i < FinalFFT.Count; i++)
            {
                FinalFFT[i].Y += data[i].Y;
            }
         
        }
        private PointPairList DividePointPairList(PointPairList data, double divider)
        {
            PointPairList result = new PointPairList();
            foreach (PointPair a in data)
            {
                result.Add(a.X, a.Y / divider);
            }
            return result;
        }
        private void RestartPreciseVoltageMeasurementInThread(object Sender, EventArgs e)
        {

            AllCustomEvents.Instance.BeforeMeasurementFinished -= RestartPreciseVoltageMeasurementInThread;
            if (MeasurementThread.MeasurementInProgress)
                _VoltageMeasurement.PerformVoltagePresiseMeasurement();
            else
               MeasurementThread.Instance.StartThread(_VoltageMeasurement.PerformVoltagePresiseMeasurement);
        }
    }
}
