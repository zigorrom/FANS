using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace FANS.classes
{
    
    class MeasurementThread
    {
        public delegate void SomeMeasurement();
        public delegate void SomeParametrizedMeasurement(object param);
        public static bool MeasurementInProgress;


        private Thread _Measurement;

        private static MeasurementThread _instance;
        private static readonly object padlock = new object();
        public static MeasurementThread Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new MeasurementThread();
                    return _instance;

                }

            }
        }

        public bool MeasurementRunning
        {
            get
            {
                if (_Measurement != null)
                {
                    if (_Measurement.IsAlive) return true;
                    else if (MeasurementInProgress) this.StopThread();
                }
                return (MeasurementInProgress);
            }
            set
            {
                if (MeasurementInProgress)
                {
                    if (value == false)
                        this.StopThread();
                }
                
            }              
                    
            
        }

        public void StartThread(SomeParametrizedMeasurement DesiredFunction, object param)
        {
            _Measurement = new Thread(new ParameterizedThreadStart(DesiredFunction));
            _Measurement.IsBackground = true;
            MeasurementInProgress = true;
            _Measurement.Start(param);
        }

        public void StartThread(SomeMeasurement DesiredFunction)
        {
            _Measurement = new Thread(new ThreadStart(DesiredFunction));
            _Measurement.IsBackground = true;
            MeasurementInProgress = true;
            _Measurement.Start();
        }
        public void StopThread()
        {
            MeasurementInProgress = false;
           bool result=_Measurement.Join(5000);
            if (!result) _Measurement.Abort();
            AllCustomEvents.Instance.OnNoiseMeasurementStatusChanged(this, new StatusEventArgs("Measurement Aborted"));
            AllCustomEvents.Instance.OnMeasurementStatusChanged(this, new StatusEventArgs("Measurement Aborted"));
            if (AllCustomEvents.Instance.isAtLeastOneListenerTo_BeforeMeasurementFinished())
            { AllCustomEvents.Instance.OnBeforeMeasurementFinished(this, null); return; }
            AllCustomEvents.Instance.OnMeasurementFinished(this, null);
        }

        
    }
}
