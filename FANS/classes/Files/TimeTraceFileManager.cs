using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FANS.interfaces;
namespace FANS.classes
{
    class TimeTraceFileManager:FileManagerParent
    {
        
        private ListOfRawADCDataString _ListOfRawADCDataStrings;
        private ListOfTimeTraceMeasurDataString _ListOfTimeTraceMeasurDataString;
        private double _Timeshift_Raw_ADC,_timeLimit;
        private TimeTraceMeasurDataString _CurrentTimeTraceMeasurement;
        private int _QuantityOfVoltageMeasurements;
        private static TimeTraceFileManager _instance;
        public  bool WritingInProgress;
        public static TimeTraceFileManager Instance
        {
            get
            {
                if (_instance == null) _instance = new TimeTraceFileManager();
                return _instance;
            }
        }

        
        private TimeTraceFileManager()
        {
            this.readFolder();
            
            _ListOfTimeTraceMeasurDataString = new ListOfTimeTraceMeasurDataString();
            _ListOfTimeTraceMeasurDataString.FileName = "MeasurDataTimeTrace.dat";
            _ListOfTimeTraceMeasurDataString.readFromFile();
        }
      
        
        public void PrepareForRealTimeDataRecording(string filename, double rload,double kampl,double samplingRate,double timelimit = 0)
        {

            _CurrentTimeTraceMeasurement = new TimeTraceMeasurDataString();
            _CurrentTimeTraceMeasurement.FileName = filename;
            
            _CurrentTimeTraceMeasurement.Rload = rload;
            _QuantityOfVoltageMeasurements = 0;
            _CurrentTimeTraceMeasurement.SamplingRate = samplingRate;
            _CurrentTimeTraceMeasurement.kAmpl = kampl;
            AllCustomEvents.Instance.VoltagesMeasurementDone += VoltagesArrived;
            
            this.PrepareForRAW_RealTimeDataRecording(filename, timelimit);
        }
        private void VoltagesArrived(object sender, MeasuredVoltages_DataArrivedEventArgs e)
        {
            if (!e.Precise)return;
            
            _QuantityOfVoltageMeasurements++;
            if (_QuantityOfVoltageMeasurements == 1)
            {
                
                _CurrentTimeTraceMeasurement.U0sample = e.Voltages[0];
                _CurrentTimeTraceMeasurement.U0whole = e.Voltages[1];
                _CurrentTimeTraceMeasurement.U0Rload = e.Voltages[2];
                _CurrentTimeTraceMeasurement.U0Gate = e.Voltages[3];
                _CurrentTimeTraceMeasurement.R0sample = _CurrentTimeTraceMeasurement.U0sample / _CurrentTimeTraceMeasurement.U0Rload * _CurrentTimeTraceMeasurement.Rload;
                return;
            }
            if (_QuantityOfVoltageMeasurements == 2)
            {
                _CurrentTimeTraceMeasurement.SampleVoltage = e.Voltages[0];
                _CurrentTimeTraceMeasurement.Uwhole = e.Voltages[1];
                _CurrentTimeTraceMeasurement.URload = e.Voltages[2];
                _CurrentTimeTraceMeasurement.Vg = e.Voltages[3];
                _CurrentTimeTraceMeasurement.SampleCurrent = (_CurrentTimeTraceMeasurement.URload) / _CurrentTimeTraceMeasurement.Rload;
                _CurrentTimeTraceMeasurement.REsample = _CurrentTimeTraceMeasurement.SampleVoltage / _CurrentTimeTraceMeasurement.SampleCurrent;
                _CurrentTimeTraceMeasurement.EquivalentResistance = _CurrentTimeTraceMeasurement.REsample * _CurrentTimeTraceMeasurement.Rload / (_CurrentTimeTraceMeasurement.REsample + _CurrentTimeTraceMeasurement.Rload);

                _ListOfTimeTraceMeasurDataString.readFromFile();
                if(this.FileExists(_CurrentTimeTraceMeasurement.FileName))
                _ListOfTimeTraceMeasurDataString.ListOfData.Add(_CurrentTimeTraceMeasurement);
                _ListOfTimeTraceMeasurDataString.writeToFile();
                AllCustomEvents.Instance.VoltagesMeasurementDone -= VoltagesArrived;

            }
            else
            {
                MessageBox.Show("Quantity of VoltageMEasurements is too big, strange..." + _QuantityOfVoltageMeasurements);
            }
        }
        public void PrepareForRAW_RealTimeDataRecording(string filename, double timeLimit=0)
        {
            this.readFolder();
            this._ListOfRawADCDataStrings = new ListOfRawADCDataString();
            _ListOfRawADCDataStrings.FileName = filename;
            _ListOfRawADCDataStrings.OpenFileForWriting(true);
            _Timeshift_Raw_ADC = 0;
            _timeLimit = timeLimit;

            if (timeLimit != 0)
            {
                AllCustomEvents.Instance.AI_Data_Arrived += RawDataArrivedWithTimeLimit;
                this.WritingInProgress = true;
            }
            else AllCustomEvents.Instance.AI_Data_Arrived += RawDataArrived;
            AllCustomEvents.Instance.MeasurementFinished += FinishWritingToFile;
        }
        private void RawDataArrived(object sender, ADC_DataArrivedEventArgs data)
        {
            _ListOfRawADCDataStrings.ParseFromADC_DataArrivedEventArgs(data, _Timeshift_Raw_ADC);
            _Timeshift_Raw_ADC = _ListOfRawADCDataStrings.getLastTimeStamp();
            
        }
        private void RawDataArrivedWithTimeLimit(object sender, ADC_DataArrivedEventArgs data)
        {
            _ListOfRawADCDataStrings.ParseFromADC_DataArrivedEventArgs(data, _Timeshift_Raw_ADC);
            _Timeshift_Raw_ADC = _ListOfRawADCDataStrings.getLastTimeStamp();
            int currentStatus=(int)(_Timeshift_Raw_ADC/_timeLimit*100);
            
            AllCustomEvents.Instance.OnMeasurementStatusChanged(this,new StatusEventArgs("Recording ...",0,100,(currentStatus<100)?currentStatus:100));

            if (_Timeshift_Raw_ADC > _timeLimit)
            {
             //  MessageBox.Show("File with " + Convert.ToString(_timeLimit, ImportantConstants.NumberFormat()) + "s limit recorded");
                FinishWritingToFile(this, null);
                
                
                
            }

        }
        private void FinishWritingToFile(object sender, EventArgs e)
        {
            AllCustomEvents.Instance.BeforeMeasurementFinished -= FinishWritingToFile;
            AllCustomEvents.Instance.MeasurementFinished -= FinishWritingToFile;
            if (_ListOfRawADCDataStrings!=null)
            _ListOfRawADCDataStrings.CloseFileForWriting();
            if (_timeLimit != 0) AllCustomEvents.Instance.AI_Data_Arrived -= RawDataArrivedWithTimeLimit;
            else AllCustomEvents.Instance.AI_Data_Arrived -= RawDataArrived;
            if (_QuantityOfVoltageMeasurements == 1)
                _CurrentTimeTraceMeasurement.Length = _ListOfRawADCDataStrings.getLastTimeStamp();
            this.WritingInProgress = false;
        }
                
     
    }
}
