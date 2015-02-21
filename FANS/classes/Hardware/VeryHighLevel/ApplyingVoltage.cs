using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace FANS.classes
{
    class ApplyingVoltage
    {
       private double _Voltage;
       public double Voltage { get { return _Voltage; } set { _Voltage = value; } }
       private int _numberOfFeedbackChannel, _numberOfMotorChannel, _numberOfRelayChannel;
       private double _tolerance;
       //public AutoResetEvent VoltageIsSet { get; private set; }

        public ApplyingVoltage(int numberOfFeedback_Channel, int numberOfMotor_Channel, int numberOfRelay_Channel,double tolerance=0.005)
        {
            _numberOfFeedbackChannel = numberOfFeedback_Channel;
            _numberOfMotorChannel = numberOfMotor_Channel;
            _numberOfRelayChannel = numberOfRelay_Channel;
            _tolerance = tolerance;
            //VoltageIsSet = new AutoResetEvent(false);
        }
        public void setTolerance(double Tolerance){
            _tolerance = Tolerance;
        }
        public void setChannels(int numberOfFeedback_Channel, int numberOfMotor_Channel, int numberOfRelay_Channel)
        {
            _numberOfFeedbackChannel = numberOfFeedback_Channel;
            _numberOfMotorChannel = numberOfMotor_Channel;
            _numberOfRelayChannel = numberOfRelay_Channel;
         
        }
        public void ApplyVoltageInThread(double VoltageToApply)
        {
            _Voltage = VoltageToApply;
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementFinished;
                return;
            }
            MeasurementThread.Instance.StartThread(ApplyVoltage);
        }

        private void WaitUntilMeasurementIsFinished(object sender, EventArgs e)
        {
            AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementFinished;
            MeasurementThread.Instance.StartThread(ApplyVoltage); 
        }

        private void WaitForMeasurementFinished(object sender, EventArgs e)
        {
            AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementFinished;
            ApplyVoltageInThread(_Voltage);
        }
        //method was private 
        public void ApplyVoltage()
        {
            double[] Voltages= AI_Channels.Instance.VoltageMeasurement101_104();
            int voltageSign = Math.Sign(_Voltage);
            double FeedBackVoltage=Voltages[_numberOfFeedbackChannel-1];
            int RealitySign = Math.Sign(FeedBackVoltage);

            if (!MeasurementThread.MeasurementInProgress) return;
            if(RealitySign!=voltageSign)
            {
                gotoVoltageOfTheSameSign(0);
                SwitchVoltageDirection(voltageSign);
            }
            if (MeasurementThread.MeasurementInProgress)
            gotoVoltageOfTheSameSign(_Voltage);
            //VoltageIsSet.Set();
        }
#region switch direction
        private void SwitchVoltageDirection(int sign)
        {
            if (sign > 0)
            {
                SwitchDirectionToPlus();
            }
            else
            {
                SwitchDirectionToMinus();
            }
        }
        private void SwitchDirectionToPlus()
        {
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfRelayChannel, 3);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfRelayChannel, 3, 0, 0));
            Thread.Sleep(200);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfRelayChannel, 0, 0, 0));
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfRelayChannel, 0);
        }

        private void SwitchDirectionToMinus()
        {
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfRelayChannel, -3);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfRelayChannel, -3, 0, 0));
            Thread.Sleep(200);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfRelayChannel, 0, 0, 0));
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfRelayChannel, 0);
        }
        public void SwitchVoltageDirectionInThread(int sign)
        {
            if(MeasurementThread.MeasurementInProgress)return;
            if (sign > 0) MeasurementThread.Instance.StartThread(SwitchDirectionToPlus);
            else MeasurementThread.Instance.StartThread(SwitchDirectionToMinus);

        }
#endregion
        private void gotoVoltageOfTheSameSign(double Voltage)
        {
            double[] Voltages;
            double FeedBackVoltage;
            Voltages = AI_Channels.Instance.VoltageMeasurement101_104();
            FeedBackVoltage = Voltages[_numberOfFeedbackChannel - 1];
            int MotorVoltageSign;
            double MotorVoltage, Difference;

            while (((Difference = Math.Abs(Voltage - FeedBackVoltage)) > _tolerance) && (MeasurementThread.MeasurementInProgress))
            {
                MotorVoltageSign = 1;
                if (Math.Abs(Voltage) > Math.Abs(FeedBackVoltage))
                    MotorVoltageSign = -1;
                MotorVoltage = 6 / (1 + Math.Exp((-Difference + 0.1) / 0.04));
                AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfMotorChannel, MotorVoltage * MotorVoltageSign);
                AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, MotorVoltage * MotorVoltageSign, 0, 0));
                //Thread.Sleep(200);
                //AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfMotorChannel, 0);
                //AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, MotorVoltage * MotorVoltageSign, 0, 0));

                Voltages = AI_Channels.Instance.VoltageMeasurement101_104();
                AllCustomEvents.Instance.OnVoltagesMeasurementDone(this, new MeasuredVoltages_DataArrivedEventArgs(Voltages));
                FeedBackVoltage = Voltages[_numberOfFeedbackChannel - 1];
            }

            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfMotorChannel, 0);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, 0, 0, 0));

            AllCustomEvents.Instance.OnVoltageSettingFinished(this, new EventArgs());
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfMotorChannel, 0);
        }


        private double MotorVoltageForRawChanging;
        private void setMotorVoltageRaw()
        {
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(_numberOfMotorChannel, MotorVoltageForRawChanging);
        }
        public void StopChangingVoltageAbsoluteValue()
        {
            MotorVoltageForRawChanging = 0;
            if (!MeasurementThread.MeasurementInProgress) MeasurementThread.Instance.StartThread(setMotorVoltageRaw);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, 0, 0, 0));
        }
        public void IncreaseVoltageAbsoluteValue()
        {
            MotorVoltageForRawChanging = -2;
            if (!MeasurementThread.MeasurementInProgress) MeasurementThread.Instance.StartThread(setMotorVoltageRaw);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, -2, 0, 0));
        }
        public void IncreaseVoltageAbsoluteValueFast()
        {
            MotorVoltageForRawChanging = -6;
            if (!MeasurementThread.MeasurementInProgress) MeasurementThread.Instance.StartThread(setMotorVoltageRaw);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, -6, 0, 0));
        }
        public void DecreaseVoltageAbsoluteValue()
        {
            MotorVoltageForRawChanging = 2;
            if (!MeasurementThread.MeasurementInProgress) MeasurementThread.Instance.StartThread(setMotorVoltageRaw);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, 2, 0, 0));
        }
        public void DecreaseVoltageAbsoluteValueFast()
        {
            MotorVoltageForRawChanging = 6;
            if (!MeasurementThread.MeasurementInProgress) MeasurementThread.Instance.StartThread(setMotorVoltageRaw);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(_numberOfMotorChannel, 6, 0, 0));
        }

      
    }
}
