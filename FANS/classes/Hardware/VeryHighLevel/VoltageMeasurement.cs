using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class VoltageMeasurement
    {
        private Agilent_AnalogInput_LowLevel _AI;
        public VoltageMeasurement()
        {
            _AI = new Agilent_AnalogInput_LowLevel();
        }


        public void MeasureVoltageNormallyInThread()
        {
            if (!MeasurementThread.Instance.MeasurementRunning)  MeasurementThread.Instance.StartThread(PerformVoltageNormalMeasurement);
        }

        public void PerformVoltagePresiseMeasurement()
        {
            
            int AveragingFactor = 10;
            List<double[]> results = new List<double[]> { new double[AveragingFactor], new double[AveragingFactor], new double[AveragingFactor], new double[AveragingFactor] };
            double[] result=new double[]{};
            int prevAverage = AI_Channels.Instance.DC_Average;
            AI_Channels.Instance.DC_Average=1000;
            
            for (int i = 0; i < AveragingFactor; i++)
            {
                if (!MeasurementThread.MeasurementInProgress) return;
                result = AI_Channels.Instance.VoltageMeasurement101_104();
                for (int j = 0; j < results.Count; j++)
                    results[j][i] = result[j];
                AllCustomEvents.Instance.OnMeasurementStatusChanged(this, new StatusEventArgs("Voltage measured " + (i + 1) + "/" + AveragingFactor, 1, AveragingFactor, i + 1));
                AllCustomEvents.Instance.OnNoiseMeasurementStatusChanged(this, new StatusEventArgs("Voltage measured " + (i + 1) + "/" + AveragingFactor, 1, AveragingFactor, i + 1));
            }
            result = new double[] { 0, 0, 0, 0 };
            foreach (double[] ChannelVoltages in results)
            {
                int count = 0;
                double min = ChannelVoltages.Min();
                double max = ChannelVoltages.Max();
                for (int i = 0; i < ChannelVoltages.Length; i++)
                {
                    if ((ChannelVoltages[i] > min) && (ChannelVoltages[i] < max))
                    {
                        count++;
                        result[results.IndexOf(ChannelVoltages)] += ChannelVoltages[i];
                    }
                 }
                if (count != 0)
                    result[results.IndexOf(ChannelVoltages)] /= count;
                
            }
            AI_Channels.Instance.DC_Average=prevAverage;
            AllCustomEvents.Instance.OnVoltagesMeasurementDone(this, new MeasuredVoltages_DataArrivedEventArgs(result, true));
        }

        private void PerformVoltageNormalMeasurement()
        {
            if (MeasurementThread.MeasurementInProgress == false) return;
            double[] result = AI_Channels.Instance.VoltageMeasurement101_104();
            if (MeasurementThread.MeasurementInProgress == false) return;
            AllCustomEvents.Instance.OnVoltagesMeasurementDone(this, new MeasuredVoltages_DataArrivedEventArgs(result, false));
            
}
        


        
        
    }
}
