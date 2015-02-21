using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class Agilent_AnalogOutput_LowLevel


    {
        private int DAQ_Number;
        public Agilent_AnalogOutput_LowLevel(int ch_number)
        {
            if (!Agilent_USB_DAQ.Instance.isAlive())
                Agilent_USB_DAQ.Instance.Open();
            DAQ_Number = ch_number;
            if (!Agilent_USB_DAQ.Instance.isAlive()) throw new Exception("Device Not Connected");
            Agilent_USB_DAQ.Instance.WriteString("SOUR:VOLT:POL BIP, (@201:202)");
            Agilent_USB_DAQ.Instance.WriteString("OUTP:WAV:ITER 0");
            Agilent_USB_DAQ.Instance.WriteString("OUTP:WAV:SRAT 0");


        }
        public void SetDCVoltage(double Voltage)
        {
            if(!((Voltage<10)&&((Voltage>-10))))return;
            var test = Agilent_USB_DAQ.Instance.WriteString("SOUR:VOLT " + Voltage.ToString("G3",ImportantConstants.NumberFormat()) + ", (@"+DAQ_Number+")");
            
        }
        public void SetIterations(int Iter)
        {
            Agilent_USB_DAQ.Instance.WriteString("OUTP:WAV:ITER "+Iter);
        }

        public void SetFrequency(int Frequency)
        {
            if (Frequency > 10000) return;
            if (Frequency < 0) return;
            Agilent_USB_DAQ.Instance.WriteString("OUTP:WAV:FREQ " + Frequency);
        }
        public void Enable()
        {
            Agilent_USB_DAQ.Instance.WriteString("ROUT:ENAB ON,(@" + DAQ_Number + ")");
        }
        public void Disable()
        {
            Agilent_USB_DAQ.Instance.WriteString("ROUT:ENAB OFF,(@" + DAQ_Number + ")");
        }
        public void applySine(double amplitude, double offset)
        {
            if (amplitude < 0) return;
            if (amplitude > 10) return;
            if (offset > 10) return;
            if (offset < -10) return;
            Agilent_USB_DAQ.Instance.WriteString("APPL:SIN " + amplitude.ToString("G3") + "," + offset.ToString("G3") + ", (@" + DAQ_Number + ")");
            
            
        }
        public void OutputON()
        {
            Agilent_USB_DAQ.Instance.WriteString("OUTP ON");
        }
        public void OutputOFF()
        {
            Agilent_USB_DAQ.Instance.WriteString("OUTP OFF");
        }


    }

}
