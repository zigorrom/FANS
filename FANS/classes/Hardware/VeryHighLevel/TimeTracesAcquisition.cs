using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes
{
   

    class TimeTracesAcquisition
    {

        private AI_Channels _Channels;
        private DataStringConverter _DataConverter;
        private VoltageMeasurement _VoltageMeasurement;
        public TimeTracesAcquisition()
        {
            _Channels = AI_Channels.Instance;
            _Channels.Read_AI_Channel_Status();
            _DataConverter = new DataStringConverter();
            _VoltageMeasurement = new VoltageMeasurement();
        }

       
        
        public void ContiniousAcquisition()
        {
            Agilent_DigitalOutput_LowLevel.Instance.AllToZero();
            _Channels.Read_AI_Channel_Status();
            int ACQ_Rate = _Channels.ACQ_Rate;
            _Channels.SetChannelsToAC();
            _Channels.StartAnalogAcqusition();
            while (MeasurementThread.MeasurementInProgress)
            {
                while (!_Channels.CheckAcquisitionStatus()) ;
                string result = AI_Channels.Instance.AcquireStringWithData();
                Int16[] resultInt = _DataConverter.ParseDataStringToInt(result);
                PointPairList[] ChannelData = _DataConverter.ParseIntArrayIntoChannelData(resultInt, ACQ_Rate);
                AllCustomEvents.Instance.OnAI_Data_Arrived(this, new ADC_DataArrivedEventArgs(ChannelData, result));
            }
            _Channels.StopAnalogAcqusition();
        }
        public PointPairList MakeSingleShot(int NumberOfChannel)
        {
            _Channels.DisableAllChannelsForContiniousDataAcquisition();
            _Channels.ChannelArray[NumberOfChannel - 1].Enabled = true;
            _Channels.ChannelArray[NumberOfChannel - 1].ChannelProperties.isAC = true;
            _Channels.Read_AI_Channel_Status();
            int ACQ_Rate = _Channels.ACQ_Rate;
            _Channels.AcquireSingleShot();
            while ((!_Channels.CheckSingleShotAcquisitionStatus())&&MeasurementThread.MeasurementInProgress) ;
            if (!MeasurementThread.MeasurementInProgress) return null;
            string result = AI_Channels.Instance.AcquireStringWithData();
            Int16[] resultInt = _DataConverter.ParseDataStringToInt(result);
            PointPairList[] ChannelData = _DataConverter.ParseIntArrayIntoChannelData(resultInt, ACQ_Rate);
            
            return ChannelData[NumberOfChannel-1];
        }

        public void ContiniousAcquisitionWithPresiseVoltageMeasurement()
        {
            Agilent_DigitalOutput_LowLevel.Instance.AllToZero();

            _VoltageMeasurement.PerformVoltagePresiseMeasurement();
            if (!MeasurementThread.MeasurementInProgress) return;

            AllCustomEvents.Instance.OnMeasurementStatusChanged(this,new StatusEventArgs("Recording"));
            
            _Channels.Read_AI_Channel_Status();
            int ACQ_Rate = _Channels.ACQ_Rate;
            _Channels.SetChannelsToAC();
            _Channels.StartAnalogAcqusition();
            while ((MeasurementThread.MeasurementInProgress) && (TimeTraceFileManager.Instance.WritingInProgress))
            {
                while (!_Channels.CheckAcquisitionStatus()) ;
                string result = AI_Channels.Instance.AcquireStringWithData();
                Int16[] resultInt = _DataConverter.ParseDataStringToInt(result);
                PointPairList[] ChannelData = _DataConverter.ParseIntArrayIntoChannelData(resultInt, ACQ_Rate);
                AllCustomEvents.Instance.OnAI_Data_Arrived(this, new ADC_DataArrivedEventArgs(ChannelData, result));
            }
            _Channels.StopAnalogAcqusition();

            if (!MeasurementThread.MeasurementInProgress)
                AllCustomEvents.Instance.BeforeMeasurementFinished += RestartPreciseVoltageMeasurementInThread;
            else
            {
                _VoltageMeasurement.PerformVoltagePresiseMeasurement();
            }
        }
        private void RestartPreciseVoltageMeasurementInThread(object Sender, EventArgs e)
        {
            AllCustomEvents.Instance.BeforeMeasurementFinished -= RestartPreciseVoltageMeasurementInThread;
            MeasurementThread.Instance.StartThread(_VoltageMeasurement.PerformVoltagePresiseMeasurement);
            
        }

        public void startAC_Autorange(int NumberOfChannel)
        {
            AI_Channels.Instance.SingleShotPointsPerBlock=10000;
            AI_Channels.Instance.ChannelArray[NumberOfChannel - 1].AC_Range = 10;
            PointPairList data=MakeSingleShot(NumberOfChannel);

            double[] AcquidredYData=data.Select(p=>p.Y).ToArray();
            double Max = AcquidredYData.Max();
            double Min = AcquidredYData.Min();
            
            if (Min < 0) _Channels.ChannelArray[NumberOfChannel - 1].isBiPolarAC = true;
            else _Channels.ChannelArray[NumberOfChannel - 1].isBiPolarAC = false;

            Min = Math.Abs(Min);
            Max = Math.Max(Min, Max);

            foreach (double rng in ImportantConstants.Ranges)
            {
                if (Max < rng)
                {
                    _Channels.ChannelArray[NumberOfChannel - 1].AC_Range = rng;
                    break;
                }
            }

          AllCustomEvents.Instance.OnAC_AutoRangeComplete(this,new AC_AutoRangeEventArgs(_Channels.ChannelArray[NumberOfChannel-1].AC_Range,_Channels.ChannelArray[NumberOfChannel-1].isBiPolarAC,NumberOfChannel));
            
       }

        

    }
}

