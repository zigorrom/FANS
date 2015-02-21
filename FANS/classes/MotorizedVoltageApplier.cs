using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace FANS.classes
{
    interface ICommand
    {
        void Execute();
       
    }

    class SetVoltageCommand:ICommand
    {
        private MotorizedVoltageApplier m_VoltageApplier;
        public double VoltageToSet { get; set; }
        public SetVoltageCommand(MotorizedVoltageApplier VoltageApplier)
        {
            m_VoltageApplier = VoltageApplier;
        }

        public void Execute()
        {
            m_VoltageApplier.SetVoltage(VoltageToSet);
        }

        
    }

    public class MotorizedVoltageApplier
    {
        
        public int FeedbackChannel { get; private set; }
        public int MotorChannel { get; private set; }
        public int RelayChannel { get; private set; }
        public double Tolerance { get; set; }
        public double CurrentVoltage
        {
            get
            {
                var VoltagesInChannels = AI_Channels.Instance.VoltageMeasurement101_104();
                AllCustomEvents.Instance.OnVoltagesMeasurementDone(this, new MeasuredVoltages_DataArrivedEventArgs(VoltagesInChannels));
                return VoltagesInChannels[FeedbackChannel - 1];
            }
        }

        
        private double m_MovingMotorVoltage;
        private const double MaxMovingMotorVoltage = 6.0;
        private int m_MotorDirection;

        public void SetChannels(int feedbackChannel, int motorChannel, int relayChannel)
        {
            FeedbackChannel = feedbackChannel;
            MotorChannel = motorChannel;
            RelayChannel = relayChannel;
        }

        public MotorizedVoltageApplier(int feedbackChannel, int motorChannel, int relayChannel, double tolerance = 0.001)
        {
            
            Tolerance = tolerance;
            m_MovingMotorVoltage = 6;
            FeedbackChannel = feedbackChannel;
            RelayChannel = relayChannel;
            MotorChannel = motorChannel;
            m_MotorDirection = 0;
            
        }


        private const int MaxCounts = 100000;

        public void SetVoltage(double VoltageToSet)
        {

            var Voltage = CurrentVoltage;
            var CurrentVoltageSign = Math.Sign(Voltage);
            var VoltageToSetSign = Math.Sign(VoltageToSet);

            if (!MeasurementThread.MeasurementInProgress) return;
            if (CurrentVoltageSign * VoltageToSetSign < 0)
            {
                SetVoltage(0);
                SwitchVoltageDirection(VoltageToSetSign);
            }
            if (!MeasurementThread.MeasurementInProgress) return;
            Voltage = CurrentVoltage;
            
            var difference = Math.Abs(VoltageToSet) - Math.Abs(Voltage);
            m_MotorDirection = -1 * Math.Sign(difference);

            var differenceSign = Math.Sign(VoltageToSet - Voltage);


            var counter = 0;

            //while ((difference = Math.Abs(VoltageToSet - Voltage)) > Tolerance&& (differenceSign == Math.Sign(VoltageToSet-Voltage)) && MeasurementThread.MeasurementInProgress &&(counter++<MaxCounts))
            //{
            //    EstimateMotorVoltage(difference);
            //    SetMotorVoltage(m_MovingMotorVoltage);
            //    Voltage = CurrentVoltage;
            //    System.Diagnostics.Debug.WriteLine(String.Format("{0}",counter));
            //}

            while(MeasurementThread.MeasurementInProgress&& (!IsInToleranceRegion(VoltageToSet,Voltage))&&(counter++<MaxCounts))
            {
                EstimateMotorVoltage(VoltageToSet, Voltage);
                SetMotorVoltage(m_MovingMotorVoltage);
                Voltage = CurrentVoltage;
            }

            SetMotorVoltage(0);
            AllCustomEvents.Instance.OnVoltageSettingFinished(this, new EventArgs());
        }

        private void EstimateMotorVoltage(double VoltageToSet, double Voltage)
        {
            var difference = Math.Abs(VoltageToSet) - Math.Abs(Voltage);
            m_MotorDirection = -1 * Math.Sign(difference);
            difference = Math.Abs(Voltage - VoltageToSet);
            EstimateMotorVoltage(difference);
        }

        private void EstimateMotorVoltage(double difference)
        {
            
            m_MovingMotorVoltage = m_MotorDirection * MaxMovingMotorVoltage / (1 + Math.Exp((-difference + 0.1) / 0.08));  /// previous version (1 + Math.Exp((-Math.Abs(difference) + 0.1) / 0.04))
        }

        private bool IsInToleranceRegion(double VoltageToSet, double Voltage)
        {
            if ((Voltage > VoltageToSet - Tolerance) && (Voltage < VoltageToSet + Tolerance))
                return true;
            return false;
                    
        }

        

        private void SetMotorVoltage(double motorVoltage)
        {
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(MotorChannel, motorVoltage);
            
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(MotorChannel, motorVoltage, 0, 0));
        }

       

        

        

        private void SwitchVoltageDirection(int DirectionSign)
        {
            var sign = 3;
            if (DirectionSign < 0)
                sign = -3;

            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(RelayChannel, sign);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(RelayChannel, sign, 0, 0));
            Thread.Sleep(200);
            AllCustomEvents.Instance.OnOutputStatusChanged(this, new VoltageAdjustment_EventArgs(RelayChannel, 0, 0, 0));
            AO_Channels.Instance.SetDC_Output_To_Certain_Channel(RelayChannel, 0);
        }



       


    }
}
