﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class AllCustomEvents
    {
        private static AllCustomEvents _instance;
        public static AllCustomEvents Instance
        {
            get
            {
                if (_instance == null) _instance = new AllCustomEvents();
                return _instance;
            }
        }
        private AllCustomEvents(){
        }

        public virtual void OnAI_Data_Arrived(object Sender, ADC_DataArrivedEventArgs e)
        {
            EventHandler<ADC_DataArrivedEventArgs> handler = _AI_Data_Arrived;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        private EventHandler<ADC_DataArrivedEventArgs> _AI_Data_Arrived;
        public event EventHandler<ADC_DataArrivedEventArgs> AI_Data_Arrived
        {
            add
            {
                if (_AI_Data_Arrived == null || !_AI_Data_Arrived.GetInvocationList().Contains(value))
                {
                    _AI_Data_Arrived += value;
                }
            }
            remove
            {
                _AI_Data_Arrived -= value;
            }
        }

        public virtual void OnAI_SingleShot_Data_Arrived(object Sender, ADC_DataArrivedEventArgs e)
        {
            EventHandler<ADC_DataArrivedEventArgs> handler = _AI_SingleShot_Data_Arrived;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        private EventHandler<ADC_DataArrivedEventArgs> _AI_SingleShot_Data_Arrived;
        public event EventHandler<ADC_DataArrivedEventArgs> AI_SingleShot_Data_Arrived
        {
            add
            {
                if (_AI_SingleShot_Data_Arrived == null || !_AI_SingleShot_Data_Arrived.GetInvocationList().Contains(value))
                {
                    _AI_SingleShot_Data_Arrived += value;
                }
            }
            remove
            {
                _AI_SingleShot_Data_Arrived -= value;
            }
        }

        private EventHandler<MeasuredVoltages_DataArrivedEventArgs> _VoltagesMeasurementDone;
        public event EventHandler<MeasuredVoltages_DataArrivedEventArgs> VoltagesMeasurementDone
        {
            add
            {
                if (_VoltagesMeasurementDone == null || !_VoltagesMeasurementDone.GetInvocationList().Contains(value))
                {
                    _VoltagesMeasurementDone += value;
                }
            }
            remove
            {
                _VoltagesMeasurementDone -= value;
            }
        }
        public virtual void OnVoltagesMeasurementDone(object sender, MeasuredVoltages_DataArrivedEventArgs e)
        {
            EventHandler<MeasuredVoltages_DataArrivedEventArgs> handler = _VoltagesMeasurementDone;
            if (handler != null)
            {
                handler(sender, e);
            }
        }


        public virtual void OnMeasurementFinished(object Sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = _MeasurementFinished;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        

        private EventHandler<EventArgs> _MeasurementFinished;
        public event EventHandler<EventArgs> MeasurementFinished
        {
            add
            {
                if (_MeasurementFinished == null || !_MeasurementFinished.GetInvocationList().Contains(value))
                {
                    _MeasurementFinished += value;
                }
            }
            remove
            {
                _MeasurementFinished -= value;
            }
        }

          public virtual void OnBeforeMeasurementFinished(object Sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = _BeforeMeasurementFinished;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        private EventHandler<EventArgs> _BeforeMeasurementFinished;
        public event EventHandler<EventArgs> BeforeMeasurementFinished
        {
            add
            {
                if (_BeforeMeasurementFinished == null || !_BeforeMeasurementFinished.GetInvocationList().Contains(value))
                {
                    _BeforeMeasurementFinished += value;
                }
            }
            remove
            {
                _BeforeMeasurementFinished -= value;
            }
        }
        public bool isAtLeastOneListenerTo_BeforeMeasurementFinished()
        {
            if ((_BeforeMeasurementFinished!=null)&&(_BeforeMeasurementFinished.GetInvocationList().Length > 0)) return true;
            return false;
        }

        private EventHandler<AC_AutoRangeEventArgs> _AC_AutoRangeComplete;
        public event EventHandler<AC_AutoRangeEventArgs> AC_AutoRangeComplete
        {
            add
            {
                if (_AC_AutoRangeComplete == null || !_AC_AutoRangeComplete.GetInvocationList().Contains(value))
                {
                    _AC_AutoRangeComplete += value;
                }
            }
            remove
            {
                _AC_AutoRangeComplete -= value;
            }
        }
        public virtual void OnAC_AutoRangeComplete(object sender, AC_AutoRangeEventArgs e)
        {
            EventHandler<AC_AutoRangeEventArgs> handler = _AC_AutoRangeComplete;
            if (handler != null)
            {
                handler(sender, e);
            }
        }


        private EventHandler<EventArgs> _AI_Channel_DigitalParameterChange_Started;
        public event EventHandler<EventArgs> AI_Channel_DigitalParameterChange_Started
        {
            add
            {
                if (_AI_Channel_DigitalParameterChange_Started == null || !_AI_Channel_DigitalParameterChange_Started.GetInvocationList().Contains(value))
                {
                    _AI_Channel_DigitalParameterChange_Started += value;
                }
            }
            remove
            {
                _AI_Channel_DigitalParameterChange_Started -= value;
            }
        }
        public virtual void OnAI_Channel_DigitalParameterChange_Started(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = _AI_Channel_DigitalParameterChange_Started;
            if (handler != null)
            {
                handler(sender, e);
            }
        }


        private EventHandler<EventArgs> _AI_Channel_DigitalParameterChange_Finished;
        public event EventHandler<EventArgs> AI_Channel_DigitalParameterChange_Finished
        {
            add
            {
                if (_AI_Channel_DigitalParameterChange_Finished == null || !_AI_Channel_DigitalParameterChange_Finished.GetInvocationList().Contains(value))
                {
                    _AI_Channel_DigitalParameterChange_Finished += value;
                }
            }
            remove
            {
                _AI_Channel_DigitalParameterChange_Finished -= value;
            }
        }
        public virtual void OnAI_Channel_DigitalParameterChange_Finished(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = _AI_Channel_DigitalParameterChange_Finished;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private EventHandler<StatusEventArgs> _MeasurementStatusChanged;
        public event EventHandler<StatusEventArgs> MeasurementStatusChanged
        {
            add
            {
                if (_MeasurementStatusChanged == null || !_MeasurementStatusChanged.GetInvocationList().Contains(value))
                {
                    _MeasurementStatusChanged += value;
                }
            }
            remove
            {
                _MeasurementStatusChanged -= value;
            }
        }
        public virtual void OnMeasurementStatusChanged(object sender, StatusEventArgs e)
        {
            EventHandler<StatusEventArgs> handler = _MeasurementStatusChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private EventHandler<StatusEventArgs> _NoiseMeasurementStatusChanged;
        public event EventHandler<StatusEventArgs> NoiseMeasurementStatusChanged
        {
            add
            {
                if (_NoiseMeasurementStatusChanged == null || !_NoiseMeasurementStatusChanged.GetInvocationList().Contains(value))
                {
                    _NoiseMeasurementStatusChanged += value;
                }
            }
            remove
            {
                _NoiseMeasurementStatusChanged -= value;
            }
        }
        public virtual void OnNoiseMeasurementStatusChanged(object sender, StatusEventArgs e)
        {
            EventHandler<StatusEventArgs> handler = _NoiseMeasurementStatusChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public virtual void OnNoiseSpectraArrived(object Sender, NoiseEventArgs e)
        {
            EventHandler<NoiseEventArgs> handler = _NoiseSpectraArrived;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        private EventHandler<NoiseEventArgs> _NoiseSpectraArrived;
        public event EventHandler<NoiseEventArgs> NoiseSpectraArrived
        {
            add
            {
                if (_NoiseSpectraArrived == null || !_NoiseSpectraArrived.GetInvocationList().Contains(value))
                {
                    _NoiseSpectraArrived += value;
                }
            }
            remove
            {
                _NoiseSpectraArrived -= value;
            }
        }

        public virtual void OnLastNoiseSpectraArrived(object Sender, FinalNoiseEventArgs e)
        {
            EventHandler<FinalNoiseEventArgs> handler = _LastNoiseSpectraArrived;
            if (handler != null)
            {
                handler(Sender, e);
            }
        }
        private EventHandler<FinalNoiseEventArgs> _LastNoiseSpectraArrived;
        public event EventHandler<FinalNoiseEventArgs> LastNoiseSpectraArrived
        {
            add
            {
                if (_LastNoiseSpectraArrived == null || !_LastNoiseSpectraArrived.GetInvocationList().Contains(value))
                {
                    _LastNoiseSpectraArrived += value;
                }
            }
            remove
            {
                _LastNoiseSpectraArrived -= value;
            }
        }

        private EventHandler<VoltageAdjustment_EventArgs> _OutputStatusChanged;
        public event EventHandler<VoltageAdjustment_EventArgs> OutputStatusChanged
        {
            add
            {
                if (_OutputStatusChanged == null || !_OutputStatusChanged.GetInvocationList().Contains(value))
                {
                    _OutputStatusChanged += value;
                }
            }
            remove
            {
                _OutputStatusChanged -= value;
            }
        }
        public virtual void OnOutputStatusChanged(object sender, VoltageAdjustment_EventArgs e)
        {
            EventHandler<VoltageAdjustment_EventArgs> handler = _OutputStatusChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }


        private EventHandler<EventArgs> _VoltageSettingFinished;
        public event EventHandler<EventArgs> VoltageSettingFinished
        {
            add
            {
                if (_VoltageSettingFinished == null || !_VoltageSettingFinished.GetInvocationList().Contains(value))
                {
                    _VoltageSettingFinished += value;
                }
            }
            remove
            {
                _VoltageSettingFinished -= value;
            }
        }
        public virtual void OnVoltageSettingFinished(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = _VoltageSettingFinished;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
