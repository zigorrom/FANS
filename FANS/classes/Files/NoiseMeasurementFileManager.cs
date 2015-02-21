using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace FANS.classes
{
    class NoiseMeasurementFileManager:FileManagerParent
    {
        private ListOfMeasurDataString _ListOfMeasurDataString;
        private MeasurDataString _CurrentNoiseMeasurement;
        private static NoiseMeasurementFileManager _instance;
        public  static NoiseMeasurementFileManager Instance
        {
            get { if (_instance == null) _instance = new NoiseMeasurementFileManager();
            return _instance;
            }
            }
        int _QuantityOfVoltageMeasurements;
        public NoiseMeasurementFileManager():base()
        {
            
            _ListOfMeasurDataString = new ListOfMeasurDataString();
            _ListOfMeasurDataString.FileName="MeasurData.dat";
            _ListOfMeasurDataString.readFromFile();
        }

        public void prepareForNoiseMeasurement(string filename, double rload,double kampl)
        {
            _CurrentNoiseMeasurement = new MeasurDataString();
            _ListOfMeasurDataString.readFromFile();
            _CurrentNoiseMeasurement.FileName=filename;
            _CurrentNoiseMeasurement.Rload=rload;
            _CurrentNoiseMeasurement.kAmpl=kampl;
            _QuantityOfVoltageMeasurements = 0;
            AllCustomEvents.Instance.VoltagesMeasurementDone += VoltagesArrived;
            this.readFolder();
            AllCustomEvents.Instance.LastNoiseSpectraArrived += NoiseSpectraArrived;

        }
        public void Unsubscribe()
        {
            AllCustomEvents.Instance.VoltagesMeasurementDone -= VoltagesArrived;
            AllCustomEvents.Instance.LastNoiseSpectraArrived -= NoiseSpectraArrived;
            
        }
        private void VoltagesArrived(object sender, MeasuredVoltages_DataArrivedEventArgs e)
        {
            if (!e.Precise) return;

            _QuantityOfVoltageMeasurements++;
            if (_QuantityOfVoltageMeasurements == 1)
            {

                _CurrentNoiseMeasurement.U0sample = e.Voltages[0];
                _CurrentNoiseMeasurement.U0whole = e.Voltages[1];
                _CurrentNoiseMeasurement.U0Rload = e.Voltages[2];
                _CurrentNoiseMeasurement.U0Gate = e.Voltages[3];
                _CurrentNoiseMeasurement.R0sample = _CurrentNoiseMeasurement.U0sample / _CurrentNoiseMeasurement.U0Rload * _CurrentNoiseMeasurement.Rload;
                return;
            }
            if (_QuantityOfVoltageMeasurements == 2)
            {
                _CurrentNoiseMeasurement.SampleVoltage = e.Voltages[0];
                _CurrentNoiseMeasurement.Uwhole = e.Voltages[1];
                _CurrentNoiseMeasurement.URload = e.Voltages[2];
                _CurrentNoiseMeasurement.Vg = e.Voltages[3];
                _CurrentNoiseMeasurement.SampleCurrent = (_CurrentNoiseMeasurement.URload) / _CurrentNoiseMeasurement.Rload;
                _CurrentNoiseMeasurement.REsample = _CurrentNoiseMeasurement.SampleVoltage / _CurrentNoiseMeasurement.SampleCurrent;
                _CurrentNoiseMeasurement.EquivalentResistance = _CurrentNoiseMeasurement.REsample * _CurrentNoiseMeasurement.Rload / (_CurrentNoiseMeasurement.REsample + _CurrentNoiseMeasurement.Rload);

                _ListOfMeasurDataString.readFromFile();
                if (this.FileExists(_CurrentNoiseMeasurement.FileName))
                    _ListOfMeasurDataString.ListOfData.Add(_CurrentNoiseMeasurement);
                _ListOfMeasurDataString.Open_Write_CloseFile();
                AllCustomEvents.Instance.VoltagesMeasurementDone -= VoltagesArrived;

            }
            else
            {
                MessageBox.Show("Quantity of VoltageMEasurements is too big, strange..." + _QuantityOfVoltageMeasurements);
            }
        }

        private void NoiseSpectraArrived(object sender, FinalNoiseEventArgs data)
        {
            ListOfNoiseDataString _NoiseSpectra = new ListOfNoiseDataString(data.FinalData);
            _NoiseSpectra.FileName = _CurrentNoiseMeasurement.FileName;
            _NoiseSpectra.Open_Write_CloseFile();
            AllCustomEvents.Instance.LastNoiseSpectraArrived -= NoiseSpectraArrived;
        }
        
    }
}
